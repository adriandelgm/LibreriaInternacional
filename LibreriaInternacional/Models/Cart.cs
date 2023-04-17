﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaInternacional.Models
{
    public enum Form
    {
        none,
        moreThan15,
        negativeNights
    }
    public class Cart : Books
    {
        public int idCart { get; set; }
        public int idBook { get; set; }
        public LoginResponsePayload Session { get; set; }
        public string ISBN { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
        public int Units { get; set; }
        public decimal Cost { get; set; }

        public bool isReady = false;
    }

}