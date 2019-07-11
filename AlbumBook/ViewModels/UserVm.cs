using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumBook.ViewModels
{
    public class UserVm
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public AddressVm address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public CompanyVm company { get; set; }
        public virtual ICollection<PostVm> posts { get; set; }
        public bool display { get; set; }
    }
}