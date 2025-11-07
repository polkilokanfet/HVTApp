namespace HVTApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StructureCost", "PriceIncreaseFactor", c => c.Double());
            AddColumn("dbo.PriceEngineeringTask", "PriceIncreaseFactor", c => c.Double());
            AddColumn("dbo.DesignDepartment", "IsPriceIncreaseFactor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DesignDepartment", "IsPriceIncreaseFactor");
            DropColumn("dbo.PriceEngineeringTask", "PriceIncreaseFactor");
            DropColumn("dbo.StructureCost", "PriceIncreaseFactor");
        }
    }
}
