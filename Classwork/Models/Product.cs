namespace Classwork.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal FirstPrice { get; set; }
        public string ImageUrl { get; set; }
        public string SKU { get; set; }
        public string FirstDescribtion { get; set; }
        public string LastDescribtion { get; set; }
        public List<Category> Categories { get; set; }
    }
}
