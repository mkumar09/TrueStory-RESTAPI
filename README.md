# RestApi

Steps to run the project locally :

Open a terminal and execute the following commands :

1. cd RestApi
2. docker compose up --build

The application will spin up as localhost:8080


API endpoints exposed :

1. GET /product</br>
  Query Params: </br>
  search</br>
                 page</br>
                 pageSize</br>
                 
Sample API Request:  http://localhost:8080/product?search=Apple&page=3&pageSize=2</br> 
Sample API Response: 
      [
  {
    "id": "7",
    "name": "Apple MacBook Pro 16",
    "data": {
      "year": 2019,
      "price": 1849.99,
      "CPU model": "Intel Core i9",
      "Hard disk size": "1 TB"
    }
  },
  {
    "id": "8",
    "name": "Apple Watch Series 8",
    "data": {
      "Strap Colour": "Elderberry",
      "Case Size": "41mm"
    }
  }
]
</br>
</br>
2. POST /product</br>
  Sample API call: http//localhost:8080/product</br>
   Request Body : 
    {
   "name": "Apple MacBook Pro 29",
   "data": {
    "year" : 2023,
    "price" : 249.99,
      "cpu model" : "intel core i9",
      "Hard disk size": "1 TB"
   }
}</br>

Sample API Response:
{
  "id": "ff808181932badb60196eee71a785026",
  "name": "Apple MacBook Pro 29",
  "data": {
    "year": 2023,
    "price": 249.99,
    "cpu model": "intel core i9",
    "Hard disk size": "1 TB"
  }
}</br></br>

3. DELETE /product/{id}</br>
  Sample API call : http//localhost:8080/product/ff808181932badb60196eee71a785026</br>

  Sample API response : 
  {
  "message": "Object with id = ff808181932badb60196eee71a785026 has been deleted.",
  "error": null
  }

Notes about the project :

1. Whenever an API call to add the request is made, the product to be added is validated using a validator.
2. The Validator is created by the ProductValidatorFactory.cs class.
3. Since the product category label has not been mentioned/available by the restful-api.dev team, I have written my own logic to determine the category.
4. Category is determined based on keywords found in the name of the product.
5. The keywords that the application looks for in the request are present in the Constants.cs file.
6. There's a validator for each product category type, which can be extended if more categories are added.
7. Special care has been taken to enhance extensibility and maintainability if more categories of products are added.
8. OOAD and Factory Design Pattern are used in the Project.
9. Necessary Exception Handling is added wherever required.
10. Appropriate Status Codes are returned for all the endpoints in case of a Bad Request or a 404 Not Found.
11. REST API naming conventions have been followed
   
