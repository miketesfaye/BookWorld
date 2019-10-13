namespace BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateToMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Birthdate");
        }
    }
}
