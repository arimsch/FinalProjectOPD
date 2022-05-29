using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int LecId { get; set; }
        public Lec Lec { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int Grade { get; set; }
        public bool Attend { get; set; }
    }
}
