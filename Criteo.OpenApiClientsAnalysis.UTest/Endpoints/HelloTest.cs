namespace Criteo.OpenApiClientsAnalysis.UTest.Endpoints;

public class HelloTest : EndpointTest
{
    [Test]
    public override async Task TestKiota()
    {
        var res = await KiotaClient.Api.Sandbox.Hello.GetAsHelloGetResponseAsync();
        Assert.That(res, Is.Not.Null);
        Assert.That(res.Message, Is.EqualTo("Hello, World!"));
    }

    [Test]
    public override async Task TestNSwag()
    {
        var res = await NSwagClient.HelloAsync();
        Assert.That(res, Is.Not.Null);
        Assert.That(res.Message, Is.EqualTo("Hello, World!"));
    }

    [Test]
    public override async Task TestOpenApiGenerator()
    {
        var res = await OagClient.ApiSandboxHelloGetAsync();
        Assert.That(res.IsOk, Is.True);
        Assert.That(res.Ok()!.Message, Is.EqualTo("Hello, World!"));
    }
}
