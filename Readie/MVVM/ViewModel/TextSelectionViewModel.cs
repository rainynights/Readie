using Readie.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readie.MVVM.ViewModel;
public class TextSelectionViewModel : ViewModelBase
{
    public Command SelectCommand { get; }
    public Text[] Texts { get; }

    public TextSelectionViewModel()
    {
        SelectCommand = new Command<Text>(Select);

        // TODO geçici bu
        Texts = new Text[] { new Text { Pages = new string[] { "Bir iki üç, dört beş; \n", "altı yedi sekiz dokuz on." }, Title = "Deneme" } };
        OnPropertyChanged(nameof(Texts));
    }

    private void Select(Text selectedText)
    {
        Shell.Current.GoToAsync("Preperation", parameters: new Dictionary<string, object>
        {
            {"SelectedText", selectedText }
        });
    }
}
