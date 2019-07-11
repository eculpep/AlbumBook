using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumBook.Models
{
    public partial class address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public geo geo { get; set; }
    }
}