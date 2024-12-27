using BookManagementApp.Models;
using Microsoft.EntityFrameworkCore;
namespace BookManagementApp.Db
{
    public class BookDbContext :DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
