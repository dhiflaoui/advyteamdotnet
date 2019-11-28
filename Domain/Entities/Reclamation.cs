using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum Statut
    {
        ouvert, cloture, attente
    }
    [Table("Reclamation")]
    public class Reclamation
    {
        [Key]
        public int Numclaim { get; set; }
        public String descp { get; set; }
        public Statut statut { get; set; }
        public DateTime dateouverture { get; set; }
        public DateTime datecloture { get; set; }
        public String reponse { get; set; }
        public String comment { get; set; }
        //public int? userID { get; set; }
        //[ForeignKey("userID")]
       // public virtual user user { get; set; }
        public int? evaluationID { get; set; }
        [ForeignKey("evaluationID")]
        public virtual evaluation evaluation { get; set; }
    }
}
