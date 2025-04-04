using Application.Contracts.Persistences;
using Application.Contracts.Services;
using Application.Wrappers;
using AutoMapper;
using Domain;
using System;
using System.Threading.Tasks;


namespace Application.Implementations
{
    public class OrganizationService : ResponseHandler, IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<string> OrganizationNameById(int id)
        {
            var org = new Organization();
            try
            {
                // Fetch the organization based on the provided ID
                org = _unitOfWork.GenericRepository<Organization>().Get(c => c.Id == id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Map the list of KeyRescource to a list of KeyRescourceResponse
            return org.Name;
        }

    }
}
