using Microsoft.Extensions.DependencyInjection;
using TagValidator.Services.Implements;
using TagValidator.Services.Interfaces;

namespace TagValidator
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ITagCheckerService, TagCheckerService>();
            services.AddSingleton<ITagValidatorService, TagValidatorService>();
            services.AddSingleton<EntryPoint>();
            return services;
        }
    }
}