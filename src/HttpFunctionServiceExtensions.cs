using System;
using Redpanda.OpenFaaS;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HttpFunctionServiceExtensions
    {
        /// <summary>
        /// Adds a scoped IHttpFunction with an implementation type specified in TFunction
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to</param>
        /// <typeparam name="TFunction">The type of the implementation to use</typeparam>
        /// <returns>The IServiceCollection so that additional calls can be chained</returns>
        public static IServiceCollection AddHttpFunction<TFunction>( this IServiceCollection services )
            where TFunction : class, IHttpFunction
        {
            services.AddScoped<IHttpFunction, TFunction>();

            return ( services );            
        }

        /// <summary>
        /// Adds a scoped IHttpFunction with an implementation type specified in TFunction
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to</param>
        /// <param name="configure">An action delegate to configure the provided Redpanda.OpenFaaS.HttpFunctionOptions</param>
        /// <typeparam name="TFunction">The type of the implementation to use</typeparam>
        /// <returns>The IServiceCollection so that additional calls can be chained</returns>
        public static IServiceCollection AddHttpFunction<TFunction>( this IServiceCollection services, Action<HttpFunctionOptions> configure )
            where TFunction : class, IHttpFunction
        {
            AddHttpFunction<TFunction>( services )
                .Configure<HttpFunctionOptions>( configure );

            return ( services );            
        }
    }
}
