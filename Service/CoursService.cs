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
    public class CoursService : Service<cours>, ICoursService
    {
        private static IDatabaseFactory dbfactor = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbfactor);

        public CoursService():base(wow)
    {
        }

        public object GetByformation(int? idfo)
        {
            IEnumerable<cours> fact = GetAll().Where(x => x.formationEnLign_formationElLigneId.Equals(idfo));
            return fact;
        }

        public int nbrCours(int? idf)
        { IEnumerable<cours> fact = GetAll().Where(x => x.formationEnLign_formationElLigneId.Equals(idf));
            return fact.Count();
        }
       
    }
}
