namespace SuperMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPicUrlToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "PicUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "PicUrl");
        }
    }
}
