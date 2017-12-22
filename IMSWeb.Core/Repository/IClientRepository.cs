using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Models;

namespace IMSWeb.Core.Repository
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetNoNicknames(out int totalRecords, string globalSearch, int? limitOffset, int? limitRowCount, string orderBy, bool desc);
        IEnumerable<Client> GetNoNicknames(out int totalRecords, int? limitOffset, int? limitRowCount, string orderBy, bool desc);

    }
}
