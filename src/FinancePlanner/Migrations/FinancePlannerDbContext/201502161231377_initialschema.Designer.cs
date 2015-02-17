using FinancePlanner.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using System;

namespace FinancePlanner.Migrations.FinancePlannerDbContext
{
    [ContextType(typeof(FinancePlanner.Models.FinancePlannerDbContext))]
    public partial class initialschema : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201502161231377_initialschema";
            }
        }
        
        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta2-11909";
            }
        }
        
        IModel IMigrationMetadata.TargetModel
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("FinancePlanner.Models.Transaction", b =>
                    {
                        b.Property<decimal>("Amount");
                        b.Property<DateTime>("Date");
                        b.Property<string>("Description");
                        b.Property<DateTime?>("EndDate");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<int?>("NumberOfTimes");
                        b.Property<int>("Status");
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}