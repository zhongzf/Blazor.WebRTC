using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.WebRTC
{
    public class RTCPeerConnectionIceEvent : Event
    {
        public readonly RTCIceCandidate candidate;
        public readonly string url;

        public RTCPeerConnectionIceEvent()
        {
        }

        public RTCPeerConnectionIceEvent(IJSRuntime jsRuntime, IJSObjectReference jsObjectReference)
            : base(jsRuntime, jsObjectReference)
        {
        }

        public RTCPeerConnectionIceEvent(string type, RTCPeerConnectionIceEventInit init)
            : base(type, null)
        {
            this.candidate = init.candidate;
            this.url = init.url;
        }
    }
}
