namespace HVTApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceIncreaseFactor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StructureCost", "PriceIncreaseFactor", c => c.Double());
            AddColumn("dbo.DesignDepartment", "IsPriceIncreaseFactor", c => c.Boolean(nullable: false));
            AddColumn("dbo.PriceEngineeringTask", "PriceIncreaseFactor", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PriceEngineeringTask", "PriceIncreaseFactor");
            DropColumn("dbo.DesignDepartment", "IsPriceIncreaseFactor");
            DropColumn("dbo.StructureCost", "PriceIncreaseFactor");
        }
    }
}
