using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using AlbumBook.Models;
using AlbumBook.DataService;
using AlbumBook.ViewModels;
using PagedList;

namespace AlbumBook.Controllers
{
    public class albumsController : Controller
    {
        //private AlbumBookEntities db = new AlbumBookEntities();
        private MyAlbums myAlbums = new MyAlbums();

        // GET: albums
        public async Task<ViewResult> Index(string titleFilter, string userFilter, int? page)
        {
            int pageSize = 6;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<album> pagedAlbums = null;
            var albums = await myAlbums.Albums();
            if (!string.IsNullOrEmpty(titleFilter))
            {
                albums = albums.Where(a => a.title.Contains(titleFilter));
            }
            if (!string.IsNullOrEmpty(userFilter))
            {
                albums = albums.Where(a => a.user.name.Contains(userFilter));
            }
            if (albums.Count() < 1)
            {
                var a = new album();
                List<album> lA = new List<album>();
                a.id = 1;
                a.title = "No Albums found matching entered criteria ";
                a.user = new user();
                a.user.id = -1;
                a.user.name = " ";
                lA.Add(a);
                albums = lA.AsQueryable();
            }
            pagedAlbums = albums.ToPagedList(pageIndex, pageSize);
            ViewBag.TitleFilter = " ";
            ViewBag.UserFilter = " ";

            return View(pagedAlbums);
        }

    }
}
