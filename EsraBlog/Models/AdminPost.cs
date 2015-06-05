﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsraBlog.Models
{
    public class AdminPost
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
    }
}