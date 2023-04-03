using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required(ErrorMessage = "ulica jest polem obowiązkowym")]
        public string Street { get; set; }
        [Required(ErrorMessage = "numer ulicy jest polem obowiązkowym")]
        public string NumberOf { get; set; } = null!;
        [Required(ErrorMessage = "Post Code jest polem obowiązkowym")]
        public string PostCode { get; set; }
        [Required(ErrorMessage = "Miasto jest polem obowiązkowym")]
        public string City { get; set; }
    }
}
