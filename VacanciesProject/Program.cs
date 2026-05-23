using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using VacanciesProject.Application.Common;
using VacanciesProject.Application.Common.Validation;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Application.Interfaces.Services;
using VacanciesProject.Application.Services;
using VacanciesProject.CurrentUser;
using VacanciesProject.Domain.Entity;
using VacanciesProject.Extensions;
using VacanciesProject.Infrastructure.Persistance;
using VacanciesProject.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Mediator DI
builder.Services.AddMediatR(cfg =>
{
	cfg.RegisterServicesFromAssembly(
		typeof(ApplicationAssemblyReference).Assembly);
});
builder.Services
	.AddIdentity<AppUser, IdentityRole<int>>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

//JWT Authentication
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddScoped<IJwtTokenService, JwtServices>();

//Caching Service
//builder.Services.AddScoped<ICacheRepository, CacheRepository>();

//builder.Services.AddSingleton<IConnectionMultiplexer>(_ =>
//	ConnectionMultiplexer.Connect(
//		builder.Configuration.GetConnectionString("RedisConnection")!));

//Validation Behaviour
builder.Services.AddValidatorsFromAssembly(typeof(ValidationBehavior<,>).Assembly);

//Audit Logging Service
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


