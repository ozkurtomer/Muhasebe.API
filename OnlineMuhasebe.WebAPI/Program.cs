using MediatR;
using OnlineMuhasebe.Domain;
using Microsoft.OpenApi.Models;
using OnlineMuhasebe.Persistence;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Persistence.Context;
using OnlineMuhasebe.Domain.AppEntities.Identities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OnlineMuhasebe.Application.Services.AppServices;
using OnlineMuhasebe.Persistence.Services.AppServices;
using OnlineMuhasebe.Persistence.Services.CompanyServices;
using OnlineMuhasebe.Application.Services.CompanyServices;
using OnlineMuhasebe.Domain.Repositories.UniformChartOfAccountRepositories;
using OnlineMuhasebe.Persistence.Repositories.UniformCharOfAccountRepositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddApplicationPart(typeof(OnlineMuhasebe.Presentation.AssemblyReference).Assembly);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<ICompanyService, CompanyServices>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUniformChartOfAccountCommandRepository, UniformChartOfAccountCommandRepository>();
builder.Services.AddScoped<IUniformChartOfAccountQueryRepository, UniformChartOfAccountQueryRepository>();
builder.Services.AddScoped<IContextService, ContextService>();
builder.Services.AddScoped<IUniformChartOfAccountService, UniformChartOfAccountService>();

builder.Services.AddMediatR(typeof(OnlineMuhasebe.Application.AssemblyReference).Assembly);
builder.Services.AddAutoMapper(typeof(OnlineMuhasebe.Persistence.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    //Swagger authorize button
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below'",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwtSecurityScheme, Array.Empty<string>() }
    });

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
