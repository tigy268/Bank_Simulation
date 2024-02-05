using Bank_simulation.Models;
using Bank_Simulation.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulation.Repositories
{
    public class ActionsRepository : IActionRepository
    {
        private readonly Bank_SimulationContext _context;

        public ActionsRepository(Bank_SimulationContext context)
        {
            _context = context;
        }

        public void Add(Action action) { }


   
    }
}
