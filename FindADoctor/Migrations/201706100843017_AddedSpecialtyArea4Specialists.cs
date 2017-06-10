namespace FindADoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpecialtyArea4Specialists : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Specialties", "SpecialtyArea", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Specialties", "SpecialtyArea");
        }
    }
}
