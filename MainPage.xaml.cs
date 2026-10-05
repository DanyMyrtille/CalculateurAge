using CalculateurAge.Services;

namespace CalculateurAge;

// Phase A : tout est géré en code-behind
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BirthPicker.MaximumDate = DateTime.Today;
        BirthPicker.Date = new DateTime(2000, 1, 1);
    }

    private void OnCalculate(object? sender, EventArgs e)
    {
        var r = AgeCalculator.Compute(BirthPicker.Date, DateTime.Today);
        ResultLabel.Text = $"{r.Years} an(s), {r.Months} mois, {r.Days} jour(s)";
        NextLabel.Text = r.DaysUntilBirthday == 0
            ? "🎉 Joyeux anniversaire !"
            : $"Prochain anniversaire dans {r.DaysUntilBirthday} jour(s)";
    }
}
