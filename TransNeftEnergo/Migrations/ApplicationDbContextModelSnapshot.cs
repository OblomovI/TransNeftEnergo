// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransNeftEnergo;

namespace TransNeftEnergo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransNeftEnergo.Models.CalculatingMeter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PowerSupplyPointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PowerSupplyPointId")
                        .IsUnique();

                    b.ToTable("CalculatingMeters");
                });

            modelBuilder.Entity("TransNeftEnergo.Models.ChildOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("ChildOrganizations");
                });

            modelBuilder.Entity("TransNeftEnergo.Models.ConsumptionObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChildOrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChildOrganizationId");

                    b.ToTable("ConsumptionObjects");
                });

            modelBuilder.Entity("TransNeftEnergo.Models.CurrentMeter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InspectionPeriod")
                        .HasColumnType("int");

                    b.Property<string>("MeterType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CurrentMeters");
                });

            modelBuilder.Entity("TransNeftEnergo.Models.CurrentTransformer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentTransformerType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InspectionPeriod")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("TransformationCoefficient")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CurrentTransformers");
                });

            modelBuilder.Entity("TransNeftEnergo.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("TransNeftEnergo.Models.PowerMeasuringPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsumptionObjectId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentMeterId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentTransformerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VoltageTransformerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsumptionObjectId");

                    b.HasIndex("CurrentMeterId");

                    b.HasIndex("CurrentTransformerId");

                    b.HasIndex("VoltageTransformerId");

                    b.ToTable("PowerMeasuringPoints");
                });

            modelBuilder.Entity("TransNeftEnergo.Models.PowerMeasuringPointToCalculatingMeter", b =>
                {
                    b.Property<int>("PowerMeasuringPointId")
                        .HasColumnType("int");

                    b.Property<int>("CalculatingMeterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ToTime")
                        .HasColumnType("datetime2");

                    b.HasKey("PowerMeasuringPointId", "CalculatingMeterId");

                    b.HasIndex("CalculatingMeterId");

                    b.ToTable("PowerMeasuringPointToCalculatingMeter");
                });

            modelBuilder.Entity("TransNeftEnergo.Models.PowerSupplyPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsumptionObjectId")
                        .HasColumnType("int");

                    b.Property<double>("MaximumPower")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsumptionObjectId");

                    b.ToTable("PowerSupplyPoints");
                });

            modelBuilder.Entity("TransNeftEnergo.Models.VoltageTransformer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InspectionPeriod")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("TransformationCoefficient")
                        .HasColumnType("float");

                    b.Property<string>("VoltageTransformerType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VoltageTransformers");
                });

            modelBuilder.Entity("TransNeftEnergo.Models.CalculatingMeter", b =>
                {
                    b.HasOne("TransNeftEnergo.Models.PowerSupplyPoint", "PowerSupplyPoint")
                        .WithOne("CalculatingMeter")
                        .HasForeignKey("TransNeftEnergo.Models.CalculatingMeter", "PowerSupplyPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TransNeftEnergo.Models.ChildOrganization", b =>
                {
                    b.HasOne("TransNeftEnergo.Models.Organization", "Organization")
                        .WithMany("ChildOrganizations")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TransNeftEnergo.Models.ConsumptionObject", b =>
                {
                    b.HasOne("TransNeftEnergo.Models.ChildOrganization", "ChildOrganization")
                        .WithMany("ConsumptionObjects")
                        .HasForeignKey("ChildOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TransNeftEnergo.Models.PowerMeasuringPoint", b =>
                {
                    b.HasOne("TransNeftEnergo.Models.ConsumptionObject", "ConsumptionObject")
                        .WithMany("PowerMeasuringPoints")
                        .HasForeignKey("ConsumptionObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransNeftEnergo.Models.CurrentMeter", "CurrentMeter")
                        .WithMany()
                        .HasForeignKey("CurrentMeterId");

                    b.HasOne("TransNeftEnergo.Models.CurrentTransformer", "CurrentTransformer")
                        .WithMany()
                        .HasForeignKey("CurrentTransformerId");

                    b.HasOne("TransNeftEnergo.Models.VoltageTransformer", "VoltageTransformer")
                        .WithMany()
                        .HasForeignKey("VoltageTransformerId");
                });

            modelBuilder.Entity("TransNeftEnergo.Models.PowerMeasuringPointToCalculatingMeter", b =>
                {
                    b.HasOne("TransNeftEnergo.Models.CalculatingMeter", "CalculatingMeter")
                        .WithMany("PowerMeasuringPointToCalculatingMeter")
                        .HasForeignKey("CalculatingMeterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TransNeftEnergo.Models.PowerMeasuringPoint", "PowerMeasuringPoint")
                        .WithMany("PowerMeasuringPointToCalculatingMeters")
                        .HasForeignKey("PowerMeasuringPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TransNeftEnergo.Models.PowerSupplyPoint", b =>
                {
                    b.HasOne("TransNeftEnergo.Models.ConsumptionObject", "ConsumptionObject")
                        .WithMany("PowerSupplyPoints")
                        .HasForeignKey("ConsumptionObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
