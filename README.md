# CSharp Rest API

It was built for study purpose, some parts can appear incompleted, but it's only a start.
Everything here could be improved :) always look for that.

This API expose endpoints for Customers and Orders. 

*	Return a list of customers, without orders;
*	Return a customer and his orders;
*	Add a new Order for an existing Customer;
*	Add a new Customer.

## Technologies

*	Developed using Visual Studio 2019 Community.
*	Asp.Net Core 3.1 with C#
*	Sql Server (local) with Entity Framework (database first)
*	Unit tests with xUnit and functional tests with Postman

## Usage

Open the solution file .sln with Visual Studio 2019.

Setup your database with the scripts in the *Csharp.Api\Csharp.Data\Scripts folder*, execute in the order by name.
Configure the connection string in *appsettings.json file*.

Compile and build;

In your browser (with dev tools, or postman) execute:

*	to list customers: GET https://localhost:44393/api/v1/customers/
*	to return a customer: GET https://localhost:44393/api/v1/customers/{id} (change {id} by an id number)
*	to add a customer: POST https://localhost:44393/api/v1/customers/ (in the body send name and email)
*	to add a order: POST https://localhost:44393/api/v1/orders/ (in the body send customerid, price, and createddate)

The return of all requests will be a JSON.

TIP: import the *"API.postman_collection.json"* into Postman, that will help to check the results;

## For future improvement

This is under development and need to be improved and do some fixes:

*	Add other methods to complete the CRUD operations, using correct HTTP methods;
*	On controllers: improve and create a standard return for errors;
*	On services: improve mappings with third-party plugin;
*	On repositories: improve mappings with third-party plugin;
*	On tests: improve DbContext usage with some mock framework;
*	On tests: add more tests and theories;

## Support

In any case, don't hesitate to contact me tulio.marks@gmail.com
