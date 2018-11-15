using System;
using System.Collections.Generic;
using System.Text;

namespace StepAspNetServer.Tools
{
    public class HttpMethodAttribute : Attribute
    {
        //public string Method { get; set; }

        public HttpMethodAttribute(string method)
        {
            //Method = method;
        }
    }
}
