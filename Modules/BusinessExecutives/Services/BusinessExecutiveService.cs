using expotec_driver.Modules.BusinessExecutives.Repositories;
using expotec_driver.Modules.BusinessExecutives.Models;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using expotec_driver.Modules.BusinessExecutives.Models.Dtos;

namespace expotec_driver.Modules.BusinessExecutives.Services
{
    public class BusinessExecutiveService(IBusinessExecutiveRepository businessExecutiveRepository)
    {
        private readonly IBusinessExecutiveRepository _businessExecutiveRepository = businessExecutiveRepository;

        public async Task<List<BusinessExecutive>> GetAllBusinessExecutives()
        {
            var businessExecutives = await _businessExecutiveRepository.GetAllBusinessExecutives();
            return businessExecutives.ToList();
        }

        public async Task<BusinessExecutive> GetOneBusinessExecutive(int id)
        {
            BusinessExecutive businessExecutive = await _businessExecutiveRepository.GetOneBusinessExecutive(id);
            return businessExecutive;
        }

        public async Task<BusinessExecutive> InsertBusinessExecutive(CreateBusinessExecutiveDto businessExecutives)
        {
            BusinessExecutive businessExecutive = await _businessExecutiveRepository.InsertBusinessExecutive(businessExecutives);
            return businessExecutive;
        }

        public async Task<BusinessExecutive> UpdateBusinessExecutives(UpdateBusinessExecutiveDto businessExecutives, int id)
        {
            BusinessExecutive businessExecutive = await _businessExecutiveRepository.UpdateBusinessExecutives(businessExecutives, id);
            return businessExecutive;
        }

        public async Task<BusinessExecutive> DeleteBusinessExecutive(int id)
        {
            BusinessExecutive deletedBusinessExecutive = await _businessExecutiveRepository.DeleteBusinessExecutives(id);
            return deletedBusinessExecutive;
        }

    }
}
