using Microsoft.Extensions.Localization;

namespace API.Extensions
{
    public static class StringLocalizerFactoryExtensions
    {
        public static IStringLocalizer CreateLocalizer(this IStringLocalizerFactory stringLocalizerFactory, string fileLocation)
        {
            return stringLocalizerFactory.CreateLocalizer($"Resources.{fileLocation}");
        }
        public static IStringLocalizer CreateLocalizer(this IStringLocalizerFactory stringLocalizerFactory, string fileLocation, string fileName)
        {
            return stringLocalizerFactory.CreateLocalizer($"Resources.{fileLocation}.{fileName}");
        }
    }
}
