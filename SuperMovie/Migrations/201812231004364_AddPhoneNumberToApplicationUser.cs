 namespace SuperMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: true, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
        }
    }
}
