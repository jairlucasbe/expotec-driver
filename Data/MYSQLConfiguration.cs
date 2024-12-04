namespace expotec_driver.Data
{
    public class MYSQLConfiguration
    {
        public MYSQLConfiguration()
        {
            ConnectionString = string.Empty;
        }

        public MYSQLConfiguration(string connectionString)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public string ConnectionString { get; set; }
    }
}
