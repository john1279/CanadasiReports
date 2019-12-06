using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reports.Models;

namespace Reports.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TotalLeads> TotalLeads { get; set; }

        public DbSet<Reports.Models.SalesPersonsPendingFollowUps> SalesPersonsPendingFollowUps { get; set; }

        public DbSet<Reports.Models.SalesPersonsPendingTasks> SalesPersonsPendingTasks { get; set; }

        public DbSet<Reports.Models.ContractsSent> ContractsSent { get; set; }
    }
}
