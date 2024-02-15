using System.ComponentModel.DataAnnotations;

namespace Blazor.Todo.Models
{
	public class Assignment
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        public bool Finished { get; set; }
    }
}
