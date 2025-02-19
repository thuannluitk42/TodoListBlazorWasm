using Microsoft.AspNetCore.Identity;
using TodoListBlazor.API.Entities;
using TodoListBlazor.API.Enums;
using Task = System.Threading.Tasks.Task;


namespace TodoListBlazor.API.Data
{
    public class TodoListDbContextSeed
    {

        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public async Task SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin1@gmail.com",
                    PhoneNumber = "032132131",
                    UserName = "admin"
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, password: "Admin@123$");
                context.Users.Add(user);
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.Add(entity: new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Same tasks 1",
                    CreatedDate = DateTime.Now,
                    Priority =  Priority.High,
                    Status =  Status.Open
                });
            
            }
            await context.SaveChangesAsync();
        } 
    }
}
