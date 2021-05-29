using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.WebRTC
{
    public class RTCIceCandidate
    {
        public RTCIceCandidate(RTCIceCandidateInit init)
        {
        }

        public RTCIceCandidate()
        {
        }

        public readonly string candidate;
        public readonly string sdpMid;
        public readonly uint sdpMLineIndex;
        public readonly string foundation;
        //readonly attribute RTCIceComponent? component;
        public readonly ulong priority;
        public readonly string address;
        //readonly attribute RTCIceProtocol? protocol;
        public readonly ushort port;
        //readonly attribute RTCIceCandidateType? type;
        //readonly attribute RTCIceTcpCandidateType? tcpType;
        public readonly string relatedAddress;
        public readonly ushort relatedPort;
        public readonly string usernameFragment;
        //RTCIceCandidateInit toJSON();
    }
}
