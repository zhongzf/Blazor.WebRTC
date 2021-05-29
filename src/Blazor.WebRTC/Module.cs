using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.WebRTC
{
    public class Module : IAsyncDisposable
    {
        private readonly IJSRuntime jsRuntime;
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public Module(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Blazor.WebRTC/module.js").AsTask());
        }

        public async Task<RTCPeerConnection> createRTCPeerConnection(RTCConfiguration configuration = null)
        {
            var module = await moduleTask.Value;
            var connection = new RTCPeerConnection(jsRuntime, await module.InvokeAsync<IJSObjectReference>(nameof(createRTCPeerConnection), configuration));
            await module.InvokeVoidAsync("bindRTCPeerConnection", connection.JSObjectReference, DotNetObjectReference.Create(connection));
            return connection;
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
