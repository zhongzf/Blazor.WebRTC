using Microsoft.JSInterop;

namespace Blazor.WebRTC
{
    public class RTCLocalSessionDescriptionInit : RTCSessionDescriptionInit
    {
        public RTCLocalSessionDescriptionInit(IJSRuntime jsRuntime, IJSObjectReference jsObjectReference)
            :base(jsRuntime, jsObjectReference)
        {
        }

        public RTCLocalSessionDescriptionInit(RTCSessionDescriptionInit init)
        {
        }
    }
}