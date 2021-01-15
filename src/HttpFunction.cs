using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OpenFaaS
{
    /// <summary>
    /// A default implementation of OpenFaaS.IHttpFunction
    /// </summary>
    public abstract class HttpFunction : IHttpFunction
    {
        private static Task<IActionResult> methodNotAllowed = Task.FromResult<IActionResult>( new StatusCodeResult( StatusCodes.Status405MethodNotAllowed ) );

        public virtual Task<IActionResult> HandleAsync( HttpRequest request )
        {
            if ( HttpMethods.IsGet( request.Method ) )
            {
                return HandleGetAsync( request );
            }

            if ( HttpMethods.IsPost( request.Method ) )
            {
                return HandlePostAsync( request );
            }

            if ( HttpMethods.IsPut( request.Method ) )
            {
                return HandlePutAsync( request );
            }

            if ( HttpMethods.IsPatch( request.Method ) )
            {
                return HandlePatchAsync( request );
            }

            if ( HttpMethods.IsDelete( request.Method ) )
            {
                return HandleDeleteAsync( request );
            }

            return ( methodNotAllowed );
        }

        protected virtual Task<IActionResult> HandleGetAsync( HttpRequest request ) => methodNotAllowed;

        protected virtual Task<IActionResult> HandlePostAsync( HttpRequest request ) => methodNotAllowed;

        protected virtual Task<IActionResult> HandlePutAsync( HttpRequest request ) => methodNotAllowed;

        protected virtual Task<IActionResult> HandlePatchAsync( HttpRequest request ) => methodNotAllowed;

        protected virtual Task<IActionResult> HandleDeleteAsync( HttpRequest request ) => methodNotAllowed;

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.NoContentResult object that produces an empty 204 response
        /// </summary>
        protected NoContentResult NoContent()
        {
            return new NoContentResult();
        }

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.OkResult object that produces an empty 200 response
        /// </summary>
        protected OkResult Ok()
        {
            return new OkResult();
        }

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.OkObjectResult object that produces a 200 response
        /// </summary>
        protected OkObjectResult Ok( object value )
        {
            return new OkObjectResult( value );
        }

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.UnauthorizedResult object that produces an empty 401 response
        /// </summary>
        protected UnauthorizedResult Unauthorized()
        {
            return new UnauthorizedResult();
        }

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.ForbidResult object that produces an empty 403 response
        /// </summary>
        protected ForbidResult Forbidden()
        {
            return new ForbidResult();
        }

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.NotFoundResult object that produces an empty 404 response
        /// </summary>
        protected NotFoundResult NotFound()
        {
            return new NotFoundResult();
        }

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.AcceptedResult object that produces an empty 202 response
        /// </summary>
        protected AcceptedResult Accepted()
        {
            return new AcceptedResult();
        }

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.AcceptedResult object that produces a 202 response
        /// </summary>
        protected AcceptedResult Accepted( string location, object value )
        {
            return new AcceptedResult( location, value );
        }

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.CreatedResult object that produces a 201 response
        /// </summary>
        protected CreatedResult Created( string location, object value )
        {
            return new CreatedResult( location, value );
        }

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.BadRequestResult object that produces an empty 400 response
        /// </summary>
        protected BadRequestResult BadRequest()
        {
            return new BadRequestResult();
        }

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.ConflictResult object that produces an empty 409 response
        /// </summary>
        protected ConflictResult Conflict()
        {
            return new ConflictResult();
        }

        /// <summary>
        /// Creates a Microsoft.AspNetCore.Mvc.StatusCodeResult object by specifying a statusCode
        /// </summary>
        protected IActionResult StatusCode( int statusCode )
        {
            return new StatusCodeResult( statusCode );
        }
    }
}
