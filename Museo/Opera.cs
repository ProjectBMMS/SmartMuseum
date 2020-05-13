﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museo
{
    class Opera
    {
        public string Nome { get; set; }
        public string Autore { get; set; }
        public int Anno { get; set; }
        public string Link { get; set; }

        public override string ToString()
        {
            return $"{Nome}, {Autore}, {Anno}";
        }
    }
}
