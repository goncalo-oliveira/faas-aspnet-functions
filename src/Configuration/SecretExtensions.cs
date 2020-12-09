using System;
using System.Text;

namespace Microsoft.Extensions.Configuration
{
    public static class OpenFaaSSecretConfigurationExtensions
    {
        /// <summary>
        /// Reads secret with given name from configuration
        /// </summary>
        /// <param name="secretName">The name of the secret</param>
        /// <returns>The raw value of the secret</returns>
        public static byte[] GetSecret( this IConfiguration configuration, string secretName )
        {
            var valueBase64 = configuration[ $"_secret_{secretName}" ];

            if ( valueBase64 == null )
            {
                // attempt to read secret with legacy name
                valueBase64 = configuration[ $"openfaas_secret_{secretName}" ];
            }

            if ( valueBase64 == null )
            {
                return ( null );
            }

            return Convert.FromBase64String( valueBase64 );
        }

        /// <summary>
        /// Reads secret with given name from configuration as an UTF8 string
        /// </summary>
        /// <param name="secretName">The name of the secret</param>
        /// <returns>The value of the secret as a string</returns>
        public static string GetSecretAsString( this IConfiguration configuration, string secretName )
        {
            var value = GetSecret( configuration, secretName );

            if ( value == null )
            {
                return ( null );
            }

            return Encoding.UTF8.GetString( value );
        }
    }
}
