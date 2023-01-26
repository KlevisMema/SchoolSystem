#region Usings

using SchoolSystem.API.ProgramExtension;
using SchoolSystem.DAL.DataBase.Configuration.Seeding;

#endregion

#region Services 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.InjectServices(builder.Configuration);

#endregion

#region Build/Use services

var app = builder.Build();

await DatabaseSeeding.Seed(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion