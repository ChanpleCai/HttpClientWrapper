using System;
using System.Net.Http;

namespace HttpClientWrapper
{
    public class DisposableClient : IClient, IDisposable
    {
        public DisposableClient(HttpClient client)
        {
            HttpClient = client;
        }

        public HttpClient HttpClient { get; set; }

        public static implicit operator DisposableClient(HttpClient client)
            => new DisposableClient(client);

        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}