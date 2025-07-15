using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBaseApp.Models;

/// <summary>
/// מייצג את מודל הנתונים של משתמש באפליקציה.
/// </summary>
public class User
{
	/// <summary>
	/// זיהוי משתמש
	/// </summary>
	public int UserId
	{
		get; set;
	}
	/// <summary>
	/// שם המשתמש לצורך הזדהות.
	/// </summary>
	public string? Username
	{
		get; set;
	}

	/// <summary>
	/// סיסמת המשתמש.
	/// </summary>
	public string? Password
	{
		get; set;
	}
}