using Atos.DevSkills.API.Filters;
using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.IService;
using Atos.DevSkills.Infra.Data.Context;
using Atos.DevSkills.Infra.Data.Repository;
using Atos.DevSkills.Infra.Data.Repository.Factories;
using Atos.DevSkills.Service.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DevSkillsContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

// Add services to the container.
builder.Services.AddScoped<DesenvolvedorRepositoryFactory>();
builder.Services.AddScoped<SkillRepositoryFactory>();
builder.Services.AddScoped<IDesenvolvedorService, DesenvolvedorService>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IDesenvolvedorRepository, DesenvolvedorRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
    options.Filters.Add(typeof(ValidationFilter));
})
.AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
.ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
