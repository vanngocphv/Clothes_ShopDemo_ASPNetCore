using ShopDemo_ASPNetMVC.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDemo_ASPNetMVC.Models
{
    public class Clothe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(1, int.MaxValue)]
        public float Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        //[ForeignKey("ClotheCategory"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int ClotheCategoryId { get; set; }
        //public ClotheCategory ClotheCategory { get; set; }
        public ClothCategory ClotheCategory { get; set; }

        [NotMapped]
        public IFormFile? FileImage { get; set; }
    }
}
