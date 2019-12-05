using Data.Infrastructure;
using Domain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ParticipationService : Service<participation>, IParticipationService
    {

        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        //crud
        private static UnitOfWork uow = new UnitOfWork(dbFactory);
        public ParticipationService() : base(uow)
        {


        }


        public void AddParticipation(participation p)
        {

            uow.getRepository<participation>().Add(p);
            uow.Commit();
        }

        public void SaveChange()
        {
            uow.Commit();
        }

    }
}
