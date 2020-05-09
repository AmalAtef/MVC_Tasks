namespace MVCDay2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelEmpDept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FK_DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "FK_DepartmentId");
            AddForeignKey("dbo.Employees", "FK_DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "FK_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "FK_DepartmentId" });
            DropColumn("dbo.Employees", "FK_DepartmentId");
        }
    }
}
