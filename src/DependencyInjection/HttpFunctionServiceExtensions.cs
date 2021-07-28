using System;
using OpenFaaS;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HttpFunctionServiceExtensions
    {
        /// <summary>
        /// Adds a scoped IHttpFunction with an implementation type specified in TFunction
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to</param>
        /// <typeparam name="TFunction">The type of the implementation to use</typeparam>
        /// <returns>An IHttpFunctionBuilder so that additional configuration can be chained</returns>
        public static IHttpFunctionBuilder AddHttpFunction<TFunction>( this IServiceCollection services )
            where TFunction : class, IHttpFunction
        {
            services.AddScoped<IHttpFunction, TFunction>();

            return ( new HttpFunctionBuilder( services ) );
        }

        /// <summary>
        /// Adds a scoped IHttpFunction with an implementation type specified in TFunction
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to</param>
        /// <param name="configure">An action delegate to configure the provided OpenFaaS.HttpFunctionOptions</param>
        /// <typeparam name="TFunction">The type of the implementation to use</typeparam>
        /// <returns>An IHttpFunctionBuilder so that additional configuration can be chained</returns>
        public static IHttpFunctionBuilder AddHttpFunction<TFunction>( this IServiceCollection services, Action<HttpFunctionOptions> configure )
            where TFunction : class, IHttpFunction
        {
            AddHttpFunction<TFunction>( services );

            services.Configure<HttpFunctionOptions>( configure );

            return ( new HttpFunctionBuilder( services ) );
        }

        /// <summary>
        /// Retrieves an OpenFaaS.IHttpFunctionBuilder to allow further customization
        /// </summary>
        /// <returns>An OpenFaaS.IHttpFunctionBuilder instance</returns>
        public static IHttpFunctionBuilder ConfigureHttpFunction( this IServiceCollection services )
        {
            return new HttpFunctionBuilder( services );
        }
    }
}
