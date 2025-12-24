namespace Classwork.Areas.AdminPanel.ViewModels
{
    public class GetProductVM
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<string> CategoryNames { get; set; }


    }
}
