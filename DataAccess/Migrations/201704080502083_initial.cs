namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "contact.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "contact.ContactDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        Address = c.String(),
                        PostalCode = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("contact.City", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "character.InsuranceStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "character.Nationality",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "character.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InsuranceStatusId = c.Int(nullable: false),
                        NationalityId = c.Int(nullable: false),
                        ContactDetailsId = c.Int(nullable: false),
                        Cnp = c.Int(nullable: false),
                        Sex = c.Byte(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateOfDeath = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("contact.ContactDetails", t => t.ContactDetailsId, cascadeDelete: true)
                .ForeignKey("character.InsuranceStatus", t => t.InsuranceStatusId, cascadeDelete: true)
                .ForeignKey("character.Nationality", t => t.NationalityId, cascadeDelete: true)
                .Index(t => t.InsuranceStatusId)
                .Index(t => t.NationalityId)
                .Index(t => t.ContactDetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("character.Person", "NationalityId", "character.Nationality");
            DropForeignKey("character.Person", "InsuranceStatusId", "character.InsuranceStatus");
            DropForeignKey("character.Person", "ContactDetailsId", "contact.ContactDetails");
            DropForeignKey("contact.ContactDetails", "CityId", "contact.City");
            DropIndex("character.Person", new[] { "ContactDetailsId" });
            DropIndex("character.Person", new[] { "NationalityId" });
            DropIndex("character.Person", new[] { "InsuranceStatusId" });
            DropIndex("contact.ContactDetails", new[] { "CityId" });
            DropTable("character.Person");
            DropTable("character.Nationality");
            DropTable("character.InsuranceStatus");
            DropTable("contact.ContactDetails");
            DropTable("contact.City");
        }
    }
}
