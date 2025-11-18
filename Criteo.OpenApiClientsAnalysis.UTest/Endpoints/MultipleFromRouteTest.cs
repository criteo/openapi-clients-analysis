namespace Criteo.OpenApiClientsAnalysis.UTest.Endpoints;

public class MultipleFromRouteTest : EndpointTest
{
    [Test]
    public override async Task TestKiota()
    {
        var res = await KiotaClient.Api.Sandbox.MultipleFromRoute["first"]["second"]["third"].PostAsync();
        Assert.That(res, Is.EqualTo("first,second,third"));
    }

    [Test]
    public override async Task TestNSwag()
    {
        var res = await NSwagClient.MultipleFromRouteAsync("first", "second", "third");
        Assert.That(res, Is.EqualTo("first,second,third"));
    }

    [Test]
    public override async Task TestOpenApiGenerator()
    {
        var res = await OagClient.ApiSandboxMultipleFromRouteFirstSecondThirdPostAsync("first", "second", "third");
        Assert.That(res.IsOk, Is.True);
        var response = res.Ok();
        Assert.That(response, Is.EqualTo("first,second,third"));
    }
}
