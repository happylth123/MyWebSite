namespace MyWebSite.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogEntities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        F_Date = c.DateTime(),
                        F_Account = c.String(),
                        F_NickName = c.String(),
                        F_Type = c.String(),
                        F_IPAddress = c.String(),
                        F_IPAddressName = c.String(),
                        F_ModuleId = c.String(),
                        F_ModuleName = c.String(),
                        F_Result = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogEntities");
        }
    }
}
