OPENAPI_SPEC=openapi.yaml
OPENAPI_GENERATOR_VERSION=7.17.0

CLIENTS_DIR=clients
TMP_DIR=$(CLIENTS_DIR)/tmp
DOTNET_CLIENTS_DIR=$(CLIENTS_DIR)/dotnet
PYTHON_CLIENTS_DIR=$(CLIENTS_DIR)/python

KIOTA_CSHARP_DIR=$(DOTNET_CLIENTS_DIR)/Criteo.OpenApiClientsAnalysis.Kiota.Client
NSWAG_CSHARP_DIR=$(DOTNET_CLIENTS_DIR)/Criteo.OpenApiClientsAnalysis.NSwag.Client
OAG_CSHARP_DIR=$(DOTNET_CLIENTS_DIR)/Criteo.OpenApiClientsAnalysis.OpenApiGenerator.Client

KIOTA_PYTHON_DIR=$(PYTHON_CLIENTS_DIR)/kiota
OAG_PYTHON_DIR=$(PYTHON_CLIENTS_DIR)/openapi-generator

.PHONY: all dotnet-tool-restore kiota-csharp kiota-python nswag-csharp openapi-generator-csharp openapi-generator-python

all: kiota-csharp kiota-python nswag-csharp openapi-generator-csharp openapi-generator-python

dotnet-tool-restore:
	dotnet tool restore

kiota-csharp: dotnet-tool-restore
	rm -rf $(KIOTA_CSHARP_DIR)/client
	dotnet kiota generate -d $(OPENAPI_SPEC) -l CSharp -n Criteo.OpenApiClientsAnalysis.Kiota.Client -o $(KIOTA_CSHARP_DIR)/client

kiota-python: dotnet-tool-restore
	rm -rf $(KIOTA_PYTHON_DIR)/client
	dotnet kiota generate -d $(OPENAPI_SPEC) -l Python -o $(KIOTA_PYTHON_DIR)/client

nswag-csharp: dotnet-tool-restore
	rm -rf $(NSWAG_CSHARP_DIR)/client
	dotnet nswag openapi2csclient /input:$(OPENAPI_SPEC) /namespace:Criteo.OpenApiClientsAnalysis.NSwag.Client /output:$(NSWAG_CSHARP_DIR)/client/Client.cs

openapi-generator-csharp:
	rm -rf $(OAG_CSHARP_DIR)/client $(TMP_DIR)
	uvx openapi-generator-cli@$(OPENAPI_GENERATOR_VERSION) generate -i $(OPENAPI_SPEC) -g csharp -o $(TMP_DIR) --package-name Criteo.OpenApiClientsAnalysis.OpenApiGenerator.Client --additional-properties=targetFramework=net8.0
	mv $(TMP_DIR)/src/Criteo.OpenApiClientsAnalysis.OpenApiGenerator.Client $(OAG_CSHARP_DIR)/client
	mv $(OAG_CSHARP_DIR)/client/Criteo.OpenApiClientsAnalysis.OpenApiGenerator.Client.csproj $(OAG_CSHARP_DIR)/
	rm -rf $(TMP_DIR)

openapi-generator-python:
	rm -rf $(OAG_PYTHON_DIR)/client
	uvx openapi-generator-cli@$(OPENAPI_GENERATOR_VERSION) generate -i $(OPENAPI_SPEC) -g python -o $(OAG_PYTHON_DIR)/client --additional-properties=library=asyncio
