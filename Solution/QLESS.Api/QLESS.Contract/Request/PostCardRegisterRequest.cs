using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLESS.Contract.Request
{
    public class PostCardRegisterRequest
    {
        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public int CardRegTypeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
