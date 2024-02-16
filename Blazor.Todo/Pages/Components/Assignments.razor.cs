using Blazor.Todo.Models;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Blazor.Todo.Pages.Components
{
    public partial class Assignments
    {
        [Parameter] public List<Assignment> AssignmentsList { get; set; } = new List<Assignment>();
        [Parameter] public EventCallback<int> HandleUpdateAssignment { get; set; }
        [Parameter] public EventCallback<int> HandleDeleteAssignment { get; set; }
        private ConfirmDialog dialog = default!;

        private void UpdateAssignmentStatus(int id)
        {
            var assignment = AssignmentsList.FirstOrDefault(a => a.Id == id);
            if (assignment != null && !assignment.Finished)
                if (HandleUpdateAssignment.HasDelegate)
                    HandleUpdateAssignment.InvokeAsync(id);
        }

        private async Task DeleteAssignment(int id)
        {
            var confirmation = await dialog.ShowAsync(
            title: "Are you sure you want to delete this?",
            message1: "This will delete the record. Once deleted can not be rolled back.");

            if (confirmation && HandleDeleteAssignment.HasDelegate)
                await HandleDeleteAssignment.InvokeAsync(id);
        }
    }
}
