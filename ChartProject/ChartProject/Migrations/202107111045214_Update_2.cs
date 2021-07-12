namespace ChartProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeSkills", "EmployeeId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeSkills", "EmployeeId");
        }
    }
}
