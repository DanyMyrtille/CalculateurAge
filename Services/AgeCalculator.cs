using System.Globalization;

namespace CalculateurAge.Services;

public record AgeResult(int Years, int Months, int Days, int DaysUntilBirthday,
    int TotalDays, string BirthWeekday, string Zodiac);

public static class AgeCalculator
{
    public static AgeResult Compute(DateTime birth, DateTime today)
    {
        birth = birth.Date; today = today.Date;
        if (birth > today) throw new ArgumentException("La date de naissance ne peut pas être dans le futur.");

        int y = today.Year - birth.Year, m = today.Month - birth.Month, d = today.Day - birth.Day;
        if (d < 0)
        {
            m--;
            var prev = today.AddMonths(-1);
            d += DateTime.DaysInMonth(prev.Year, prev.Month);
        }
        if (m < 0) { y--; m += 12; }

        var next = Anniversary(birth, today.Year);
        if (next < today) next = Anniversary(birth, today.Year + 1);
        return new AgeResult(y, m, d, (next - today).Days,
            (today - birth).Days,
            CultureInfo.GetCultureInfo("fr-FR").DateTimeFormat.GetDayName(birth.DayOfWeek),
            Zodiac(birth.Month, birth.Day));
    }

    private static DateTime Anniversary(DateTime birth, int year) =>
        new(year, birth.Month, Math.Min(birth.Day, DateTime.DaysInMonth(year, birth.Month)));

    private static string Zodiac(int m, int d) => (m, d) switch
    {
        (1, <= 19) or (12, >= 22) => "Capricorne",
        (1, _) or (2, <= 18) => "Verseau",
        (2, _) or (3, <= 20) => "Poissons",
        (3, _) or (4, <= 19) => "Bélier",
        (4, _) or (5, <= 20) => "Taureau",
        (5, _) or (6, <= 20) => "Gémeaux",
        (6, _) or (7, <= 22) => "Cancer",
        (7, _) or (8, <= 22) => "Lion",
        (8, _) or (9, <= 22) => "Vierge",
        (9, _) or (10, <= 22) => "Balance",
        (10, _) or (11, <= 21) => "Scorpion",
        _ => "Sagittaire"
    };
}
