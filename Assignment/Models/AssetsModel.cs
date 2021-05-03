using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class AssetsModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AssetName { get; set; }

        [Required]
        public int AssetAmount { get; set; }
    }
}
