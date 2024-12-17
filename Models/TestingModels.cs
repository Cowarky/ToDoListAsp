using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class TestingModels
    {
        
        public int ID { get; set; } 
        [Required]
        public string? Name { get; set; } 

        public bool IsComplete { get; set; } 

        [Required]
        public string? Description { get; set; } 
    }
}