﻿
namespace UniversityProject.Testing.Helpers
{
    public static class MockUserManager
    {
        public static Mock<UserManager<User>> mock()
        {
            var mock = new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<User>>().Object,
                new IUserValidator<User>[0],
                new IPasswordValidator<User>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<User>>>().Object);
            return mock;
        }
    }
}
