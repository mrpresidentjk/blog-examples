using backend.Features.Enrollments;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", corsBuilder => corsBuilder.WithOrigins("http://localhost:5000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true));
});


builder.Services.AddDbContext<EnrollmentsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CollegeContext")));

builder.Services
    .AddGraphQLServer()
    .AddFiltering()
    .AddProjections()
    .RegisterDbContext<EnrollmentsContext>()
    .AddQueryType<EnrollmentsQuery>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGraphQL();

app.UsePlayground();

app.UseCors("CorsPolicy");

app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EnrollmentsContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();