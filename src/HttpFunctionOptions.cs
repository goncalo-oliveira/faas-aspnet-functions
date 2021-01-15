using System;

namespace OpenFaaS
{
    /// <summary>
    /// Function options
    /// </summary>
    public class HttpFunctionOptions
    {
        /// <summary>
        /// Gets or sets whether to ignore default routing rules
        /// </summary>
        public bool IgnoreRoutingRules { get; set; }
    }
}
