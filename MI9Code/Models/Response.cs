using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MI9.Models
{
    public class Response
    {
        public string image { get; set; }
        public string slug { get; set; }
        public string title { get; set; }

        public override bool Equals(object obj)
        {
            return this.image == ((Response)obj).image && this.slug == ((Response)obj).slug && this.title == ((Response)obj).title;
        }
    }
}