using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetPracticeTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetPracticeTodo.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
