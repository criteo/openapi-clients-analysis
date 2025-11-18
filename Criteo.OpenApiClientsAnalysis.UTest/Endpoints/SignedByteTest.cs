namespace Criteo.OpenApiClientsAnalysis.UTest.Endpoints;

public class SignedByteTest : EndpointTest
{
    [Test]
    public override async Task TestKiota()
    {
        sbyte testValue = 42;
        var res = await KiotaClient.Api.Sandbox.Sbyte[testValue].GetAsync();
        Assert.That(res, Is.Not.Null);
        Assert.That(res, Is.EqualTo(testValue));
    }

    [Test]
    public override async Task TestNSwag()
    {
        sbyte testValue = 42;
        var res = await NSwagClient.SbyteAsync(testValue);
        Assert.That(res, Is.EqualTo(testValue));
    }

    [Test]
    public override async Task TestOpenApiGenerator()
    {
        sbyte testValue = 42;
        var res = await OagClient.ApiSandboxSbyteSbGetAsync(testValue);
        Assert.That(res.IsOk, Is.True);
        Assert.That(res.Ok(), Is.EqualTo(testValue));
    }
}
