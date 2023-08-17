using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopDemo_ASPNetMVC.Models
{
    public class ClotheCategory
    {
        [Key, DisplayName("Category type")]
        public int Id { get; set; }
        [DisplayName("Category name")]
        public string CategoryName { get; set; }

    }
}
