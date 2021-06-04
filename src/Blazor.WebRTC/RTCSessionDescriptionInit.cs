using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Blazor.WebRTC
{
    public class RTCSessionDescriptionInit
    {
        private readonly IJSRuntime jsRuntime;
        public IJSRuntime JSRuntime => jsRuntime;

        private readonly IJSObjectReference jsObjectReference;
        public IJSObjectReference JSObjectReference => jsObjectReference;

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

            Task.Run(async () =>
            {
                var typeValue = await Module.JsInvokeAsync<string>("getJsObjectPropertyValue", jsObjectReference, "type");
                System.Console.WriteLine("typeValue: " + typeValue);
                this.type = typeValue switch { "offer" => RTCSdpType.offer, "answer" => RTCSdpType.answer, _ => RTCSdpType.pranswer };
                //System.Diagnostics.Debug.WriteLine("type: " + this.type);
                this.sdp = await Module.JsInvokeAsync<string>("getJsObjectPropertyValue", jsObjectReference, "sdp");
                System.Diagnostics.Debug.WriteLine("sdp: " + sdp);
            }).Wait();
        }
    }
}
