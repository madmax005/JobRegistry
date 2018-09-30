namespace JobRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJobSeekerForeignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.JobSeekers", name: "JobID_JobId", newName: "JobDetail_JobId");
            RenameIndex(table: "dbo.JobSeekers", name: "IX_JobID_JobId", newName: "IX_JobDetail_JobId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.JobSeekers", name: "IX_JobDetail_JobId", newName: "IX_JobID_JobId");
            RenameColumn(table: "dbo.JobSeekers", name: "JobDetail_JobId", newName: "JobID_JobId");
        }
    }
}
