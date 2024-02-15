using Blazor.Todo.Models;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.Todo.Pages.Components
{
	public partial class AssignmentForm
	{
		private bool formInvalid = true;
		public Assignment Assignment { get; set; } = new Assignment();
		[Parameter] public EventCallback<Assignment> HandleAddAssignment { get; set; }
        [Inject] protected ToastService ToastService { get; set; } = default!;

        private void OnValidSubmit()
		{
			if (HandleAddAssignment.HasDelegate)
			{
				HandleAddAssignment.InvokeAsync(Assignment);
				Assignment = new Assignment();
                ToastService.Notify(new(ToastType.Success, $"Assignment was added successfully"));
            }
		}
    }
}
