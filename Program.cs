using Microsoft.EntityFrameworkCore;
using RestApiGraphQL.Models.Emp;
using RestApiGraphQL.Models.Invoices;
using RestApiGraphQL.Models.Todo;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<RestApiGraphQL.Models.Emp.RestApiGraphQldbContext>(); // for database table
builder.Services.AddDbContext<RestApiGraphQL.Models.Invoices.RestApiGraphQldbContext>();

// Model
// Type
// Query
// Schema
// DI setup
// Access from Postman


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
