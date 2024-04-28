using Amazon.Lambda.TestUtilities;

using Moq;

using Tenants.Abstractions.Models;
using Tenants.Data.DynamoDb;

using Xunit;

namespace Tenants.Functions.Tests;

public class FunctionTest
{
    public Mock<ITenantsRepository> mock = new Mock<ITenantsRepository>();

    [Fact]
    public async void TestToUpperFunction()
    {
        var context = new TestLambdaContext();
        mock.Setup(p => p.GetTenant(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Tenant
            {
                Id = "1234",
                Name = "Hello World"
            });
        Function fn = new Function(mock.Object);

        var model = await fn.FunctionHandler(new TenantQuery("1234"), context);

        Assert.Equal("1234", model?.Id);
    }
}