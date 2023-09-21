using Samples.Authentication.Basic.Core;

var builder = WebApplication.CreateBuilder(args);

// register Sequoia components
builder.Services.AddCoreServices(builder.Configuration);

// register default components
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(); TODO: add swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();