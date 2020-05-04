using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDay2.Models
{

    public enum Gender
    {
        Male,
        Female
    }
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public int Age { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}