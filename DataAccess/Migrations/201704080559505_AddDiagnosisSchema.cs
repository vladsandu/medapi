namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiagnosisSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Diagnosis.ConditionCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Diagnosis.Condition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ConditionCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Diagnosis.ConditionCategory", t => t.ConditionCategory_Id)
                .Index(t => t.ConditionCategory_Id);
            
            CreateTable(
                "Diagnosis.Diagnosis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Condition_Id = c.Int(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Diagnosis.Condition", t => t.Condition_Id)
                .ForeignKey("Diagnosis.Type", t => t.Type_Id)
                .Index(t => t.Condition_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "Diagnosis.Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Diagnosis.Diagnosis", "Type_Id", "Diagnosis.Type");
            DropForeignKey("Diagnosis.Diagnosis", "Condition_Id", "Diagnosis.Condition");
            DropForeignKey("Diagnosis.Condition", "ConditionCategory_Id", "Diagnosis.ConditionCategory");
            DropIndex("Diagnosis.Diagnosis", new[] { "Type_Id" });
            DropIndex("Diagnosis.Diagnosis", new[] { "Condition_Id" });
            DropIndex("Diagnosis.Condition", new[] { "ConditionCategory_Id" });
            DropTable("Diagnosis.Type");
            DropTable("Diagnosis.Diagnosis");
            DropTable("Diagnosis.Condition");
            DropTable("Diagnosis.ConditionCategory");
        }
    }
}
