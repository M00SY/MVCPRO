using AutoMapper;
using Demo_Dal.Entities;
using Demo_PL.Models;

namespace Demo_PL.Mapper
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
        }
    }
}
