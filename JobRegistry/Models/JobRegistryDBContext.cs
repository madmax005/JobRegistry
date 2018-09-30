using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobRegistry.Models
{
    public class JobRegistryDBContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<JobDetail> JobDetails { get; set; }
    }
}