using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListBlazor.API.Enums;

namespace TodoList.Models
{
    public class TaskUpdateRequest
    {
        public string Name { get; set; }
        public Priority Priority { get; set; }
    }
}
