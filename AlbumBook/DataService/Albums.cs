using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using AlbumBook.Models;
using System.Net.Http;

namespace AlbumBook.DataService
{
    public class MyAlbums
    {
        private const string albumsApi = "https://jsonplaceholder.typicode.com/albums";
        private const string usersApi = "https://jsonplaceholder.typicode.com/users";
        private const string photosApi = "https://jsonplaceholder.typicode.com/photos";
        private const string postsApi = "https://jsonplaceholder.typicode.com/posts";

        public async Task <IQueryable<album>> Albums ()
        {
            IQueryable<album> qAlbums = Enumerable.Empty<album>().AsQueryable();
            List<album> lAlbums = new List<album>();
            List<user> lUsers = new List<user>();
            List<photo> lPhotos = new List<photo>();
            List<post> lPosts = new List<post>();
            var client = new HttpClient();

            //albums
            HttpResponseMessage response = await client.GetAsync(albumsApi);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            lAlbums = Newtonsoft.Json.JsonConvert.DeserializeObject<List<album>>(result);

            //users
            response = await client.GetAsync(usersApi);
            response.EnsureSuccessStatusCode();
            result = await response.Content.ReadAsStringAsync();
            lUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<user>>(result);

            //photos
            response = await client.GetAsync(photosApi);
            response.EnsureSuccessStatusCode();
            result = await response.Content.ReadAsStringAsync();
            lPhotos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<photo>>(result);

            //posts
            response = await client.GetAsync(postsApi);
            response.EnsureSuccessStatusCode();
            result = await response.Content.ReadAsStringAsync();
            lPosts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<post>>(result);

            //populate post in users
            foreach (user u in lUsers)
            {
                if (lPosts.Count(p => p.userId == u.id) > 0)
                {
                    u.posts = new Collection<post>( lPosts.FindAll(p => p.userId == u.id));
                }

            }

            //populate users in albums
            //populate photos in albums
            foreach (album a in lAlbums)
            {
                a.user = new user();
                a.user = lUsers.First(u => u.id == a.userId);
                a.photos = new Collection<photo>(lPhotos.FindAll(p => p.albumId == a.id));
            }

            qAlbums = lAlbums.AsQueryable<album>();
            return (qAlbums);
        }

    }
}