using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Lec
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int LectorId { get; set; }
        public Lector Lector { get; set; }
    }
}
