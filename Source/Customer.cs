using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radman
{
    public class Customer
    { 
        public bool Check { get; set; }       
        public string Id { get; set; }
        public string Name { get; set; }
        public string DefultRefNo { get; set; }
        public string Contact { get; set; }
        public string Fax { get; set; }      
        public string Email { get; set; }         
        public string Address { get; set; }

        public Customer(string _Id, string _Name, string _DefultRefNo, string _Contact, string _Fax,
                        string _Email, string _Address)
        {
            Id = _Id;           
            Name = _Name;
            DefultRefNo = _DefultRefNo;
            Email = _Email;           
            Contact = _Contact;
            Fax = _Fax;            
            Address = _Address;
        }

        public Customer(bool _Check,string _Id, string _Name, string _DefultRefNo, string _Contact, string _Fax,
                        string _Email, string _Address)
        {
            Check = _Check;
            Id = _Id;
            Name = _Name;
            DefultRefNo = _DefultRefNo;
            Email = _Email;
            Contact = _Contact;
            Fax = _Fax;
            Address = _Address;
        }
    }

    
}
