using Microsoft.JSInterop;

namespace Blazor.WebRTC
{
    public class RTCConfiguration
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IJSObjectReference jsObjectReference;

        public RTCConfiguration(IJSRuntime jsRuntime, IJSObjectReference jsObjectReference)
        {
            this.jsRuntime = jsRuntime;
            this.jsObjectReference = jsObjectReference;
        }

        public RTCConfiguration()
        {
        }
    }
}
