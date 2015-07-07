using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MI9.Models
{
    public class Episode
    {
        public string channel { get; set; }
        public string channelLogo { get; set; }
        public string html { get; set; }
        public string url { get; set; }
        public DateTime? date { get; set; }
    }
}
