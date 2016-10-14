[![Build status](https://ci.appveyor.com/api/projects/status/yt4ng6wtcd1nrd3b/branch/master?svg=true)](https://ci.appveyor.com/project/HristoKolev/tvdbsharper/branch/master) [![NuGet](https://img.shields.io/nuget/v/TvDbSharper.svg?maxAge=2592000?style=plastic)](https://www.nuget.org/packages/TvDbSharper/)

# The client

There is one client you need to know about:

```C#
var client = new TvDbClient();
```
or 

```C#
ITvDbClient client = new TvDbClient();
```

# Authentication

Before you do anything else you need to authenticate yourself.

* You will need an account on https://thetvdb.com/
* Then you will need to register an API key here: https://thetvdb.com/?tab=apiregister
* Then you can see all of the required information on your account page here: https://thetvdb.com/?tab=userinfo 
* **Note**: The "Account Identifier" field holds the UserKey.

Then you can use the client like this:

```C#
await client.Authentication.AuthenticateAsync("ApiKey", "Username", "UserKey");
```

The session expires after 24 hours, but you can refresh that period by calling `RefreshTokenAsync`

```C#
await client.Authentication.RefreshTokenAsync();
```

