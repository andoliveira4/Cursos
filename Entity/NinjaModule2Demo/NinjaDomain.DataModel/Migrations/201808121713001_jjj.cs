namespace NinjaDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jjj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ninjas", "teste", c => c.Int(nullable: false));
            DropColumn("dbo.Ninjas", "teste2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ninjas", "teste2", c => c.Int(nullable: false));
            DropColumn("dbo.Ninjas", "teste");
        }
    }
}
