using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EagerAndExplicitAndLazyLoading.Extensions;

public static class ModelBuilderExtensions
{
    private const string ApplyConfigurationMethodName = "ApplyConfiguration";

    public static ModelBuilder ApplyConfiguration(this ModelBuilder source, params Type[] types)
    {
        var sourceType = typeof(ModelBuilder);
        var methodInfo = sourceType.GetMethod(ApplyConfigurationMethodName, BindingFlags.Instance | BindingFlags.InvokeMethod);

        if (methodInfo == null)
        {
            throw new MissingMethodException(nameof(ModelBuilder), ApplyConfigurationMethodName);
        }

        foreach (var type in types)
        {
            var configInstance = Activator.CreateInstance(type);

            if (configInstance == null)
            {
                throw new ArgumentException($"All types must have default constructor. Faulting type: {type.Name}.");
            }

            methodInfo.Invoke(source, [configInstance]);
        }

        return source;
    }
}