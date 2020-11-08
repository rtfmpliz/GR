﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class EditBookViewModel
    {
        [Display(Name = "Book Name")]
        public string BookName
        {
            get;
            set;
        }
        public string ISBN
        {
            get;
            set;
        }
        public string Publisher
        {
            get;
            set;
        }
        public List<SelectListItem> Authors
        {
            get;
            set;
        } = new List<SelectListItem>();
        [Display(Name = "Author")]
        public long AuthorId
        {
            get;
            set;
        }
    }
}
