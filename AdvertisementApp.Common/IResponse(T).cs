using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Common
{
    public interface IResponse<T>:IResponse
    {
         List<CustomValidationError> ValidationErrors { get; set; }
         T Data { get; set; }


    }
}
