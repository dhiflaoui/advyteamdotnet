using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IFeedbackService : IService<feedback>
    {
        int nb_Comment(int idp);
        int superFun(int idpu, int idu);

    }
}
