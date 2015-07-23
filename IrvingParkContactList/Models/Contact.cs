using System.ComponentModel.DataAnnotations;

namespace IrvingParkContactList.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        [Required]
        public CityBlock Block { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

         [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public bool PreferSms { get; set; }
        
        public bool PreferEmail { get; set; }

        public string Notes { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }
    }
}