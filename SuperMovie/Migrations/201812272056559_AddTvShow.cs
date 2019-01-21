namespace SuperMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTvShow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TvShows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        PicUrl = c.String(),
                        VideoUrl = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TvShows", "GenreId", "dbo.Genres");
            DropIndex("dbo.TvShows", new[] { "GenreId" });
            DropTable("dbo.TvShows");
        }
    }
}
