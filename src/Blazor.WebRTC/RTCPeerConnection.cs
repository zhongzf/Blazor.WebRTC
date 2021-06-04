using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.WebRTC
{
    public class RTCPeerConnection
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IJSObjectReference jsObjectReference;
        public IJSObjectReference JSObjectReference => jsObjectReference;

        public RTCPeerConnection(IJSRuntime jsRuntime, IJSObjectReference jsObjectReference)
        {
            this.jsRuntime = jsRuntime;
            this.jsObjectReference = jsObjectReference;
        }

        public async Task<RTCSessionDescriptionInit> createOffer(RTCOfferOptions options = null)
        {
            return new RTCSessionDescriptionInit(jsRuntime, await jsObjectReference.InvokeAsync<IJSObjectReference>(nameof(createOffer), options));
        }

        public async Task<RTCSessionDescriptionInit> createAnswer(RTCAnswerOptions options = null)
        {
            return new RTCSessionDescriptionInit(jsRuntime, await jsObjectReference.InvokeAsync<IJSObjectReference>(nameof(createAnswer), options));
        }

        public async Task setLocalDescription(RTCLocalSessionDescriptionInit description = null)
        {
            if (description.JSObjectReference != null)
            {
                await jsObjectReference.InvokeVoidAsync(nameof(setLocalDescription), description.JSObjectReference);
            }
            else
            {
                await jsObjectReference.InvokeVoidAsync(nameof(setLocalDescription), description);
            }
        }

        //readonly attribute RTCSessionDescription? localDescription;
        //readonly attribute RTCSessionDescription? currentLocalDescription;
        //readonly attribute RTCSessionDescription? pendingLocalDescription;

        public async Task setRemoteDescription(RTCSessionDescriptionInit description = null)
        {
            if (description.JSObjectReference != null)
            {
                await jsObjectReference.InvokeVoidAsync(nameof(setRemoteDescription), description.JSObjectReference);
            }
            else
            {
                await jsObjectReference.InvokeVoidAsync(nameof(setRemoteDescription), description);
            }
        }

        //readonly attribute RTCSessionDescription? remoteDescription;
        //readonly attribute RTCSessionDescription? currentRemoteDescription;
        //readonly attribute RTCSessionDescription? pendingRemoteDescription;

        public async Task addIceCandidate(RTCIceCandidateInit candidate = null)
        {
            await jsObjectReference.InvokeVoidAsync(nameof(addIceCandidate), candidate);
        }

        //readonly attribute RTCSignalingState signalingState;
        //readonly attribute RTCIceGatheringState iceGatheringState;
        //readonly attribute RTCIceConnectionState iceConnectionState;
        //readonly attribute RTCPeerConnectionState connectionState;
        //readonly attribute boolean? canTrickleIceCandidates;

        public async Task restartIce()
        {
            await jsObjectReference.InvokeVoidAsync(nameof(restartIce));
        }

        public async Task<RTCConfiguration> getConfiguration()
        {
            return new RTCConfiguration(jsRuntime, await jsObjectReference.InvokeAsync<IJSObjectReference>(nameof(getConfiguration)));
        }

        public async Task setConfiguration(RTCConfiguration configuration = null)
        {
            await jsObjectReference.InvokeVoidAsync(nameof(setConfiguration), configuration);
        }

        public async Task close()
        {
            await jsObjectReference.InvokeVoidAsync(nameof(close));
        }

        public event EventHandler<Event> onnegotiationneeded;
        public event EventHandler<RTCPeerConnectionIceEvent> onicecandidate;
        public event EventHandler<RTCPeerConnectionIceErrorEvent> onicecandidateerror;
        public event EventHandler<Event> onsignalingstatechange;
        public event EventHandler<Event> oniceconnectionstatechange;
        public event EventHandler<Event> onicegatheringstatechange;
        public event EventHandler<Event> onconnectionstatechange;

        [JSInvokable]
        public Task HandleEventAsync(string eventName, IJSInProcessObjectReference e)
        {
            switch (eventName)
            {
                case nameof(onnegotiationneeded):
                    {
                        onnegotiationneeded?.Invoke(this, new Event(jsRuntime, e));
                        break;
                    }
                case nameof(onicecandidate):
                    {
                        onicecandidate?.Invoke(this, new RTCPeerConnectionIceEvent(jsRuntime, e));
                        break;
                    }
                case nameof(onicecandidateerror):
                    {
                        onicecandidateerror?.Invoke(this, new RTCPeerConnectionIceErrorEvent(jsRuntime, e));
                        break;
                    }
                case nameof(onsignalingstatechange):
                    {
                        onsignalingstatechange?.Invoke(this, new Event(jsRuntime, e));
                        break;
                    }
                case nameof(oniceconnectionstatechange):
                    {
                        oniceconnectionstatechange?.Invoke(this, new Event(jsRuntime, e));
                        break;
                    }
                case nameof(onicegatheringstatechange):
                    {
                        onicegatheringstatechange?.Invoke(this, new Event(jsRuntime, e));
                        break;
                    }
                case nameof(onconnectionstatechange):
                    {
                        onconnectionstatechange?.Invoke(this, new Event(jsRuntime, e));
                        break;
                    }
            }
            return Task.CompletedTask;
        }

    }
}
