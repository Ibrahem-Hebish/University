using UniversityProject.Core.Dtos.HallDtos;

namespace UniversityProject.Core.Mapping.HallMappings
{
    public partial class Mappings
    {
        public void GetHallMapping()
        {
            CreateMap<Hall, GetHall>()
                  .ForMember(dest => dest.DepartmentName, opt =>
                                       opt.MapFrom(src => src.Deprtment.Name));
        }
    }
}
