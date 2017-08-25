using System;
using Microsoft.SPOT;
using Ws.Services.Binding;

namespace GadgeteerApp1
{
    class WebBinding : Binding
    {
        public WebBinding(TransportBindingElement transport) : base(transport, null) { }
    }
}
