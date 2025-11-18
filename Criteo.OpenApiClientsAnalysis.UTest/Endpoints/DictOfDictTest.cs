using Microsoft.Kiota.Abstractions.Serialization;

namespace Criteo.OpenApiClientsAnalysis.UTest.Endpoints;

public class DictOfDictTest : EndpointTest
{
    [Test]
    public override async Task TestKiota()
    {
        var res = await KiotaClient.Api.Sandbox.DictOfDict.PostAsDictOfDictPostResponseAsync(new()
        {
            // kiota: untyped request body IDictionary<string, object>
            AdditionalData =
            {
                ["first"] = new Dictionary<string, object> { ["a"] = 1, ["b"] = 2 },
                ["second"] = new Dictionary<string, object> { ["c"] = 3, ["d"] = 4 }
            }
        });
        Assert.That(res, Is.Not.Null);
        Assert.That(res.AdditionalData, Is.Not.Null);
        Assert.That(res.AdditionalData["dummy"], Is.Not.Null);
        // kiota: untyped response
        var dummyDict = ((UntypedObject)res.AdditionalData["dummy"]).GetValue();
        Assert.That(dummyDict, Is.Not.Null);
        Assert.That(((UntypedInteger)dummyDict["first"]).GetValue(), Is.EqualTo(1));
        Assert.That(((UntypedInteger)dummyDict["second"]).GetValue(), Is.EqualTo(2));
        Assert.That(((UntypedInteger)dummyDict["third"]).GetValue(), Is.EqualTo(3));
    }

    [Test]
    public override async Task TestNSwag()
    {
        var res = await NSwagClient.DictOfDictAsync(new Dictionary<string, IDictionary<string, int>>
        {
            ["first"] = new Dictionary<string, int>
            {
                ["a"] = 1,
                ["b"] = 2
            },
            ["second"] = new Dictionary<string, int>
            {
                ["c"] = 3,
                ["d"] = 4
            }
        });
        Assert.That(res, Is.Not.Null);
        Assert.That(res["dummy"], Is.Not.Null);
        Assert.That(res["dummy"]["first"], Is.EqualTo(1));
        Assert.That(res["dummy"]["second"], Is.EqualTo(2));
        Assert.That(res["dummy"]["third"], Is.EqualTo(3));
    }

    [Test]
    public override async Task TestOpenApiGenerator()
    {
        var res = await OagClient.ApiSandboxDictOfDictPostAsync(new()
        {
            ["first"] = new()
            {
                ["a"] = 1,
                ["b"] = 2
            },
            ["second"] = new()
            {
                ["c"] = 3,
                ["d"] = 4
            }
        });
        Assert.That(res.IsOk, Is.True);
        var response = res.Ok();
        Assert.That(response, Is.Not.Null);
        Assert.That(response["dummy"], Is.Not.Null);
        Assert.That(response["dummy"]["first"], Is.EqualTo(1));
        Assert.That(response["dummy"]["second"], Is.EqualTo(2));
        Assert.That(response["dummy"]["third"], Is.EqualTo(3));
    }
}
