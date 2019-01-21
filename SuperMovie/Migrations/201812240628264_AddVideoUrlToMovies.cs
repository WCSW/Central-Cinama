namespace SuperMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideoUrlToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "VideoUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "VideoUrl");
        }
    }
}
