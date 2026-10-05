namespace CalculateurAge.Services;

public record AgeResult(int Years, int Months, int Days, int DaysUntilBirthday);

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
        return new AgeResult(y, m, d, (next - today).Days);
    }

    private static DateTime Anniversary(DateTime birth, int year) =>
        new(year, birth.Month, Math.Min(birth.Day, DateTime.DaysInMonth(year, birth.Month)));
}
