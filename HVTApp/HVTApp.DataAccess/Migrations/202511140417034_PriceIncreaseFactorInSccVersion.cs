namespace HVTApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceIncreaseFactorInSccVersion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StructureCostVersion", "PriceIncreaseFactor", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StructureCostVersion", "PriceIncreaseFactor");
        }
    }
}
