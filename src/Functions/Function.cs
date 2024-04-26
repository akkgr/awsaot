using Amazon.Lambda.Annotations;
using Amazon.Lambda.Core;

using Tenants.Abstractions.Models;
using Tenants.Data.DynamoDb;

namespace Tenants.Functions;

public class Function
{
    private readonly ITenantsRepository _dataAccess;

    public Function(ITenantsRepository dataAccess)
    {
        this._dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
    }

    [LambdaFunction]
    public async Task<Tenant?> FunctionHandler(TenantQuery query, ILambdaContext context)
    {
        var cts = new CancellationTokenSource(context.RemainingTime);
        var dao = await _dataAccess.GetTenant(query.Id, cts.Token);

        if (dao == null)
        {
            return null;
        }

        return new Tenant
        {
            Id = dao.Id,
            Name = dao.Name,
        };
    }
}