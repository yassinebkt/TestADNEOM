using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TheMachineCafe.Models
{
    public class Boisson
    {
        public int Id { get; set; }

        [Required]
        public string nom { get; set; }
    }
}