using Bank_Simulation.BasesClass;
using Bank_Simulation.Models;

namespace Bank_simulation.Models
{
    public class Account:BaseClass
    {
       
        public int AccountNumber { get; set; }
    
        
        public DateTime Created { get; set;}=DateTime.Now;

    
        public ICollection<Credentials> credentials { get; }= new List<Credentials>();
       // public List<Client> clients { get; } = new(); 




        



    }
}
