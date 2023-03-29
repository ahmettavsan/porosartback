﻿using Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Identity
{
    public class AppUser:IdentityUser<int>,IEntity
    {
        public string? ImagePath { get; set; }     
    }
}
