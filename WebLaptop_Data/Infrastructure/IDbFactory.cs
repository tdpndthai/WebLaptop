﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLaptop_Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        WebLaptopDbContext Init();
    }
}
