using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientWrapper
{
    public static class ClientWrapper
    {
        #region Client

        private static readonly Lazy<NotDisposableClient> MainClient =
            new Lazy<NotDisposableClient>(() => new NotDisposableClient(new HttpClient()), LazyThreadSafetyMode.ExecutionAndPublication);

        public static NotDisposableClient Client() => MainClient.Value;

        public static DisposableClient Client(Action<HttpClient> action)
        {
            DisposableClient client = new HttpClient();

            action(client.HttpClient);

            return client;
        }

        #endregion

        #region NotDisposableClient

        #region Send

        public static void Send(HttpRequestMessage request)
            => MainClient.Value.Call(_ => _.SendAsync(request));

        public static TResult Send<TResult>(HttpRequestMessage request)
            => MainClient.Value.Call<TResult>(_ => _.SendAsync(request));

        public static Task SendAsync(HttpRequestMessage request, bool continueOnCapturedContext = true)
            => MainClient.Value.CallAsync(_ => _.SendAsync(request), continueOnCapturedContext);

        public static Task<TResult> SendAsync<TResult>(HttpRequestMessage request,
            bool continueOnCapturedContext = true)
            => MainClient.Value.CallAsync<TResult>(_ => _.SendAsync(request), continueOnCapturedContext);

        #endregion

        #region Get

        public static void Get(string uri)
            => MainClient.Value.Call(_ => _.GetAsync(uri));

        public static TResult Get<TResult>(string uri)
            => MainClient.Value.Call<TResult>(_ => _.GetAsync(uri));

        public static Task GetAsync(string uri, bool continueOnCapturedContext = true)
            => MainClient.Value.CallAsync(_ => _.GetAsync(uri), continueOnCapturedContext);

        public static Task<TResult> GetAsync<TResult>(string uri, bool continueOnCapturedContext = true)
            => MainClient.Value.CallAsync<TResult>(_ => _.GetAsync(uri), continueOnCapturedContext);

        #endregion

        #region Post

        public static void Post(string uri, HttpContent content = null)
            => MainClient.Value.Call(_ => _.PostAsync(uri, content));

        public static TResult Post<TResult>(string uri, HttpContent content = null)
            => MainClient.Value.Call<TResult>(_ => _.PostAsync(uri, content));

        public static Task PostAsync(string uri, HttpContent content = null, bool continueOnCapturedContext = true)
            => MainClient.Value.CallAsync(_ => _.PostAsync(uri, content), continueOnCapturedContext);

        public static Task<TResult> PostAsync<TResult>(string uri, HttpContent content = null,
            bool continueOnCapturedContext = true)
            => MainClient.Value.CallAsync<TResult>(_ => _.PostAsync(uri, content), continueOnCapturedContext);

        #endregion

        #region Put

        public static void Put(string uri, HttpContent content = null)
            => MainClient.Value.Call(_ => _.PutAsync(uri, content));

        public static TResult Put<TResult>(string uri, HttpContent content = null)
            => MainClient.Value.Call<TResult>(_ => _.PutAsync(uri, content));

        public static Task PutAsync(string uri, HttpContent content = null, bool continueOnCapturedContext = true)
            => MainClient.Value.CallAsync(_ => _.PutAsync(uri, content), continueOnCapturedContext);

        public static Task<TResult> PutAsync<TResult>(string uri, HttpContent content = null,
            bool continueOnCapturedContext = true)
            => MainClient.Value.CallAsync<TResult>(_ => _.PutAsync(uri, content), continueOnCapturedContext);

        #endregion

        #region Delete

        public static void Delete(string uri)
            => MainClient.Value.Call(_ => _.DeleteAsync(uri));

        public static TResult Delete<TResult>(string uri)
            => MainClient.Value.Call<TResult>(_ => _.DeleteAsync(uri));

        public static Task DeleteAsync(string uri, bool continueOnCapturedContext = true)
            => MainClient.Value.CallAsync(_ => _.DeleteAsync(uri), continueOnCapturedContext);

        public static Task<TResult> DeleteAsync<TResult>(string uri, bool continueOnCapturedContext = true)
            => MainClient.Value.CallAsync<TResult>(_ => _.DeleteAsync(uri), continueOnCapturedContext);

        #endregion

        #endregion

        #region DisposableClient

        #region Send

        public static void Send(this IClient client, HttpRequestMessage request)
            => client.Call(_ => _.SendAsync(request));

        public static TResult Send<TResult>(this IClient client, HttpRequestMessage request)
            => client.Call<TResult>(_ => _.SendAsync(request));

        public static Task SendAsync(this IClient client, HttpRequestMessage request,
            bool continueOnCapturedContext = true)
            => client.CallAsync(_ => _.SendAsync(request), continueOnCapturedContext);

        public static Task<TResult> SendAsync<TResult>(this IClient client, HttpRequestMessage request,
            bool continueOnCapturedContext = true)
            => client.CallAsync<TResult>(_ => _.SendAsync(request), continueOnCapturedContext);

        #endregion

        #region Get

        public static void Get(this IClient client, string uri)
            => client.Call(_ => _.GetAsync(uri));

        public static TResult Get<TResult>(this IClient client, string uri)
            => client.Call<TResult>(_ => _.GetAsync(uri));

        public static Task GetAsync(this IClient client, string uri, bool continueOnCapturedContext = true)
            => client.CallAsync(_ => _.GetAsync(uri), continueOnCapturedContext);

        public static Task<TResult> GetAsync<TResult>(this IClient client, string uri,
            bool continueOnCapturedContext = true)
            => client.CallAsync<TResult>(_ => _.GetAsync(uri), continueOnCapturedContext);

        #endregion

        #region Post

        public static void Post(this IClient client, string uri, HttpContent content = null)
            => client.Call(_ => _.PostAsync(uri, content));

        public static TResult Post<TResult>(this IClient client, string uri, HttpContent content = null)
            => client.Call<TResult>(_ => _.PostAsync(uri, content));


        public static Task PostAsync(this IClient client, string uri, HttpContent content = null,
            bool continueOnCapturedContext = true)
            => client.CallAsync(_ => _.PostAsync(uri, content), continueOnCapturedContext);

        public static Task<TResult> PostAsync<TResult>(this IClient client, string uri, HttpContent content = null,
            bool continueOnCapturedContext = true)
            => client.CallAsync<TResult>(_ => _.PostAsync(uri, content), continueOnCapturedContext);

        #endregion

        #region Put

        public static void Put(this IClient client, string uri, HttpContent content = null)
            => client.Call(_ => _.PutAsync(uri, content));

        public static TResult Put<TResult>(this IClient client, string uri, HttpContent content = null)
            => client.Call<TResult>(_ => _.PutAsync(uri, content));

        public static Task PutAsync(this IClient client, string uri, HttpContent content = null,
            bool continueOnCapturedContext = true)
            => client.CallAsync(_ => _.PutAsync(uri, content), continueOnCapturedContext);

        public static Task<TResult> PutAsync<TResult>(this IClient client, string uri, HttpContent content = null,
            bool continueOnCapturedContext = true)
            => client.CallAsync<TResult>(_ => _.PutAsync(uri, content), continueOnCapturedContext);

        #endregion

        #region Delete

        public static void Delete(this IClient client, string uri)
            => client.Call(_ => _.DeleteAsync(uri));

        public static TResult Delete<TResult>(this IClient client, string uri)
            => client.Call<TResult>(_ => _.DeleteAsync(uri));

        public static Task DeleteAsync(this IClient client, string uri, bool continueOnCapturedContext = true)
            => client.CallAsync(_ => _.DeleteAsync(uri), continueOnCapturedContext);

        public static Task<TResult> DeleteAsync<TResult>(this IClient client, string uri,
            bool continueOnCapturedContext = true)
            => client.CallAsync<TResult>(_ => _.DeleteAsync(uri), continueOnCapturedContext);

        #endregion

        #endregion
    }
}