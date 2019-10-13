namespace BookWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Mystery')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Science Fiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Biography')");
        }
        
        public override void Down()
        {
        }
    }
}
