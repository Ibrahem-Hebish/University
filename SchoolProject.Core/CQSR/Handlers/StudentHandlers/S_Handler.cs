
namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers;

public class StudentHandler(
    IStudentService studentService,
    IStudentRepository studentRepository,
    IStudentCourseRepository studentCourseRepository,
    ICourseRepository CourseRepository,
    ISectionRepository sectionRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetStudentById, Response<GetStudentDto>>,
    IRequestHandler<GetAllStudents, Response<List<GetStudentDto>>>,
    IRequestHandler<GetStudentByName, Response<GetStudentDto>>,
    IRequestHandler<GroupStudentsByCourse, Response<List<GetStudentDto>>>,
    IRequestHandler<GroupStudentsByDep, Response<List<GetStudentDto>>>,
    IRequestHandler<StudentPagination, PaginationResponse<GetStudentDto>>,
    IRequestHandler<AddStudent, Response<string>>,
    IRequestHandler<UpdateStudent, Response<GetStudentDto>>,
    IRequestHandler<DeleteStudennt, Response<string>>

{
    public async Task<Response<GetStudentDto>> Handle(
        GetStudentById request,
        CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<GetStudentDto>("Id must be grater than 0");
        var student = await studentService.GetStudentById(request.Id);

        if (student is null) return NotFouned<GetStudentDto>();

        var s_dto = mapper.Map<GetStudentDto>(student);

        return Success(s_dto);
    }

    public async Task<Response<List<GetStudentDto>>> Handle(GetAllStudents request, CancellationToken cancellationToken)
    {
        var students = await studentService.GetAll();

        if (students is null || students.Count == 0)
            return NotFouned<List<GetStudentDto>>();

        var studentsDtos = mapper.Map<List<GetStudentDto>>(students);

        return Success(studentsDtos);
    }

    public async Task<Response<GetStudentDto>> Handle(
        GetStudentByName request,
        CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
            return BadRequest<GetStudentDto>();

        var Student = await studentService.GetStudentByName(request.Name);

        if (Student is null) return NotFouned<GetStudentDto>();

        var s_dto = mapper.Map<GetStudentDto>(Student);

        return Success(s_dto);
    }
    public async Task<Response<List<GetStudentDto>>> Handle(
        GroupStudentsByCourse request,
        CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
            return BadRequest<List<GetStudentDto>>();

        var Student = await studentService.GroupStudentsByCourse(request.Name);

        if (Student.Count == 0) return NotFouned<List<GetStudentDto>>();

        List<GetStudentDto> studentDtos = mapper.Map<List<GetStudentDto>>(Student);

        return Success(studentDtos);
    }
    public async Task<Response<List<GetStudentDto>>> Handle(
        GroupStudentsByDep request,
        CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
            return BadRequest<List<GetStudentDto>>();

        var Student = await studentService.GroupStudentsByDepartment(request.Name);

        if (Student.Count == 0) return NotFouned<List<GetStudentDto>>();

        List<GetStudentDto> studentDtos = mapper.Map<List<GetStudentDto>>(Student);

        return Success(studentDtos);
    }
    public async Task<PaginationResponse<GetStudentDto>> Handle(
        StudentPagination request,
        CancellationToken cancellationToken)
    {
        if (request.Pagenum < 0 || request.Pagesize < 0)
            return new PaginationResponse<GetStudentDto> { Successed = false, Count = 0 };

        var Students = studentService.Filter(request.StudentOrder, request.Search);

        var studentsDtos = mapper.Map<IQueryable<GetStudentDto>>(Students);

        var paginatedlist = await studentsDtos.ToPaginate(request.Pagenum, request.Pagesize);

        return paginatedlist;
    }
    public async Task<Response<string>> Handle(
        AddStudent request,
        CancellationToken cancellationToken)
    {
        var StudentsNumber = await studentRepository.GetAllWhere(x =>
        x.Level == request.Level && x.Term == request.Term);

        if (StudentsNumber.Count == 200)
            return BadRequest<string>("Sorry,We can not exceed 200 student,So we can not accept this student");

        using var transaction = studentCourseRepository.BeginTransaction();
        try
        {
            var student = mapper.Map<Student>(request);

            var Courses = await CourseRepository.GetAllWhere(x =>
                                      x.Level == request.Level && x.Term == request.Term);

            student.Courses.AddRange(Courses);

            var Sections = await sectionRepository.GetAllWhere(x =>
            x.Level.Equals(request.Level) && x.Term.Equals(request.Term));

            List<Section> StudentSections = [];

            var DistincitSections = Sections.DistinctBy(x => x.Course).ToList();

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
        if (request.Id <= 0)
            return BadRequest<string>("id must be grater than 0");

        var student = await studentService.DeleteStudent(request.Id);

        if (student == false)
            return NotFouned<string>();
        return Deleted<string>();

    }
}