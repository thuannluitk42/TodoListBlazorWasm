using System.ComponentModel.DataAnnotations;
using TodoListBlazor.API.Enums;

namespace TodoList.Models
{
    public class TaskCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
        public Priority Priority { get; set; }
        public Guid? AssigneeId { get; set; }
    }
}
