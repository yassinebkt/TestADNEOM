using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheMachineCafe.Models;

namespace TheMachineCafe.Dtos
{
    public class SelectionDto
    {
        public int Id { get; set; }

        [Required]
        public int BoissonId { get; set; }

        public string UserId { get; set; }

        [Required]
        [Range(0, 10)]
        //[RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public int Sucre { get; set; }

        [Required]
        public bool HasMuge { get; set; }

        public BoissonDto boisson { get; set; }
    }
}