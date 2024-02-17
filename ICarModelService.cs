namespace CarServiceAPI.Services;

using System.Collections.Generic;
using CarServiceAPI.Models;

public interface ICarModelService
{
    CarModel GetById(string id);
    void Add(CarModel carModel);
    bool Delete(string id);
    List<CarModel> GetAll();
}
