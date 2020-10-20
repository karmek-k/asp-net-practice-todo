using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetPracticeTodo.Models
{
    public class TodoItem
    {
        public int TodoItemId { get; set; }

        [Required]
        public string Name { get; set; }
        public bool Done { get; set; }

        public int TodoListId { get; set; }
        public TodoList TodoList { get; set; }
    }
}
