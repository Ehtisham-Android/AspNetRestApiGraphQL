global using GraphQL.Types;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using RestApiGraphQL.GQLSchemas;
using RestApiGraphQL.Models.Todo;
using RestApiGraphQL.GQLTypes;
using RestApiGraphQL.GQLQueries;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<RestApiGraphQL.Models.Emp.RestApiGraphQldbContext>();
builder.Services.AddDbContext<RestApiGraphQL.Models.Invoices.RestApiGraphQldbContext>();

builder.Services.AddSingleton<EmployeeType>();
builder.Services.AddSingleton<EmployeeQuery>();
builder.Services.AddSingleton<ISchema, EmployeeSchema>();
builder.Services.AddGraphQL(b => b.AddAutoSchema<EmployeeSchema>().AddSystemTextJson());


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

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("Hello World!");
//    });
//    endpoints.MapGraphQL();
//});

app.UseGraphQL<ISchema>("/graphql");            // url to host GraphQL endpoint
app.UseGraphQLPlayground(
    "/",                               // url to host Playground at
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
    });

app.Run();
