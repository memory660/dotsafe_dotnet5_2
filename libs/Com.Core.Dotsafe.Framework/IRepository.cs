﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.Dotsafe.Framework
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
