using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICoursService : IService<cours>
    {
        int nbrCours(int? idf);
        object GetByformation(int? idfo);
    }
}
