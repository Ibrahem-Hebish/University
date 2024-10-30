namespace UniversityProject.Core.Mapping.StudentMapping;

public partial class StudentMapping
{
    public void AddStudentMapping()
    {

        CreateMap<AddStudennt, Student>()
         .ForMember(s => s.StudentCourses, opt => opt.Ignore())
         .ForMember(s => s.Department, opt => opt.Ignore())
         .ForMember(s => s.Courses, opt => opt.Ignore()); ;
    }
}
