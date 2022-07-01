using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApi.Core.DTOs
{
    public class CustomResponseDto
    {
        public object Data { get; set; }
        public string Message { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        
    }
}
