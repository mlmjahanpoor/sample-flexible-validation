using Moslem.FlexibleValidation.Extensions;
using Moslem.FlexibleValidation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//1
builder.AddFlexibleValidation();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

//2
app.UseFlexibleValidation();

app.Run();