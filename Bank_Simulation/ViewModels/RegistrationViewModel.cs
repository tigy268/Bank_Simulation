
using Bank_Simulation.BasesClass;
using Bank_Simulation.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bank_Simulation.ViewModels
{/*Combination Client Model+Credentials Model*/
    public class RegistrationViewModel : BaseClass
    {
       
        [DisplayName("Imię")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }
        [DisplayName("Miasto")]
        public string City { get; set; }
        [DisplayName("Ulica")]
        public string Street { get; set; }
        [DisplayName("Numer ulicy")]
        public string StreetNumber { get; set; }
        [DisplayName("Kod pocztowy")]
        //[RegularExpression("^[0-9]{2}-[0-9]{3}$")]
        public string PostCode { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
       
        public string Pesel { get; set; }
        [DisplayName("Numer dowodu")]
        public string NumberId {  get; set; }
        public DateTime Created { get; set; }=DateTime.Now;

        public TypeAccount typeAccount { get; set; } 
            

    }
}
