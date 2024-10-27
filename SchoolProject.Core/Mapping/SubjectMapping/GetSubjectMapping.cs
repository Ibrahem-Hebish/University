
namespace UniversityProject.Core.Mapping.SubjectMapping;

public partial class SubjectMapping
{
    public void GetSectionMapping()
    {
        CreateMap<Subject, GetSubjectDto>();
    }
}
