using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal class PhoneBookContext : DbContext
    {
        public DbSet<Contact> PhoneBook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PQ5I4GS\MSSQLSERVER02;Database=PhoneBookDB;Trusted_Connection=True;");
        }
    }

}
