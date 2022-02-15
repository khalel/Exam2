using System.ComponentModel.DataAnnotations;

namespace QLESS.Domain.Model
{
    public class Line
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string LineDesc { get; set; }
    }
}
