using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class GeneralIssuesModel
    {   
        [Required]
        [Key]
        public int ID { get; set; }
        [Required]
        public string IssueName { get; set; }
        [Required]
        public string IssueDetails { get; set; }
        [Required]
        public string StaffName { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
