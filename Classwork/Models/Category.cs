namespace Classwork.Models
{
    public class Category :BaseEntity
    {
        public string Name { get; set; }
        public List<Product> products { get; set; }
    }
}
