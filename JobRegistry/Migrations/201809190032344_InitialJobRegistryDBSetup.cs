namespace JobRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialJobRegistryDBSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobDetails",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobDescription = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.JobSeekers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        DOB = c.String(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        JobDetail_JobId = c.Int(),
                        Users_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.JobDetails", t => t.JobDetail_JobId)
                .ForeignKey("dbo.Users", t => t.Users_ID)
                .Index(t => t.JobDetail_JobId)
                .Index(t => t.Users_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobSeekers", "Users_ID", "dbo.Users");
            DropForeignKey("dbo.JobSeekers", "JobDetail_JobId", "dbo.JobDetails");
            DropIndex("dbo.JobSeekers", new[] { "Users_ID" });
            DropIndex("dbo.JobSeekers", new[] { "JobDetail_JobId" });
            DropTable("dbo.Users");
            DropTable("dbo.JobSeekers");
            DropTable("dbo.JobDetails");
        }
    }
}
