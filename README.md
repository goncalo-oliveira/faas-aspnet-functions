# OpenFaaS ASPNET Functions

Function handler abstracts used by the template and function implementations.

> Since the release of v2.x of the template, this package is no longer used and considered deprecated. See [here](https://github.com/goncalo-oliveira/faas-aspnet-template#migrating-from-v1x) how to migrate your function if you're still using v1.x.

Learn more about the [template](https://github.com/goncalo-oliveira/faas-aspnet-template).

Learn more about [OpenFaas](https://github.com/openfaas/faas).

## IHttpFunction

This interface defines a contract for an ASPNET function. A function implementation needs to implement, as a base minimum, this interface.

```csharp
public interface IHttpFunction
{
    Task<IActionResult> HandleAsync( HttpRequest request );
}
```

## HttpFunction

An abstract implementation for the `IHttpFunction` interface. Although not required, the template by default generates a function that inherits from this class. It provides a few helper methods to make it easier to return specific `IActionResult` objects, simillar to ASPNET `ControllerBase` class.

```csharp
public class Function : HttpFunction
{
   [HttpPost]
   public override async Task<IActionResult> HandleAsync( HttpRequest request )
   {
      var result = await DoSomethingAsync();
      
      return Ok( result );
   }
}
```
