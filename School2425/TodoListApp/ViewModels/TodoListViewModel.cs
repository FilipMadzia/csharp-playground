using System.Collections.ObjectModel;
using TodoListApp.Models;

namespace TodoListApp.ViewModels;

public class TodoListViewModel
{
	public ObservableCollection<TodoListItem> TodoList { get; set; } = [
		new() { Title = "Zadanie fizyka", IsCompleted = false },
		new() { Title = "Zakupy", IsCompleted = false },
		new() { Title = "Projekt programowanie", IsCompleted = true } ];
}
