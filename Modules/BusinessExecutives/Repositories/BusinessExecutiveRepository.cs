using Dapper;
using MySql.Data.MySqlClient;
using expotec_driver.Data;
using expotec_driver.Modules.BusinessExecutives.Models;
using expotec_driver.Modules.BusinessExecutives.Models.Dtos;

namespace expotec_driver.Modules.BusinessExecutives.Repositories
{
    public class BusinessExecutiveRepository(MYSQLConfiguration connectionString) : IBusinessExecutiveRepository
    {
        private readonly MYSQLConfiguration _connectionString = connectionString;
        private const string TableName = "business_executives";

        protected MySqlConnection DbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<BusinessExecutive>> GetAllBusinessExecutives()
        {
            var db = DbConnection();
            var sql = $@"SELECT id, name, dni, type FROM {TableName}";
            return await db.QueryAsync<BusinessExecutive>(sql, new { });
        }

        public async Task<BusinessExecutive> GetOneBusinessExecutive(int id)
        {
            var db = DbConnection();
            var sql = $@"SELECT id, name, dni, type FROM {TableName} WHERE id = @Id";
            var result = await db.QueryFirstOrDefaultAsync<BusinessExecutive>(sql, new { Id = id });
            return result ?? throw new KeyNotFoundException($"BusinessExecutive with id {id} was not found.");
        }

        public async Task<BusinessExecutive> InsertBusinessExecutive(CreateBusinessExecutiveDto businessExecutives)
        {
            var db = DbConnection();
            var sql = $@"INSERT INTO {TableName} (name, dni, type) VALUES (@Name, @Dni, @Type)";
            var result = await db.ExecuteAsync(sql, new { businessExecutives.Name, businessExecutives.Dni, businessExecutives.Type });
            return result == 0
                ? throw new InvalidOperationException("Failed to insert the BusinessExecutive.")
                : await this.GetOneBusinessExecutive(await db.QuerySingleAsync<int>("SELECT LAST_INSERT_ID();"));
        }

        public async Task<BusinessExecutive> UpdateBusinessExecutives(UpdateBusinessExecutiveDto businessExecutives, int id)
        {
            var db = DbConnection();
            BusinessExecutive foundBusinessExecutive = await this.GetOneBusinessExecutive(id);
            var sql = $@"UPDATE {TableName} SET ";
            var updates = new List<string>();
            var parameters = new
            {
                Name = businessExecutives.Name ?? foundBusinessExecutive.Name,
                Dni = businessExecutives.Dni ?? foundBusinessExecutive.Dni,
                Type = businessExecutives.Type ?? foundBusinessExecutive.Type,
                foundBusinessExecutive.Id
            };
            if (businessExecutives.Name != null) updates.Add("name = @Name");
            if (businessExecutives.Dni != null) updates.Add("dni = @Dni");
            if (businessExecutives.Type != null) updates.Add("type = @Type");
            sql += string.Join(", ", updates) + " WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, parameters);
            return result == 0
                ? throw new InvalidOperationException($"Failed to update the BusinessExecutive with id {id}")
                : await this.GetOneBusinessExecutive(id);
        }

        public async Task<BusinessExecutive> DeleteBusinessExecutives(int id)
        {
            var db = DbConnection();
            BusinessExecutive businessExecutive = await this.GetOneBusinessExecutive(id);
            var sql = $@"DELETE FROM {TableName} WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { businessExecutive.Id });
            Console.WriteLine(businessExecutive);
            return result == 0
                ? throw new InvalidOperationException($"Failed to delete the BusinessExecutive with id {id}")
                : businessExecutive;
        }
    }
}
