using System.ComponentModel.DataAnnotations;

namespace QLESS.Domain.Model
{
    class Station
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string StationDesc { get; set; }
        [Required]
        public int LineId { get; set; }
    }
}
