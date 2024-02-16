using Blazor.Todo.Models;

namespace Blazor.Todo.Pages
{
	public partial class Index
	{
		private List<Assignment> assignments = new List<Assignment>();
		private int nextId = 1;

		private void AddAssignment(Assignment assignment)
		{
			assignment.Id = nextId++;
			assignments.Add(assignment);
			StateHasChanged();
		}		

		private void UpdateAssignment(int id)
		{
			foreach (var assignment in assignments)
			{
                if (assignment.Id == id)
				{
                    assignment.Finished = !assignment.Finished;
                    break;
                }
            }

			StateHasChanged();
		}

		private void DeleteAssignment(int id)
		{
            assignments.RemoveAll(a => a.Id == id);
            StateHasChanged();
        }
	}
}
