namespace Blazor.WebRTC
{
    public class RTCIceCandidateInit
    {
        public string candidate { get; set; }
        public string sdpMid { get; set; } = "0";
        public ushort sdpMLineIndex { get; set; }
        public string usernameFragment { get; set; }
    }
}