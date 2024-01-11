using System.ComponentModel.DataAnnotations;

namespace Veebipood2.Data
{
    public class ProductType : Entity
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Pealkirja maksimaalne pikkus on 50 tähemärki")]

        public string TypeName { get; set; }

        public IList<Product> Items { get; set; }

        public ProductType()
        {
            Items = new List<Product>();
        }
    }
}

// namespace Veebipood2.Models
//{
//public class ProductType
//{
//public int Id { get; set; }
//public string TypeName { get; set; }
//}
//}
