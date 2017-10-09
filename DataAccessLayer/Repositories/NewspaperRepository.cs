using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class NewspaperRepository : INewspaperRepository
    {
        private PublicationContext db;

        public NewspaperRepository(string connectionString)
        {
            this.db = new PublicationContext(connectionString);
        }

        public List<Newspaper> GetAll()
        {
            List<Newspaper> newspapersList = new List<Newspaper>();
            var newspapers = db.Newspapers;
            foreach (var newspapersItem in newspapers)
            {
                newspapersList.Add(newspapersItem);
            }
            return newspapersList;
        }

        public Newspaper GetItemById(int? id)
        {
            Newspaper newspaper = db.Newspapers.Find(id);
            return newspaper;
        }

        public void Create(Newspaper newspaper)
        {
            db.Newspapers.Add(newspaper);
            db.SaveChanges();
        }

        public void Update(int? Id, Newspaper newspaper)
        {
            Newspaper newNewspaper = db.Newspapers.Find(Id);
            if (newNewspaper != null)
            {
                newNewspaper.Name = newspaper.Name;
                newNewspaper.Category = newspaper.Category;
                newNewspaper.Publisher = newspaper.Publisher;
                newNewspaper.Price = newspaper.Price;
            }
            db.Entry(newNewspaper).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            Newspaper newspaper = db.Newspapers.Find(id);
            if (newspaper != null)
            {
                db.Newspapers.Remove(newspaper);
                db.SaveChanges();
            }
        }

        public List<Newspaper> FilterByPublisher(string publisherName)
        {
            List<Newspaper> filteredPublisherList = new List<Newspaper>();
            var newspapersList = db.Newspapers;
            foreach (var newspapersItem in newspapersList)
            {
                if (newspapersItem.Publisher == publisherName)
                {
                    filteredPublisherList.Add(newspapersItem);
                }
            }
            return filteredPublisherList;
        }

        public List<string> GetAllPublishers()
        {
            List<string> publishersList = new List<string>();
            var newspaperList = db.Newspapers;
            foreach (var newspapersItem in newspaperList)
            {
                publishersList.Add(newspapersItem.Publisher);
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