using System.Net.Http;

namespace HttpClientWrapper
{
    public interface IClient
    {
        HttpClient HttpClient { get; set; }
    }
}