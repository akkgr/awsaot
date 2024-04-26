
using System.Text.Json.Serialization;

using Tenants.Abstractions.Models;

[JsonSerializable(typeof(Tenant))]
[JsonSerializable(typeof(TenantQuery))]
public partial class LambdaFunctionJsonSerializerContext : JsonSerializerContext
{

}