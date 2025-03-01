using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Dto.ResponseDtos
{
    public class MyResponse<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccesfull { get; private set; }//response başarılı olup olmadığını tek kodla kontrol etmek istediğimizden dolay property tanımladık

        public ErrorDto Error { get; set; }

        public static MyResponse<T> Success(T data, int statusCode)
        {
            return new MyResponse<T> { Data = data, StatusCode = statusCode, IsSuccesfull = true };
        }

        public static MyResponse<T> Success(int statusCode)
        {
            return new MyResponse<T> { Data = default, StatusCode = statusCode, IsSuccesfull = true };
        }


        public static MyResponse<T> Fail(ErrorDto errorDto, int statusCode)
        {
            return new MyResponse<T> { Error = errorDto, StatusCode = statusCode, IsSuccesfull = false };
        }


        public static MyResponse<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);

            return new MyResponse<T> { Error = errorDto, StatusCode = statusCode, IsSuccesfull = false };
        }
    }
}
