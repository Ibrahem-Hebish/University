namespace UniversityProject.Core.Mapping.StudentMapping;

public partial class StudentMapping
{
    public void GetStudentMapping()
    {
        CreateMap<Student, GetStudentDto>()
         .ForMember(std => std.DepName, opt => opt.MapFrom(s => s.Department.Name))
         .ReverseMap()
         .ForMember(s => s.Id, opt => opt.Ignore())
         .ForMember(s => s.Courses, opt => opt.Ignore())
         .ForMember(s => s.StudentCourses, opt => opt.Ignore())
         .ForMember(s => s.DepId, opt => opt.Ignore());
    }

}
