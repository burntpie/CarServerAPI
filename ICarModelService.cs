using System.Collections.Generic;

public interface ICarModelService
{
    CarModel GetById(string id);
    void Add(CarModel carModel);
    bool Delete(string id);
    List<CarModel> GetAll();
}
