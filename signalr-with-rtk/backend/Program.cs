using backend.Features.Messages.Hubs;
using backend.Features.Messages.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IMessageService, MessageService>();
builder.Services.AddHostedService<TimedBroadcastService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", corsBuilder => corsBuilder.WithOrigins("http://localhost:5000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");
app.MapHub<MessageHub>("/messageHub");

app.MapControllers();

app.Run();
