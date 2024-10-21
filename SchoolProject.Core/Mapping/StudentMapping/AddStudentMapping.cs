﻿namespace SchoolProject.Core.Mapping.StudentMapping;

public partial class StudentMapping
{
    public void AddStudentMapping()
    {

        CreateMap<AddStudennt, Student>()
         .ForMember(s => s.Studentsubjects, opt => opt.Ignore())
         .ForMember(s => s.Department, opt => opt.Ignore())
         .ForMember(s => s.Subjects, opt => opt.Ignore()); ;
    }
}
