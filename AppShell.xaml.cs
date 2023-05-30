namespace F.V_Apuntes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Views.FV_NotePage), typeof(Views.FV_NotePage));
	}
}
