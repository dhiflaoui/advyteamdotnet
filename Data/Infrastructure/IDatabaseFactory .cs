﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        AdvyteamContext DataContext { get; }
    }

}
