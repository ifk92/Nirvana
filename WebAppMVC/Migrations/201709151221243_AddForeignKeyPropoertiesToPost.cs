namespace WebAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropoertiesToPost : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "Categorie_Id", newName: "CategorieId");
            RenameColumn(table: "dbo.Posts", name: "Utilisateur_Id", newName: "UtilisateurId");
            RenameIndex(table: "dbo.Posts", name: "IX_Utilisateur_Id", newName: "IX_UtilisateurId");
            RenameIndex(table: "dbo.Posts", name: "IX_Categorie_Id", newName: "IX_CategorieId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_CategorieId", newName: "IX_Categorie_Id");
            RenameIndex(table: "dbo.Posts", name: "IX_UtilisateurId", newName: "IX_Utilisateur_Id");
            RenameColumn(table: "dbo.Posts", name: "UtilisateurId", newName: "Utilisateur_Id");
            RenameColumn(table: "dbo.Posts", name: "CategorieId", newName: "Categorie_Id");
        }
    }
}
