using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientWrapper
{
    public static class Caller
    {
        internal static TResult Call<TResult>(this HttpClient client, Func<HttpClient, Task<HttpResponseMessage>> func,
            string api)
        {
            try
            {
                using (var send = func(client).GetAwaiter().GetResult())
                {
                    var result = send.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    if (send.IsSuccessStatusCode)
                        return string.IsNullOrWhiteSpace(result)
                            ? default
                            : JsonConvert.DeserializeObject<TResult>(result);
                    throw new Exception(result);
                }
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"Error accessing interface {api} , error message: {e.Message}", e);
            }
        }

        internal static string Call(this HttpClient client, Func<HttpClient, Task<HttpResponseMessage>> func,
            string api)
        {
            try
            {
                using (var send = func(client).GetAwaiter().GetResult())
                {
                    var result = send.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    if (send.IsSuccessStatusCode)
                        return result;
                    throw new Exception(result);
                }
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"Error accessing interface {api} , error message: {e.Message}", e);
            }
        }

        internal static async Task<TResult> CallAsync<TResult>(this HttpClient client,
            Func<HttpClient, Task<HttpResponseMessage>> func, string api, bool continueOnCapturedContext)
        {
            try
            {
                string result;
                using (var send = await func(client).ConfigureAwait(continueOnCapturedContext))
                {
                    result = await send.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext);
                    if (!send.IsSuccessStatusCode) throw new Exception(result);
                }

                return string.IsNullOrWhiteSpace(result) ? default : JsonConvert.DeserializeObject<TResult>(result);
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"Error accessing interface {api} , error message: {e.Message}", e);
            }
        }

        internal static async Task<string> CallAsync(this HttpClient client,
            Func<HttpClient, Task<HttpResponseMessage>> func,
            string api, bool continueOnCapturedContext)
        {
            try
            {
                string result;
                using (var send = await func(client).ConfigureAwait(continueOnCapturedContext))
                {
                    result = await send.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext);
                    if (!send.IsSuccessStatusCode) throw new Exception(result);
                }

                return result;
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"Error accessing interface {api} , error message: {e.Message}", e);
            }
        }
    }
}