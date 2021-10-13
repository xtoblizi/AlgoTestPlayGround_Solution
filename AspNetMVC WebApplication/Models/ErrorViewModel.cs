using System;
using System.Collections.Generic;

namespace AspNetMVC_WebApplication.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public List<string> Ingerdients { get; set; }
    }
}
