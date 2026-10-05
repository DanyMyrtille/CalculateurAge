using System.Text.Json;

namespace CalculateurAge.Services;

public static class HistoryService
{
    private const string Key = "history";

    public static List<string> Load()
    {
        var json = Preferences.Default.Get(Key, "");
        return string.IsNullOrEmpty(json) ? new() : JsonSerializer.Deserialize<List<string>>(json) ?? new();
    }

    public static void Save(IEnumerable<string> items) =>
        Preferences.Default.Set(Key, JsonSerializer.Serialize(items));
}
