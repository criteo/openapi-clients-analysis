import asyncio

import httpx
from client.api_client import ApiClient
from kiota_abstractions.authentication.anonymous_authentication_provider import (
    AnonymousAuthenticationProvider,
)
from kiota_http.httpx_request_adapter import HttpxRequestAdapter


async def main():
    request_adapter = HttpxRequestAdapter(
        AnonymousAuthenticationProvider(),
        http_client=httpx.AsyncClient(base_url="http://127.0.0.1:4010"),
    )
    client = ApiClient(request_adapter)
    resp = await client.api.sandbox.arrayofarray.post([[1, 2, 3], [4, 5, 6]])
    assert resp
    print(resp)


if __name__ == "__main__":
    asyncio.run(main())
