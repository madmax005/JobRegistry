using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobRegistry.Models
{
    public class JobDetail
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        [Display(Name = "Job Discription")]
        public string JobDescription { get; set; }

        [Display(Name = "Salary")]
        public decimal Salary { get; set; }
    }
}