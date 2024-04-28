
using System.Text.Json.Serialization;

using Tenants.Abstractions.Models;
using Tenants.Data.DynamoDb;

[JsonSerializable(typeof(Tenant))]
[JsonSerializable(typeof(TenantQuery))]
public partial class LambdaFunctionJsonSerializerContext : JsonSerializerContext
{

}