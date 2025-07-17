using TaskBaseApp.Views;

namespace TaskBaseApp
{
    public partial class App : Application
    {
		IServiceProvider? provider;
		Page? firstpage;
		public App(IServiceProvider provider)
		{
			InitializeComponent();
			this.provider = provider;
		
			firstpage = provider?.GetService<UserTasksPage>();
			
		}

		protected override Window CreateWindow(IActivationState? activationState)
		{
			// return new Window(new AppShell());
			return new Window(firstpage);
		}
	}
}