namespace KitKart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingRoleEntityseedData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Roles(Title) Values('Administrator')");
            Sql("Insert into Roles(Title) Values('Power User')");
            Sql("Insert into Roles(Title) Values('User')");
            Sql("Insert into Roles(Title) Values('Client')");
        }
        
        public override void Down()
        {
        }
    }
}
