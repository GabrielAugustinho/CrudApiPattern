using CrudApiPattern.Ports.Api.Configurations;
using CrudApiPattern.Ports.Api.Setup;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.AddSwaggerConfiguration();
builder.Services.RegisterService();

var app = builder.Build();

app.UseSwaggerConfiguration(app.Environment);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

[ExcludeFromCodeCoverage]
public partial class Program { }