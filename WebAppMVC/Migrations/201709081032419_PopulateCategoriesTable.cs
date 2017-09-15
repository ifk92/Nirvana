namespace WebAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories(Id, Name) VALUES (1,'Television')");
            Sql("INSERT INTO Categories(Id, Name) VALUES (2,'Sport')");
            Sql("INSERT INTO Categories(Id, Name) VALUES (3,'Culture')");
            Sql("INSERT INTO Categories(Id, Name) VALUES (4,'Musique')");
        }
        
        public override void Down()
        {
            // THe down method is the opposite of what happen in the up method
            Sql("DELETE FROM CATEGORIES WHERE Id IN (1,2,3,4)");
        }
    }
}
