namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSexEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Character.Person", "Sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Character.Person", "Sex", c => c.Byte(nullable: false));
        }
    }
}
