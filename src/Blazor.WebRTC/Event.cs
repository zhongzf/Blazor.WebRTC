using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.WebRTC
{
    public class Event : EventArgs
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IJSObjectReference jsObjectReference;

        public readonly string type;
        public readonly object target;

        public Event()
        {
        }

        public Event(IJSRuntime jsRuntime, IJSObjectReference jsObjectReference)
        {
            this.jsRuntime = jsRuntime;
            this.jsObjectReference = jsObjectReference;
        }

        public Event(string type, object target)
        {
            this.type = type;
            this.target = target;
        }
    }
}
