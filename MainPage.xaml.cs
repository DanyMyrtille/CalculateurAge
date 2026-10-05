namespace CalculateurAge;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BirthPicker.MaximumDate = DateTime.Today;
        BirthPicker.Date = new DateTime(2000, 1, 1);
    }

    // Phase B : navigation vers la 2e page avec deux paramètres (nom, date)
    private async void OnCalculate(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Champ requis", "Veuillez saisir votre nom.", "OK");
            return;
        }
        var parameters = new Dictionary<string, object>
        {
            ["name"] = NameEntry.Text.Trim(),
            ["birth"] = BirthPicker.Date
        };
        await Shell.Current.GoToAsync(nameof(ResultPage), parameters);
    }
}
