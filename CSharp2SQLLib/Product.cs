﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLLib
{
    public class Product
    {
        public int Id { get; set; }
        public int PartNbr { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string PhotoPath { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public override string ToString()
        {
            return $"{Id} | {PartNbr} | {Name} | {Price} | {Unit} || {Vendor}";
        }
    }
}
