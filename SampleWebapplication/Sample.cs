﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebapplication
{
    public class Sample
    {

        
            [Required]
            [Display(Name = "First Name")]

            public string FirstName { get; set; }

            [Required]
            
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

          
        
    }
}
