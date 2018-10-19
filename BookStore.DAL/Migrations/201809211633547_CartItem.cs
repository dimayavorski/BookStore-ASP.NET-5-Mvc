namespace BookStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartItem : DbMigration
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
            
            AddColumn("dbo.OrderDetails", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "BookId");
            AddForeignKey("dbo.OrderDetails", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "BookId", "dbo.Books");
            DropForeignKey("dbo.CartItems", "BookId", "dbo.Books");
            DropIndex("dbo.OrderDetails", new[] { "BookId" });
            DropIndex("dbo.CartItems", new[] { "BookId" });
            DropColumn("dbo.OrderDetails", "BookId");
            DropTable("dbo.CartItems");
        }
    }
}
