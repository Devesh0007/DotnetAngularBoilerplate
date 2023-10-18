using System.Net;
using System.Runtime.Serialization;

namespace DotnetAngularBoilerplate.Model
{
    [DataContract]
    public class ApiResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object? Data { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? Message { get; set; }

        public ApiResponseModel(HttpStatusCode statusCode, bool success, object? data = null, string? message = null)
        {
            StatusCode = statusCode;
            Success = success;
            Data = data;
            Message = message;
        }
    }
}