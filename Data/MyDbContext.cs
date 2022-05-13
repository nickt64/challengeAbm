using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}