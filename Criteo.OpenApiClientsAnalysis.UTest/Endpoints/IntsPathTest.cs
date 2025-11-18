namespace Criteo.OpenApiClientsAnalysis.UTest.Endpoints;

public class IntsPathTest : EndpointTest
{
    [Test]
    public override async Task TestKiota()
    {
        var res = await KiotaClient.Api.Sandbox.IntsPath
            // BROKEN API: parameter order messed up
            .WithUbWithSWithUsWithIWithUiWithLWithUl(ub: 2, s: 3, us: 4, i: 5, ui: 6, l: 7, ul: 8)
            .GetAsync();

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
        var res = await NSwagClient.IntsPathAsync(2, 3, 4, 5, 6, 7, 8);

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
    public override async Task TestOpenApiGenerator()
    {
        var res = await OagClient.ApiSandboxIntsPathUbSUsIUiLUlGetAsync(2, 3, 4, 5, 6, 7, 8);

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
