﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.models
{
    public class ResultModel
    {
        public List<string> Headers { get; set; }
        public List<List<string>> Rows { get; set; }
    }
}
