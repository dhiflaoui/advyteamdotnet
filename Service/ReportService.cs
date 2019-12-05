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
   public class ReportService : Service<report>, IReportService
    {
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        //crud
        private static UnitOfWork uow = new UnitOfWork(dbFactory);
        public ReportService() : base(uow)
        {


        }


        public void AddReport(report report)
        {

            uow.getRepository<report>().Add(report);
            uow.Commit();
        }

        public void SaveChange()
        {
            uow.Commit();
        }


    }
}
