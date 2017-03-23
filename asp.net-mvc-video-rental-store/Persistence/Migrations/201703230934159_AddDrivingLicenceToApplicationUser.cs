namespace asp.net_mvc_video_rental_store.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDrivingLicenceToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicence", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicence");
        }
    }
}
