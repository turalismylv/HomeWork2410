using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace front_to_back.Models
{
    public class ContactBannerHero
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Information { get; set; }
        public string? PhotoPath { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
