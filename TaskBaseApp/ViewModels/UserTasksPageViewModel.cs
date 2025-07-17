
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskBaseApp.Models;
using TaskBaseApp.Service;

namespace TaskBaseApp.ViewModels;

public class UserTasksPageViewModel:ViewModelBase
{
	#region Fields
	ITaskServices _service;
	List<UserTask> _allTasks = new();
	Task loadDataTask;
	string _searchText;
	bool _hasError=false;
	#endregion

	#region

	public ObservableCollection<UserTask> AllTasks
	{
		get;set;
	}
	public bool HasError
	{
		get => _hasError;
		set
		{
			if (_hasError != value)
			{
				_hasError = value;
				OnPropertyChanged();
			}
		}
	}

	public string SearchText
	{
		get => _searchText;
		set
		{
			if (_searchText != value)
			{
				_searchText = value;
				OnPropertyChanged();
				// Update the command state when SearchText changes
				(ClearFilterCommand as Command)?.ChangeCanExecute();
			}
		}
	}
	#endregion

	#region Commands
	// Define commands for user interactions, e.g., search, add task, etc.

	public ICommand DeleteTaskCommand
	{
		get;
	}
	public ICommand SearchCommand
	{
		get;
	}
	public ICommand ClearFilterCommand
	{
		get;
	}

	public ICommand LoadDataCommand
	{
		get;
	}
	#endregion

	public  UserTasksPageViewModel(ITaskServices service)
	{
		_service = service;
		// Initialize properties or commands here if needed
		SearchCommand = new Command(OnSearch);
		ClearFilterCommand = new Command(ClearFilter, () => string.IsNullOrEmpty(SearchText));
		LoadDataCommand = new Command(async () => await GetTasksAsync(1));
		// Load all tasks from the service
		loadDataTask = GetTasksAsync(1);
		DeleteTaskCommand = new Command<UserTask>(DeleteTask);
		AllTasks = new ();
	}

	private void DeleteTask(UserTask task)
	{
		if (task == null) return; // Ensure task is not null
		AllTasks.Remove(task);
	}

	private async Task? GetTasksAsync(int userId)
	{
		IsBusy = true;
		try
		{
			_allTasks = await _service.GetTasks(userId);
			// Clear the existing collection and add the new tasks
			AllTasks.Clear();
			foreach (var task in _allTasks)
			{
				AllTasks.Add(task);
			}
			IsBusy = false;
		}
		catch (Exception ex)
		{
			HasError= true; // Set error state if an exception occurs	
							 // Handle exceptions, e.g., log the error or show a message to the user
			Console.WriteLine($"Error loading tasks: {ex.Message}");
		}
		finally
		{
			loadDataTask = null; // Reset the task after loading
			OnPropertyChanged(nameof(_allTasks)); // Notify that tasks have been loaded
			IsBusy = false;
		}
	}

	private void ClearFilter()
	{
		throw new NotImplementedException();
	}

	private void OnSearch()
	{
		throw new NotImplementedException();
	}
	// Add properties, commands, and methods for the UserTasksPage functionality
}

