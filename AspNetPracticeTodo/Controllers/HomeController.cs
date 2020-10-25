using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetPracticeTodo.Models;
using AspNetPracticeTodo.Data;

namespace AspNetPracticeTodo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TodoDbContext _db;

        public HomeController(ILogger<HomeController> logger, TodoDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var lists = _db.TodoLists.ToList();
            return View(lists);
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

            return RedirectToAction("Index");
        }

        public IActionResult EditList(int id)
        {
            var todoList = _db.TodoLists
                .Where(list => list.TodoListId == id)
                .FirstOrDefault();

            return View(todoList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
