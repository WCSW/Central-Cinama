namespace SuperMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomers : DbMigration
    {
        public override void Up()
        { 
            Sql("INSERT INTO Customers (Name, Subscribe, MembershipTypeId, Birthdate) VALUES ('Channa Sudath', 0, 1,03/07/1994 ) ");
        }
        
        public override void Down()
        {
        }
    }
}
