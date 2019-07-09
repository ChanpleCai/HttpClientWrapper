using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientWrapper
{
    public static class Caller
    {
        internal static TResult Call<TResult>(this HttpClient client, Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            using (var send = func(client).GetAwaiter().GetResult())
            {
                var result = send.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (send.IsSuccessStatusCode)
                {
                    return string.IsNullOrWhiteSpace(result) ? default : JsonConvert.DeserializeObject<TResult>(result);
                }
                throw new HttpRequestException(result);
            }
        }

        internal static void Call(this HttpClient client, Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            using (var send = func(client).GetAwaiter().GetResult())
            {
                if (!send.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(send.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
        }

        internal static async Task<TResult> CallAsync<TResult>(this HttpClient client, Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            string result;
            using (var send = await func(client))
            {
                result = await send.Content.ReadAsStringAsync();
                if (!send.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(result);
                }
            }

            return string.IsNullOrWhiteSpace(result) ? default : JsonConvert.DeserializeObject<TResult>(result);
        }

        internal static async Task CallAsync(this HttpClient client, Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            using (var send = await func(client))
            {
                if (!send.IsSuccessStatusCode)
                {
                    var result = await send.Content.ReadAsStringAsync();
                    throw new HttpRequestException(result);
                }
            }
        }
    }
}
