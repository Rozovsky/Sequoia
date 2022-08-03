using Microsoft.EntityFrameworkCore;
using Samples.Data.Postgresql.Core;
using Samples.Data.Postgresql.Core.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// register Sequoia components
builder.Services.AddCoreServices(builder.Configuration);

// register default components
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// migrate db
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dataContext.Database.Migrate();
}

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