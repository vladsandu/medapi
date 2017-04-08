namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStaffSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Staff.Contract",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Staff.MedicalField",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Staff.PhysicianGrade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Staff.Physician",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Contract_Id = c.Int(),
                        MedicalField_Id = c.Int(),
                        Person_Id = c.Int(),
                        PhysicianGrade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Staff.Contract", t => t.Contract_Id)
                .ForeignKey("Staff.MedicalField", t => t.MedicalField_Id)
                .ForeignKey("Character.Person", t => t.Person_Id)
                .ForeignKey("Staff.PhysicianGrade", t => t.PhysicianGrade_Id)
                .Index(t => t.Contract_Id)
                .Index(t => t.MedicalField_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.PhysicianGrade_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Staff.Physician", "PhysicianGrade_Id", "Staff.PhysicianGrade");
            DropForeignKey("Staff.Physician", "Person_Id", "Character.Person");
            DropForeignKey("Staff.Physician", "MedicalField_Id", "Staff.MedicalField");
            DropForeignKey("Staff.Physician", "Contract_Id", "Staff.Contract");
            DropIndex("Staff.Physician", new[] { "PhysicianGrade_Id" });
            DropIndex("Staff.Physician", new[] { "Person_Id" });
            DropIndex("Staff.Physician", new[] { "MedicalField_Id" });
            DropIndex("Staff.Physician", new[] { "Contract_Id" });
            DropTable("Staff.Physician");
            DropTable("Staff.PhysicianGrade");
            DropTable("Staff.MedicalField");
            DropTable("Staff.Contract");
        }
    }
}
