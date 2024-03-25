using CoreBankAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreBankAPI.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}