using Data.Infrastructure;
using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MissionService : Service<mission>, IMissionService
    {

        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork iow = new UnitOfWork(factory);
        public MissionService() : base(iow)
        {


        }

    
    }
}
