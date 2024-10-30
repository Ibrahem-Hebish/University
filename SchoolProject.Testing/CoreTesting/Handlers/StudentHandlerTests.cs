
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
    private readonly StudentHandler _handler;
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
        _handler = new StudentHandler(
            StudentserviceMock.Object,
            _studentRepositoryMock.Object,
            _studentCourseRepositoryMock.Object,
            _CourseRepositoryMock.Object,
            _sectionRepositoryMock.Object,
            _mapperMock); ;
    }
    [Theory]
    [InlineData(1)]
    public async Task Get_Student_Dto_Should_Not_Be_Null_Or_Empty(int id)
    {
        var query = new GetStudentById(id);
        var student = new Student()
        {
            Id = 1,
            DepId = 2,
            Phone = "01092836457",
            Address = "elmahalla",
            Name = "Ali"
        };
        StudentserviceMock.Setup(x => x.GetStudentById(id)).Returns(Task.FromResult(student));

        //_memoryCache.Setup(x => x.TryGetValue(It.IsAny<object>(), out It.Ref<object>.IsAny!))
        //    .Returns((object key, out Student student2) =>
        //    {
        //        student2 = student;
        //        return true;
        //    });

        //_memoryCache.Setup(m => m.CreateEntry(It.IsAny<object>()))
        //    .Returns(Mock.Of<ICacheEntry>());

        var result = await _handler.Handle(query, CancellationToken.None);
        result.Should().BeOfType<Response<GetStudentDto>>();
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    [Theory]
    [InlineData(12)]
    public async Task Get_Student_Dto_Should_Be_Null_Or_Empty(int id)
    {
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
        StudentserviceMock.Setup(x => x.GetStudentById(id)).Returns(Task.FromResult(returnresult!));
        var result = await _handler.Handle(query, CancellationToken.None);
        result.Should().BeOfType<Response<GetStudentDto>>();
        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    [Fact]
    public async Task Get_PaginatedList_Should_Not_Be_Null_Or_Empty()
    {
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
        StudentserviceMock.Setup(x => x.Filter(query.StudentOrder, query.Search)).Returns(student.AsQueryable());
        var result = await _handler.Handle(query, CancellationToken.None);
        result.Should().NotBeNull();
    }
}
