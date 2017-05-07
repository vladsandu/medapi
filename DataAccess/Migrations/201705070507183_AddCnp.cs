namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCnp : DbMigration
    {
        public override void Up()
        {
            AddColumn("Character.Person", "Cnp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Character.Person", "Cnp");
        }
    }
}
