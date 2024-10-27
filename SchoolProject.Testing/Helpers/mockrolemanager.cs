﻿namespace UniversityProject.Testing.Helpers;

public static class MockRoleManager
{
    public static Mock<RoleManager<Role>> mock()
    {
        var mock = new Mock<RoleManager<Role>>(
            new Mock<IRoleStore<Role>>().Object,
            new IRoleValidator<Role>[0],
            new Mock<ILookupNormalizer>().Object,
            new Mock<IdentityErrorDescriber>().Object,
            new Mock<ILogger<RoleManager<Role>>>().Object);
        return mock;
    }
}