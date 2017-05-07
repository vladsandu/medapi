namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCnpField : DbMigration
    {
        public override void Up()
        {
            DropColumn("Character.Person", "Cnp");
        }
        
        public override void Down()
        {
            AddColumn("Character.Person", "Cnp", c => c.Int(nullable: false));
        }
    }
}
