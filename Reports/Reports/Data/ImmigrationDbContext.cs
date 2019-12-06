using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Data
{
    public class ImmigrationDbContext : IdentityDbContext
    {
        public ImmigrationDbContext(DbContextOptions<ImmigrationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ImmigrationAccount> immigrationAccounts { get; set; }

    }
}
