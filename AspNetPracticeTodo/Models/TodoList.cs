using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetPracticeTodo.Models
{
    public class TodoList
    {
        public int TodoListId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<TodoItem> TodoItems { get; set; }
    }
}
