namespace Criteo.OpenApiClientsAnalysis.UTest.Endpoints;

public class ArrayOfArrayRecordTest : EndpointTest
{
    [Test]
    public override async Task TestKiota()
    {
        var res = await KiotaClient.Api.Sandbox.Arrayofarrayrecord.PostAsync(
        [
            new() { Items = [1, 2, 3] },
            new() { Items = [4, 5, 6] },
        ]);
        Assert.That(res, Is.Not.Null);
        Assert.That(res, Has.Count.EqualTo(2));
        Assert.That(res[0].Items, Is.Not.Null);
        Assert.That(res[0].Items, Has.Count.EqualTo(3));
        Assert.That(res[0].Items[0], Is.EqualTo(1));
        Assert.That(res[0].Items[1], Is.EqualTo(2));
        Assert.That(res[0].Items[2], Is.EqualTo(3));
        Assert.That(res[1].Items, Is.Not.Null);
        Assert.That(res[1].Items, Has.Count.EqualTo(3));
        Assert.That(res[1].Items[0], Is.EqualTo(4));
        Assert.That(res[1].Items[1], Is.EqualTo(5));
        Assert.That(res[1].Items[2], Is.EqualTo(6));
    }

    [Test]
    public override async Task TestNSwag()
    {
        var res = await NSwagClient.ArrayofarrayrecordAsync(
        [
            new() { Items = [1, 2, 3] },
            new() { Items = [4, 5, 6] },
        ]);
        Assert.That(res, Is.Not.Null);
        Assert.That(res, Has.Count.EqualTo(2));
        var arr0 = res.ElementAt(0);
        Assert.That(arr0.Items, Is.Not.Null);
        Assert.That(arr0.Items, Has.Count.EqualTo(3));
        Assert.That(arr0.Items.ElementAt(0), Is.EqualTo(1));
        Assert.That(arr0.Items.ElementAt(1), Is.EqualTo(2));
        Assert.That(arr0.Items.ElementAt(2), Is.EqualTo(3));
        var arr1 = res.ElementAt(1);
        Assert.That(arr1.Items, Is.Not.Null);
        Assert.That(arr1.Items, Has.Count.EqualTo(3));
        Assert.That(arr1.Items.ElementAt(0), Is.EqualTo(4));
        Assert.That(arr1.Items.ElementAt(1), Is.EqualTo(5));
        Assert.That(arr1.Items.ElementAt(2), Is.EqualTo(6));
    }

    [Test]
    public override async Task TestOpenApiGenerator()
    {
        var res = await OagClient.ApiSandboxArrayofarrayrecordPostAsync(
        [
            new([1, 2, 3]),
            new([4, 5, 6]),
        ]);
        Assert.That(res.IsOk, Is.True);
        var response = res.Ok();
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Has.Count.EqualTo(2));
        Assert.That(response[0].Items, Is.Not.Null);
        Assert.That(response[0].Items, Has.Count.EqualTo(3));
        Assert.That(response[0].Items[0], Is.EqualTo(1));
        Assert.That(response[0].Items[1], Is.EqualTo(2));
        Assert.That(response[0].Items[2], Is.EqualTo(3));
        Assert.That(response[1].Items, Is.Not.Null);
        Assert.That(response[1].Items, Has.Count.EqualTo(3));
        Assert.That(response[1].Items[0], Is.EqualTo(4));
        Assert.That(response[1].Items[1], Is.EqualTo(5));
        Assert.That(response[1].Items[2], Is.EqualTo(6));
    }
}
