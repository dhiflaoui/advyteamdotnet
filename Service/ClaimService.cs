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
   public class ClaimService : Service<reclamation> , IClaimService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork iow = new UnitOfWork(factory);
        public ClaimService() : base(iow)
        {
        }

        public IEnumerable<reclamation> getListByEval(String eval)
        {
            return GetAll().Where(x => x.evaluation.id.Equals(eval));
        }
        public IEnumerable<reclamation> getListByUser(String usr)
        {
            return GetAll().Where(x => x.user.nom.Equals(usr));
        }
    }
}
