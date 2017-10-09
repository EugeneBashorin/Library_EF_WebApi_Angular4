using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private PublicationContext db;
        public BookRepository(string connectionstring)
        {
            this.db = new PublicationContext(connectionstring);
        }

        public List<Book> GetAll()
        {
            List<Book> booksList = new List<Book>();
            var books = db.Books;
            foreach (var booksItem in books)
            {
                booksList.Add(booksItem);
            }
            return booksList;
        }

        public Book GetItemById(int? id)
        {
            Book book = db.Books.Find(id); //=new Book();
            return book;
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void Update(int? Id, Book book)
        {
            Book newBook = db.Books.Find(Id);
            if (newBook != null)
            {
                newBook.Name = book.Name;
                newBook.Author = book.Author;
                newBook.Publisher = book.Publisher;
                newBook.Price = book.Price;
            }
            db.Entry(newBook).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        public List<Book> FilterByPublisher(string publisherName)
        {
            List<Book> filteredPublisherList = new List<Book>();
            var booksList = db.Books;
            foreach (var booksItem in booksList)
            {
                if (booksItem.Publisher == publisherName)
                {
                    filteredPublisherList.Add(booksItem);
                }
            }
            return filteredPublisherList;
        }

        public List<string> GetAllPublishers()
        {
            List<string> publishersList = new List<string>();
            var bookList = db.Books;
            foreach (var booksItem in bookList)
            {
                publishersList.Add(booksItem.Publisher);
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