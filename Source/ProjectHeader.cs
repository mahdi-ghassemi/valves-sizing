using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radman
{
    public class ProjectHeader
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string ProjectRefNo { get; set; }
        public string CustomerRefNo { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string RadmanRefNo { get; set; }
        public string EndUserName { get; set; }
        public string EnduserNameId { get; set; }
        public string Location { get; set; }
        public string CustomerId { get; set; }
        public List<Personel> PersonelList { get; set; }
        public string RadmanNote { get; set; }
        public string ProjectNote { get; set; }
        public string CustomerNote { get; set; }

        public ProjectHeader(string _Id, string _Name, string _CustomerName, string _ProjectRefNo, string _CustomerRefNo, string _ContactPerson,
                        string _ContactNo, string _RadmanRefNo, string _EndUserName, string _Location, string _CustomerId,
                        List<Personel> _PersonelList,string _EnduserNameId,string _RadmanNote,string _ProjectNote,
                        string _CustomerNote)
        {
            Id = _Id;
            CustomerName = _CustomerName;
            ContactPerson = _ContactPerson;
            Name = _Name;
            ProjectRefNo = _ProjectRefNo;
            CustomerRefNo = _CustomerRefNo;
            ContactNo = _ContactNo;
            RadmanRefNo = _RadmanRefNo;
            EndUserName = _EndUserName;
            Location = _Location;
            CustomerId = _CustomerId;
            PersonelList = new List<Personel>();
            PersonelList = _PersonelList;
            EnduserNameId = _EnduserNameId;
            RadmanNote = _RadmanNote;
            ProjectNote = _ProjectNote;
            CustomerNote = _CustomerNote;
        }
    }
}
