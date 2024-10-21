using Microsoft.Extensions.Caching.Memory;
using SchoolProject.Infrustructure.SubjectRepositories;

namespace SchoolProject.Core.CQSR.Handlers.StudentHandlers;

public class StudentHandler(
    IStudentService studentService,
    IMapper mapper,
    IMemoryCache cache)

    : ResponseHandler,
    IRequestHandler<GetStudentById, Response<GetStudentDto>>,
    IRequestHandler<GetAllStudents, Response<List<GetStudentDto>>>

{
    public async Task<Response<GetStudentDto>> Handle(
        GetStudentById request,
        CancellationToken cancellationToken)
    {

        var student = await studentService.GetStudentById(request.Id);

        if (student is null) return NotFouned<GetStudentDto>();

        var s_dto = mapper.Map<GetStudentDto>(student);

        return Success(s_dto);
    }

    public async Task<Response<List<GetStudentDto>>> Handle(GetAllStudents request, CancellationToken cancellationToken)
    {
        var students = await studentService.GetAll();

        if (students is null) return NotFouned<List<GetStudentDto>>();

        var studentsDtos = mapper.Map<List<GetStudentDto>>(students);

        return Success(studentsDtos);
    }
}
public class GetStudentByNameHandler(
    IStudentService studentService,
    IMapper mapper)

: ResponseHandler,
  IRequestHandler<GetStudentByName, Response<GetStudentDto>>

{
    public async Task<Response<GetStudentDto>> Handle(
        GetStudentByName request,
        CancellationToken cancellationToken)
    {
        var Student = await studentService.GetStudentByName(request.name);

        if (Student is null) return NotFouned<GetStudentDto>();

        var s_dto = mapper.Map<GetStudentDto>(Student);

        return Success(s_dto);
    }
}

public class GroupStudentBySubjectIdHandler(
    IStudentService studentService,
    IMapper mapper)

: ResponseHandler,
    IRequestHandler<GroupStudentsBySub, Response<List<GetStudentDto>>>
{
    public async Task<Response<List<GetStudentDto>>> Handle(
        GroupStudentsBySub request,
        CancellationToken cancellationToken)
    {
        var Student = await studentService.GroupStudentsBySubject(request.name);

        if (Student.Count == 0) return NotFouned<List<GetStudentDto>>();

        List<GetStudentDto> studentDtos = mapper.Map<List<GetStudentDto>>(Student);

        return Success(studentDtos);
    }
}
public class GroupStudentByDepartmentIdHandler(
    IStudentService studentService,
    IMapper mapper)

    : ResponseHandler,
      IRequestHandler<GroupStudentsByDep, Response<List<GetStudentDto>>>
{
    public async Task<Response<List<GetStudentDto>>> Handle(
        GroupStudentsByDep request,
        CancellationToken cancellationToken)
    {
        var Student = await studentService.GroupStudentsByDepartment(request.name);

        if (Student.Count == 0) return NotFouned<List<GetStudentDto>>();

        List<GetStudentDto> studentDtos = mapper.Map<List<GetStudentDto>>(Student);

        return Success(studentDtos);
    }
}
public class AddStudentByIdHandler(
    IStudentService studentService,
    IStudentSubjectservice studentSubjectService,
    ISubjectRepository subjectRepository,
    IMapper mapper)
    : ResponseHandler,
      IRequestHandler<AddStudennt, Response<string>>
{
    public async Task<Response<string>> Handle(
        AddStudennt request,
        CancellationToken cancellationToken)
    {
        var student = mapper.Map<Student>(request);

        var s = await studentService.AddAsync(student);

        if (s != null)
        {
            List<StudentSubject> StudentSubject = [];
            foreach (var subject in request.Subjects)
            {
                var Subject = await subjectRepository.GetOneAsync(s => s.Name.ToLower() == subject.ToLower());
                if (Subject is not null)
                    StudentSubject.Add(new StudentSubject() { StuId = s.Id, SubId = Subject.Id });
            }
            await studentSubjectService.AddRangeAsync(StudentSubject);
            return Created<string>();

        }

        return UnprocessableEntity<string>();
    }
}
public class UpdateStudentByIdHandler(
    IStudentService studentService,
    IMapper mapper,
    AppDbContext appdbcontext)
: ResponseHandler, IRequestHandler<UpdateStudent, Response<GetStudentDto>>
{
    public async Task<Response<GetStudentDto>> Handle(
        UpdateStudent request,
        CancellationToken cancellationToken)
    {
        var student = mapper.Map<Student>(request);

        if (!appdbcontext.Students.Any(s => s.Id == request.Id))
            return UnprocessableEntity(mapper.Map<GetStudentDto>(student));

        List<StudentSubject> studentSubjects = new List<StudentSubject>();

        foreach (var subject in request.Subjects)
        {
            var sub = appdbcontext.Subjects.FirstOrDefault(x => x.Name.ToLower() == subject.ToLower());

            if (sub is not null)
                studentSubjects.Add(new StudentSubject() { StuId = request.Id, SubId = sub.Id });

        }

        appdbcontext.StudentSubjects.RemoveRange
            (appdbcontext.StudentSubjects.Where(s => s.StuId == request.Id));

        await appdbcontext.StudentSubjects.AddRangeAsync(studentSubjects);

        await appdbcontext.SaveChangesAsync();

        var s = await studentService.Update(student);

        var dto = mapper.Map<GetStudentDto>(s);

        return Success(dto);
    }
}
public class DeleteStudentByIdHandler(
    IStudentService studentService)

    : ResponseHandler,
    IRequestHandler<DeleteStudennt, Response<string>>
{
    public async Task<Response<string>> Handle(
        DeleteStudennt request,
        CancellationToken cancellationToken)
    {
        var s = await studentService.DeleteStudent(request.id);

        if (s == false)
            return NotFouned<string>();
        return Deleted<string>();

    }
}
public class StudentPaginationIdHandler(IStudentService studentService)
: ResponseHandler, IRequestHandler<StudentPagination, PaginationResponse<GetStudentDto>>
{
    public async Task<PaginationResponse<GetStudentDto>> Handle(
        StudentPagination request,
        CancellationToken cancellationToken)
    {
        Expression<Func<Student, GetStudentDto>> expression = s => new GetStudentDto()
        {
            Name = s.Name,

            Address = s.Address,

            Phone = s.Phone,

            DepName = s.Department.Name,

            Subjects = s.Subjects.Select(s => s.Name).ToList()
        };

        var Students = studentService.Filter(request.StudentOrder, request.search);

        var studentsdtos = Students.Select(expression);

        var paginatedlist = await studentsdtos.ToPaginate(request.pagenum, request.pagesize);

        return paginatedlist;
    }
}
