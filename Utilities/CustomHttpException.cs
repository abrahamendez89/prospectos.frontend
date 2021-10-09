using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace utilities
{
    public class CustomHttpException:Exception
    {
        public String Class { get; set; }
        public String Method { get; set; }
        public HttpStatusCode HttpCode { get; set; }
        public String Message { get; set; }
        public String StackTrace { get; set; }
        public CustomHttpException(String Class, String Method, String Message, HttpStatusCode httpCode, Exception ex = null) {
            //base(ex.Message);
            this.Class = Class;
            this.Method = Method;
            this.HttpCode = httpCode;
            this.Message = Message;
            this.StackTrace = ex?.StackTrace;
            //aqui meter reflection para copiar un objeto a otro
        }
    }
}
