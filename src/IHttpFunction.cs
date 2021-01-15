using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OpenFaaS
{
    /// <summary>
    /// Defines an ASPNET function
    /// </summary>
    public interface IHttpFunction
    {
        /// <summary>
        /// Executes the function with the incoming request
        /// </summary>
        /// <param name="request">Incoming request</param>
        /// <returns>The created Microsoft.AspNetCore.Mvc.IActionResult for the response.</returns>
        Task<IActionResult> HandleAsync( HttpRequest request );
    }
}
