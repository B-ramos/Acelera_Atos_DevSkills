using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.IService;
using Atos.DevSkills.Infra.Data.Context;
using Atos.DevSkills.Infra.Data.Repository;
using Atos.DevSkills.Service.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DevSkillsContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


builder.Services.AddScoped<IDesenvolvedorService, DesenvolvedorService>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IDesenvolvedorRepository, DesenvolvedorRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

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
