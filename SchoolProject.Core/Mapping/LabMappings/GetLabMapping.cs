using UniversityProject.Core.Dtos.LabDtos;

namespace UniversityProject.Core.Mapping.LabMappings;

public partial class Mappings
{
    public void GetLabMapping()
    {
        CreateMap<Lab, GetLab>()
              .ForMember(dest => dest.DepartmentName, opt =>
                                    opt.MapFrom(src => src.Department.Name));
    }
}
