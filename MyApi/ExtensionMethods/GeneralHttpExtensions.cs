using System.Runtime.CompilerServices;

namespace MyApi.ExtensionMethods;

public  static class GeneralHttpExtensions
{
    public static void RegisterHttpServices( this IServiceCollection services  ) {
        services.AddEndpointsApiExplorer();
        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.SerializerOptions.DefaultIgnoreCondition =
                System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        });
    }
}
