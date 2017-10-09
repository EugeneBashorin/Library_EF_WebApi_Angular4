using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class MagazineRepository : IMagazineRepository
    {
        private PublicationContext db;

        public MagazineRepository(string connectionstring)
        {
            this.db = new PublicationContext(connectionstring);
        }

        public List<Magazine> GetAll()
        {
            List<Magazine> magazinesList = new List<Magazine>();
            var magazines = db.Magazines;
            foreach (var magazinesItem in magazines)
            {
                magazinesList.Add(magazinesItem);
            }
            return magazinesList;
        }

        public Magazine GetItemById(int? id)
        {
            Magazine magazine = db.Magazines.Find(id);
            return magazine;
        }

        public void Create(Magazine magazine)
        {
            db.Magazines.Add(magazine);
            db.SaveChanges();
        }

        public void Update(int? Id, Magazine magazine)
        {
            Magazine newMagazine = db.Magazines.Find(Id);
            if (newMagazine != null)
            {
                newMagazine.Name = magazine.Name;
                newMagazine.Category = magazine.Category;
                newMagazine.Publisher = magazine.Publisher;
                newMagazine.Price = magazine.Price;
            }
            db.Entry(newMagazine).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            Magazine magazine = db.Magazines.Find(id);
            if (magazine != null)
            {
                db.Magazines.Remove(magazine);
                db.SaveChanges();
            }
        }

        public List<Magazine> FilterByPublisher(string publisherName)
        {
            List<Magazine> filteredPublisherList = new List<Magazine>();
            var magazinesList = db.Magazines;
            foreach (var magazinesItem in magazinesList)
            {
                if (magazinesItem.Publisher == publisherName)
                {
                    filteredPublisherList.Add(magazinesItem);
                }
            }
            return filteredPublisherList;
        }

        public List<string> GetAllPublishers()
        {
            List<string> publishersList = new List<string>();
            var magazineList = db.Magazines;
            foreach (var magazinesItem in magazineList)
            {
                publishersList.Add(magazinesItem.Publisher);
            }
            return publishersList;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}