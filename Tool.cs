﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsRental
{
    public sealed class Tool
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public int Price { get; private set; }
        public string Note { get; private set; }
        public string PathToPicture { get; private set; }
        

        public Tool(string name, int price, int id, string note = null, string pathToPicture = null)
        {
            Name = name;
            Price = price;
            Id = id;
            Note = note;
            PathToPicture = pathToPicture;
        }
    }
}
