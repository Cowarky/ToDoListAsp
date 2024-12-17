using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class TasksDBContext : DbContext {
        public DbSet<TestingModels> MyTasks {get; set;}

        public TasksDBContext(DbContextOptions<TasksDBContext> options)
        : base(options)
        {
            
        }
    }
}