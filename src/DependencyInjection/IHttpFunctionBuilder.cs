using System;
using Microsoft.Extensions.DependencyInjection;

namespace OpenFaaS
{
    public interface IHttpFunctionBuilder
    {
        IServiceCollection Services { get; }
    }
}
