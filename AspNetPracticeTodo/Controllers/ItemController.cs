using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetPracticeTodo.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspNetPracticeTodo.Controllers
{
    public class ItemController : Controller
    {
        private readonly TodoDbContext _db;

        public ItemController(TodoDbContext db)
        {
            _db = db;
        }
    }
}
