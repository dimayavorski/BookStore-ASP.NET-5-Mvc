namespace BookStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Back : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Email", c => c.String(nullable: false));
        }
    }
}
