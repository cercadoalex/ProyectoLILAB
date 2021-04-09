using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Error
{
    public class CodeErrorResponse
    {
        public CodeErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(StatusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El Request tiene errores",
                404 => "No se encontro el item buscado",
                500 => "Se producieron errores en el servidor",
                _=> null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}
