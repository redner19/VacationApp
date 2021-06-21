﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StartVacation.Model
{
    public class Property
    {
        public string Id => Guid.NewGuid().ToString("N");
        public string PropertyName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Price { get; set; }
        public string Bed { get; set; }
        public string Bath { get; set; }
        public string Space { get; set; }
        public string Details { get; set; }
        public bool IsKingSize { get; set; }
        public bool IsQueenSize { get; set; }

        public float getCurrentPrice() => float.Parse(Price);
    }
}
