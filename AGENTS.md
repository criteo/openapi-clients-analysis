# Agent Instructions

## Build Commands

- **Build all clients**: `make -j4` (generates OpenAPI clients in parallel)
- **Setup Python env**: `uv sync` (only after generating clients)
- **Build .NET tests**: `dotnet build`
- **Run all tests**: `dotnet test`
- **Run single test**: `dotnet test --filter "FullyQualifiedName~<TestClassName>.<TestMethodName>"`

## Architecture

This is an OpenAPI client generation comparison project analyzing Kiota, NSwag, and OpenAPI Generator for C# and Python.

- **Source**: `openapi.yaml` - OpenAPI spec that drives all client generation
- **Clients**: `clients/dotnet/` (Kiota, NSwag, OpenApiGenerator), `clients/python/` (kiota, openapi-generator)
- **Tests**: `Criteo.OpenApiClientsAnalysis.UTest/` - NUnit tests comparing all three client libraries
- **Base test**: All endpoint tests inherit from `EndpointTest.cs` which initializes all three clients

## Code Style

- **C# (.NET 8)**: Nullable enabled, implicit usings, follow standard .NET conventions
- **Test framework**: NUnit with async test methods returning `Task`
- **Naming**: PascalCase for types/methods, namespace matches project structure
- **DI pattern**: OpenAPI Generator client uses ServiceCollection/DI, others use direct instantiation

## Workflow for Adding New Endpoints

1. **Add endpoint to OpenAPI spec**: Add new `/api/sandbox/<something>` endpoint to `openapi.yaml` with request/response schemas and include an example response (used by Prism mock server)
2. **Generate clients**: Run `make -j4` to regenerate all clients
3. **Restore dependencies**: Run `dotnet restore Criteo.OpenApiClientsAnalysis.UTest/Criteo.OpenApiClientsAnalysis.UTest.csproj`
4. **Create test class**: Add new `<Feature>Test.cs` in `Criteo.OpenApiClientsAnalysis.UTest/Endpoints/` extending `EndpointTest` with three test methods: `TestKiota()`, `TestNSwag()`, `TestOpenApiGenerator()` using `KiotaClient`, `NSwagClient`, and `OagClient` properties
5. **Build and check**: Run `dotnet build` and fix any compilation issues
6. **Run mock server**: Execute `./mock.sh` to start Prism mock server on port 4010
7. **Run tests**: Execute `dotnet test` to verify all three clients behave correctly
