using System;
using Microsoft.Extensions.DependencyInjection;

namespace OpenFaaS
{
    internal class HttpFunctionBuilder : IHttpFunctionBuilder
    {
        public HttpFunctionBuilder( IServiceCollection services )
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
