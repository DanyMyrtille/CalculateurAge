using System.Collections.ObjectModel;
using System.Windows.Input;
using CalculateurAge.Services;

namespace CalculateurAge.ViewModels;

public class MainViewModel : BaseViewModel
{
    private string _name = "", _error = "";
    private DateTime _birthDate = new(2000, 1, 1);

    public DateTime Today => DateTime.Today;
    public string Name { get => _name; set => Set(ref _name, value); }
    public DateTime BirthDate { get => _birthDate; set => Set(ref _birthDate, value); }
    public string Error { get => _error; set => Set(ref _error, value); }
    public ICommand CalculateCommand { get; }
    public ICommand ClearHistoryCommand { get; }
    public ObservableCollection<string> History { get; }

    public MainViewModel()
    {
        History = new ObservableCollection<string>(HistoryService.Load());
        CalculateCommand = new Command(async () => await CalculateAsync());
        ClearHistoryCommand = new Command(() => { History.Clear(); HistoryService.Save(History); });
    }

    private async Task CalculateAsync()
    {
        if (string.IsNullOrWhiteSpace(Name)) { Error = "Veuillez saisir votre nom."; return; }
        Error = "";
        History.Insert(0, $"{Name.Trim()} — {BirthDate:dd/MM/yyyy}");
        while (History.Count > 20) History.RemoveAt(History.Count - 1);
        HistoryService.Save(History);
        await Shell.Current.GoToAsync(nameof(ResultPage), new Dictionary<string, object>
        {
            ["name"] = Name.Trim(),
            ["birth"] = BirthDate
        });
    }
}
