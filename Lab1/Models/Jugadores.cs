using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class Jugadores
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Club { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public double Compensation { get; set; }

    }
}
