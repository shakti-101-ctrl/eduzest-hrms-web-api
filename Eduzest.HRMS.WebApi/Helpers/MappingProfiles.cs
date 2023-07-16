using AutoMapper;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO.Employee;

namespace Eduzest.HRMS.WebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Branch, BranchDto>().ReverseMap();
        }
    }
}
