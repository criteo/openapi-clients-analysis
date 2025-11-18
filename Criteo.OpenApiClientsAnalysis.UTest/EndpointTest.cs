using Criteo.OpenApiClientsAnalysis.OpenApiGenerator.Client.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using KiotaClient = Criteo.OpenApiClientsAnalysis.Kiota.Client.ApiClient;
using NSwagClient = Criteo.OpenApiClientsAnalysis.NSwag.Client.Client;
using OpenApiGeneratorClient = Criteo.OpenApiClientsAnalysis.OpenApiGenerator.Client.Api.IDefaultApi;

namespace Criteo.OpenApiClientsAnalysis.UTest;

public abstract class EndpointTest
{
    private const string BaseUrl = "http://127.0.0.1:4010";

    protected KiotaClient KiotaClient;
    protected NSwagClient NSwagClient;
    protected OpenApiGeneratorClient OagClient;

    [SetUp]
    public void Setup()
    {
        // Initialize Kiota client
        KiotaClient = new(new HttpClientRequestAdapter(new AnonymousAuthenticationProvider()) { BaseUrl = BaseUrl });

        // Initialize NSwag client
        NSwagClient = new(BaseUrl, new());

        // Initialize OpenAPI Generator client using DI
        var services = new ServiceCollection();
        services.AddApi(config => { config.AddApiHttpClients(client => client.BaseAddress = new(BaseUrl)); });
        var provider = services.BuildServiceProvider();
        OagClient = provider.GetRequiredService<OpenApiGeneratorClient>();
    }

    [Test]
    public abstract Task TestKiota();

    [Test]
    public abstract Task TestNSwag();

    [Test]
    public abstract Task TestOpenApiGenerator();
}
