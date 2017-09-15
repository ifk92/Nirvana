namespace WebAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 255),
                        Categorie_Id = c.Byte(nullable: false),
                        Utilisateur_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Categorie_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Utilisateur_Id, cascadeDelete: true)
                .Index(t => t.Categorie_Id)
                .Index(t => t.Utilisateur_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Utilisateur_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "Categorie_Id", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Utilisateur_Id" });
            DropIndex("dbo.Posts", new[] { "Categorie_Id" });
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
