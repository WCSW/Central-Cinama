namespace SuperMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Johnny English Strikes Again', 1, 17/12/2018, 01/12/2018, 20)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('First Man', 5, 10/12/2018, 01/11/2018, 25)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('A Simple Favor', 1, 12/12/2018, 01/12/2018, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
