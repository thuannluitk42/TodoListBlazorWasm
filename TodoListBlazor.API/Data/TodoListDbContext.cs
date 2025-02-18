using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoListBlazor.API.Entities;

namespace TodoListBlazor.API.Data
{
    public class TodoListDbContext : IdentityDbContext<User, Role, Guid>
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Task> Tasks { get; set; }
    }
}
