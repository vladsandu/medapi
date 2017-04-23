namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSchema : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Character.Person", "DateOfDeath", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("Character.Person", "DateOfDeath", c => c.DateTime(nullable: false));
        }
    }
}
