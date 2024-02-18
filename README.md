# CarServerAPI
- Backend RESTful API for managing a set of cars with unique UUIDs
- It is built using ASP.NET Core 8.002 and deployed on cloud using AWS Elastic Beanstalk
- No database is used, the data is stored in memory
- 'data.json' file is used to store the data in JSON format

## API Endpoints
### Get All Car Models
- URL: /api/carmodels
- Method: GET
- Description: Retrieves a list of all car models.
- Response: A list of car models.

### Get Car Model by ID
- URL: /api/carmodels/{id}
- Method: GET
- Description: Retrieves a specific car model by its ID.
- URL Parameters: id=[string] where id is the ID of the car model.
- Response: A single car model.

### Create a New Car Model
- URL: /api/carmodels
- Method: POST
- Description: Adds a new car model to the collection.
- Data Parameters:
```
{
  "Id": "string",
  "Make": "string",
  "RunsOn": "string"
}
```
- Make must be one of the specified brands: Toyota, Ford, Chevrolet, Honda, Mercedes-Benz, BMW, Audi, Tesla, Nissan, Hyundai.
- RunsOn must be either 'petrol', 'diesel', or 'electric'.
- Response: The created car model.

### Delete a Car Model
- URL: /carmodels/{id}
- Method: DELETE
- Description: Deletes a car model by its ID.
- URL Parameters: id=[string] where id is the ID of the car model to delete.
- Response: A status code indicating success or failure.

## Examples

### Get All Car Models
```
GET /api/carmodels HTTP/1.1
Host: localhost:7271
```

### Create a New Car Model
```
POST /api/carmodels HTTP/1.1
Host: localhost:7271
Content-Type: application/json

{
  "Id": "new-id",
  "Make": "Toyota",
  "RunsOn": "petrol"
}
```