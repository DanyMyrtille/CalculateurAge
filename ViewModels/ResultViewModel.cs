using System.Windows.Input;
using CalculateurAge.Services;

namespace CalculateurAge.ViewModels;

// Reçoit les paramètres de navigation via IQueryAttributable
public class ResultViewModel : BaseViewModel, IQueryAttributable
{
    private string _hello = "", _summary = "", _nextBirthday = "", _details = "";

    public string Hello { get => _hello; set => Set(ref _hello, value); }
    public string Summary { get => _summary; set => Set(ref _summary, value); }
    public string NextBirthday { get => _nextBirthday; set => Set(ref _nextBirthday, value); }
    public string Details { get => _details; set => Set(ref _details, value); }

    public ICommand ShareCommand { get; }

    public ResultViewModel() => ShareCommand = new Command(async () =>
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Title = "Mon âge",
            Text = $"{Hello} J'ai {Summary}. {NextBirthday}"
        }));

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var name = (string)query["name"];
        var birth = (DateTime)query["birth"];
        var r = AgeCalculator.Compute(birth, DateTime.Today);
        Hello = $"Bonjour {name} !";
        Summary = $"{r.Years} an(s), {r.Months} mois, {r.Days} jour(s)";
        NextBirthday = r.DaysUntilBirthday == 0
            ? "🎉 Joyeux anniversaire !"
            : $"Prochain anniversaire dans {r.DaysUntilBirthday} jour(s)";
        Details = $"Jours vécus : {r.TotalDays:N0}\nNé(e) un {r.BirthWeekday}\nSigne : {r.Zodiac}";
    }
}