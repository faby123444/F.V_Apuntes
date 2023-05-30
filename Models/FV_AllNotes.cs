using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F.V_Apuntes.Models
{
    internal class FV_AllNotes
    {

		public ObservableCollection<FV_Note> Notes { get; set; } = new ObservableCollection<FV_Note>();

	public FV_AllNotes() =>
		LoadNotes();

	public void LoadNotes()
	{
		Notes.Clear();

		// Get the folder where the notes are stored.
		string appDataPath = FileSystem.AppDataDirectory;

		// Use Linq extensions to load the *.notes.txt files.
		IEnumerable<FV_Note> notes = Directory

									// Select the file names from the directory
									.EnumerateFiles(appDataPath, "*.notes.txt")

									// Each file name is used to create a new Note
									.Select(filename => new FV_Note()
									{
										Filename = filename,
										Text = File.ReadAllText(filename),
										Date = File.GetCreationTime(filename)
									})

									// With the final collection of notes, order them by date
									.OrderBy(note => note.Date);

		// Add each note into the ObservableCollection
		foreach (FV_Note note in notes)
			Notes.Add(note);
	}
		}

}
