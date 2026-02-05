namespace HVTApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsPriceEngineeringTaskMessagesEnabled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsPriceEngineeringTaskMessagesEnabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "IsPriceEngineeringTaskMessagesEnabled");
        }
    }
}
