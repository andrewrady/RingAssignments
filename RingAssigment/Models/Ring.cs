using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RingAssigment.Models
{
    public class Ring
    {
        public int Id { get; set; }

        [Required]
        public int RingNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Rank { get; set; }
        
        [Required]
        [MaxLength(25)]
        public string AgeRange { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(100)]
        public string Division { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
