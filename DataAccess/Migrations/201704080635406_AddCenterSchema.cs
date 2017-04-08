namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCenterSchema : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Diagnosis.Type", newName: "CenterType");
            MoveTable(name: "Diagnosis.CenterType", newSchema: "Center");
            CreateTable(
                "Diagnosis.Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Center.MedicalCenter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CenterType_Id = c.Int(),
                        ContactDetails_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Center.CenterType", t => t.CenterType_Id)
                .ForeignKey("contact.ContactDetails", t => t.ContactDetails_Id)
                .Index(t => t.CenterType_Id)
                .Index(t => t.ContactDetails_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Center.MedicalCenter", "ContactDetails_Id", "contact.ContactDetails");
            DropForeignKey("Center.MedicalCenter", "CenterType_Id", "Center.CenterType");
            DropIndex("Center.MedicalCenter", new[] { "ContactDetails_Id" });
            DropIndex("Center.MedicalCenter", new[] { "CenterType_Id" });
            DropTable("Center.MedicalCenter");
            DropTable("Diagnosis.Type");
            MoveTable(name: "Center.CenterType", newSchema: "Diagnosis");
            RenameTable(name: "Diagnosis.CenterType", newName: "Type");
        }
    }
}
