namespace Veebipood2.Data.Queries
{
    public class ProductQuery : BaseQuery
    {
        public int? TypeId { get; set; }

        public string ProductSearch { get; set; }

        public override bool IsEmpty()
        {
            return TypeId == null &&
                string.IsNullOrWhiteSpace(ProductSearch);
        }
    }
}
