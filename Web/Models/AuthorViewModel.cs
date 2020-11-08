﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class AuthorViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName
        {
            get;
            set;
        }
        [Display(Name = "Last Name")]
        public string LastName
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
    }
}
