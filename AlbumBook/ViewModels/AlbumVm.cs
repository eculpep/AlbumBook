using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlbumBook.Models;

namespace AlbumBook.ViewModels
{
    public class AlbumVm
    {
        public int id { get; set; }
        public Nullable<int> userId { get; set; }
        public string title { get; set; }
        public UserVm user { get; set; }
        public ICollection<PhotoVm> photos { get; set; }
        public bool display { get; set; }
    }
}