using Module_21_MVC_Domain.Unum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC_Domain.Response
{
    public class BaseResponse<T>: IBaseResponse<T>
    {
        public string Description { get; set; }

        public StatusCode StatuseCode { get; set; }

        public T Data { get; set; }
    }
    public interface IBaseResponse<T>
    {
        T Data { get; }
    }
        
}
