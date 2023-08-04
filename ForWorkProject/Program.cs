using ForWorkProject.Context;
using ForWorkProject.Loggers;
using ForWorkProject.Managers;
using ForWorkProject.Middleware;
using ForWorkProject.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = CustomLogger
    .WriteLogToFile(builder.Configuration, $"Loggers/{DateTime.Now.ToString("dd/MM/yyyy")}.txt");

builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    options.UseNpgsql("Server=localhost; Port=5434; Database=postgres; User Id=postgres; Password=postgres;");
});
builder.Services.AddScoped<IChatRepository,ChatRepository>();
builder.Services.AddScoped<IMessageRepository,MessageRepository>();
builder.Services.AddScoped<IChatManager, ChatManager>();
builder.Services.AddScoped<IMessageManager, MessageManager>();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseErrorHandlerMiddleware();

app.MapControllers();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
