namespace SchoolProject.Services.AbstractionServices;

public interface IStudentSubjectservice
{
    public Task<StudentSubject> AddAsync(StudentSubject Entity);

    public Task<ICollection<StudentSubject>> AddRangeAsync(
                                    ICollection<StudentSubject> Entities);
}
