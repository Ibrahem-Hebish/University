using UniversityProject.Core.Dtos.SectionDtos;

namespace UniversityProject.Core.Mapping.SectionMappings;

public partial class SectionMappings
{
    public void GetSectionMapping()
    {
        CreateMap<Section, GetSectionDto>();
    }
}
