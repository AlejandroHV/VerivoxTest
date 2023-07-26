# VERIVOX Interview Test

## Introduction
ONION Architecture application to compare the energy consumption tariffs of different products. 
This light implementation of the ONION architecture uses the mediator pattern to send request from the controller to the handler to calculate the tariff for 
the products. 
As there is no need to use a database I created a simple Mock of a DBContext but for data obtained from a file called FileContext. 
In order to dynamically get the tariff of different products obtained from the database I stored the assembly names along the products in the "Database" and created 
instances of them using reflection and then executing the calculations. 

## TO DO's:
* Increase the coverage of the Unit Tests for the different layers. Currently the unit tests cover the Product tariff calculation and the FileContext. -- INCREASED.
* Basic configuration for the API such as CORS, Versioning. 
* --DONE--Improve the Swagger documentation. Add the descriptions for the Request object and the return type of the controller. --DONE
* Implement the Unit of work/Repository pattern to handle an actual DBContext. 
* Implement Authentication through JWT tokens. 
* Implement the command pattern to send request from the Application layer to the Domain layer. 
* Implement a factory pattern for the Product creation to avoid storing the assembly name in the database. 


## Project Support Features
* Endpoints to get information about:
  - Tariff cost comparation  of two products given an annual consumption.
* Swagger documentation. 
* Does not require authentication.
## Versions
* 1.0
## Installation Guide
* Clone this repository [here](https://github.com/AlejandroHV/VerivoxTest).
* The master branch is the most stable branch at any given time, ensure you're working from it.
* Run `dotnet build` command to generate the build of the project.

## Usage
IN PROGRESS.
* Clone the repo. 
* Open a bash or sh terminal on the project root "Verivox" folder. 
* Run the "runApp.sh" `./runApp.sh`
Current: 
* Clone the repo. 
* Run `dotnet build` command to generate the build of the project.
* Run `dotnet run --project VerivoxTest.API/` command to run the API/Endpoint.
* Open in a browser the localhost path "http://localhost:5002/swagger/index.html" to see the swagger documentation. 
* Execute any queries to the tariff endpoint to get the tariff comparations.


* Swagger documentation can be found in the following [URL](http://localhost:5002/swagger/index.html)

## API Endpoints
| HTTP Verbs | Endpoints                                        | Action                                                                                   |
| ---------- | -------------------------------------------------| -----------------------------------------------------------------------------------------|
| GET        | api/Tarrif?AnnualConsumption={annualConsumption} | Get a list of the cost of the annual consumption of the different products in the system |

## Response Example 
* Content type: "application/json". Responses are JSON Objects. 
* Response header contains the HTTP CODE with the status. 
* Example:
 
```json
 {
  "payload": [
    {
      "productName": "Basic Electricity Tariff",
      "consumption": 610
    },
    {
      "productName": "Packaged Tariff",
      "consumption": 800
    }
  ],
  "itemCount": 0
 ```
## Technologies Used
* [.NET 7.*](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) is a free, cross-platform, open source developer platform for building many kinds of applications. .NET is built on a high-performance runtime that is used in production by many high-scale apps.
* [Mediator Design Patter/MeditR ](https://github.com/jbogard/MediatR) Mediator is a behavioral design pattern that lets you reduce chaotic dependencies between objects. The pattern restricts direct communications between the objects and forces them to collaborate only via a mediator object.
* [Onion Architecture](https://medium.com/expedia-group-tech/onion-architecture-deed8a554423) Domain entities are the core and centre part. Onion architecture is built on a domain model in which layers are connected through interfaces. The idea is to keep external dependencies as far outward as possible where domain entities and business rules form the core part of the architecture.
* Fluent Validation

