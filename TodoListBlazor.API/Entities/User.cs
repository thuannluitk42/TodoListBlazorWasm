using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TodoListBlazor.API.Entities
{
    public class User:IdentityUser<Guid>
    {
        [MaxLength(250)]
        [Required]
        public string FirstName { set; get; }

        [MaxLength(250)]
        [Required]
        public string LastName { set; get; }

    }
}
