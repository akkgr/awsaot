using System.Threading;
using System.Threading.Tasks;

using Tenants.Abstractions.Models;

namespace Tenants.Data.DynamoDb;

public interface ITenantsRepository
{
    Task<Tenant?> GetTenant(string id, CancellationToken token);
}