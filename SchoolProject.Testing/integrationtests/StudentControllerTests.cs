using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SchoolProject.Core.CQSR.Commands.StudentCommands;
using SchoolProject.Core.Dtos.Student_Dtos;
using SchoolProject.Core.Response;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace SchoolProject.Testing.integrationtests
{
    public class StudentControllerTests(WebApplicationFactory<Program> factory)
        : IClassFixture<WebApplicationFactory<Program>>
    {
        [Theory]
        [InlineData(1)]
        public async Task GetStudentEndPoint_Should_Return_A_Student(int id)
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7056/Api/V1/Student/id?id={id}");
            var responsebody = await response.Content.ReadAsStringAsync();
            var student = JsonSerializer.Deserialize<Response<GetStudentDto>>(responsebody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            student!.Should().BeOfType(typeof(Response<GetStudentDto>));
            student.Should().NotBeNull();
            student!.Data!.Name.Should().Be("Ahmed Ali");
        }

        [Theory]
        [InlineData(12)]
        public async Task GetStudent_when_Id_Not_Found_Returns_Not_Found(int id)
        {
            var client = factory.CreateClient();
            var jsonresponse = await client.GetAsync($"https://localhost:7056/Api/V1/Student/id?id={id}");
            var responsebody = await jsonresponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<Response<GetStudentDto>>(responsebody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            response!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            response!.Success.Should().BeFalse();
        }
        [Fact]
        public async Task AddStudentEndPoint_When_Send_Right_Data_Should_Return_StatusCode_201()
        {
            var client = factory.CreateClient();
            var newstudent = new AddStudennt()
            { Name = "Ibrahem Ahmed", Address = "Elrahbien", Phone = "01224127241", DepId = 1, Subjects = ["OOP", "Physics"] };
            var response = await client.PostAsJsonAsync("https://localhost:7056/Api/V1/Student/AddNewStudent", newstudent);
            var responsebody = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<Response<string>>(responsebody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            data!.StatusCode.Should().Be(HttpStatusCode.Created);
        }
        [Theory]
        [InlineData(82)]
        public async Task DeleteStudentEndPoint_When_Send_Exisisted_Id_Should_Return_StatusCode_200(int id)
        {
            var client = factory.CreateClient();
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"https://localhost:7056/Api/V1/Student/DeleteStudent?id={id}")
            };
            request.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJJYnJhaGVtQGdtYWlsLmNvbSIsInVuaXF1ZV9uYW1lIjoiSWJyYWhlbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2NvdW50cnkiOiJFZ3lwdCIsInJvbGUiOlsiU3VwZXJBZG1pbiIsIlVzZXIiXSwiR2V0IjoiVHJ1ZSIsIkNyZWF0ZSI6IlRydWUiLCJVcGRhdGUiOiJUcnVlIiwiRGVsZXRlIjoiVHJ1ZSIsIm5iZiI6MTcyNTQ2MTUxNSwiZXhwIjoxNzI1NzIwNzE1LCJpYXQiOjE3MjU0NjE1MTUsImlzcyI6IlNjaG9vbFByb2plY3QiLCJhdWQiOiJodHRwOi8vMTI3LjAuMC4xOjU1MDAifQ.1qmoOp1XiOKfSbEDTTM_cNYLA-5YebYUWVR_VP1GFSo");
            request.Headers.Add("Accept", "application/json");
            var response = await client.SendAsync(request);
            var responsebody = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<Response<string>>(responsebody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            data!.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
