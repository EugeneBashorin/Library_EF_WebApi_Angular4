using Entities.Entities;
using System;
using System.Configuration;
using System.Data.Entity;

namespace DataAccessLayer.Context
{
    public class PublicationContext : DbContext
    {
        public PublicationContext(string connectionString)// : base()
        {
            this.Database.Connection.ConnectionString = connectionString;         
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Newspaper> Newspapers { get; set; }
        public DbSet<Buklet> Buklets { get; set; }
        public string ConnectionString { get; set; }
    }
}