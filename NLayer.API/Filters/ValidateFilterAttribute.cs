using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;

namespace NLayer.API.Filters
{
    public class ValidateFilterAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //eror geliyor eroru liste atarım o sınıftan bana hata mesajı ver dedim 
                var errors= context.ModelState.Values.SelectMany(x => x.Errors).Select(x=>x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.fail(400, errors));  
            }
        }
    }
}
