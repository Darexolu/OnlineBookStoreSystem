using Microsoft.EntityFrameworkCore;
using OnlineBookStoreSystem.Models;
using System.Collections.Generic;

namespace OnlineBookStoreSystem.Data
{
    public class OnlineDbContext: DbContext
    {
        public OnlineDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
