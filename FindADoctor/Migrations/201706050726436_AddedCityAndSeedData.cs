namespace FindADoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCityAndSeedData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalCenters", "City", c => c.String());
            AlterColumn("dbo.MedicalCenters", "PostCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicalCenters", "PostCode", c => c.Int(nullable: false));
            DropColumn("dbo.MedicalCenters", "City");
        }
    }
}
