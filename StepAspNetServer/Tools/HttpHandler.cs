using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StepAspNetServer.Tools
{
    public delegate void HttpHandler(HttpListenerContext context);
}
