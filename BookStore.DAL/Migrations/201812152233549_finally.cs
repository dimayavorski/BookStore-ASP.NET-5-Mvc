namespace BookStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _finally : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Genres");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Genres", newName: "Categories");
        }
    }
}
