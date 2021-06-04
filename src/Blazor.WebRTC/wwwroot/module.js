export function createRTCPeerConnection(configuration) {
    return new RTCPeerConnection(configuration);
}

export function bindRTCPeerConnection(connection, dotnetReference) {
    connection.onnegotiationneeded = async (e) => {
        await dotnetReference.invokeMethodAsync("HandleEventAsync", "onnegotiationneeded", e);
    };
    connection.onicecandidate = async (e) => {
        await dotnetReference.invokeMethodAsync("HandleEventAsync", "onicecandidate", e);
    };
    connection.onicecandidateerror = async (e) => {
        await dotnetReference.invokeMethodAsync("HandleEventAsync", "onicecandidateerror", e);
    };
    connection.onsignalingstatechange = async (e) => {
        await dotnetReference.invokeMethodAsync("HandleEventAsync", "onsignalingstatechange", e);
    };
    connection.oniceconnectionstatechange = async (e) => {
        await dotnetReference.invokeMethodAsync("HandleEventAsync", "oniceconnectionstatechange", e);
    };
    connection.onicegatheringstatechange = async (e) => {
        await dotnetReference.invokeMethodAsync("HandleEventAsync", "onicegatheringstatechange", e);
    };
    connection.onconnectionstatechange = async (e) => {
        await dotnetReference.invokeMethodAsync("HandleEventAsync", "onconnectionstatechange", e);
    };
}

export function getJsObjectPropertyValue(jsObject, name) {
    console.log('jsObject: ' + jsObject + ', name: ' + name);
    var value = jsObject[name];
    console.log('value: ' + value);
    return value;
}