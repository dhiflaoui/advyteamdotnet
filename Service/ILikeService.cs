using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ILikeService : IService<reactp>
    {
        int LikeExist(int idp, int idu);

        int nb_like(int idp);

    }
}
