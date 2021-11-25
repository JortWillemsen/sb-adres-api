# Social Brothers Address API
Jort Willemsen - 25/11/21

## Introduction

This project is a case made for Social Brothers. A software company based in Utrecht. The case for this project was to create a simple ASP .NET web api capable of the following:

- Creating addresses.
- Modifying addresses.
- Querying Addresses.
- Query distance between two addresses. (Not implemented)

## Dependencies

- [Swashbuckle ASP.NET Core](https://www.nuget.org/packages/Swashbuckle.AspNetCore/) (Swagger UI implementation)
- [Entity Framework Core SQlite](https://docs.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli) (SQLite repositories and Entity mapping)
- [Gridify](https://alirezanet.github.io/Gridify/) (Sorting and Filtering database resources)

## Endpoints

- GET `/swagger` exposes the Swagger UI documentation.
- GET `/api/address` gives back all addresses found in the database.
- GET `/api/address/{id}` gives back an address with a certain id found in the database.
- POST `/api/address` Creates a new address entry in the Database.
- PUT `/api/address/{id}` Modifies an existing address.
- DELETE `/api/address/{id}` Deletes an existing address from the database.

For more information about the endpoints and how to use them head over to `/swagger`.
## How to Run

### Dotnet

When .NET core is installed you can head to the `/api` directory  and run the following command:

`dotnet run`

This will build the project. You can head over to [localhost:7299](http://localhost:7299/) to see it running.

### Docker
If you have Docker installed you can run this project by running:

`docker run -d -p 5024:80 --name app sbaddressapi`

When going to [localhost:5024](http://localhost:5024/) you will access the API.

Note: This creates a new database instance and will not contain any data.

## What am I proud of
I am proud of the fact that I was able to build an API in C# wich I have never done before. I managed to learn my way around ASP.NET core very fast. It looks a lot like Spring Boot ;). 

If I had more time I would like to add HATEOAS to all my endpoints and create a different Docker container to run my database.

I think the solution I used for sorting and filtering is quite nifty. I have limited experience in C# .NET and needed to find a solution to this problem. This package did the trick and the way I created a string from the filter options is rather scalable because it doesn't care how much attribues AddressFilterOptions has and loops through them all.
if you wanted to add another option to filter by you just add it to the FilterOptions Model and it will work (Given the database has a row named like the attribute).

## What I would do differently
I come from the world of Java where we use a strictly layerd architecture with a Presentation, Application and Data layer. For this project I only used the Presentation and Data layers wich is fine for this type of project but it might not be scalable when trying to add more functionality to one request.

I also did not like the way I used git for this project. I generally use [Git Flow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow) for my projects wich requires strict branch protection and feature branches for everything you add. I quickly figured out that because I was working alone on this using Git flow really does not add anything, so i just pushed to the development branch.

## Querying distances between addresses

A part of this case was the ability to query distance in kilometers between certain addresses in the database.
Unfortunately due to time constraints I wasn't able to finish this part of the project. To give an idea of what I was intending to do I will explain the workflow of what I would do.

First I would use the [gateway pattern](https://martinfowler.com/articles/gateway-pattern.html) to create an interface for abstraction. Secondly we need to use a NuGet package to handle Http Rest requests to the second API we are querying. For this there are multiple options. Due to my limited experience with C# I would choose the straight forward answer and use the package from Microsoft to handle this problem: **System.Net.Http.Client**.
There is documentation available about this problem on the 
[Microsoft docs](https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client).

And Last we need an API that has the capability to query distances for us to use. There are loads of API's that take coordinates and can give back driving routes, absolute distances and much more but there is one problem. We only have addresses.
I found an API that could handle both of these problems seperately: [Mapbox](https://www.mapbox.com/). 

Mapbox has some constrainst though. It is technically free but we need an account to get an API key and can only query 1000 times a month. And when we need 2 queries for one result that benifits us that can tick up rather quickly. There is another solution:

Just as Mapbox, Google Maps also has an public API for querying distances and can even deduct coordinates from a string that represents an address. But just as Mapbox the Google maps api also has limitations. We need to supply a credit card, even when we are only using the free tier of the API and to do that we first need to create a Google developer account wich requires a €25 fee.

And thus whilest those solutions will absolutely work when given the proper resources the are most likely not viable for such a small problem as this. Due to my limited time to research this problem I have not found a suitable solution for this assignment but I hope I have given a sufficient explanation on how I would go about solving a problem like this!
