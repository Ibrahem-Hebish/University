using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.Mapping.OfficeMappings
{
    public partial class Mappings
    {
        public void GetOfficeMapping()
        {
            CreateMap<Office, GetOffice>()
                  .ForMember(dest => dest.DepartmentName, opt =>
                                 opt.MapFrom(src => src.Department.Name));
        }
    }
}
