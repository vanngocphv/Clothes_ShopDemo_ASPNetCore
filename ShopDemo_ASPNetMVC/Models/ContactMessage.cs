using System.ComponentModel.DataAnnotations;

namespace ShopDemo_ASPNetMVC.Models
{
    public class ContactMessage
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, EmailAddress, MaxLength(30)]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
