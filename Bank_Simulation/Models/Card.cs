using Bank_Simulation.BasesClass;

namespace Bank_simulation.Models
{
    public class Card:BaseClass
    {
        
        public int CardNumber { get; set; }
        public int AccountID { get; set; }

        public required Account Account  { get; set; }
    }
}
