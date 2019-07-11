using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlbumBook.Models;

namespace AlbumBook.ViewModels
{
    public class PhotoVm : photo
    {
        public bool display { get; set; }
    }
}