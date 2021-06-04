using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.WebRTC
{
    public class Module : IAsyncDisposable
    {
        private readonly IJSRuntime jsRuntime;
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        private static Module instance;

        public static async ValueTask<T> JsInvokeAsync<T>(string identifier, params object?[]? args)
        {
            return await instance.InvokeAsync<T>(identifier, args);
        }

        public static async ValueTask JsInvokeVoidAsync(string identifier, params object?[]? args)
        {
            await instance.InvokeVoidAsync(identifier, args);
        }

        public static T JsInvoke<T>(string identifier, params object?[]? args)
        {
            return instance.Invoke<T>(identifier, args);
        }

        public static void JsInvokeVoid(string identifier, params object?[]? args)
        {
            instance.InvokeVoid(identifier, args);
        }

        public Module(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Blazor.WebRTC/module.js").AsTask());
            instance = this;
        }

        public async Task<RTCPeerConnection> createRTCPeerConnection(RTCConfiguration configuration = null)
        {
            var connection = new RTCPeerConnection(jsRuntime, await InvokeAsync<IJSObjectReference>(nameof(createRTCPeerConnection), configuration));
            await InvokeVoidAsync("bindRTCPeerConnection", connection.JSObjectReference, DotNetObjectReference.Create(connection));
            return connection;
        }

        public async ValueTask<T> InvokeAsync<T>(string identifier, params object?[]? args)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<T>(identifier, args);
        }

        public async ValueTask InvokeVoidAsync(string identifier, params object?[]? args)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(identifier, args);
        }

        public T Invoke<T>(string identifier, params object?[]? args)
        {
            return InvokeAsync<T>(identifier, args).GetAwaiter().GetResult();
        }

        public void InvokeVoid(string identifier, params object?[]? args)
        {
            InvokeVoidAsync(identifier, args).GetAwaiter().GetResult();
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
