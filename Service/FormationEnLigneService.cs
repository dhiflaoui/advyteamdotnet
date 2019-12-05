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
    public class FormationEnLigneService : Service<formationenligne>, IFormationEnLigneService
    {
        private static IDatabaseFactory dbfactor = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbfactor);

        public FormationEnLigneService() : base(wow)
        {
        }
       }
    }

