using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

using System.Web;

namespace DataAccessLayer.Repositories
{
    public class BukletRepository : IBukletRepository
    {
        private PublicationContext db;

        public BukletRepository(string connectionString)
        {
            this.db = new PublicationContext(connectionString);
        }

        public List<Buklet> GetAll()
        {
            List<Buklet> bukletsList = new List<Buklet>();
            var buklets = db.Buklets;
            foreach (var bukletsItem in buklets)
            {
                bukletsList.Add(bukletsItem);
            }
            return bukletsList;
        }

        public Buklet GetItemById(int? id)
        {
            Buklet buklet = db.Buklets.Find(id); //=new Book();
            return buklet;
        }

        public void Create(Buklet buklet)
        {
            db.Buklets.Add(buklet);
            db.SaveChanges();
        }

        public void Update(int? Id, Buklet buklet)
        {
            Buklet newBuklet = db.Buklets.Find(Id);
            if (newBuklet != null)
            {
                newBuklet.Name = buklet.Name;
                newBuklet.Author = buklet.Author;
                newBuklet.Publisher = buklet.Publisher;
                newBuklet.Price = buklet.Price;
            }
            db.Entry(newBuklet).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            Buklet buklet = db.Buklets.Find(id);
            if (buklet != null)
            {
                db.Buklets.Remove(buklet);
                db.SaveChanges();
            }
        }

        public List<Buklet> FilterByPublisher(string publisherName)
        {
            List<Buklet> filteredPublisherList = new List<Buklet>();
            var bukletsList = db.Buklets;
            foreach (var bukletsItem in bukletsList)
            {
                if (bukletsItem.Publisher == publisherName)
                {
                    filteredPublisherList.Add(bukletsItem);
                }
            }
            return filteredPublisherList;
        }

        public List<string> GetAllPublishers()
        {
            List<string> publishersList = new List<string>();
            var bukletList = db.Buklets.Select(buklet => buklet.Publisher).Distinct();
            foreach (var bukletsItem in bukletList)
            {
                publishersList.Add(bukletsItem);
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