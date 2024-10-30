namespace UniversityProject.Core.Mapping.Teaching_Assistant_Mapping;

public partial class TeachingAssistantMapping
{
    public void GetTeachingAssistantMap()
    {
        CreateMap<TeachingAssistant, GetTeachingAssistantDto>()
            .ForMember(ta => ta.DepartmentName, opt => opt.MapFrom(t => t.Department.Name));
    }
}
