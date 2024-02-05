using Bank_Simulation.BasesClass;

namespace Bank_Simulation.Models

{
    public class Transaction:BaseClass
    {
       public DateTime Date {  get; set; }
        public int Amount {  get; set; }
        public string Status { get; set; }
        public string ReceiverName { get; set; }




        

    }
}
