using Microsoft.EntityFrameworkCore;

namespace RestApiGraphQL.Models.Todo;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItemModel> TodoItems { get; set; } = null!;
}