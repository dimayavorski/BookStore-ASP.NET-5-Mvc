namespace BookStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoleandUserentities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserProfiles", new[] { "Id" });
            DropTable("dbo.UserProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserProfiles", "Id");
            AddForeignKey("dbo.UserProfiles", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
