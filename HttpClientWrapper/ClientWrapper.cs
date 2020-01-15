using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientWrapper
{
    public static class ClientWrapper
    {
        #region Default Client

        private static readonly Lazy<HttpClient> MainClient =
            new Lazy<HttpClient>(() => new HttpClient(), LazyThreadSafetyMode.ExecutionAndPublication);

        #region Send

        public static string Send(HttpRequestMessage request)
            => MainClient.Value.Call(_ => _.SendAsync(request), request.RequestUri.ToString());

        public static TResult Send<TResult>(HttpRequestMessage request)
            => MainClient.Value.Call<TResult>(_ => _.SendAsync(request), request.RequestUri.ToString());

        public static Task<string> SendAsync(HttpRequestMessage request, bool continueOnCapturedContext = false)
            => MainClient.Value.CallAsync(_ => _.SendAsync(request), request.RequestUri.ToString(),
                continueOnCapturedContext);

        public static Task<TResult> SendAsync<TResult>(HttpRequestMessage request,
            bool continueOnCapturedContext = false)
            => MainClient.Value.CallAsync<TResult>(_ => _.SendAsync(request), request.RequestUri.ToString(),
                continueOnCapturedContext);

        #endregion

        #region Get

        public static string Get(string uri)
            => MainClient.Value.Call(_ => _.GetAsync(uri), uri);

        public static TResult Get<TResult>(string uri)
            => MainClient.Value.Call<TResult>(_ => _.GetAsync(uri), uri);

        public static Task<string> GetAsync(string uri, bool continueOnCapturedContext = false)
            => MainClient.Value.CallAsync(_ => _.GetAsync(uri), uri, continueOnCapturedContext);

        public static Task<TResult> GetAsync<TResult>(string uri, bool continueOnCapturedContext = false)
            => MainClient.Value.CallAsync<TResult>(_ => _.GetAsync(uri), uri, continueOnCapturedContext);

        #endregion

        #region Post

        public static string Post(string uri, HttpContent content = null)
            => MainClient.Value.Call(_ => _.PostAsync(uri, content), uri);

        public static TResult Post<TResult>(string uri, HttpContent content = null)
            => MainClient.Value.Call<TResult>(_ => _.PostAsync(uri, content), uri);

        public static Task<string> PostAsync(string uri, HttpContent content = null,
            bool continueOnCapturedContext = false)
            => MainClient.Value.CallAsync(_ => _.PostAsync(uri, content), uri, continueOnCapturedContext);

        public static Task<TResult> PostAsync<TResult>(string uri, HttpContent content = null,
            bool continueOnCapturedContext = false)
            => MainClient.Value.CallAsync<TResult>(_ => _.PostAsync(uri, content), uri, continueOnCapturedContext);

        #endregion

        #region Put

        public static string Put(string uri, HttpContent content = null)
            => MainClient.Value.Call(_ => _.PutAsync(uri, content), uri);

        public static TResult Put<TResult>(string uri, HttpContent content = null)
            => MainClient.Value.Call<TResult>(_ => _.PutAsync(uri, content), uri);

        public static Task<string> PutAsync(string uri, HttpContent content = null,
            bool continueOnCapturedContext = false)
            => MainClient.Value.CallAsync(_ => _.PutAsync(uri, content), uri, continueOnCapturedContext);

        public static Task<TResult> PutAsync<TResult>(string uri, HttpContent content = null,
            bool continueOnCapturedContext = false)
            => MainClient.Value.CallAsync<TResult>(_ => _.PutAsync(uri, content), uri, continueOnCapturedContext);

        #endregion

        #region Delete

        public static string Delete(string uri)
            => MainClient.Value.Call(_ => _.DeleteAsync(uri), uri);

        public static TResult Delete<TResult>(string uri)
            => MainClient.Value.Call<TResult>(_ => _.DeleteAsync(uri), uri);

        public static Task<string> DeleteAsync(string uri, bool continueOnCapturedContext = false)
            => MainClient.Value.CallAsync(_ => _.DeleteAsync(uri), uri, continueOnCapturedContext);

        public static Task<TResult> DeleteAsync<TResult>(string uri, bool continueOnCapturedContext = false)
            => MainClient.Value.CallAsync<TResult>(_ => _.DeleteAsync(uri), uri, continueOnCapturedContext);

        #endregion

        #endregion

        #region Other Client

        #region Send

        public static string Send(this HttpClient client, HttpRequestMessage request)
            => client.Call(_ => _.SendAsync(request), request.RequestUri.ToString());

        public static TResult Send<TResult>(this HttpClient client, HttpRequestMessage request)
            => client.Call<TResult>(_ => _.SendAsync(request), request.RequestUri.ToString());

        public static Task<string> SendAsync(this HttpClient client, HttpRequestMessage request,
            bool continueOnCapturedContext = false)
            => client.CallAsync(_ => _.SendAsync(request), request.RequestUri.ToString(), continueOnCapturedContext);

        public static Task<TResult> SendAsync<TResult>(this HttpClient client, HttpRequestMessage request,
            bool continueOnCapturedContext = false)
            => client.CallAsync<TResult>(_ => _.SendAsync(request), request.RequestUri.ToString(),
                continueOnCapturedContext);

        #endregion

        #region Get

        public static string Get(this HttpClient client, string uri)
            => client.Call(_ => _.GetAsync(uri), uri);

        public static TResult Get<TResult>(this HttpClient client, string uri)
            => client.Call<TResult>(_ => _.GetAsync(uri), uri);

        public static Task<string> GetAsync(this HttpClient client, string uri, bool continueOnCapturedContext = false)
            => client.CallAsync(_ => _.GetAsync(uri), uri, continueOnCapturedContext);

        public static Task<TResult> GetAsync<TResult>(this HttpClient client, string uri,
            bool continueOnCapturedContext = false)
            => client.CallAsync<TResult>(_ => _.GetAsync(uri), uri, continueOnCapturedContext);

        #endregion

        #region Post

        public static string Post(this HttpClient client, string uri, HttpContent content = null)
            => client.Call(_ => _.PostAsync(uri, content), uri);

        public static TResult Post<TResult>(this HttpClient client, string uri, HttpContent content = null)
            => client.Call<TResult>(_ => _.PostAsync(uri, content), uri);

        public static Task<string> PostAsync(this HttpClient client, string uri, HttpContent content = null,
            bool continueOnCapturedContext = false)
            => client.CallAsync(_ => _.PostAsync(uri, content), uri, continueOnCapturedContext);

        public static Task<TResult> PostAsync<TResult>(this HttpClient client, string uri, HttpContent content = null,
            bool continueOnCapturedContext = false)
            => client.CallAsync<TResult>(_ => _.PostAsync(uri, content), uri, continueOnCapturedContext);

        #endregion

        #region Put

        public static string Put(this HttpClient client, string uri, HttpContent content = null)
            => client.Call(_ => _.PutAsync(uri, content), uri);

        public static TResult Put<TResult>(this HttpClient client, string uri, HttpContent content = null)
            => client.Call<TResult>(_ => _.PutAsync(uri, content), uri);

        public static Task<string> PutAsync(this HttpClient client, string uri, HttpContent content = null,
            bool continueOnCapturedContext = false)
            => client.CallAsync(_ => _.PutAsync(uri, content), uri, continueOnCapturedContext);

        public static Task<TResult> PutAsync<TResult>(this HttpClient client, string uri, HttpContent content = null,
            bool continueOnCapturedContext = false)
            => client.CallAsync<TResult>(_ => _.PutAsync(uri, content), uri, continueOnCapturedContext);

        #endregion

        #region Delete

        public static string Delete(this HttpClient client, string uri)
            => client.Call(_ => _.DeleteAsync(uri), uri);

        public static TResult Delete<TResult>(this HttpClient client, string uri)
            => client.Call<TResult>(_ => _.DeleteAsync(uri), uri);

        public static Task<string> DeleteAsync(this HttpClient client, string uri,
            bool continueOnCapturedContext = false)
            => client.CallAsync(_ => _.DeleteAsync(uri), uri, continueOnCapturedContext);

        public static Task<TResult> DeleteAsync<TResult>(this HttpClient client, string uri,
            bool continueOnCapturedContext = false)
            => client.CallAsync<TResult>(_ => _.DeleteAsync(uri), uri, continueOnCapturedContext);

        #endregion

        #endregion
    }
}