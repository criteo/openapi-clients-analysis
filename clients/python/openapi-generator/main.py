import asyncio

from openapi_client import ApiClient, Configuration, DefaultApi


async def main():
    async with ApiClient(Configuration(host="http://127.0.0.1:4010")) as api_client:
        client = DefaultApi(api_client)
        resp = await client.api_sandbox_arrayofarray_post([[1, 2, 3], [4, 5, 6]])
        print(resp)


if __name__ == "__main__":
    asyncio.run(main())
