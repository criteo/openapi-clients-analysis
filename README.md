# openapi-clients-analysis

This project aims to provide a setup to generate OpenAPI clients in various languages using multiple toolchains and to compare them.

## Getting Started

**Requirements:**

- `make` (generator tasks)
- [.NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (Kiota, NSwag, and C# tests)
- [`uv` and `uvx`](https://github.com/astral-sh/uv) (OpenAPI Generator, and Python tests)
- [Node.js and `npx`](https://nodejs.org/en) (OpenAPI mock server)

```sh
git clone https://github.com/criteo/openapi-clients-analysis.git
cd openapi-clients-analysis/
make
```

## Features

### Current setup

| Language | Generators                                           |
| -------- | ---------------------------------------------------- |
| C#       | Kiota 1.29.0, NSwag 14.6.2, OpenAPI Generator 7.17.0 |
| Python   | Kiota 1.29.0, OpenAPI Generator 7.17.0               |

### Specification and client generation

API endpoints are described in the [`openapi.yaml`](openapi.yaml) OpenAPI 3.0 specification. We generate all clients directly from it.

Each generated client corresponds to a task in the [`Makefile`](Makefile). To generate all the clients, simply run:

```sh
make  # add -j4 to build them in parallel
```

The outputs are in the [`clients`](clients) directory.

### OpenAPI mock server

To mock the OpenAPI specification, run:

```sh
./mock.sh
```

This launches a [Prism](https://github.com/stoplightio/prism) mock server on http://127.0.0.1:4010 that listens to all specified endpoints, validates requests, and returns the responses defined under `example:` in each endpoint’s specification.

### C# tests

A NUnit suite to test all three C# clients is maintained in [`Criteo.OpenApiClientsAnalysis.UTest`](Criteo.OpenApiClientsAnalysis.UTest).

To run the tests, **start the mock server**, then:

```sh
dotnet test
```

### Python tests

No proper test suite yet, just some playground scripts colocated next to the generated clients in [`clients/python`](clients/python).

```sh
uv sync   # setup .venv and install clients
uv run <script.py>
```
