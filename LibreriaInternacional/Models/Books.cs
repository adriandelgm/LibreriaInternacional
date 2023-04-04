﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaInternacional.Models
{
    public class Books
    {
        public int ISBN { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PublishingDate { get; set; }
        public decimal Price { get; set; }
    }
}