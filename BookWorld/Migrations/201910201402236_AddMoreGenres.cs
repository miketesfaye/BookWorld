namespace BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'History')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Poetry')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Young Adult')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'War')");
        }
        
        public override void Down()
        {
        }
    }
}
