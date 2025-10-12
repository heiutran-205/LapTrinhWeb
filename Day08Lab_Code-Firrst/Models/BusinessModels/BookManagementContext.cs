using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace Day08Lab_Code_Firrst.Models.BusinessModels
{
    public class BookManagementContext :  DbContext
    {
        public BookManagementContext(DbContextOptions<BookManagementContext> options): base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
    }
}
