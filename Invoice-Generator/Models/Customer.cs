using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Invoice_Generator.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "imię klienta jest polem obowiązkowym")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nazwisko klienta jest polem obowiązkowym")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Numer telefonu klienta jest polem obowiązkowym")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Nie dodano klasy Customer\\Adres")]
        public Address Address { get; set; }
    }
}
