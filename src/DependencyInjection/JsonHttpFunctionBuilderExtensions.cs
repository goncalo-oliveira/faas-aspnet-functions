using System;
using Microsoft.AspNetCore.Mvc;
using OpenFaaS;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class JsonHttpFunctionBuilderExtensions
    {
        /// <summary>
        /// Configures Json serialization options
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configure">Callback to configure <see cref="JsonOptions"/></param>
        public static IHttpFunctionBuilder ConfigureJsonOptions( this IHttpFunctionBuilder builder, Action<JsonOptions> configure )
        {
            builder.Services.Configure<JsonOptions>( configure );

            return ( builder );
        }
    }
}
