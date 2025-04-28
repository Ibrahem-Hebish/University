using UniversityProject.Core.CQSR.Handlers.StudentHandlers.Queries;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, MaxParallelThreads = 6)]

namespace UniversityProject.Testing.CoreTesting.Handlers;

public class StudentHandlerTests
{
    private readonly Mock<IStudentService> StudentserviceMock;
    private readonly IMapper _mapperMock;
    private readonly StudentMapping _studentMapping;
    private readonly Mock<IStudentCourseRepository> _studentCourseRepositoryMock;
    private readonly Mock<ICourseRepository> _CourseRepositoryMock;
    private readonly Mock<IStudentRepository> _studentRepositoryMock;
    private readonly Mock<ISectionRepository> _sectionRepositoryMock;
    public StudentHandlerTests()
    {
        StudentserviceMock = new();
        _studentMapping = new();
        var configuration = new MapperConfiguration(c => c.AddProfile(_studentMapping));
        _mapperMock = new Mapper(configuration);
        _studentCourseRepositoryMock = new();
        _CourseRepositoryMock = new();
        _sectionRepositoryMock = new();
        _studentRepositoryMock = new();
    }
    [Theory]
    [InlineData(1)]
    public async Task Get_Student_Dto_Should_Not_Be_Null_Or_Empty(int id)
    {
        var handler = new GetStudentByIdHandler(StudentserviceMock.Object, _mapperMock);

        var query = new GetStudentById(id);

        var student = new Student()
        {
            Id = 1,
            DepId = 2,
            Phone = "01092836457",
            Address = "elmahalla",
            Name = "Ali"
        };

        StudentserviceMock
            .Setup(x => x.GetStudentById(id))
            .Returns(Task.FromResult(student));

        var result = await handler
            .Handle(query, CancellationToken.None);

        result.Should()
            .BeOfType<Response<GetStudentDto>>();

        result.StatusCode.Should()
            .Be(HttpStatusCode.OK);
    }
    [Theory]
    [InlineData(12)]
    public async Task Get_Student_Dto_Should_Be_Null_Or_Empty(int id)
    {
        var handler = new GetStudentByIdHandler(StudentserviceMock.Object, _mapperMock);

        var query = new GetStudentById(id);

        var student = new Student()
        {
            Id = 1,
            DepId = 2,
            Phone = "01092836457",
            Address = "elmahalla",
            Name = "Ali"
        };

        var returnresult = student.Id == id ? student : null;

        StudentserviceMock
            .Setup(x => x.GetStudentById(id))
            .Returns(Task.FromResult(returnresult!));

        var result = await handler
            .Handle(query, CancellationToken.None);

        result.Should()
            .BeOfType<Response<GetStudentDto>>();

        result.StatusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }
    [Fact]
    public async Task Get_PaginatedList_Should_Not_Be_Null_Or_Empty()
    {
        var handler = new StudentPaginationHandler(StudentserviceMock.Object, _mapperMock);

        var query = new StudentPagination(1, 10, null, StudentOrderEnum.Name);

        var studentCourses = new List<Course>() { new() { Name = "Physics", Id = 1 } };

        var department = new Department() { Name = "CS", Id = 1 };

        var student = new AsyncEnumerable<Student>(new List<Student>()
        {
            new()
            {
                Id = 1,
                DepId = 1,
                Phone = "01092836457",
                Address = "elmahalla",
                Name = "Ali",
                Courses = studentCourses,
                Department = department
            }
        });
        StudentserviceMock
            .Setup(x => x.Filter(query.StudentOrder, query.Search))
            .Returns(student.AsQueryable());

        var result = await handler
            .Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
    }
}
