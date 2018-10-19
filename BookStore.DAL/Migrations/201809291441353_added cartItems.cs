namespace BookStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcartItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        BookId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "BookId", "dbo.Books");
            DropIndex("dbo.CartItems", new[] { "BookId" });
            DropTable("dbo.CartItems");
        }
    }
}
