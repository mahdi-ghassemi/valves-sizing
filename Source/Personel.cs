using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Radman
{
    public class Personel
    {
        public Image UserImage { get; set; }
        public string Id { get; set; }       
        public string Name { get; set; }
        public string Family { get; set; }       
        public string JobTitle { get; set; }
        public string InternalCode { get; set; }
        public string PersonelCode { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }

        public Personel(Image _UserImage, string _Id, string _Name, string _Family, string _JobTitle, string _InternalCode,
                        string _PersonelCode, string _Username, string _Email, string _Gender, string _Contact, string _Address)
        {
            Id = _Id;
            UserName = _Username;
            Name = _Name;
            Family = _Family;
            Email = _Email;
            JobTitle = _JobTitle;
            PersonelCode = _PersonelCode;
            Contact = _Contact;
            UserImage = _UserImage;
            Gender = _Gender;
            InternalCode = _InternalCode;
            Address = _Address;
        }
    }
}
