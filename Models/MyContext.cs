using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

 
namespace AttemptOne.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Note> Notes { get; set; }
    }
}