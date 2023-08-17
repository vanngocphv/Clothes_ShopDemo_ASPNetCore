using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopDemo_ASPNetMVC.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required, DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [Required, EmailAddress, DisplayName("Customer Email")]
        public string CustomerEmail { get; set; }
        [Required, DisplayName("Total Amount")]
        public float TotalPurchase { get; set; }
        public string TotalProductPurchase { get; set; }
        [MaxLength(500)]
        public string? Message { get; set; } = string.Empty;
    }
}
