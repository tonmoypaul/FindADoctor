namespace FindADoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMorePropertiestoIdentityUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "GenderId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Suburb", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "PostCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "BloodGroupId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "GenderId");
            CreateIndex("dbo.AspNetUsers", "BloodGroupId");
            AddForeignKey("dbo.AspNetUsers", "BloodGroupId", "dbo.BloodGroups", "Id");
            AddForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.AspNetUsers", "BloodGroupId", "dbo.BloodGroups");
            DropIndex("dbo.AspNetUsers", new[] { "BloodGroupId" });
            DropIndex("dbo.AspNetUsers", new[] { "GenderId" });
            DropColumn("dbo.AspNetUsers", "BloodGroupId");
            DropColumn("dbo.AspNetUsers", "PostCode");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Suburb");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "GenderId");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Genders");
            DropTable("dbo.BloodGroups");
        }
    }
}
