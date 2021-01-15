# OpenFaaS ASPNET Functions

Function handler abstracts used by the template and function implementations.

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
