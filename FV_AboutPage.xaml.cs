namespace F.V_Apuntes;

public partial class FV_AboutPage : ContentPage
{
	public FV_AboutPage()
	{
		InitializeComponent();
	}

	private async void FV_LearnMore_Clicked(object sender, EventArgs e)
	{
		await Launcher.Default.OpenAsync("https://aka.ms/maui");
	}
}