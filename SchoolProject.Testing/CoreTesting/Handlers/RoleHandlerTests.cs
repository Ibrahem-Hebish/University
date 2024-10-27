namespace UniversityProject.Testing.CoreTesting.Handlers;

public class RoleHandlerTests
{
    private readonly Mock<IRoleServices> _roleServices;
    private readonly Mock<UserManager<User>> _userManager;
    private readonly Mock<RoleManager<Role>> _roleManager;
    private readonly Mock<AppDbContext> _appDbContext;
    private readonly IMapper _mapper;
    private readonly RoleMappings _roleMappings;
    public RoleHandlerTests()
    {
        _appDbContext = new();
        _roleMappings = new();
        _roleManager = MockRoleManager.mock();
        _userManager = MockUserManager.mock();
        _roleServices = new();
        var configuration = new MapperConfiguration(c => c.AddProfile(_roleMappings));
        _mapper = new Mapper(configuration);
    }
    [Fact]
    public async Task Get_All_Roles_Should_Not_Be_Null()
    {
        var handler = new RoleHandler
            (_appDbContext.Object, _roleServices.Object, _mapper, _userManager.Object, _roleManager.Object);
        List<Role> roles = new()
        {
            new Role { Id = 1,Name = "Admin"},
            new Role { Id = 2,Name = "User"}
        };
        var query = new GetRoles();
        _roleServices.Setup(s => s.GetRolesAsync()).Returns(Task.FromResult(roles));
        var result = await handler.Handle(query, CancellationToken.None);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Success.Should().BeTrue();
    }
}
