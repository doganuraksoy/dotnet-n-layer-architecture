using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }//dış dünyaya açmak istemiyorum.
        public List<String> Errors { get; set; }
        //nesne oluşturma işlemini kontrol altına aldım.
        public static CustomResponseDto<T> success(int StatusCode, T Data)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode, Data = Data ,Errors=null};
        }
        public static CustomResponseDto<T> success(int StatusCode)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode };
        }
        public static CustomResponseDto<T> fail(int StatusCode, List<String> errors)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode,Errors=errors };
        }
        public static CustomResponseDto<T> fail(int StatusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode, Errors = new List<String> { error } };
        }
    }
}
