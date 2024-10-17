namespace SchoolProject.Core.Mapping.StudentMapping;

public partial class StudentMapping
{
    public void AddStudentMapping()
    {

        CreateMap<AddStudentDto, Student>()
         .ForMember(s => s.Id, opt => opt.Ignore())
         .ForMember(s => s.Studentsubjects, opt => opt.Ignore())
         .ForMember(s => s.Department, opt => opt.Ignore());

        CreateMap<AddStudennt, Student>()
            .IncludeBase<AddStudentDto, Student>();
    }
}
