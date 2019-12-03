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
    public class FeedbackService : Service<feedback>, IFeedbackService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork iow = new UnitOfWork(Factory);
        public FeedbackService() : base(iow)
        {

        }
        public  int nb_Comment( int idp)
        {
            IEnumerable<feedback> fact = GetAll().Where(x => x.publication_id.Equals(idp));

            return fact.Count();

            
        }
        public int superFun(int idpu, int idu)
        {
            // feedback faza = GetAll().Where(x => x.user_id.Equals(idu)).Where(x => x.publication.user_id.Equals(idpu));
            // feedback fact = GetAll().Where(x =>x )
            // IEnumerable<feedback> fact = GetAll().Where(x => x.user_id.Equals(idu)).Where(x => x.publication.user_id.Equals(idpu));
           
            return 3;


        }
    }
}
