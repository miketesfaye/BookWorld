namespace BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNumberAvailableForBooks : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Books SET NumberAvailable = NumberInStock WHERE Id = 15");
            Sql("UPDATE Books SET NumberAvailable = NumberInStock WHERE Id = 16");
            Sql("UPDATE Books SET NumberAvailable = NumberInStock WHERE Id = 17");
            Sql("UPDATE Books SET NumberAvailable = NumberInStock WHERE Id = 18");
            Sql("UPDATE Books SET NumberAvailable = NumberInStock WHERE Id = 19");
            Sql("UPDATE Books SET NumberAvailable = NumberInStock WHERE Id = 20");
        }
        
        public override void Down()
        {
        }
    }
}
