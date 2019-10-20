namespace BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Free Membership' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly Donator' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly Donator' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annual Donator' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
