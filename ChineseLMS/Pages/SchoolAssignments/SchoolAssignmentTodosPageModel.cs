using ChineseLMS.Data;
using ChineseLMS.Models;
using ChineseLMS.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ChineseLMS.Pages.SchoolAssignments
{
	public class SchoolAssignmentTodosPageModel : PageModel
	{
        public List<Todo> AssignmentTodoList;

        public void PopulateAssignmentTodo(SchoolContext context,
                                               SchoolAssignment schoolassignment)
        {
            var allTodos= context.Todos;
            var assignmentTodos = new HashSet<int>(
                schoolassignment.Todos.Select(c => c.ID));
            AssignmentTodoList = new List<Todo>();
            foreach (var todo in allTodos)
            {
                AssignmentTodoList.Add(new Todo
                {
                    ID = todo.ID,
                    TodoName = todo.TodoName,
                    Checked = todo.Checked,
                    ByTeacher = todo.ByTeacher
                    //Assigned = assignmentTodos.Contains(todo.ID)
                });
            }
        }
    }
}



