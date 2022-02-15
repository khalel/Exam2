using System.ComponentModel.DataAnnotations;

namespace QLESS.Domain.Model
{
    public class FareMatrix
    {
        public int Id { get; set; }
        [Required]
        public int StationPointAId { get; set; }
        [Required]
        public int StationPointBId { get; set; }
        [Required]
        public float Fare { get; set; }
    }
}
