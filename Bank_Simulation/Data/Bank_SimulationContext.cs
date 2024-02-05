using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bank_simulation.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Bank_Simulation.ViewModels;

namespace Bank_Simulation.Data
{
    public class Bank_SimulationContext : DbContext
    {
        public Bank_SimulationContext (DbContextOptions<Bank_SimulationContext> options)
            : base(options)
        {
        }

        public DbSet<Bank_simulation.Models.Client> Client { get; set; } = default!;
        public DbSet<Models.TypeAccount> AccountsTypes { get; set; } = default!;
        
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=PB_MASTER\\SQLEXPRESS_HOME;Database=Bank_SimulationContext-dfad491d-5972-4e31-ab1d-ee81f48919fb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Bank_Simulation.ViewModels.RegistrationViewModel> RegistrationViewModel { get; set; } = default!;
       
  

    }
}
