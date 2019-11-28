namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reclamation",
                c => new
                    {
                        Numclaim = c.Int(nullable: false, identity: true),
                        descp = c.String(unicode: false),
                        statut = c.Int(nullable: false),
                        dateouverture = c.DateTime(nullable: false, precision: 0),
                        datecloture = c.DateTime(nullable: false, precision: 0),
                        reponse = c.String(unicode: false),
                        comment = c.String(unicode: false),
                        evaluationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Numclaim)
                .ForeignKey("dbo.evaluations", t => t.evaluationID , cascadeDelete: true)
                .Index(t => t.evaluationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reclamation", "evaluationID", "dbo.evaluations");
            DropIndex("dbo.Reclamation", new[] { "evaluationID" });
            DropTable("dbo.Reclamation");
        }
    }
}
