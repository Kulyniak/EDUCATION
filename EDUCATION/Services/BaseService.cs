using EDUCATION.Models.Base;
using System;
using System.Threading.Tasks;

namespace EDUCATION.Services
{
    public class BaseService
    {
        protected async Task<T> GetResponseAsync<T>(Func<Task<T>> func) where T : ApiResponse, new()
        {
            T response;
            try
            {
                response = await func();
            }
            catch (Exception e)
            {
                response = new T
                {
                    IsSuccess = false,
                    Message = e.Message
                };
                if (e.InnerException != null)
                {
                    response.Message += e.InnerException.Message;
                }
            }
            return response;
        }
    }
}
