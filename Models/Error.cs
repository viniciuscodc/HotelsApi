using System;
using Newtonsoft.Json;

namespace HotelsApi.Models
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set;}

        public override string ToString() => JsonConvert.SerializeObject(this);

    }
}