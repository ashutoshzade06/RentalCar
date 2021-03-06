// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(Car_RentalDbContext))]
    partial class Car_RentalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Model.Car", b =>
                {
                    b.Property<string>("UIN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fuel_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UIN");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DAL.Model.Customer", b =>
                {
                    b.Property<string>("Driver_License")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postal_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Driver_License");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DAL.Model.Rented_Car", b =>
                {
                    b.Property<int>("Rented_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Car_UIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Driver_License")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("From_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("From_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Odometer_After")
                        .HasColumnType("int");

                    b.Property<int>("Odometer_Before")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("To_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("To_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Rented_Id");

                    b.HasIndex("Car_UIN");

                    b.HasIndex("Driver_License");

                    b.ToTable("Rented_Cars");
                });

            modelBuilder.Entity("DAL.Model.Rented_Car", b =>
                {
                    b.HasOne("DAL.Model.Car", "Car")
                        .WithMany()
                        .HasForeignKey("Car_UIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Driver_License")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
