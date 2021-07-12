namespace ChartProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmployeeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeSkills",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TechnicalLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LeadershipLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeadershipLevels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Level = c.String(),
                        LevelName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TechnicalLevels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Level = c.String(),
                        LevelName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TechnicalLevels");
            DropTable("dbo.LeadershipLevels");
            DropTable("dbo.EmployeeSkills");
            DropTable("dbo.Employees");
        }
    }
}
