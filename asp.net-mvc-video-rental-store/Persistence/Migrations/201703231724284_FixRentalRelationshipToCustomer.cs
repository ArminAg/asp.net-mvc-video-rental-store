namespace asp.net_mvc_video_rental_store.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRentalRelationshipToCustomer : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            AlterColumn("dbo.Rentals", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "CustomerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            AlterColumn("dbo.Rentals", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Rentals", "CustomerId");
        }
    }
}
