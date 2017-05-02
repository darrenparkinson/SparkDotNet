# SparkDotNet

An unofficial dotnet library for consuming RESTful APIs for Cisco Spark. Please visit Cisco at http://developer.ciscospark.com/.

```{.cs}
using SparkDotNet;

var token = System.Environment.GetEnvironmentVariable("SPARK_TOKEN");
var spark = new Spark(token);
var rooms = await spark.GetRoomsAsync(max: 10);
foreach (var room in rooms)
{
    WriteLine(room);
}
```

# Installation

## Prerequisites

This library requires .NET 4.5, .NET 4.6.1 or .NET Standard 1.6.

It can be used across multiple platforms using .NET Core and you will therefore require the appropriate components based on your choice of environment.

* [.NET Core for Windows and Visual Studio](https://www.microsoft.com/net/core#windowsvs2015)
* [.NET Core for Windows Command Line](https://www.microsoft.com/net/core#windowscmd)
* [.NET Core for Mac](https://www.microsoft.com/net/core#macos)
* [.NET Core for Linux](https://www.microsoft.com/net/core#linuxredhat)

You can also use Visual Studio 2015 and .NET 4.6.1 or .Net 4.5.

The following assumes you have an existing project to which you wish to add the library.

### .NET Core

1. Edit your `<application>.csproj` file to include `SparkDotNet` as a dependency.  

2. Run `dotnet restore`.

3. There is no step 3.

The following shows an example application.csproj file:

```{.csproj}
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.1</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="SparkDotNet" Version="1.2.0" />
  </ItemGroup>
</Project>
```

For previous versions of dotnet core, the following shows an example project.json file:

```{.json}
{
  "version": "1.0.0-*",
  "buildOptions": {
    "debugType": "portable",
    "emitEntryPoint": true
  },
  "dependencies": {
      "SparkDotNet": "1.0.4"
  },
  "frameworks": {
    "netcoreapp1.0": {
      "dependencies": {
        "Microsoft.NETCore.App": {
          "type": "platform",
          "version": "1.0.1"
        }
      },
      "imports": "dnxcore50"
    }
  }
}
```



### Windows Visual Studio

1. Open Tools -> NuGet Package Manager -> Package Manager Console

2. Run `Install-Package SparkDotNet`

3. There is no step 3.


# Using the library

1. Create a new project 

> `dotnet new console`

2. Include the `SparkDotNet` dependency  

> `dotnet add package SparkDotNet`  
> `dotnet restore`

3. Edit `Program.cs` to resemble the following:

```{.cs}
using static System.Console;
using SparkDotNet;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            var token = System.Environment.GetEnvironmentVariable("SPARK_TOKEN");
            var spark = new Spark(token);

            try
            {
                var orgs = await spark.GetOrganizationsAsync();
                foreach (var org in orgs)
                {
                    WriteLine(org);
                }

                WriteLine(await spark.GetMeAsync());
            }
            catch (SparkException ex)
            {
                WriteLine(ex.Message);
            }
        }
    }
}

```
4. Run the Program

> `set SPARK_TOKEN=<your token here`  
> `dotnet run`

# Reference

There are 10 endpoints covered by this library.  Please refer to the Cisco documentation for details of their use:

* [People](https://developer.ciscospark.com/resource-people.html)
* [Rooms](https://developer.ciscospark.com/resource-rooms.html)
* [Memberships](https://developer.ciscospark.com/resource-memberships.html)
* [Messages](https://developer.ciscospark.com/resource-messages.html)
* [Teams](https://developer.ciscospark.com/resource-teams.html)
* [Team Memberships](https://developer.ciscospark.com/resource-team-memberships.html)
* [Webhooks](https://developer.ciscospark.com/resource-webhooks.html)
* [Organizations](https://developer.ciscospark.com/resource-organizations.html)
* [Licenses](https://developer.ciscospark.com/resource-licenses.html)
* [Roles](https://developer.ciscospark.com/resource-roles.html)

Each endpoint has a corresponding method in the Spark class mapping to `Get`, `Create`, `Update` and `Delete` based on the HTTP method used, `GET`, `POST`, `PUT` and `DELETE` respectively.  As an example, using the People endpoint, these map as follows:

| Cisco Endpoint | HTTP Method | Spark Class Method |
| -------------- |:-----------:|:-------------------|
| [List People](https://developer.ciscospark.com/endpoint-people-get.html)| GET |  GetPeopleAsync() | 
| [Create a Person](https://developer.ciscospark.com/endpoint-people-post.html)| POST | CreatePersonAsync() | 
| [Get Person Details](https://developer.ciscospark.com/endpoint-people-personId-get.html)| GET | GetPersonAsync() | 
| [Update a Person](https://developer.ciscospark.com/endpoint-people-personId-put.html)   | PUT | UpdatePersonAsync() | 
| [Delete a Person](https://developer.ciscospark.com/endpoint-people-personId-delete.html)| DELETE | DeletePersonAsync() |
| [Get My Details](https://developer.ciscospark.com/endpoint-people-me-get.html)| GET | GetMeAsync() |

Where parameters are optional, they are also optional in the class methods.  These are variables that have default values specified. As usual, you must specify any required variables in the correct order before specifying any optional variables.

As an example, the `max` parameter is typically optional and as such you do not need to specify it.  If you wish to specify it, you can use the named argument syntax as shown below:

```
spark.GetRoomsAsync(max: 400);
```

Where a parameter requires a string array, these can be specified as follows:

```
spark.UpdatePersonAsync(id,new string[] {"someone@example.com"},orgId, new string[] {role}, name);
```

Most methods return an object of the type you are retrieving or updating.  Methods where you expect multiple objects are returned as a List<> of that object.  The exception to this is when deleting an object where the returned value is a boolean indicating the success of the operation.

# Files

As of version 1.2.0, when posting files in messages using `CreateMessageAsync()` you now have the option of sending local files.

You could already send files available publicly using the existing `files` object:

`var message = await spark.CreateMessageAsync(roomId, text:"Here is the logo you wanted.", files:new string[] {"https://developer.cisco.com/images/mobility/Spark.png"} );`

To upload a local file, you simple replace the URI with a local filename:

`var message = await spark.CreateMessageAsync(roomId, text:"Here is the logo you wanted.", files:new string[] {"Spark.png"} );`

This example assumes the `Spark.png` file is in the same location you are running the application. 

Note that you can only send a single file at a time using this method, even though the parameter accepts a string array.


# Pagination

An initial version of pagination has been added to provide support for Cisco Spark API as outlined on [the Cisco Spark Developer Portal](https://developer.ciscospark.com/pagination.html).  

For backwards compatibility, this has been added as a separate method (`GetItemsWithLinksAsync`) which you must use over and above those specific to each resource if you specifically want to use pagination.  

This method returns a new `PaginationResult` class which contains the `Items` of the type you requested and `Links` to any additional resources for `First`, `Prev` and `Next`.

The following provides an example of returning `Person` items with pagination:

```{.cs}
var result = await spark.GetItemsWithLinksAsync<SparkDotNet.Person>("/v1/people?max=3");
foreach (var person in result.Items)
{
    WriteLine(person);
}
if (!string.IsNullOrEmpty(result.Links.Next))
{
    var result2 = await spark.GetItemsWithLinksAsync<SparkDotNet.Person>(result.Links.Next);
    foreach (var person in result2.Items)
    {
        WriteLine(person);
    }
}
```

# Exceptions

As of version 1.1.0, all calls to the Cisco Spark platform will throw a `SparkException` if an unexpected result is received. 

To avoid runtime errors, wrap calls to Cisco Spark in a `try-catch` statement:

```{.cs}
try
{
    WriteLine(await spark.GetMeAsync());    
}
catch (SparkException ex)
{
    WriteLine(ex.Message)
}
```

`SparkException` provides the following properties:

* `Message` (`string`)
* `StatusCode` : (`int`)
* `Headers` : (`System.Net.Http.Headers.HttpResponseHeaders`)

The `Headers` property is useful since this will provide the Cisco `Trackingid` for troubleshooting purposes.

```{.cs}
using System.Linq;

try
{
    WriteLine(await spark.GetMeAsync());    
}
catch (SparkException ex)
{
    WriteLine(ex.Headers.GetValues("Trackingid").FirstOrDefault());
}
```