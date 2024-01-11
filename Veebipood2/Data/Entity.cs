using System.ComponentModel.DataAnnotations.Schema;

namespace Veebipood2.Data
{
    public abstract class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
