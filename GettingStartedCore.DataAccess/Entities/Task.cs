using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GettingStartedCore.DataAccess.Entities
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Level { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [Required]
        public int EmployeeId { get; set; }
    }
}
