using Microsoft.JSInterop;

namespace Blazor.WebRTC
{
    public class RTCSessionDescriptionInit
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IJSObjectReference jsObjectReference;

        public RTCSdpType type { get; set; }
        public string sdp { get; set; }

        public RTCSessionDescriptionInit()
        {
        }

        public RTCSessionDescriptionInit(RTCSdpType type, string sdp)
        {
            this.type = type;
            this.sdp = sdp;
        }

        public RTCSessionDescriptionInit(IJSRuntime jsRuntime, IJSObjectReference jsObjectReference)
        {
            this.jsRuntime = jsRuntime;
            this.jsObjectReference = jsObjectReference;

            // TODO: get property values from jsObjectReference
        }
    }
}
