namespace BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "IsSubscribedToNewsLetter");
        }
    }
}
