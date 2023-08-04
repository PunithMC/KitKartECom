namespace KitKart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatabsedesignaddedCategoryId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        categoryName = c.String(),
                        categoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        itemName = c.String(nullable: false, maxLength: 50),
                        CategoryId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KartItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.KartItems", new[] { "CategoryId" });
            DropTable("dbo.KartItems");
            DropTable("dbo.Categories");
        }
    }
}
