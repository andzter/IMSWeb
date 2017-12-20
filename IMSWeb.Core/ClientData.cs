using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Models;

namespace IMSWeb.Core
{
    public static class ClientData
    {
        public static IQueryable<Client> NoNicknames()
        {

            IEnumerable<Client> myEnumerable =
              new DataHelper().GetDataTable("select * from vwRepClientNoNicknames").ToList<Client>();

            return myEnumerable.AsQueryable();

        }

        public static IQueryable<Client> NoBirthdays()
        {

            IEnumerable<Client> myEnumerable =
              new DataHelper().GetDataTable("select * from vwRepClientNoBirthdays").ToList<Client>();

            return myEnumerable.AsQueryable();

        }
    }
}
