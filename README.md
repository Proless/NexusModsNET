# NexusModsNET

[![NuGet](https://img.shields.io/nuget/v/NexusModsNET?label=NuGet&style=flat-square)](https://www.nuget.org/packages/NexusModsNET/)

A client for the [NexusMods](https://www.nexusmods.com/) API to process requests and responses as described in the API [documentation](https://app.swaggerhub.com/apis-docs/NexusMods/nexus-mods_public_api_params_in_form_data/1.0#/), it handles the server responses and deserializes the content to .NET objects

This is a **.NET Standard 2.0** class library, it is compatible with every .NET Standard 2.0 supported platform as described [here](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) 

## Usage

The **`NexusModsClient`** is used by any **`Inquirer`** to process the requests and responses of the API, it also does the error-handling and deserialization to .NET objects.
You can create a new Instance of the client by calling the **`NexusModsClient.Create`** method, which requires you to provide a valid API key and optionally your application name and version. Note that if you only provide a API key, then the name and version of this Library will be sent to the API with each request as per the API [documentation](https://app.swaggerhub.com/apis-docs/NexusMods/nexus-mods_public_api_params_in_form_data/1.0#/). 

```c#
var client = NexusModsClient.Create("your_private_api_key");
```
## Inquirers

An **Inquirer** is the actual endpoint of the API, where you can call methods that corresponds the routes of the API

- InfosInquirer
- ColourSchemesInquirer
- GamesInquirer
- ModFilesInquirer
- ModsInquirer
- UserInquirer

Mainly you want to use the `InfosInquirer`, which combines all available endpoints of the API.

```c#
var client = NexusModsClient.Create("your_private_api_key");
var infosInquirer = new InfosInquirer(client);
```

## Instantiating

You can use the provided NexusModsFactory to create Inquirers:

```c#
var infosInquirer = NexusModsFactory.New("your_private_api_key").CreateInfosInquirer();
```
```c#
var infosInquirerFactory = NexusModsFactory.New("your_private_api_key");
var userInquirer = infosInquirerFactory.CreateUserInquirer();
```
## Limits management

The RateLimitsManagement property of an Inquirer helps you with reading the current limits of the API, you can also set your own custom daily and hourly limits and decide whether to throw an exception if they are both exceeded. Note that a `LimitsExceededException` will always be thrown if both API Limits are exceeded (100 Hourly, 2500 Daily).
The RateLimitsManagement also has two events `DailyLimitsExceeded` and `HourlyLimitsExceeded` which will get invoked whenever a Limit is exceeded (both API and Custom) and recives a `LimitType` which is either API limit or Custom limit

```c#
/// <summary>
/// Indicates that a Daily limit has been exceeded.
/// </summary>
event EventHandler<LimitType> DailyLimitsExceeded;
/// <summary>
/// Indicates that a Hourly limit has been exceeded.
/// </summary>
event EventHandler<LimitType> HourlyLimitsExceeded;
```

## Exceptions

- `NexusAPIException` --> The base exception for all errors.
- `ForbiddenException`
- `LimitsExceededException`
- `UnauthorizedException`

Any responses form the API with a status code that is not in the range 200 - 299 are treated as errors and an exception will be thrown based on the status code.
All exceptions derive from the base exception class **`NexusAPIException`**
