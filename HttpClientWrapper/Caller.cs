using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientWrapper
{
    public static class Caller
    {
        internal static TResult Call<TResult>(this IClient client, Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            using (var send = func(client.HttpClient).GetAwaiter().GetResult())
            {
                var result = send.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (send.IsSuccessStatusCode)
                    return string.IsNullOrWhiteSpace(result) ? default : JsonConvert.DeserializeObject<TResult>(result);
                throw new HttpRequestException(result);
            }
        }

        internal static void Call(this IClient client, Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            using (var send = func(client.HttpClient).GetAwaiter().GetResult())
            {
                if (!send.IsSuccessStatusCode)
                    throw new HttpRequestException(send.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            }
        }

        internal static async Task<TResult> CallAsync<TResult>(this IClient client,
            Func<HttpClient, Task<HttpResponseMessage>> func, bool continueOnCapturedContext)
        {
            string result;
            using (var send = await func(client.HttpClient).ConfigureAwait(continueOnCapturedContext))
            {
                result = await send.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext);
                if (!send.IsSuccessStatusCode) throw new HttpRequestException(result);
            }

            return string.IsNullOrWhiteSpace(result) ? default : JsonConvert.DeserializeObject<TResult>(result);
        }

        internal static async Task CallAsync(this IClient client, Func<HttpClient, Task<HttpResponseMessage>> func,
            bool continueOnCapturedContext)
        {
            using (var send = await func(client.HttpClient).ConfigureAwait(continueOnCapturedContext))
            {
                if (!send.IsSuccessStatusCode)
                {
                    var result = await send.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext);
                    throw new HttpRequestException(result);
                }
            }
        }
    }
}