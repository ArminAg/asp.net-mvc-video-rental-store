namespace asp.net_mvc_video_rental_store.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerNameConfiguration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
