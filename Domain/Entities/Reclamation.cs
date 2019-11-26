using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum Statut
    {
        ouvert, cloture, attente

    }
    public class Reclamation
    {[Key]
        public int Numclaim { get; set; }
        public String descp { get; set; }
        public Statut statut { get; set; }
        public DateTime dateouverture { get; set; }
        public DateTime datecloture { get; set; }
        public String reponse { get; set; }
        public String comment { get; set; }

        public user user { get; set; }
        public evaluation evaluation { get; set; }

    }
}
