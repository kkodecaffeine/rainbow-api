using System.Net;

namespace RainbowApp.Core.Entities
{
    public class ApiFailResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }

    public class ApiResponse
    {
        public ApiResponse()
        {
            data = null;
            ResultStatusCode = HttpStatusCode.OK;
            ApiV2Result = new ApiFailResult();
        }

        private bool isSucecss = false;

        public bool IsSuccess { get => isSucecss; }

        public HttpStatusCode ResultStatusCode { get; set; }

        public ApiFailResult ApiV2Result { get; set; }

        private dynamic data;

        public void SetFailStatusCode(HttpStatusCode statusCode)
        {
            isSucecss = false;
            ResultStatusCode = statusCode;
        }

        public void SetFail(HttpStatusCode statusCode,int code, string message)
        {
            SetFailStatusCode(statusCode);
            ApiV2Result = new ApiFailResult { Code = code, Message = message };
        }

        public void SetSuccess(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            isSucecss = true;
            ResultStatusCode = statusCode;
        }

        public void SetSuccessData(dynamic data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            isSucecss = true;
            this.data = data;
            ResultStatusCode = statusCode;
        }

        public void SetNotfoundResult()
        {
            SetFailStatusCode(HttpStatusCode.NotFound);
            ApiV2Result = new ApiFailResult() { Code = 20024, Message = "Does not exists" };
        }

        public void SetPermissionDenied()
        {
            SetFailStatusCode(HttpStatusCode.Forbidden);
            ApiV2Result = new ApiFailResult() { Code = 20023, Message = "Permission Denied" };
        }
    }
}
