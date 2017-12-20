using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSWeb.Core
{
    public static class AdminDataContext
    {
        public static int LoginUser(string user, string password)
        {
            return int.Parse((new DataHelper()).ExecSQLScalarSP("usp_userlogin", user, password).ToString());
             
        }
    }
}
