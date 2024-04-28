using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

using Tenants.Abstractions.Models;

namespace Tenants.Data.DynamoDb;

public class TenantsRepository(IAmazonDynamoDB dynamoDbClient) : ITenantsRepository
{
    private static readonly string tableName = "products";
    private readonly IAmazonDynamoDB _dynamoDbClient = dynamoDbClient ?? throw new ArgumentNullException(nameof(dynamoDbClient));

    public async Task<Tenant?> GetTenant(string id, CancellationToken token)
    {
        var key = new Dictionary<string, AttributeValue>
        {
            ["id"] = new AttributeValue { S = id }
        };

        var request = new GetItemRequest
        {
            Key = key,
            TableName = tableName,
        };

        var response = await _dynamoDbClient.GetItemAsync(request);

        if (response.Item == null)
        {
            return null;
        }

        var result = new Tenant
        {
            Id = response.Item["id"].S,
            Name = response.Item["name"].S
        };
        return result;
    }
}