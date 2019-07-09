using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientWrapper
{
    public static class HttpWrapper
    {
        #region Clilent

        private static readonly HttpClient MainClient = new HttpClient();

        public static HttpClient GetClient() => MainClient;

        // todo
        public static HttpClient NewClient(Action<HttpClient> action)
        {
            var client = new HttpClient();

            action(client);

            return client;
        }

        #endregion


        #region Send

        public static TResult Send<TResult>(this HttpClient client, HttpRequestMessage request)
            => client.Call<TResult>(_ => _.SendAsync(request));

        public static Task<TResult> SendAsync<TResult>(this HttpClient client, HttpRequestMessage request)
            => client.CallAsync<TResult>(_ => _.SendAsync(request));

        #endregion


        #region Get



        public static TResult Get<TResult>(this HttpClient client, string uri)
            => client.Call<TResult>(_ => _.GetAsync(uri));

        public static Task<TResult> GetAsync<TResult>(this HttpClient client, string uri)
            => client.CallAsync<TResult>(_ => _.GetAsync(uri));


        #endregion

        #region Post

        public static void Post(this HttpClient client, string uri, HttpContent content)
            => client.Call(_ => _.PostAsync(uri, content));

        public static TResult Post<TResult>(this HttpClient client, string uri, HttpContent content)
            => client.Call<TResult>(_ => _.PostAsync(uri, content));


        public static Task PostAsync(this HttpClient client, string uri, HttpContent content)
            => client.CallAsync(_ => _.PostAsync(uri, content));

        public static Task<TResult> PostAsync<TResult>(this HttpClient client, string uri, HttpContent content)
            => client.CallAsync<TResult>(_ => _.PostAsync(uri, content));

        #endregion

        #region Put

        public static void Put(this HttpClient client, string uri, HttpContent content)
            => client.Call(_ => _.PutAsync(uri, content));

        public static TResult Put<TResult>(this HttpClient client, string uri, HttpContent content)
            => client.Call<TResult>(_ => _.PutAsync(uri, content));

        public static Task PutAsync(this HttpClient client, string uri, HttpContent content)
            => client.CallAsync(_ => _.PutAsync(uri, content));

        public static Task<TResult> PutAsync<TResult>(this HttpClient client, string uri, HttpContent content)
            => client.CallAsync<TResult>(_ => _.PutAsync(uri, content));

        #endregion

        #region Delete

        public static void Delete(this HttpClient client, string uri)
            => client.Call(_ => _.DeleteAsync(uri));

        public static TResult Delete<TResult>(this HttpClient client, string uri)
            => client.Call<TResult>(_ => _.DeleteAsync(uri));

        public static Task DeleteAsync(this HttpClient client, string uri)
            => client.CallAsync(_ => _.DeleteAsync(uri));

        public static Task<TResult> DeleteAsync<TResult>(this HttpClient client, string uri)
            => client.CallAsync<TResult>(_ => _.DeleteAsync(uri));

        #endregion

    }
}
