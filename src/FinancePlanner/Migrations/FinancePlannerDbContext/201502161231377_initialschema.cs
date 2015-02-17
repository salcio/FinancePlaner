using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Model;
using System;

namespace FinancePlanner.Migrations.FinancePlannerDbContext
{
    public partial class initialschema : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        EndDate = c.DateTime(),
                        NumberOfTimes = c.Int(),
                        Status = c.Int(nullable: false)
                    })
                .PrimaryKey("PK_Transaction", t => t.Id);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Transaction");
        }
    }
}