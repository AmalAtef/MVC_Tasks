using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(256)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public int Age { get; set; }
        [Required]
        [Range(1500,10000)]
        [DataType(DataType.Currency)]
        public int Salary { get; set; }
        [Required]
        public Gender Gender { get; set; }

        [Display(Name ="Department")]
        public int FK_DepartmentId { get; set; }

        [ForeignKey("FK_DepartmentId")]
        public virtual Department Department { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}