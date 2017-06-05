namespace FindADoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDocAssignmentAndMedical : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        MedicalCenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.MedicalCenters", t => t.MedicalCenterId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.MedicalCenterId);
            
            CreateTable(
                "dbo.MedicalCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Suburb = c.String(),
                        PostCode = c.Int(nullable: false),
                        Phone = c.String(),
                        Website = c.String(),
                        Latitute = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorAssignments", "MedicalCenterId", "dbo.MedicalCenters");
            DropForeignKey("dbo.DoctorAssignments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.DoctorAssignments", new[] { "MedicalCenterId" });
            DropIndex("dbo.DoctorAssignments", new[] { "DoctorId" });
            DropTable("dbo.MedicalCenters");
            DropTable("dbo.DoctorAssignments");
        }
    }
}
