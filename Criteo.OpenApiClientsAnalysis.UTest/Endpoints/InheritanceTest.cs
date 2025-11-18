namespace Criteo.OpenApiClientsAnalysis.UTest.Endpoints;

public class InheritanceTest : EndpointTest
{
    private static readonly byte[] RequestData = new byte[12];

    [Test]
    public override async Task TestKiota()
    {
        var payload = new Kiota.Client.Models.SandboxInheritance { Data = RequestData };
        var res = await KiotaClient.Api.Sandbox.Inheritance.PostAsync(payload);
        Assert.That(res, Is.Not.Null);
        Assert.That(res.Data?.Length, Is.EqualTo(12));
    }

    [Test]
    public override async Task TestNSwag()
    {
        // NSwag directly uses SandboxImplementation
        var payload = new NSwag.Client.SandboxImplementation { Data = RequestData };
        var res = await NSwagClient.InheritanceAsync(payload);
        Assert.That(res, Is.Not.Null);
        Assert.That(res.Data?.Length, Is.EqualTo(12));
    }

    [Test]
    public override async Task TestOpenApiGenerator()
    {
        var payload = new OpenApiGenerator.Client.Model.SandboxInheritance(RequestData);
        var res = await OagClient.ApiSandboxInheritancePostAsync(payload);
        Assert.That(res.IsOk, Is.True);
        var response = res.Ok();
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Data?.Length, Is.EqualTo(12));
    }
}
