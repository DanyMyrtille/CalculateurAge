using CalculateurAge.Services;

namespace CalculateurAge;

// Réception des paramètres de navigation via QueryProperty
[QueryProperty(nameof(UserName), "name")]
[QueryProperty(nameof(Birth), "birth")]
public partial class ResultPage : ContentPage
{
    private string _name = "";
    private DateTime _birth;

    public string UserName { get => _name; set { _name = value; Refresh(); } }
    public DateTime Birth { get => _birth; set { _birth = value; Refresh(); } }

    public ResultPage() => InitializeComponent();

    private void Refresh()
    {
        if (_birth == default) return;
        var r = AgeCalculator.Compute(_birth, DateTime.Today);
        HelloLabel.Text = $"Bonjour {_name} !";
        SummaryLabel.Text = $"{r.Years} an(s), {r.Months} mois, {r.Days} jour(s)";
        NextLabel.Text = r.DaysUntilBirthday == 0
            ? "🎉 Joyeux anniversaire !"
            : $"Prochain anniversaire dans {r.DaysUntilBirthday} jour(s)";
    }
}
