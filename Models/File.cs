﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace ligtasUnaAPI.Models
{
    public class File
    {
        public IFormFile FileData { get; set; }
    }
}
