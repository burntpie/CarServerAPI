namespace CarServiceAPI.Services;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using CarServiceAPI.Models;

public class CarModelService : ICarModelService
{
    private readonly List<CarModel> _carModels;

    public CarModelService()
    {
        // Load the car models from the data.json file
        string jsonFilePath = "data.json";
        string json = File.ReadAllText(jsonFilePath);
        _carModels = JsonConvert.DeserializeObject<List<CarModel>>(json);
    }

    public CarModel GetById(string id) => _carModels.FirstOrDefault(cm => cm.Id == id);

    public void Add(CarModel carModel)
    {
        _carModels.Add(carModel);
    }

    public bool Delete(string id)
    {
        var carModel = GetById(id);
        if (carModel == null) return false;
        _carModels.Remove(carModel);
        return true;
    }

    public List<CarModel> GetAll() => _carModels;
}
