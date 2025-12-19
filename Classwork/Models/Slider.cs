using System.ComponentModel.DataAnnotations.Schema;

namespace Classwork.Models
{
    public class Slider : BaseEntity
    {

        public string ImageUrl { get; set; }
        public int Order { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
