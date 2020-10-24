﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetPracticeTodo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetPracticeTodo.Controllers
{
    public class ListController : Controller
    {
        private readonly TodoDbContext _db;

        public ListController(TodoDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {
            var todoList = _db.TodoLists
                .Include("TodoItems")  // TODO: remove if not needed
                .Where(list => list.TodoListId == id)
                .FirstOrDefault();

            if (todoList == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(todoList);
        }
    }
}
