namespace TheMachineCafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToSelection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Selections", "UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Selections", new[] { "UserId_Id" });
            RenameColumn(table: "dbo.Selections", name: "UserId_Id", newName: "UserId");
            AlterColumn("dbo.Selections", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Selections", "UserId");
            AddForeignKey("dbo.Selections", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Selections", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Selections", new[] { "UserId" });
            AlterColumn("dbo.Selections", "UserId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Selections", name: "UserId", newName: "UserId_Id");
            CreateIndex("dbo.Selections", "UserId_Id");
            AddForeignKey("dbo.Selections", "UserId_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
