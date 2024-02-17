using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

public class CarModel
{
    public required string Id { get; set; } // UUIDs are strings, not integers

    [MakeValidation(ErrorMessage = "Make must be one of these specific car brands: Toyota, Ford, Chevrolet, Honda, Mercedes-Benz, BMW, Audi, Tesla, Nissan, Hyundai")]
    public required string Make { get; set; }

    [JsonProperty("runs_on")]
    [RunsOnValidation(ErrorMessage = "Value for RunsOn must be 'petrol', 'diesel', or 'electric'.")]
    public required string RunsOn { get; set; } // This property holds the fuel type (petrol, diesel, electric)
}

public class MakeValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var allowedMakes = new string[] { "Toyota", "Ford", "Chevrolet", "Honda", "Mercedes-Benz",
                                          "BMW", "Audi", "Tesla", "Nissan", "Hyundai" };
        if (value is string makeValue && allowedMakes.Any(m => m.Equals(makeValue, StringComparison.OrdinalIgnoreCase)))
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult(ErrorMessage);
        }
    }
}

public class RunsOnValidation : ValidationAttribute
{
    public string[] AllowedValues = new string[] { "petrol", "diesel", "electric" };

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string runsOnValue && AllowedValues.Contains(runsOnValue.ToLower()))
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult(ErrorMessage);
        }
    }
}