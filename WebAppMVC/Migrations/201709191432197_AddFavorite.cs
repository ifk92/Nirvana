namespace WebAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavorite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        FavUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PostId, t.FavUserId })
                .ForeignKey("dbo.AspNetUsers", t => t.FavUserId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId)
                .Index(t => t.FavUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Favorites", "FavUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Favorites", new[] { "FavUserId" });
            DropIndex("dbo.Favorites", new[] { "PostId" });
            DropTable("dbo.Favorites");
        }
    }
}
