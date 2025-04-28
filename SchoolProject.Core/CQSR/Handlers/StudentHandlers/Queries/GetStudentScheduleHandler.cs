namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Queries;

public class GetStudentScheduleHandler(IStudentRepository studentRepository) :
    ResponseHandler,
    IRequestHandler<GetStudentSchedule, Response<StudentSchedule>>
{
    public async Task<Response<StudentSchedule>> Handle(GetStudentSchedule request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<StudentSchedule>("Id must be grater than 0");

        var student = await studentRepository.FindAsync(request.Id);

        if (student is null)
            return BadRequest<StudentSchedule>("There is no student with this id");

        StudentSchedule studentSchedule = new()
        {
            StudentName = student.Name
        };

        var studentCourses = await studentRepository.GetStudentCourses(student);

        if (studentCourses is not null)
        {
            foreach (var course in studentCourses)
            {
                Subject subject = new()
                {
                    Type = "Course",
                    Name = course.Name,
                    Place = "Hall" + course.HallName ?? "There is no hall yet",
                    Day = course.Day,
                    StartTime = course.StartTime,
                    EndTime = course.EndTime
                };
                studentSchedule.Schedule.Add(subject);
            }
        }

        var studentSections = await studentRepository.GetStudentSections(student);

        if (studentSections is not null)
        {
            foreach (var section in studentSections)
            {
                Subject subject = new()
                {
                    Type = "section",
                    Name = section.Name,
                    Place = "Lab" + section.LabName ?? "There is no lab yet",
                    Day = section.Day,
                    StartTime = section.StartTime,
                    EndTime = section.EndTime
                };
                studentSchedule.Schedule.Add(subject);
            }
        }

        return Success(studentSchedule);
    }

}

