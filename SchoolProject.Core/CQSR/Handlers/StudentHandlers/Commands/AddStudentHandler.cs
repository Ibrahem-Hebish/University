namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Commands;

public class AddStudentHandler(IStudentService studentService,
    IStudentRepository studentRepository,
    ISectionRepository sectionRepository,
    IStudentCourseRepository studentCourseRepository,
    ICourseRepository courseRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<AddStudent, Response<string>>
{
    public async Task<Response<string>> Handle(
        AddStudent request,
        CancellationToken cancellationToken)
    {
        var StudentsNumber = await studentRepository.GetAllWhere(x =>
        x.Level == request.Level && x.Term == request.Term);

        if (StudentsNumber.Count() == 200)
            return BadRequest<string>("Sorry,We can not exceed 200 student,So we can not accept this student");

        using var transaction = studentCourseRepository.BeginTransaction();
        try
        {
            var student = mapper.Map<Student>(request);

            var Courses = await courseRepository.GetAllWhere(x =>
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
}



