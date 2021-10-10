using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystemFrontEnd.Models
{
    class GeneralResponse<T>
    {
        public bool isSuccessful { get; set; }
        public T payload { get; set; }
    }
}
