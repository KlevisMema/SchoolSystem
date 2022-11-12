using SchoolSystem.API.ProgramExtension;
using SchoolSystem.DAL.Configuration.Seeding;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.InjectServices(builder.Configuration);

var app = builder.Build();

await DatabaseSeeding.Seed(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();