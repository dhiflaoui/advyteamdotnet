using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Service.Pattern;
using Data.Infrastructure;

namespace Service
{
    public class ParticipationService : Service<affectationenligne>, IParticipationService
    {
        private static IDatabaseFactory dbfactor = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbfactor);

        public ParticipationService():base(wow)
        {

        }

       

        public int? UpdateNiveau( affectationenligne a)
        {
            int? c1 = a.niveau;
            int? w = c1 + 1;
            return w;
        }

    }
}
