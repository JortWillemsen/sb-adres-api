# Social Brothers Address API
Jort Willemsen - 25/11/21

## Introduction

This project is a case made for Social Brothers. A software company based in Utrecht. The case for this project was to create a simple ASP .NET web api capable of the following:

- Creating addresses.
- Modifying addresses.
- Querying Addresses.
- Query distance between two addresses. (Not implemented)

## Dependencies

- [Swashbuckle ASP.NET Core](https://www.nuget.org/packages/Swashbuckle.AspNetCore/)
- [Entity Framework Core SQlite](https://docs.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli)
- [Gridify](https://alirezanet.github.io/Gridify/)

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
