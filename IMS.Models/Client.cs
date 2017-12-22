using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models
{
    public class Client
    {
        public string Clientid { get; set; }
        
        public string ClientName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string NickName { get; set; }
        public string ClientType { get; set; }
        public string Title { get; set; }
        public DateTime DateofBirth { get; set; }
        public string ClientAge { get; set; }
        public string OfficeAddress { get; set; }
        public string HomeAddress { get; set; }
        public string MailingAddress { get; set; }
        public string ContactNo { get; set; }
        public string ReferredBy { get; set; }
        public string Createdby { get; set; }
        public DateTime Createdate { get; set; }
        public string Updatedby { get; set; }
        public DateTime Updatedate { get; set; }
        public string Suffix { get; set; }
        public string PolicyId { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string Account { get; set; }
        public string ContactOf { get; set; }
        public string Notes { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
