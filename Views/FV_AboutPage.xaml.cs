namespace F.V_Apuntes.Views;

public partial class FV_AboutPage : ContentPage
{
	public FV_AboutPage()
	{
		InitializeComponent();
	}

	private async void FV_LearnMore_Clicked(object sender, EventArgs e)
	{
		if (BindingContext is Models.FV_About about)
		{
			// Navigate to the specified URL in the system browser.
			await Launcher.Default.OpenAsync(about.MoreInfoUrl);
		}
	}
}