using Blazor.Todo.Models;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.Todo.Pages.Components
{
	public partial class AssignmentForm
	{
		private bool formInvalid = true;
        private EditContext? _editContext;
        public Assignment Assignment { get; set; } = new Assignment();
		[Parameter] public EventCallback<Assignment> HandleAddAssignment { get; set; }
        [Inject] protected ToastService ToastService { get; set; } = default!;

        protected override void OnInitialized()
        {
            _editContext = new EditContext(Assignment);
            _editContext.OnFieldChanged += HandleFieldChanged;
        }

        private void OnValidSubmit()
		{
			if (HandleAddAssignment.HasDelegate)
			{
				HandleAddAssignment.InvokeAsync(Assignment);
				Assignment = new Assignment();
                ToastService.Notify(new(ToastType.Success, $"Assignment was added successfully"));
            }
		}

        private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            formInvalid = (bool)!_editContext?.Validate()!;
            StateHasChanged();
        }
    }
}
