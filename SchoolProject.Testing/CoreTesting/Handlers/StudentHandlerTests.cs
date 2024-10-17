using AutoMapper;
using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using SchoolProject.Core.CQSR.Handlers.StudentHandlers;
using SchoolProject.Core.CQSR.Queries.StudentQueries;
using SchoolProject.Core.Dtos.Student_Dtos;
using SchoolProject.Core.Mapping.StudentMapping;
using SchoolProject.Core.Response;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helper;
using SchoolProject.Services.AbstractionServices;
using System.Net;
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, MaxParallelThreads = 6)]
namespace SchoolProject.Testing.CoreTesting.Handlers
{
    public class StudentHandlerTests
    {
        private readonly Mock<IStudentService> StudentserviceMock;
        private readonly IMapper _mapperMock;
        private readonly StudentMapping _studentMapping;
        private readonly Mock<IMemoryCache> _memoryCache;
        private readonly StudentHandler _handler;
        public StudentHandlerTests()
        {
            StudentserviceMock = new();
            _studentMapping = new();
            var configuration = new MapperConfiguration(c => c.AddProfile(_studentMapping));
            _mapperMock = new Mapper(configuration);
            _memoryCache = new();
            _handler = new StudentHandler(StudentserviceMock.Object, _mapperMock, _memoryCache.Object); ;
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
            _memoryCache.Setup(x => x.TryGetValue(It.IsAny<object>(), out It.Ref<object>.IsAny!))
                .Returns((object key, out Student student2) =>
                {
                    student2 = student;
                    return true;
                });

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
            var handler = new StudentPaginationIdHandler(StudentserviceMock.Object);
            var query = new StudentPagination(1, 10, null, StudentOrderEnum.Name);
            var studentSubjects = new List<Subject>() { new() { Name = "Physics", Id = 1 } };
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
                    Subjects = studentSubjects,
                    Department = department
                }
            });
            StudentserviceMock.Setup(x => x.Filter(query.StudentOrder, query.search)).Returns(student.AsQueryable());
            var result = await handler.Handle(query, CancellationToken.None);
            result.Should().NotBeNull();
        }
    }
}
