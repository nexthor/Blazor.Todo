using Blazor.Todo.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Todo.Pages.Components
{
    public partial class Assignments
    {
        [Parameter]
        public List<Assignment> AssignmentsList { get; set; } = new List<Assignment>();
        [Parameter]
        public EventCallback<int> HandleUpdateAssignment { get; set; }

        private void UpdateAssignmentStatus(int id)
        {
            if (HandleUpdateAssignment.HasDelegate)
                HandleUpdateAssignment.InvokeAsync(id);
        }
    }
}
