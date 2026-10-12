using System.Text.Json.Serialization;

// Single entry endpoint: { "data": { ... } }
public class CompendiumEntryResponse
{
    [JsonPropertyName("data")] public CompendiumEntry? Data { get; set; }
}

// Category and all endpoints: { "data": [ ... ] }
public class CompendiumListResponse
{
    [JsonPropertyName("data")] public List<CompendiumEntry> Data { get; set; } = new();
}

public class CompendiumEntry
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; } = "";
    [JsonPropertyName("category")] public string Category { get; set; } = "";
    [JsonPropertyName("description")] public string Description { get; set; } = "";
    [JsonPropertyName("image")] public string? Image { get; set; }

    [JsonPropertyName("common_locations")] public List<string>? CommonLocations { get; set; }
    [JsonPropertyName("drops")] public List<string>? Drops { get; set; }

    // Category-specific fields (null when they don't apply)
    [JsonPropertyName("cooking_effect")] public string? CookingEffect { get; set; }
    [JsonPropertyName("hearts_recovered")] public double? HeartsRecovered { get; set; }
    [JsonPropertyName("properties")] public EquipmentProperties? Properties { get; set; }
    [JsonPropertyName("dlc")] public bool? Dlc { get; set; }
}

public class EquipmentProperties
{
    [JsonPropertyName("attack")] public int? Attack { get; set; }
    [JsonPropertyName("defense")] public int? Defense { get; set; }
}