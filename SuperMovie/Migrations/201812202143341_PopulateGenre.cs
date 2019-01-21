namespace SuperMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Animation')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Biography')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5,'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6,'Crime')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7,'Documentary')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8,'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9,'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10,'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (11,'History')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (12,'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (13,'Music')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (14,'Musical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (15,'Mystery')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (16,'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (17,'Sci-Fi')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (18,'Short')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (19,'Sport')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (20,'Superhero')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (21,'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (22,'War')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (23,'Western')");
        }
        
        public override void Down()
        {
        }
    }
}
