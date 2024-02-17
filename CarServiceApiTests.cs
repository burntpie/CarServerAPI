using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using CarServiceAPI.Models;
using CarServiceAPI;

public class CarServiceApiTests : IClassFixture<CustomWebApplicationFactory<CarServiceAPI.ProgramMarkerClass>>
{
    private readonly HttpClient _client;

    public CarServiceApiTests(CustomWebApplicationFactory<CarServiceAPI.ProgramMarkerClass> factory)
    {
        _client = factory.WithWebHostBuilder(builder =>
        {
            // Here you can modify the builder if necessary, for example, to add test-specific services or configuration
        }).CreateClient();
    }

    [Fact]
    public async Task GetCarModel_ReturnsNotFound_WhenCarModelDoesNotExist()
    {
        var nonExistingId = "non-existing-id";
        var response = await _client.GetAsync($"/api/carmodels/{nonExistingId}");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task PostCarModel_AddsNewCarModel()
    {
        var newCarModel = new CarModel { Id = "new-id", Make = "Toyota", RunsOn = "petrol" };
        var content = new StringContent(JsonConvert.SerializeObject(newCarModel), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/carmodels", content);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var returnedCarModel = JsonConvert.DeserializeObject<CarModel>(responseString);
        Assert.Equal("Toyota", returnedCarModel.Make);
    }

    [Fact]
    public async Task GetAllCarModels_ReturnsSuccess_WithCarModels()
    {
        // Act
        var response = await _client.GetAsync("/api/carmodels");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var responseString = await response.Content.ReadAsStringAsync();
        var carModels = JsonConvert.DeserializeObject<List<CarModel>>(responseString);

        Assert.NotNull(carModels);
        Assert.True(carModels.Count > 0); // Assuming there are car models in your test setup
                                          // Optionally, further assert on the contents of carModels to match expected values
    }

    [Fact]
    public async Task DeleteCarModel_ReturnsNoContent_WhenCarModelExists()
    {
        // Arrange
        var existingId = "64f9a012-ce06-4686-a9a8-4e7cea9c753d"; // Existing ID which is deletable

        // Act
        var response = await _client.DeleteAsync($"/api/carmodels/{existingId}");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);

        // Further verify that the car model is indeed deleted, by attempting to fetch it
        var fetchResponse = await _client.GetAsync($"/api/carmodels/{existingId}");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, fetchResponse.StatusCode);
    }

}
