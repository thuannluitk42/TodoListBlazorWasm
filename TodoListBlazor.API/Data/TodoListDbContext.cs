using Microsoft.EntityFrameworkCore;
using TodoListBlazor.API.Entities;

namespace TodoListBlazor.API.Data
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Task> Tasks { get; set; }
    }
}
