using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

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

        public Jugadores(int id, string name, string lastname, string club, string position, double salary, double compensation)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
            this.Club = club;
            this.Position = position;
            this.Salary = salary;
            this.Compensation = compensation;
        }
      

    }
}
