using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystemFrontEnd.Constants
{
    class AppConstants
    {
        private static readonly string BASE_URL = "http://localhost:8090/account-system/mvc/";
        public static readonly string VIEW_CURRENCY_URL = BASE_URL + "currency";
        public static readonly string ADD_CURRENCY_URL = BASE_URL + "currency/add/";
        public static readonly string SUBTRACT_CURRENCY_URL = BASE_URL + "currency/sub/";
    }
}
