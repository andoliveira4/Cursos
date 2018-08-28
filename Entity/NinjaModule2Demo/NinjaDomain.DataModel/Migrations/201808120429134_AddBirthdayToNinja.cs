namespace NinjaDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayToNinja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ninjas", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Ninjas", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ninjas", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Ninjas", "DateOfBirth");
        }
    }
}
