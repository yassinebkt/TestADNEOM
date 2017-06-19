using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheMachineCafe.Dtos
{
    public class BoissonDto
    {
        public int Id { get; set; }
        [Required]
        public string nom { get; set; }
    }
}