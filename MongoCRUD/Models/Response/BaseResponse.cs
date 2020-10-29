using System.Collections.Generic;
using System.Linq;

namespace MongoCRUD.Models.Response
{
    public class BaseResponse<T> where T : new()
    {
        public BaseResponse()
        {
            Data = new T();
            Errors = new List<string>();
        }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public bool HasError => Errors.Any();
    }
}
