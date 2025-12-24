using System.ComponentModel.DataAnnotations.Schema;

namespace Classwork.Areas.AdminPanel.ViewModels.Slider
{
    public class SliderUpdateVM
    {
        public string? ImageUrl { get; set; }
        public int Order { get; set; }

        public IFormFile Photo { get; set; }
    }
}
