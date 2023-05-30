namespace Sequoia.Client.Http.PoC.Tests
{
    public class TestRepository
    {
        private readonly IClient _client;

        public TestRepository(IClient client)
        {
            _client = client;
        }

        public async Task MakeQuery()
        {
            _client
                .Path("https://google.com")
                .Path("fit-api/equipments")
                .Query("?id=10")
                .Query(new { id = 10, type = 2 })
                .Auth("Bearer token")
                .Auth("Basic token")
                .Auth()
                .Headers("x-client-id", 100)
                .Body("my payload");
        }
    }
}
