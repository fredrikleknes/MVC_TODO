using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODOWEB.Models;

namespace TODOWEB.Models
{
    public class TODOWEBContext : DbContext
    {
        public TODOWEBContext (DbContextOptions<TODOWEBContext> options)
            : base(options)
        {
        }

        public DbSet<TODOWEB.Models.Person> Person { get; set; }

        public DbSet<TODOWEB.Models.Todolist> Todolist { get; set; }

        public DbSet<TODOWEB.Models.Overview> Overview { get; set; }
    }
}
