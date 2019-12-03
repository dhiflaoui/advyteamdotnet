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
    public class LikeService : Service<reactp>, ILikeService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork iow = new UnitOfWork(Factory);
        public LikeService() : base(iow)
        {

        }
        public int nb_like(int idp)
        {
            IEnumerable<reactp> fact = GetAll().Where(x => x.publication_id.Equals(idp));

            return fact.Count();


        }
        public int LikeExist(int idp , int idu)
        {
            IEnumerable<reactp> fact = GetAll().Where(x => x.publication_id.Equals(idp)).Where(s => s.user_id.Equals(idu));

            return fact.Count();


        }

    }
}
