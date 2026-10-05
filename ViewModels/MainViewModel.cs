using System.Windows.Input;

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

    public MainViewModel() => CalculateCommand = new Command(async () => await CalculateAsync());

    private async Task CalculateAsync()
    {
        if (string.IsNullOrWhiteSpace(Name)) { Error = "Veuillez saisir votre nom."; return; }
        Error = "";
        await Shell.Current.GoToAsync(nameof(ResultPage), new Dictionary<string, object>
        {
            ["name"] = Name.Trim(),
            ["birth"] = BirthDate
        });
    }
}
