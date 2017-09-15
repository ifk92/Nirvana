namespace WebAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreigncategorie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Categorie_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Posts", "Categorie_Id");
            AddForeignKey("dbo.Posts", "Categorie_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Categorie_Id", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Categorie_Id" });
            DropColumn("dbo.Posts", "Categorie_Id");
        }
    }
}
