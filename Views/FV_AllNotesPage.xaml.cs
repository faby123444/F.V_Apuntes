using F.V_Apuntes.Models;
using Microsoft.Maui.Controls;

namespace F.V_Apuntes.Views;

public partial class FV_AllNotesPage : ContentPage
{
	public FV_AllNotesPage()
	{
		InitializeComponent();

		BindingContext = new Models.FV_AllNotes();
	}
	protected override void OnAppearing()
	{
		((Models.FV_AllNotes)BindingContext).LoadNotes();
	}
	private async void FV_Add_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(FV_NotePage));
	}

	private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.Count != 0)
		{
			// Get the note model
			var note = (Models.FV_Note)e.CurrentSelection[0];

			// Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
			await Shell.Current.GoToAsync($"{nameof(FV_NotePage)}?{nameof(FV_NotePage.ItemId)}={note.Filename}");

			// Unselect the UI
			notesCollection.SelectedItem = null;
		}
	}

}