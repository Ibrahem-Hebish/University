
namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers;

public class StudentHandler(
    IStudentService studentService,
    IStudentRepository studentRepository,
    IStudentSubjectRepository studentSubjectRepository,
    ISubjectRepository subjectRepository,
    ISectionRepository sectionRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetStudentById, Response<GetStudentDto>>,
    IRequestHandler<GetAllStudents, Response<List<GetStudentDto>>>,
    IRequestHandler<GetStudentByName, Response<GetStudentDto>>,
    IRequestHandler<GroupStudentsBySub, Response<List<GetStudentDto>>>,
    IRequestHandler<GroupStudentsByDep, Response<List<GetStudentDto>>>,
    IRequestHandler<StudentPagination, PaginationResponse<GetStudentDto>>,
    IRequestHandler<AddStudennt, Response<string>>,
    IRequestHandler<UpdateStudent, Response<GetStudentDto>>,
    IRequestHandler<DeleteStudennt, Response<string>>

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

        if (students is null || students.Count == 0) return NotFouned<List<GetStudentDto>>();

        var studentsDtos = mapper.Map<List<GetStudentDto>>(students);

        return Success(studentsDtos);
    }

    public async Task<Response<GetStudentDto>> Handle(
        GetStudentByName request,
        CancellationToken cancellationToken)
    {
        var Student = await studentService.GetStudentByName(request.name);

        if (Student is null) return NotFouned<GetStudentDto>();

        var s_dto = mapper.Map<GetStudentDto>(Student);

        return Success(s_dto);
    }
    public async Task<Response<List<GetStudentDto>>> Handle(
        GroupStudentsBySub request,
        CancellationToken cancellationToken)
    {
        var Student = await studentService.GroupStudentsBySubject(request.name);

        if (Student.Count == 0) return NotFouned<List<GetStudentDto>>();

        List<GetStudentDto> studentDtos = mapper.Map<List<GetStudentDto>>(Student);

        return Success(studentDtos);
    }
    public async Task<Response<List<GetStudentDto>>> Handle(
        GroupStudentsByDep request,
        CancellationToken cancellationToken)
    {
        var Student = await studentService.GroupStudentsByDepartment(request.name);

        if (Student.Count == 0) return NotFouned<List<GetStudentDto>>();

        List<GetStudentDto> studentDtos = mapper.Map<List<GetStudentDto>>(Student);

        return Success(studentDtos);
    }
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
            Term = s.Term,
            Level = s.Level,
        };

        var Students = studentService.Filter(request.StudentOrder, request.search);

        var studentsdtos = Students.Select(expression);

        var paginatedlist = await studentsdtos.ToPaginate(request.pagenum, request.pagesize);

        return paginatedlist;
    }
    public async Task<Response<string>> Handle(
        AddStudennt request,
        CancellationToken cancellationToken)
    {
        var StudentsNumber = await studentRepository.GetAllWhere(x =>
        x.Level == request.Level && x.Term == request.Term);

        if (StudentsNumber.Count == 200)
            return BadRequest<string>("Sorry,We can not exceed 200 student,So we can not accept this student");

        using var transaction = studentSubjectRepository.BeginTransaction();
        try
        {
            var student = mapper.Map<Student>(request);

            var Courses = await subjectRepository.GetAllWhere(x =>
                                      x.Level == request.Level && x.Term == request.Term);

            student.Subjects.AddRange(Courses);

            var Sections = await sectionRepository.GetAllWhere(x =>
            x.Level.Equals(request.Level) && x.Term.Equals(request.Term));

            List<Section> StudentSections = [];

            var DistincitSections = Sections.DistinctBy(x => x.Subject).ToList();

            foreach (var section in DistincitSections)
            {
                var SectionGroup = Sections.Where(x => x.Name.Equals(section.Name)).ToList();

                foreach (var sectionInGroup in SectionGroup)
                {
                    if (sectionInGroup.Students.Count < 70)
                    {
                        StudentSections.Add(sectionInGroup);
                        break;
                    }
                }
            }

            student.Sections.AddRange(StudentSections);

            List<Doctor> doctors = [];

            foreach (var Course in Courses)
                doctors.Add(Course.Doctor);

            List<TeachingAssistant> TeachingAssistants = [];

            foreach (var Section in StudentSections)
                TeachingAssistants.Add(Section.TeachingAssistant);

            student.Doctors.AddRange(doctors);

            student.TeachingAssistants.AddRange(TeachingAssistants.Distinct());

            var s = await studentService.AddAsync(student);

            transaction.Commit();

            return Created<string>();

        }
        catch (Exception ex)
        {
            transaction.Rollback();
            await Console.Out.WriteLineAsync(ex.ToString());
            return BadRequest<string>("Something went wrong,please try again later");
        }
    }
    public async Task<Response<GetStudentDto>> Handle(
        UpdateStudent request,
        CancellationToken cancellationToken)
    {
        var ExsistingStudent = await studentService.GetStudentById(request.Id);

        if (ExsistingStudent == null)
            return BadRequest<GetStudentDto>("Student is not found");

        var student = mapper.Map<Student>(request);

        ExsistingStudent.Address = student.Address;
        ExsistingStudent.Name = student.Name;
        ExsistingStudent.Phone = student.Phone;

        await studentRepository.UpdateAsync(ExsistingStudent, request.Id);

        var StudentDto = mapper.Map<GetStudentDto>(ExsistingStudent);

        return Success(StudentDto, "Updated Successfully");

    }
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