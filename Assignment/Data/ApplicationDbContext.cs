using Assignment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ITmanagerModel> ITmanagerModel { get; set; }

        public DbSet<TechnicalIssueModel> TechnicalIssue { get; set; }

        public DbSet<GeneralIssuesModel> GeneralIssues { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
