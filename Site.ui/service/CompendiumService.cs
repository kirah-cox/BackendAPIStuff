public class CompendiumService
{
    private readonly HttpClient _http;

    public CompendiumService(HttpClient http) => _http = http;

    // game: "botw" (default) or "totk"
    public async Task<CompendiumEntry?> GetEntryAsync(string idOrName, string game = "botw")
    {
        var key = Uri.EscapeDataString(idOrName.Trim().ToLower());
        var response = await _http.GetAsync($"compendium/entry/{key}?game={game}");

        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<CompendiumEntryResponse>();
        return result?.Data;
    }

    public async Task<List<CompendiumEntry>> GetCategoryAsync(string category, string game = "botw")
    {
        var response = await _http.GetAsync($"compendium/category/{category.Trim().ToLower()}?game={game}");

        if (!response.IsSuccessStatusCode)
            return new List<CompendiumEntry>();

        var result = await response.Content.ReadFromJsonAsync<CompendiumListResponse>();
        return result?.Data ?? new List<CompendiumEntry>();
    }

    public async Task<List<CompendiumEntry>> GetAllAsync(string game = "botw")
    {
        var response = await _http.GetAsync($"compendium/all?game={game}");

        if (!response.IsSuccessStatusCode)
            return new List<CompendiumEntry>();

        var result = await response.Content.ReadFromJsonAsync<CompendiumListResponse>();
        return result?.Data ?? new List<CompendiumEntry>();
    }
}