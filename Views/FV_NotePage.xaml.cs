namespace F.V_Apuntes.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class FV_NotePage : ContentPage
{
	string _fileName = Path.Combine(FileSystem.AppDataDirectory, "FV_notes.txt");
	public FV_NotePage(string itemId)
	{

		InitializeComponent();
		string appDataPath = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

		LoadNote(Path.Combine(appDataPath, randomFileName));
		if (!string.IsNullOrEmpty(itemId))
		{
			LoadNote(itemId);
		}
	}

	internal static object ItemId()
	{
		throw new NotImplementedException();
	}

	private async void FV_SaveButton_Clicked(object sender, EventArgs e)
	{
		if (BindingContext is Models.FV_Note note)
		{
			File.WriteAllText(note.Filename, note.Text);
		}

		await Shell.Current.GoToAsync("..");
	}

	private async void FV_DeleteButton_Clicked(object sender, EventArgs e)
	{
		if (BindingContext is Models.FV_Note note)
		{
			// Delete the file.
			if (File.Exists(note.Filename))
			{
				File.Delete(note.Filename);
			}
		}

		await Shell.Current.GoToAsync("..");
	}

	private void LoadNote(string fileName)
	{
		Models.FV_Note noteModel = new Models.FV_Note();
		noteModel.Filename = fileName;

		if (File.Exists(fileName))
		{
			noteModel.Date = File.GetCreationTime(fileName);
			noteModel.Text = File.ReadAllText(fileName);
		}

		BindingContext = noteModel;
	}


}