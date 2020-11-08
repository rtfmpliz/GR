using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class BookListingViewModel
    {
        public long Id
        {
            get;
            set;
        }
        public string BookName
        {
            get;
            set;
        }
        public string AuthorName
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
    }
}
