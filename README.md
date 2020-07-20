# NexusModsNET

[![NuGet](https://img.shields.io/nuget/v/NexusModsNET?label=NuGet&style=flat-square)](https://www.nuget.org/packages/NexusModsNET/)

A client for the [NexusMods](https://www.nexusmods.com/) API to proccess requests and resposes as described in the API [documentaion](https://app.swaggerhub.com/apis-docs/NexusMods/nexus-mods_public_api_params_in_form_data/1.0#/), it handles the server responses and deseriliazes the content to .NET objects

This is a **.NET Standard 2.0** class library, it is compataible with every .NET Standard 2.0 supported platform as described [here](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) 

## Usage

The **`NexusModsClient`** is used by any **`Inquirer`** to process the requests and respnses of the API, it also does the error-handling and deserialisation to .NET objects.
You can create a new Instance of the client by calling the **`NexusModsClient.Create`** method, which requires you to provide a valid API key and optionally your application name and version. Note that if you only provide a API key, then the name and version of this Library will be sent to the API with each request as per the API [documentaion](https://app.swaggerhub.com/apis-docs/NexusMods/nexus-mods_public_api_params_in_form_data/1.0#/). 

```c#
var client = NexusModsClient.Create("your_private_api_key");
```
### Inquirers

An **Inquirer** is the actuall endpoint of the API, where you can call methods that corresponds the routes of the API

- InfosInquirer
- ColourSchemesInquirer
- GamesInquirer
- ModFilesInquirer
- ModsInquirer
- UserInquirer
- CustomInquirer

Mainly you want to use the `InfosInquirer`, which combines all available endpoints of the API.

```c#
var client = NexusModsClient.Create("your_private_api_key");
var infosInquirer = new InfosInquirer(client);
```

### Instantiating

You can use the provided NexusModsFactory to create Inquirers:

```c#
var infosInquirer = NexusModsFactory.New("your_private_api_key").CreateInfosInquirer();
```
```c#
var infosInquirerFactory = NexusModsFactory.New("your_private_api_key");
var userInquirer = infosInquirerFactory.CreateUserInquirer();
```

## Exceptions

- `NexusAPIException` --> The base exception for all errors.
- `ForbiddenException` -->
- `QuotaLimitsExceededException` -->
- `UnauthorizedException` -->

Any responses form the API with a status code that is not in the range 200 - 299 are treated as errors and an exception will be thrown based on the status code.
All exceptions derive from the base exception class **`NexusAPIException`**
