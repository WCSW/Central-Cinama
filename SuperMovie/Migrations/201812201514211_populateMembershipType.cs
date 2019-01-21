namespace SuperMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFree, DurationInMonths, DiscountRate) VALUES (1,'Pay as You Go', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFree, DurationInMonths, DiscountRate) VALUES (2,'Monthly', 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFree, DurationInMonths, DiscountRate) VALUES (3,'Quarterly', 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, Name, SignUpFree, DurationInMonths, DiscountRate) VALUES (4,'Annual', 300, 12, 25)");
        }
        
        public override void Down()
        {
        }
    }
}
