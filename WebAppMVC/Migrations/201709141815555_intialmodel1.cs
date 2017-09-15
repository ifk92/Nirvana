namespace WebAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialmodel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Categorie_Id", "dbo.Categories");
            DropForeignKey("dbo.Posts", "Utilisateur_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "Categorie_Id" });
            DropIndex("dbo.Posts", new[] { "Utilisateur_Id" });
            DropTable("dbo.Categories");
            DropTable("dbo.Posts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 255),
                        Categorie_Id = c.Byte(nullable: false),
                        Utilisateur_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Posts", "Utilisateur_Id");
            CreateIndex("dbo.Posts", "Categorie_Id");
            AddForeignKey("dbo.Posts", "Utilisateur_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "Categorie_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
