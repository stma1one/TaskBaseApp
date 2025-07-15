using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBaseApp.Models;
using TaskBaseApp.Service;

namespace TaskBaseApp.ViewModels;

internal class UserTasksPageViewModel:ViewModelBase
{
	// Add properties, commands, and methods for the UserTasksPage functionality
	#region Fields
	ITaskServices _taskService;// Service for task management
	List<UserTask> userTask; // Represents a user task
	Task loadData { get; set; }// Represents a task for loading data

	ObservableCollection<UserTask> _allUserTasks=new(); // Collection of user tasks for binding to the UI
	ObservableCollection<UserTask> _filteredUserTasks = new(); // Collection of completed user tasks for binding to the UI
	string _searchText = string.Empty; // Search text for filtering tasks
	bool _isLoading = false; // Indicates whether data is currently being loaded
	int userId;
	#endregion


	#region Properties
	public ObservableCollection<UserTask> Tasks{get; set;} 
	public bool IsLoading{
		get => _isLoading;
		set
		{
			if (_isLoading != value)
			{
				_isLoading = value;
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
				FilterTasks(); // Filter tasks when search text changes
			}
		}
	}
	public int UserId
	{
		get => userId;
		set
		{
			if (userId != value)
			{
				userId = value;
				OnPropertyChanged();
			}
		}
	}

	#endregion
	#region Commands
	#endregion
	#region Constructor
	public UserTasksPageViewModel(ITaskServices services)
	{
		// Initialize properties or commands here if needed
		_taskService = services;
		Tasks = new();
		LoadUserTasksAsync().ConfigureAwait(false);
	}
	#endregion

	#region Methods
	private void FilterTasks()
	{
		throw new NotImplementedException();
	}
	/// <summary>
	/// Loads user tasks from the service.
	/// </summary>
	public async Task LoadUserTasksAsync()
	{
		IsLoading = true;
		try
		{
			userTask = await _taskService.GetTasks(UserId); // Assuming 1 is the user ID
			if (userTask != null && userTask.Count > 0)
			{
				foreach (var task in userTask)
				{
					_allUserTasks.Add(task);
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error loading tasks: {ex.Message}");
		}
		finally
		{
			IsLoading = false;
		}
	}
	#endregion
}
