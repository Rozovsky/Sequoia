using Samples.Sequoia.Complex.Core;
using Sequoia.Extensions;
using Sequoia.Logging.Microsoft;

var builder = WebApplication.CreateBuilder(args);

// register Sequoia components
builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddMicrosoftLogging(builder.Configuration);

// register default components
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// use Sequoia components
app.UseSequoiaExceptionHandler();

// use default components
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
