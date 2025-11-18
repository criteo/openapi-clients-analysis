using System.Text;

namespace Criteo.OpenApiClientsAnalysis.UTest.Endpoints;

public class ByteArrayTest : EndpointTest
{
    private static readonly byte[] TestData = [1, 2, 3, 4, 5];
    private static readonly byte[] ExpectedMockResponse = Encoding.UTF8.GetBytes("binaryvalue");

    [Test]
    public override async Task TestKiota()
    {
        using var stream = new MemoryStream(TestData);
        var res = await KiotaClient.Api.Sandbox.Bytearray.PostAsync(stream);

        Assert.That(res, Is.Not.Null);
        using var resultStream = new MemoryStream();
        await res.CopyToAsync(resultStream);
        var resultBytes = resultStream.ToArray();
        Assert.That(resultBytes, Is.EqualTo(ExpectedMockResponse));
    }

    [Test]
    public override async Task TestNSwag()
    {
        using var stream = new MemoryStream(TestData);
        var res = await NSwagClient.BytearrayAsync(stream);

        Assert.That(res, Is.Not.Null);
        Assert.That(res.Stream, Is.Not.Null);
        using var resultStream = new MemoryStream();
        await res.Stream.CopyToAsync(resultStream);
        var resultBytes = resultStream.ToArray();
        Assert.That(resultBytes, Is.EqualTo(ExpectedMockResponse));
    }

    [Test]
    public override async Task TestOpenApiGenerator()
    {
        using var stream = new MemoryStream(TestData);
        var res = await OagClient.ApiSandboxBytearrayPostAsync(stream);

        Assert.That(res.IsOk, Is.True);
        var response = res.Ok();
        Assert.That(response, Is.Not.Null);
        using var resultStream = new MemoryStream();
        await response.CopyToAsync(resultStream);
        var resultBytes = resultStream.ToArray();
        Assert.That(resultBytes, Is.EqualTo(ExpectedMockResponse));
    }
}
