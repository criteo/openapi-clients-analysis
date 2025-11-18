using Microsoft.Kiota.Abstractions.Serialization;

namespace Criteo.OpenApiClientsAnalysis.UTest.Endpoints;

public class ArrayOfArrayTest : EndpointTest
{
    private static readonly List<List<int>> RequestArrayOfArray = new()
    {
        new() { 1, 2, 3 },
        new() { 4, 5, 6 },
    };

    [Test]
    public override async Task TestKiota()
    {
        // kiota: untyped request and response
        var kiotaRequest = new UntypedArray(
            RequestArrayOfArray.Select(inner => new UntypedArray(
                inner.Select(x => new UntypedInteger(x)).ToList())).ToList());
        var res = await KiotaClient.Api.Sandbox.Arrayofarray.PostAsync(kiotaRequest);
        Assert.That(res, Is.Not.Null);
        var resArray = (res as UntypedArray)!.GetValue().ToList();
        Assert.That(resArray, Has.Count.EqualTo(2));
        var arr0 = (resArray[0] as UntypedArray)!.GetValue().ToList();
        Assert.That(arr0, Has.Count.EqualTo(3));
        Assert.That((arr0[0] as UntypedInteger)?.GetValue(), Is.EqualTo(1));
        Assert.That((arr0[1] as UntypedInteger)?.GetValue(), Is.EqualTo(2));
        Assert.That((arr0[2] as UntypedInteger)?.GetValue(), Is.EqualTo(3));
        var arr1 = (resArray[1] as UntypedArray)!.GetValue().ToList();
        Assert.That(arr1, Has.Count.EqualTo(3));
        Assert.That((arr1[0] as UntypedInteger)?.GetValue(), Is.EqualTo(4));
        Assert.That((arr1[1] as UntypedInteger)?.GetValue(), Is.EqualTo(5));
        Assert.That((arr1[2] as UntypedInteger)?.GetValue(), Is.EqualTo(6));
    }

    [Test]
    public override async Task TestNSwag()
    {
        // nswag: ICollection<ICollection<int>> response
        var res = await NSwagClient.ArrayofarrayAsync(RequestArrayOfArray);
        Assert.That(res, Is.Not.Null);
        Assert.That(res, Has.Count.EqualTo(2));
        var arr0 = res.ElementAt(0);
        Assert.That(arr0, Has.Count.EqualTo(3));
        Assert.That(arr0.ElementAt(0), Is.EqualTo(1));
        Assert.That(arr0.ElementAt(1), Is.EqualTo(2));
        Assert.That(arr0.ElementAt(2), Is.EqualTo(3));
        var arr1 = res.ElementAt(1);
        Assert.That(arr1, Has.Count.EqualTo(3));
        Assert.That(arr1.ElementAt(0), Is.EqualTo(4));
        Assert.That(arr1.ElementAt(1), Is.EqualTo(5));
        Assert.That(arr1.ElementAt(2), Is.EqualTo(6));
    }

    [Test]
    public override async Task TestOpenApiGenerator()
    {
        // OAG: List<List<int>> response
        var res = await OagClient.ApiSandboxArrayofarrayPostAsync(RequestArrayOfArray);
        Assert.That(res.IsOk, Is.True);
        var response = res.Ok();
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Has.Count.EqualTo(2));
        Assert.That(response[0], Has.Count.EqualTo(3));
        Assert.That(response[0][0], Is.EqualTo(1));
        Assert.That(response[0][1], Is.EqualTo(2));
        Assert.That(response[0][2], Is.EqualTo(3));
        Assert.That(response[1], Has.Count.EqualTo(3));
        Assert.That(response[1][0], Is.EqualTo(4));
        Assert.That(response[1][1], Is.EqualTo(5));
        Assert.That(response[1][2], Is.EqualTo(6));
    }
}
