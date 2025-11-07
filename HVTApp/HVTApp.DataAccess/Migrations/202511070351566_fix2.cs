namespace HVTApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Penalty", "IsActual");
            DropColumn("dbo.StructureCost", "PriceIncreaseFactor");
            DropColumn("dbo.PriceEngineeringTask", "PriceIncreaseFactor");
            DropColumn("dbo.DesignDepartment", "IsPriceIncreaseFactor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DesignDepartment", "IsPriceIncreaseFactor", c => c.Boolean(nullable: false));
            AddColumn("dbo.PriceEngineeringTask", "PriceIncreaseFactor", c => c.Double());
            AddColumn("dbo.StructureCost", "PriceIncreaseFactor", c => c.Double());
            AddColumn("dbo.Penalty", "IsActual", c => c.Boolean(nullable: false));
        }
    }
}
