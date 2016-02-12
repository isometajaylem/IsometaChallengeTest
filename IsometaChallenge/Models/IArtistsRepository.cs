using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IsometaChallenge.Models
{
    public interface IArtistsRepository
    {
        IEnumerable<Artist> GetAll();
        void Add(Artist model);
        void Update(Artist model);
        Artist GetById(int id);
    }

    public class DbArtistsRepository : IArtistsRepository
    {
        public IEnumerable<Artist> GetAll()
        {
            using (var db = new MusicContext())
            {
                return db.Artists.ToList();
            }
        }

        public void Add(Artist model)
        {
            using (var db = new MusicContext())
            {
                db.Artists.Add(model);
                db.SaveChanges();
            }
        }

        public void Update(Artist model)
        {
            using (var db = new MusicContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Artist GetById(int id)
        {
            using (var db = new MusicContext())
            {
                return db.Artists.Find(id);
            }
        }
    }
}