using expotec_driver.Modules.BusinessExecutives.Models;
using expotec_driver.Modules.BusinessExecutives.Models.Dtos;

namespace expotec_driver.Modules.BusinessExecutives.Repositories
{
    public interface IBusinessExecutiveRepository
    {
        Task<IEnumerable<BusinessExecutive>> GetAllBusinessExecutives();
        Task<BusinessExecutive> GetOneBusinessExecutive(int id);
        Task<BusinessExecutive> InsertBusinessExecutive(CreateBusinessExecutiveDto businessExecutives);
        Task<BusinessExecutive> UpdateBusinessExecutives(UpdateBusinessExecutiveDto businessExecutives, int id);
        Task<BusinessExecutive> DeleteBusinessExecutives(int id);
    }
}
