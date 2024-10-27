namespace UniversityProject.Core.Mapping.StudentMapping;

public partial class StudentMapping
{
    public void UpdateStudentMap()
    {
        CreateMap<UpdateStudentDto, Student>();

        CreateMap<UpdateStudent, Student>()
            .IncludeBase<UpdateStudentDto, Student>();
    }
}
