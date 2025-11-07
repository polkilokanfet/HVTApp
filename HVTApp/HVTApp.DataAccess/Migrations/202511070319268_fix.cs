namespace HVTApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Penalty", "IsActual", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Penalty", "IsActual");
        }
    }
}
