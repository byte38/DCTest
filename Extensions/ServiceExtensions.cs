using DCTest.Helpers;
using DCTest.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;

namespace DCTest.Extensions {
    public static class ServiceExtensions {
        public static void AddCustomServices (this IServiceCollection services) {
            services.AddHttpClient ("CoinCapClient", configure => {
                configure.BaseAddress = new Uri ("https://api.coincap.io/v2/");
                configure.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Bearer", "6cf7d30d-97fe-48a1-9a1a-83c25b20c548");
            });
            services.AddSingleton<ApiHelper> ();
            services.AddAutoMapper (typeof (MappingProfile));
        }
    }
}
