namespace NgoTanLoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCancelledColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "isCancelled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "isCancelled");
        }
    }
}
