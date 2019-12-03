using Data;
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
    public class PublicationService : Service<publication>, IPublicationService
    {
        AdvyteamContext dd= new AdvyteamContext();
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork iow = new UnitOfWork(Factory);
        public PublicationService() : base(iow)
        {
            

        }
        //public IEnumerable<publication> GetAll()
        //{
        //    return dd.publications.Include(p => p.feedbacks);
        //}
    }
}
