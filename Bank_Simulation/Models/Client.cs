using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using Bank_Simulation.BasesClass;

using Bank_Simulation.Models;
using System.ComponentModel;
namespace Bank_simulation.Models
{
    public class Client : BaseClass
    {
        [DisplayName("Imię")]
        public string FirsName { get; set; }
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }

        [DisplayName("Ulica")]
        public string Street { get; set; }
        [DisplayName("Numer domu")]
        public string StreetNumber { get; set; }
        [DisplayName("Kod pocztowy")]
     
        public string PostCode { get; set; }
        [DisplayName("Miasto")]
        public string City { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [HiddenInput]
        public DateTime Created { get; set; }=DateTime.Now;
        public string Pesel { get; set; }

        [DisplayName("Numer dowodu")]
        public string IDNumber { get; set; }

        public int typeAcccountId {  get; set; }
        public ICollection<Credentials> Credentials { get; }= new List<Credentials>();
     




        
      
    }
}
