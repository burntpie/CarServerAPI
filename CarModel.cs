using Newtonsoft.Json;

public class CarModel
{
    public required string Id { get; set; } // UUIDs are strings, not integers
    public required string Make { get; set; }

    [JsonProperty("runs_on")]
    public required string RunsOn { get; set; } // This property holds the fuel type (petrol, diesel, electric)
}

