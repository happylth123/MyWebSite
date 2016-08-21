namespace MyWebSite.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addsomeef : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IssueLogWorks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        DateStarted = c.DateTime(),
                        IssueLogDescription = c.String(),
                        TimeSpent = c.String(),
                        CreateTime = c.DateTime(),
                        Issue_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issues", t => t.Issue_Id, cascadeDelete: true)
                .Index(t => t.Issue_Id);
            
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IssueIDNum = c.String(),
                        IssueTitleDescription = c.String(),
                        IssueType = c.Int(nullable: false),
                        IssueTime = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        ModifyTime = c.DateTime(),
                        Reporter = c.String(),
                        Assignee = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Sprint_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sprints", t => t.Sprint_Id, cascadeDelete: true)
                .Index(t => t.Sprint_Id);
            
            CreateTable(
                "dbo.Sprints",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SprintIDNum = c.String(),
                        Description = c.String(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        CreateTime = c.DateTime(),
                        ModifyTime = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "Sprint_Id", "dbo.Sprints");
            DropForeignKey("dbo.IssueLogWorks", "Issue_Id", "dbo.Issues");
            DropIndex("dbo.Issues", new[] { "Sprint_Id" });
            DropIndex("dbo.IssueLogWorks", new[] { "Issue_Id" });
            DropTable("dbo.Sprints");
            DropTable("dbo.Issues");
            DropTable("dbo.IssueLogWorks");
        }
    }
}
