using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Http
{
    public static class HttpRequestJsonExtensions
    {
        /// <summary>
        /// Reads body as a JSON string and deserializes it to the specified .NET type
        /// </summary>
        /// <returns>The deserialized object from the JSON string</returns>
        public static async Task<T> ReadJsonBodyAsync<T>( this HttpRequest request )
        {
            using ( var reader = new System.IO.StreamReader( request.Body ) )
            {
                var json = await reader.ReadToEndAsync();

                if ( string.IsNullOrEmpty( json ) )
                {
                    return default( T );
                }

                return System.Text.Json.JsonSerializer.Deserialize<T>( json );

                // TODO: evaluate model annotations
                //       maybe throw an exception for the base handler to pick up
                //       and return a bad request with the exception message
            }
        }
    }
}
