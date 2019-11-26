namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "pidev.absence",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateDebut = c.DateTime(storeType: "date"),
                        dateFin = c.DateTime(storeType: "date"),
                        decision = c.String(maxLength: 255, unicode: false),
                        etat = c.String(maxLength: 255, unicode: false),
                        file = c.String(maxLength: 255, unicode: false),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.user", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "pidev.user",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ToBeEval = c.Boolean(storeType: "bit"),
                        adresseMail = c.String(maxLength: 255, unicode: false),
                        cin = c.String(maxLength: 255, unicode: false),
                        cv = c.String(maxLength: 255, unicode: false),
                        motdp = c.String(maxLength: 255, unicode: false),
                        nom = c.String(maxLength: 255, unicode: false),
                        photo = c.String(maxLength: 255, unicode: false),
                        prenom = c.String(maxLength: 255, unicode: false),
                        role = c.String(maxLength: 255, unicode: false),
                        salaire = c.Double(),
                        solde_absence = c.Int(),
                        solde_conge = c.Int(),
                        specialite = c.String(maxLength: 255, unicode: false),
                        tel = c.String(maxLength: 255, unicode: false),
                        ville = c.String(maxLength: 255, unicode: false),
                        memberOf_id = c.Int(),
                        mission_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.equipe", t => t.memberOf_id)
                .ForeignKey("pidev.mission", t => t.mission_id)
                .Index(t => t.memberOf_id)
                .Index(t => t.mission_id);
            
            CreateTable(
                "pidev.affectation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Montion = c.String(maxLength: 255, unicode: false),
                        Score = c.Int(),
                        formations_Id = c.Int(),
                        users_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("pidev.formation", t => t.formations_Id)
                .ForeignKey("pidev.user", t => t.users_id)
                .Index(t => t.formations_Id)
                .Index(t => t.users_id);
            
            CreateTable(
                "pidev.formation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(maxLength: 255, unicode: false),
                        date = c.String(maxLength: 255, unicode: false),
                        duree = c.Int(),
                        nbrP = c.Int(),
                        objectifs = c.String(maxLength: 255, unicode: false),
                        prix = c.Int(),
                        Specialtie = c.String(maxLength: 255, unicode: false),
                        formateur_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("pidev.formateur", t => t.formateur_id)
                .ForeignKey("pidev.user", t => t.user_id)
                .Index(t => t.formateur_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "pidev.formateur",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Disponible = c.String(maxLength: 255, unicode: false),
                        email = c.String(maxLength: 255, unicode: false),
                        nom = c.String(maxLength: 255, unicode: false),
                        numero = c.String(maxLength: 255, unicode: false),
                        prenom = c.String(maxLength: 255, unicode: false),
                        Specialite = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "pidev.assignment",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        finishedIn = c.Int(nullable: false),
                        title = c.String(maxLength: 255, unicode: false),
                        emp_id = c.Int(),
                        task_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.task", t => t.task_id)
                .ForeignKey("pidev.user", t => t.emp_id)
                .Index(t => t.emp_id)
                .Index(t => t.task_id);
            
            CreateTable(
                "pidev.task",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 255, unicode: false),
                        Title = c.String(maxLength: 255, unicode: false),
                        duration = c.Int(nullable: false),
                        spec = c.String(maxLength: 255, unicode: false),
                        state = c.String(maxLength: 255, unicode: false),
                        project_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.project", t => t.project_id)
                .Index(t => t.project_id);
            
            CreateTable(
                "pidev.project",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        budget = c.Int(nullable: false),
                        clientName = c.String(maxLength: 255, unicode: false),
                        description = c.String(maxLength: 255, unicode: false),
                        state = c.String(maxLength: 255, unicode: false),
                        title = c.String(maxLength: 255, unicode: false),
                        ownedBy_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.user", t => t.ownedBy_id)
                .Index(t => t.ownedBy_id);
            
            CreateTable(
                "pidev.bug",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        reportDate = c.DateTime(storeType: "date"),
                        state = c.String(maxLength: 255, unicode: false),
                        title = c.String(maxLength: 255, unicode: false),
                        project_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.project", t => t.project_id)
                .Index(t => t.project_id);
            
            CreateTable(
                "pidev.conge",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateDebut = c.DateTime(storeType: "date"),
                        dateFin = c.DateTime(storeType: "date"),
                        etat = c.String(maxLength: 255, unicode: false),
                        file = c.String(maxLength: 255, unicode: false),
                        type = c.String(maxLength: 255, unicode: false),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.user", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "pidev.equipe",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        score = c.Int(nullable: false),
                        title = c.String(maxLength: 255, unicode: false),
                        managedBy_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.user", t => t.managedBy_id)
                .Index(t => t.managedBy_id);
            
            CreateTable(
                "pidev.evaluation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DATE_EVAL = c.DateTime(precision: 0),
                        Titre_Eval = c.String(maxLength: 255, unicode: false),
                        Type = c.String(maxLength: 255, unicode: false),
                        desc_Eval = c.String(maxLength: 255, unicode: false),
                        score_Manager = c.Int(),
                        score_self = c.Int(),
                        score_team = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.user", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Reclamations",
                c => new
                    {
                        Numclaim = c.Int(nullable: false, identity: true),
                        descp = c.String(unicode: false),
                        statut = c.Int(nullable: false),
                        dateouverture = c.DateTime(nullable: false, precision: 0),
                        datecloture = c.DateTime(nullable: false, precision: 0),
                        reponse = c.String(unicode: false),
                        comment = c.String(unicode: false),
                        evaluation_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.Numclaim)
                .ForeignKey("pidev.evaluation", t => t.evaluation_id)
                .ForeignKey("pidev.user", t => t.user_id)
                .Index(t => t.evaluation_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "pidev.mission",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        created = c.DateTime(nullable: false, precision: 0),
                        updated = c.DateTime(nullable: false, precision: 0),
                        dateEnd = c.String(maxLength: 255, unicode: false),
                        dateStart = c.String(maxLength: 255, unicode: false),
                        description = c.String(maxLength: 255, unicode: false),
                        location = c.String(maxLength: 255, unicode: false),
                        name = c.String(maxLength: 255, unicode: false),
                        Specialite = c.String(maxLength: 255, unicode: false),
                        assignee_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.user", t => t.assignee_id)
                .Index(t => t.assignee_id);
            
            CreateTable(
                "pidev.report",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Image = c.String(maxLength: 255, unicode: false),
                        date = c.DateTime(storeType: "date"),
                        description = c.String(maxLength: 255, unicode: false),
                        name = c.String(maxLength: 255, unicode: false),
                        nature = c.Int(),
                        price = c.Long(nullable: false),
                        state = c.Int(),
                        id_M_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.mission", t => t.id_M_id)
                .Index(t => t.id_M_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("pidev.project", "ownedBy_id", "pidev.user");
            DropForeignKey("pidev.mission", "assignee_id", "pidev.user");
            DropForeignKey("pidev.user", "mission_id", "pidev.mission");
            DropForeignKey("pidev.report", "id_M_id", "pidev.mission");
            DropForeignKey("pidev.formation", "user_id", "pidev.user");
            DropForeignKey("pidev.evaluation", "user_id", "pidev.user");
            DropForeignKey("dbo.Reclamations", "user_id", "pidev.user");
            DropForeignKey("dbo.Reclamations", "evaluation_id", "pidev.evaluation");
            DropForeignKey("pidev.equipe", "managedBy_id", "pidev.user");
            DropForeignKey("pidev.user", "memberOf_id", "pidev.equipe");
            DropForeignKey("pidev.conge", "user_id", "pidev.user");
            DropForeignKey("pidev.assignment", "emp_id", "pidev.user");
            DropForeignKey("pidev.task", "project_id", "pidev.project");
            DropForeignKey("pidev.bug", "project_id", "pidev.project");
            DropForeignKey("pidev.assignment", "task_id", "pidev.task");
            DropForeignKey("pidev.affectation", "users_id", "pidev.user");
            DropForeignKey("pidev.formation", "formateur_id", "pidev.formateur");
            DropForeignKey("pidev.affectation", "formations_Id", "pidev.formation");
            DropForeignKey("pidev.absence", "user_id", "pidev.user");
            DropIndex("pidev.report", new[] { "id_M_id" });
            DropIndex("pidev.mission", new[] { "assignee_id" });
            DropIndex("dbo.Reclamations", new[] { "user_id" });
            DropIndex("dbo.Reclamations", new[] { "evaluation_id" });
            DropIndex("pidev.evaluation", new[] { "user_id" });
            DropIndex("pidev.equipe", new[] { "managedBy_id" });
            DropIndex("pidev.conge", new[] { "user_id" });
            DropIndex("pidev.bug", new[] { "project_id" });
            DropIndex("pidev.project", new[] { "ownedBy_id" });
            DropIndex("pidev.task", new[] { "project_id" });
            DropIndex("pidev.assignment", new[] { "task_id" });
            DropIndex("pidev.assignment", new[] { "emp_id" });
            DropIndex("pidev.formation", new[] { "user_id" });
            DropIndex("pidev.formation", new[] { "formateur_id" });
            DropIndex("pidev.affectation", new[] { "users_id" });
            DropIndex("pidev.affectation", new[] { "formations_Id" });
            DropIndex("pidev.user", new[] { "mission_id" });
            DropIndex("pidev.user", new[] { "memberOf_id" });
            DropIndex("pidev.absence", new[] { "user_id" });
            DropTable("pidev.report");
            DropTable("pidev.mission");
            DropTable("dbo.Reclamations");
            DropTable("pidev.evaluation");
            DropTable("pidev.equipe");
            DropTable("pidev.conge");
            DropTable("pidev.bug");
            DropTable("pidev.project");
            DropTable("pidev.task");
            DropTable("pidev.assignment");
            DropTable("pidev.formateur");
            DropTable("pidev.formation");
            DropTable("pidev.affectation");
            DropTable("pidev.user");
            DropTable("pidev.absence");
        }
    }
}
