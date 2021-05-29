using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.WebRTC
{
    public class RTCPeerConnectionIceErrorEvent : Event
    {
        public RTCPeerConnectionIceErrorEvent()
        {
        }

        public RTCPeerConnectionIceErrorEvent(IJSRuntime jsRuntime, IJSObjectReference jsObjectReference)
             : base(jsRuntime, jsObjectReference)
        {
        }
    }
}
