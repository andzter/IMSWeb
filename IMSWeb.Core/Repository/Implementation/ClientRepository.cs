using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Models;
using IMSWeb.Core;

namespace IMSWeb.Core.Repository.Impl
{
    public class ClientRepository : IClientRepository
    {
        public IEnumerable<Client> GetNoNicknames(out int totalRecords, string globalSearch, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {
            return GetData(out totalRecords, globalSearch, null, limitOffset, limitRowCount, orderBy, desc, "NoNicknames");
        }

        public IEnumerable<Client> GetNoNicknames(out int totalRecords, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {
            return GetData(out totalRecords, null, null, limitOffset, limitRowCount, orderBy, desc, "NoNicknames");
        }

        public IEnumerable<Client> GetNoBirthday(out int totalRecords, string globalSearch, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {
            return GetData(out totalRecords, globalSearch, null, limitOffset, limitRowCount, orderBy, desc, "NoBirthday");
        }

        public IEnumerable<Client> GetNoBirthday(out int totalRecords, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {
            return GetData(out totalRecords, null, null, limitOffset, limitRowCount, orderBy, desc, "NoBirthday");
        }


        public IEnumerable<Client> GetBirthday(out int totalRecords, string globalSearch, int? limitOffset, int? limitRowCount, string orderBy, bool desc, int month)
        {
            return GetData(out totalRecords, globalSearch, null, limitOffset, limitRowCount, orderBy, desc, "bday-" + month.ToString());
        }

        public IEnumerable<Client> GetBirthday(out int totalRecords, int? limitOffset, int? limitRowCount, string orderBy, bool desc, int month)
        {
            return GetData(out totalRecords, null, null, limitOffset, limitRowCount, orderBy, desc, "bday-" + month.ToString());
        }

        public IEnumerable<Client> GetNoMobile(out int totalRecords, string globalSearch, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {
            return GetData(out totalRecords, globalSearch, null, limitOffset, limitRowCount, orderBy, desc, "NoMobile");
        }

        public IEnumerable<Client> GetNoMobile(out int totalRecords, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {
            return GetData(out totalRecords, null, null, limitOffset, limitRowCount, orderBy, desc, "NoMobile");
        }

        public IEnumerable<Client> GetNoMobileWithEmail(out int totalRecords, string globalSearch, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {
            return GetData(out totalRecords, globalSearch, null, limitOffset, limitRowCount, orderBy, desc, "NoMobileWithEmail");
        }

        public IEnumerable<Client> GetNoMobileWithEmail(out int totalRecords, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {
            return GetData(out totalRecords, null, null, limitOffset, limitRowCount, orderBy, desc, "NoMobileWithEmail");
        }

        public IEnumerable<Client> GetWithMobile(out int totalRecords, string globalSearch, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {
            return GetData(out totalRecords, globalSearch, null, limitOffset, limitRowCount, orderBy, desc, "WithMobile");
        }

        public IEnumerable<Client> GetWithMobile(out int totalRecords, int? limitOffset, int? limitRowCount, string orderBy, bool desc)
        {
            return GetData(out totalRecords, null, null, limitOffset, limitRowCount, orderBy, desc, "WithMobile");
        }


        public IEnumerable<Client> GetData(out int totalRecords, string globalSearch, bool? filterActive, int? limitOffset, int? limitRowCount, string orderBy, bool desc, string reptype)
        {

            IQueryable<Client> query;

            if (reptype.Equals("NoNicknames"))
                query = ClientData.NoNicknames();
            else if (reptype.Equals("NoBirthday"))
                query = ClientData.NoBirthdays();
            else if (reptype.Equals("NoMobile"))
                query = ClientData.NoMobile();
            else if (reptype.Equals("NoMobileWithEmail"))
                query = ClientData.NoMobileWithEmail();
            else if (reptype.Equals("WithMobile"))
                query = ClientData.WithMobile();
            else
            {
                
                query = ClientData.BirthMonth(int.Parse(reptype.Split('-')[1]));
            }

            if (!String.IsNullOrWhiteSpace(globalSearch))
            {
                query = query.Where(p => (p.ClientName).Contains(globalSearch));
            }

            totalRecords = query.Count();

            if (!String.IsNullOrWhiteSpace(orderBy))
            {
                switch (orderBy.ToLower())
                {

                    case "title":
                        query = (!desc) ? query.OrderBy(p => p.Title) : query.OrderByDescending(p => p.Title);
                        break;
                    case "lastname":
                        query = (!desc) ? query.OrderBy(p => p.LastName) : query.OrderByDescending(p => p.LastName);
                        break;
                    case "firstname":
                        query = (!desc) ? query.OrderBy(p => p.FirstName) : query.OrderByDescending(p => p.FirstName);
                        break;
                    case "middlename":
                        query = (!desc) ? query.OrderBy(p => p.MiddleName) : query.OrderByDescending(p => p.MiddleName);
                        break;
                    case "nickname":
                        query = (!desc) ? query.OrderBy(p => p.NickName) : query.OrderByDescending(p => p.NickName);
                        break;
                    case "clientname":
                        query = (!desc) ? query.OrderBy(p => p.ClientName) : query.OrderByDescending(p => p.ClientName);
                        break;
                    case "clienttype":
                        query = (!desc) ? query.OrderBy(p => p.ClientType) : query.OrderByDescending(p => p.ClientType);
                        break;
  
                    case "officeaddress":
                        query = (!desc) ? query.OrderBy(p => p.OfficeAddress) : query.OrderByDescending(p => p.OfficeAddress);
                        break;
                    case "homeaddress":
                        query = (!desc) ? query.OrderBy(p => p.HomeAddress) : query.OrderByDescending(p => p.HomeAddress);
                        break;
                    case "mailingaddress":
                        query = (!desc) ? query.OrderBy(p => p.MailingAddress) : query.OrderByDescending(p => p.MailingAddress);
                        break;
                    case "dateofbirth":
                        query = (!desc) ? query.OrderBy(p => p.DateofBirth) : query.OrderByDescending(p => p.DateofBirth);
                        break;
                    case "clientage":
                        query = (!desc) ? query.OrderBy(p => p.ClientAge) : query.OrderByDescending(p => p.ClientAge);
                        break;
                    case "contactno":
                        query = (!desc) ? query.OrderBy(p => p.ContactNo) : query.OrderByDescending(p => p.ContactNo);
                        break;
                    case "referredby":
                        query = (!desc) ? query.OrderBy(p => p.ReferredBy) : query.OrderByDescending(p => p.ReferredBy);
                        break;
                     case "mobile":
                        query = (!desc) ? query.OrderBy(p => p.Mobile) : query.OrderByDescending(p => p.Mobile);
                        break;
                    case "phone":
                        query = (!desc) ? query.OrderBy(p => p.Phone) : query.OrderByDescending(p => p.Phone);
                        break;
                    case "email":
                        query = (!desc) ? query.OrderBy(p => p.Email) : query.OrderByDescending(p => p.Email);
                        break;
                    case "createdby":
                        query = (!desc) ? query.OrderBy(p => p.Createdby) : query.OrderByDescending(p => p.Createdby);
                        break;
                    case "createdate":
                        query = (!desc) ? query.OrderBy(p => p.Createdate) : query.OrderByDescending(p => p.Createdate);
                        break;
                    case "updatedby":
                        query = (!desc) ? query.OrderBy(p => p.Updatedby) : query.OrderByDescending(p => p.Updatedby);
                        break;
                    case "updatedate":
                        query = (!desc) ? query.OrderBy(p => p.Updatedate) : query.OrderByDescending(p => p.Updatedate);
                        break;
                }
            }

            if (limitOffset.HasValue)
            {
                query = query.Skip(limitOffset.Value).Take(limitRowCount.Value);
            }
            return query.ToList();

        }
    }
}
