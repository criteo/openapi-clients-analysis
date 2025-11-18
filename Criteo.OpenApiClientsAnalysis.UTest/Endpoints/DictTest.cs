namespace Criteo.OpenApiClientsAnalysis.UTest.Endpoints;

public class DictTest : EndpointTest
{
    private static readonly Dictionary<string, int> RequestDict = new()
    {
        ["first"] = 1,
        ["second"] = 2,
        ["third"] = 3
    };

    [Test]
    public override async Task TestKiota()
    {
        var res = await KiotaClient.Api.Sandbox.Dict.PostAsDictPostResponseAsync(new()
        {
            // untyped request body IDictionary<string, object>
            AdditionalData = { ["first"] = 1, ["second"] = 2, ["third"] = 3 }
        });
        Assert.That(res, Is.Not.Null);
        Assert.That(res.AdditionalData, Is.Not.Null);
        Assert.That(res.AdditionalData["first"], Is.EqualTo(1));
        Assert.That(res.AdditionalData["second"], Is.EqualTo(2));
        Assert.That(res.AdditionalData["third"], Is.EqualTo(3));
    }

    [Test]
    public override async Task TestNSwag()
    {
        var res = await NSwagClient.DictAsync(RequestDict);
        Assert.That(res, Is.Not.Null);
        Assert.That(res["first"], Is.EqualTo(1));
        Assert.That(res["second"], Is.EqualTo(2));
        Assert.That(res["third"], Is.EqualTo(3));
    }

    [Test]
    public override async Task TestOpenApiGenerator()
    {
        var res = await OagClient.ApiSandboxDictPostAsync(RequestDict);
        Assert.That(res.IsOk, Is.True);
        var response = res.Ok();
        Assert.That(response, Is.Not.Null);
        Assert.That(response["first"], Is.EqualTo(1));
        Assert.That(response["second"], Is.EqualTo(2));
        Assert.That(response["third"], Is.EqualTo(3));
    }
}
