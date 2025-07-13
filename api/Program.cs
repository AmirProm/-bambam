using api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddRepositoryService();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();

app.Run();