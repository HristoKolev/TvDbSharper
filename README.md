TvDbSharper is fully featured modern REST client for the TheTVDB API v4

### Last API compatibility check: 19-01-2022

[![NuGet](https://img.shields.io/nuget/v/TvDbSharper.svg?maxAge=2592000?style=plastic)](https://www.nuget.org/packages/TvDbSharper/)  [![Build status](https://ci.appveyor.com/api/projects/status/yt4ng6wtcd1nrd3b/branch/master?svg=true)](https://ci.appveyor.com/project/HristoKolev/tvdbsharper/branch/master)

## How to install

```
dotnet add package TvDbSharper
```

## The client

There is one client you need to know about:

```C#
var client = new TvDbClient();
```

## Authentication

Before you do anything else you need to authenticate yourself.

* You will need an account on https://thetvdb.com/
* Then you will need to register an API key and a PIN here: https://thetvdb.com/dashboard/account/apikey

Then you can use the client like this:

```C#
await client.Login("ApiKey", "PIN");
```

## Everything else

This client supports all of the functionality of the REST API and I can't list every single method here.

You can explore that yourself or read the REST API documentation provided by thetvdb.com here https://thetvdb.github.io/v4-api/

You will find equivalent method for every single route there.

## V3 code is here: https://github.com/HristoKolev/TvDbSharper/tree/v3
