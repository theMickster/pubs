using Microsoft.AspNetCore.Hosting;

namespace Pubs.API.Extensions
{
    public static class HostingEnvironmentExtensions
    {
        public static readonly string Development = nameof(Development);

        public static readonly string Obiwankenobi = nameof(Obiwankenobi);

        public static readonly string Test = nameof(Test);

        public static readonly string Uat = nameof(Uat);

        public static bool IsOneOfOurDevelopmentEnvironments(this IWebHostEnvironment webHostEnvironment)
        {
            return webHostEnvironment.EnvironmentName == Obiwankenobi ||
                   webHostEnvironment.EnvironmentName == Development;
        }

        public static bool IsOneOfOurTestEnvironments(this IWebHostEnvironment webHostEnvironment)
        {
            return webHostEnvironment.EnvironmentName == Test ||
                   webHostEnvironment.EnvironmentName == Uat;
        }
    }
}
