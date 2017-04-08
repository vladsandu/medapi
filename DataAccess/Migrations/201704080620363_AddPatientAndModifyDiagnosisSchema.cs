namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientAndModifyDiagnosisSchema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Diagnosis.Diagnosis", "Type_Id", "Diagnosis.Type");
            DropIndex("Diagnosis.Diagnosis", new[] { "Type_Id" });
            CreateTable(
                "Character.Patient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("character.Person", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            AddColumn("Diagnosis.Condition", "Type_Id", c => c.Int());
            AddColumn("Diagnosis.Diagnosis", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("Diagnosis.Diagnosis", "EndDate", c => c.DateTime());
            AddColumn("Diagnosis.Diagnosis", "Observations", c => c.String());
            AddColumn("Diagnosis.Diagnosis", "Patient_Id", c => c.Int());
            CreateIndex("Diagnosis.Condition", "Type_Id");
            CreateIndex("Diagnosis.Diagnosis", "Patient_Id");
            AddForeignKey("Diagnosis.Condition", "Type_Id", "Diagnosis.Type", "Id");
            AddForeignKey("Diagnosis.Diagnosis", "Patient_Id", "Character.Patient", "Id");
            DropColumn("Diagnosis.Diagnosis", "Type_Id");
        }
        
        public override void Down()
        {
            AddColumn("Diagnosis.Diagnosis", "Type_Id", c => c.Int());
            DropForeignKey("Diagnosis.Diagnosis", "Patient_Id", "Character.Patient");
            DropForeignKey("Character.Patient", "Person_Id", "character.Person");
            DropForeignKey("Diagnosis.Condition", "Type_Id", "Diagnosis.Type");
            DropIndex("Character.Patient", new[] { "Person_Id" });
            DropIndex("Diagnosis.Diagnosis", new[] { "Patient_Id" });
            DropIndex("Diagnosis.Condition", new[] { "Type_Id" });
            DropColumn("Diagnosis.Diagnosis", "Patient_Id");
            DropColumn("Diagnosis.Diagnosis", "Observations");
            DropColumn("Diagnosis.Diagnosis", "EndDate");
            DropColumn("Diagnosis.Diagnosis", "StartDate");
            DropColumn("Diagnosis.Condition", "Type_Id");
            DropTable("Character.Patient");
            CreateIndex("Diagnosis.Diagnosis", "Type_Id");
            AddForeignKey("Diagnosis.Diagnosis", "Type_Id", "Diagnosis.Type", "Id");
        }
    }
}
