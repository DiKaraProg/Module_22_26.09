using Microsoft.EntityFrameworkCore;
using Module_21_MVC_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC.Dal
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Worker> Worker { get; set; }

        public DbSet<User> User { get; set; }
    }
}
