using System;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShopHRM.UI.Extensions
{
    public static class HttpClientHelper
    {
        public static void RegisterHttpClient<TClient, TImplementation>(this IServiceCollection services, Uri apiBaseUrl)
            where TClient : class where TImplementation : class, TClient
        {
            services.AddHttpClient<TClient, TImplementation>(client => 
            {
                client.BaseAddress = apiBaseUrl;
            });
        }
    }
}