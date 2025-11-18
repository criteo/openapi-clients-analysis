using Criteo.OpenApiClientsAnalysis.Kiota.Client.Models;

namespace Criteo.OpenApiClientsAnalysis.UTest.Endpoints;

public class IntsBodyTest : EndpointTest
{
    [Test]
    public override async Task TestKiota()
    {
        var input = new SandboxIntegers
        {
            Ub = 2,
            S = 3,
            Us = 4,
            I = 5,
            Ui = 6,
            L = 7,
            Ul = 8
        };

        var res = await KiotaClient.Api.Sandbox.IntsBody.PostAsync(input);

        Assert.That(res, Is.Not.Null);
        Assert.That(res.Ub, Is.EqualTo(2));
        Assert.That(res.S, Is.EqualTo(3));
        Assert.That(res.Us, Is.EqualTo(4));
        Assert.That(res.I, Is.EqualTo(5));
        Assert.That(res.Ui, Is.EqualTo(6));
        Assert.That(res.L, Is.EqualTo(7));
        Assert.That(res.Ul, Is.EqualTo(8));
    }

    [Test]
    public override async Task TestNSwag()
    {
        var input = new NSwag.Client.SandboxIntegers
        {
            Ub = 2,
            S = 3,
            Us = 4,
            I = 5,
            Ui = 6,
            L = 7,
            Ul = 8
        };

        var res = await NSwagClient.IntsBodyAsync(input);

        Assert.That(res, Is.Not.Null);
        Assert.That(res.Ub, Is.EqualTo(2));
        Assert.That(res.S, Is.EqualTo(3));
        Assert.That(res.Us, Is.EqualTo(4));
        Assert.That(res.I, Is.EqualTo(5));
        Assert.That(res.Ui, Is.EqualTo(6));
        Assert.That(res.L, Is.EqualTo(7));
        Assert.That(res.Ul, Is.EqualTo((ulong)8));
    }

    [Test]
    public override async Task TestOpenApiGenerator()
    {
        var input = new OpenApiGenerator.Client.Model.SandboxIntegers(ub: 2, s: 3, us: 4, i: 5, ui: 6, l: 7, ul: 8);

        var res = await OagClient.ApiSandboxIntsBodyPostAsync(input);

        Assert.That(res.IsOk, Is.True);
        var response = res.Ok();
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Ub, Is.EqualTo(2));
        Assert.That(response.S, Is.EqualTo(3));
        Assert.That(response.Us, Is.EqualTo(4));
        Assert.That(response.I, Is.EqualTo(5));
        Assert.That(response.Ui, Is.EqualTo(6));
        Assert.That(response.L, Is.EqualTo(7));
        Assert.That(response.Ul, Is.EqualTo(8));
    }
}
