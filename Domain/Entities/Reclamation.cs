namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public enum Statut
    {
        
        Ouvert ,
        Resolu ,
        Enattente,
        [Display(Name = "En attente")]
        Cloture 
    };
    //public static class statut
    //{
    //    public const string Ouvert = "Ouvert";

    //    public const string Resolu = "Resolu";
    //    public const string Enattente = "En attente";
    //    public const string Cloture = "Cloture";
    //}
    [Table("pidev.reclamation")]
    public partial class reclamation
    {
        [Key]
        [Display(Name = " Num ticket")]
        public int ReclmationID { get; set; }

        [Display(Name = " Nom employée")]
        public int? user_id { get; set; }
        public virtual user user { get; set; }


        [Display(Name = "Titre Evaluation")]
        public int? evaluation_id { get; set; }
        public virtual evaluation evaluation { get; set; }

        [StringLength(255)]
        [Display(Name = "Titre  Reclamation")]
        //[Required(ErrorMessage = "Titre réclamation est obligatoire")]
        [MaxLength(50, ErrorMessage = "Max Length is 50")]
        public string titreclaim { get; set; }

        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        //[Required(ErrorMessage = "Description est obligatoire")]
        [MaxLength(500, ErrorMessage = "Max Length is 50")]
        public string descp { get; set; }

        [StringLength(255)]
        [Display(Name = "Importer fichier")]
        public string fich { get; set; }

        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Commentaire")]
        [MaxLength(500, ErrorMessage = "Max Length is 50")]
        public string comment { get; set; }


        [Display(Name = "Date cloture ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateclose { get; set; }

        [Display(Name = "Date ouverture ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateopen { get; set; }

       
        [StringLength(255)]
        [Display(Name = "Reponse Reclamation")]
        [DataType(DataType.MultilineText)]
        public string reponse { get; set; }

        [Display(Name = "Statut")]
        public Statut statut { get; set; }


       

        
    }
}
