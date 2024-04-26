
using Amazon.Lambda.Annotations;

using Microsoft.Extensions.DependencyInjection;

using Tenants.Data.DynamoDb;

namespace Tenants.Functions;

[LambdaStartup]

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ITenantsRepository, TenantsRepository>();
    }
}