namespace KitKart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingUserEntityuser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false),
                        password = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
