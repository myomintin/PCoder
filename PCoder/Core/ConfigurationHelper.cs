using Microsoft.Extensions.Configuration;

namespace PCoder.Core;

public static class ConfigurationHelper
{
    public static IConfigurationRoot GetConfiguration(string filename)
    {
        return new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile(filename, optional: false, reloadOnChange: true).Build();
    }

    public static IConfigurationRoot GetConfiguration(string baseDirectory, string filename)
    {
        return new ConfigurationBuilder().SetBasePath(baseDirectory).AddJsonFile(filename, optional: false, reloadOnChange: true).Build();
    }

    public static IConfigurationRoot Default()
    {
        return GetConfiguration("appsettings.json");
    }
}
