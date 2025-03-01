namespace PrintManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIpAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IPAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IPAddress");
        }
    }
}
