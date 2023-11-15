using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PFD_Project
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMvc();
            services.AddControllersWithViews();

            services.AddFido(options =>
            {
                options.Licensee = "DEMO";
                options.LicenseKey = "eyJTb2xkRm9yIjowLjAsIktleVByZXNldCI6NiwiU2F2ZUtleSI6ZmFsc2UsIkxlZ2FjeUtleSI6ZmFsc2UsIlJlbmV3YWxTZW50VGltZSI6IjAwMDEtMDEtMDFUMDA6MDA6MDAiLCJhdXRoIjoiREVNTyIsImV4cCI6IjIwMjMtMTItMTRUMDE6MDA6MDEuNDQxMDM2OSswMDowMCIsImlhdCI6IjIwMjMtMTEtMTRUMDE6MDA6MDEiLCJvcmciOiJERU1PIiwiYXVkIjo2fQ==.FBOt7iGw85yEIwc4QZL/U2F31iibXAzzzV5yb7E8mgMfWG9Kb3hZu9hObBAlW+g6XRVYRLbc69wZbG6TvLQWpq93RmUKnhhWEbnOWgm0wepDom3kOkJNhNQ5ZC3HIG8Xn7rTQbD/82NN5C2eO+JHisyssCNbG7ndT2F03/aXO7O0Q/OXNXdjrvOyeGLcbjZ4AOldrc//04Si2eQVa9hmmJtvZECVu+sPJu04MI4qULjF2TLoyRwI0IOkxh9YMsswneuJ7O49MEe0C74oSqNTZQsg3fbx925tcveEU4QBeNWZPUe7dUxF1lpZteflmZF9CzYddZSBVYnpl64SksBv12BxMC5tp7Kv7DB+rqW60NvNt0QzDkgKIuP44vwQch0MQfp+LsPQMyQ/GU9+yr8K3sjcS/ayR1SqWYR1Wv1R5wNyHyeXXeiTe+cflAHPJrQaDvUoZq3E8vCKJBQJ979NQl71LHcyk66ADKsv4YHiKjdIFXBvmqFzDwR0V5zJve+QZAyUpjpxzYpx/CzVR3Je/ARD6Yg3xS2oVN+LU248AvH2s36gLZI4K3fIqSkfdoUU0R5KiOGPZ5V1oWMIyYZSXqk32jUCCFtQGhEilMVSQhqdeX3yTznBpxUWbuY+KYjlNgdv7z1ZqwK7/OUWf3fwRDGrwTjWkkQbgQ4DZPpe7Lc=";
            })
                .AddInMemoryKeyStore();

            services.AddAuthentication("cookie")
                .AddCookie("cookie", options => { options.LoginPath = "/Fingerprint/StartLogin"; });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
