using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetPracticeTodo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetPracticeTodo.Models;

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
                .Include("TodoItems")
                .Where(list => list.TodoListId == id)
                .FirstOrDefault();

            ViewData["Title"] = todoList.Name;
            ViewData["TodoListDesc"] = todoList.Description ?? "No description";

            if (todoList == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var todoItems = todoList.TodoItems.ToList();

            return View(todoItems);
        }

        public IActionResult CreateList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateList(TodoList list)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _db.TodoLists.Add(list);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult EditList(int id)
        {
            var todoList = _db.TodoLists
                .Where(list => list.TodoListId == id)
                .FirstOrDefault();

            return View(todoList);
        }

        [HttpPost]
        public IActionResult EditList(TodoList newList)
        {
            if (!ModelState.IsValid)
            {
                return View(newList);
            }

            _db.TodoLists.Update(newList);
            _db.SaveChanges();

            return RedirectToAction("Index", "List", new { id = newList.TodoListId });
        }

        public IActionResult DeleteList(int id, bool confirmed = false)
        {
            var todoList = _db.TodoLists
                .Where(list => list.TodoListId == id)
                .FirstOrDefault();

            if (!confirmed)
            {
                return View(todoList);
            }

            _db.Remove(todoList);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
