using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TasksDBContext _context;

    public HomeController(ILogger<HomeController> logger, TasksDBContext tasksDBContext)
    {
        _logger = logger;
        _context = tasksDBContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Tasks()
    {
        var allTasks = _context.MyTasks.ToList();
        return View(allTasks);
    }
    [HttpPost]
    public ActionResult UpdateTaskCompletion(int id){
        var allTasks = _context.MyTasks.ToList();
        foreach(var task in allTasks){
            if (task.ID == id){
                task.IsComplete = !task.IsComplete;
            }
        }
        _context.SaveChanges();
        return RedirectToAction("Tasks");
    }


    public IActionResult AddTasks()
    {
        return View();
    }
    public IActionResult AddTasksForm(TestingModels Model)
    {
        _context.MyTasks.Add(Model);
        _context.SaveChanges();
        return RedirectToAction("Tasks");
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
