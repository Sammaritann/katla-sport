using AutoMapper;
using KatlaSport.DataAccess.OfficeCatalogue;

namespace KatlaSport.Services.OfficeManagement
{
   public sealed class OfficeManagementMappingProfile : Profile
    {
        public OfficeManagementMappingProfile()
        {
            CreateMap<OfficeItem, Office>();
            CreateMap<EmployeeItem, Employee>();
            CreateMap<RequiredInventoryItem, RequiredInventory>();

            CreateMap<UpdateOfficeRequest, Office>();
            CreateMap<UpdateEmployeeRequest, Employee>();
            CreateMap<UpdateRequiredInventoryRequest, RequiredInventory>();

            CreateMap<Employee, Employee>().ForMember(e => e.Id, opt => opt.Ignore());
        }
    }
}
