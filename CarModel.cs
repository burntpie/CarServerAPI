public class CarModel
{
    public string Id { get; set; } // UUIDs are strings, not integers
    public string Make { get; set; }
    public string RunsOn { get; set; } // This property holds the fuel type (petrol, diesel, electric)
}

