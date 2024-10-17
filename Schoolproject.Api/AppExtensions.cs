namespace Schoolproject.Api;

public static class AppExtensions
{
    public static async Task ConfigureAsync(
        this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var usermanager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            var rolemanager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

            await RoleSeeder.SeedAsync(rolemanager);

            await UserSeeder.SeedAsync(usermanager);
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI();
        }
        var option = app.Services.GetService<IOptions<RequestLocalizationOptions>>();

        if (option is not null) app.UseRequestLocalization(option.Value);


        app.UseHttpsRedirection();

        app.UseCors("local");

        app.UseRateLimiter();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();
    }
}
