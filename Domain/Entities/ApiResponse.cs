using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApiResponse<T> where T : class
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public T Data { get; set; }
        public string ErrorMEssage { get; set; }    
    }
    
}
