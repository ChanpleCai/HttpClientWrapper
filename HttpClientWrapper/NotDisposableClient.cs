using System.Net.Http;

namespace HttpClientWrapper
{
    public class NotDisposableClient : IClient
    {
        public NotDisposableClient(HttpClient client)
        {
            HttpClient = client;
        }

        public HttpClient HttpClient { get; set; }

        public static implicit operator NotDisposableClient(HttpClient client) =>
            new NotDisposableClient(client);
    }
}