using DiarsT1.DataBase.Map;
using DiarsT1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiarsT1.DataBase
{
    public class SimuladorContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=JOSUERIVERA\\SQLEXPRESS; DataBase=DiarsT1;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonaConfiguration());
            modelBuilder.ApplyConfiguration(new CiudadConfiguration());
        }
    }
}
