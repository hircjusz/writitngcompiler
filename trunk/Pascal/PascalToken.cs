﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace Pascal
{
    public class PascalToken : Token
    {
        public PascalToken() { }
        public PascalToken(Source source) : base(source) { }
    }
}
