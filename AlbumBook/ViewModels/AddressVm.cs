using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlbumBook.Models;

namespace AlbumBook.ViewModels
{
    public class AddressVm
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public GeoVm geo { get; set; }
        public bool display { get; set; }
    }
}