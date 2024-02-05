using Bank_simulation.Models;
using Bank_Simulation.BasesClass;
namespace Bank_Simulation.Models
{
    public class Credentials:BaseClass
    {
        public required string login { get; set; }
        public required string password { get; set; }

        public DateTime LastLogIn { get; set; }



        public bool IsActive { get; set; }
        public int AccountID { get; set; }
        public Account account { get; set; }
        public int ClientID { get; set; }
        public required Client Client { get; set; }
    }
}
