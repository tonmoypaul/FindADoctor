namespace FindADoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAppointment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PatientUserName = c.String(),
                        DoctorId = c.Int(nullable: false),
                        MedicalCenterId = c.Int(nullable: false),
                        AppointmentScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppointmentSchedules", t => t.AppointmentScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.MedicalCenters", t => t.MedicalCenterId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.MedicalCenterId)
                .Index(t => t.AppointmentScheduleId);
            
            CreateTable(
                "dbo.AppointmentSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimePeriod = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "MedicalCenterId", "dbo.MedicalCenters");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "AppointmentScheduleId", "dbo.AppointmentSchedules");
            DropIndex("dbo.Appointments", new[] { "AppointmentScheduleId" });
            DropIndex("dbo.Appointments", new[] { "MedicalCenterId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropTable("dbo.AppointmentSchedules");
            DropTable("dbo.Appointments");
        }
    }
}
