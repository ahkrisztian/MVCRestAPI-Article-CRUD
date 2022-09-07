using System.ComponentModel.DataAnnotations;

namespace MVCRestAPI.DTOs
{
    public class ArticleCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
