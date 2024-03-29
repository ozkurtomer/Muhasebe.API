
using Microsoft.AspNetCore.Identity;
using OnlineMuhasebe.WebAPI.Middleware;
using OnlineMuhasebe.WebAPI.Configurations;
using OnlineMuhasebe.Domain.AppEntities.Identities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();

app.UseHttpsRedirection();

app.MapControllers();

using (var scoped = app.Services.CreateScope())
{
    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    if (!userManager.Users.Any())
    {
        userManager.CreateAsync(new AppUser
        {
            UserName = "ozkurto",
            Email = "ozkurtomer@outlook.com",
            Id = Guid.NewGuid().ToString(),
            NameLastName = "�mer �zkurt"
        }, "1234").Wait();
    }
}


app.Run();
