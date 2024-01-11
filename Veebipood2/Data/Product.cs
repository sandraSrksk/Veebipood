using System.ComponentModel.DataAnnotations;

namespace Veebipood2.Data
{
    public class Product : Entity
    {
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }

//namespace Veebipood2.Models
//{
//  public class Product
  //{
    //  public int Id { get; set; }
      //public string Name { get; set; }
      //public string Description { get; set; }
      //public decimal Price { get; set; }
      // Foreign key
      //public int ProductTypeId { get; set; }
      //public ProductType ProductType { get; set; }
  //}
//}
}
