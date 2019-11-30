namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public enum Statut { ouvert, cloture, Enattente };
    [Table("pidev.reclamation")]
    public partial class reclamation
    {
        [Key]
        public int ReclmationID { get; set; }



        [Display(Name = "Votre Nom")]
        [Required(ErrorMessage = "Choisir votre nom")]
        public int? user_id { get; set; }
        public virtual user user { get; set; }


        [Display(Name = "Titre Evaluation")]
        [Required(ErrorMessage = "Titre Evaluation est obligatoire")]
        public int? evaluation_id { get; set; }
        public virtual evaluation evaluation { get; set; }

        [StringLength(255)]
        [Display(Name = "Titre de Reclamation")]
        [Required(ErrorMessage = "Titre réclamation est obligatoire")]
        [MaxLength(50, ErrorMessage = "Max Length is 50")]
        public string titreclaim { get; set; }

        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description est obligatoire")]
        [MaxLength(500, ErrorMessage = "Max Length is 50")]
        public string descp { get; set; }

        [StringLength(255)]
        [Display(Name = "Importer une fichier")]
        public string fich { get; set; }

        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "commentaire")]
        [MaxLength(500, ErrorMessage = "Max Length is 50")]
        public string comment { get; set; }

       
        [Column(TypeName = "date")]
        public DateTime dateclose { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateopen { get; set; }

       
        [StringLength(255)]
        [Display(Name = "Reponse Reclamation")]
        [DataType(DataType.MultilineText)]
        public string reponse { get; set; }

        public Statut statut { get; set; }


       

        
    }
}
