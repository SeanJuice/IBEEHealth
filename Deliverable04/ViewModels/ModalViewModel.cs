using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Deliverable04.ViewModels
{
    public class ModalViewModel
    {

        [Required]
        [Display(Name = "Height")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string Height { get; set; }

        [Required]
        [Display(Name = "Weight")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string Weight { get; set; }
    }
}