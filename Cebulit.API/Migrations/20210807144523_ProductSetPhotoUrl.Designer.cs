// <auto-generated />
using System;
using Cebulit.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cebulit.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210807144523_ProductSetPhotoUrl")]
    partial class ProductSetPhotoUrl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("BuildStorage", b =>
                {
                    b.Property<int>("BuildsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StorageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BuildsId", "StorageId");

                    b.HasIndex("StorageId");

                    b.ToTable("BuildStorage");
                });

            modelBuilder.Entity("Cebulit.API.Core.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Cebulit.API.Models.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Cebulit.API.Models.Auth.User+UserBuildOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuildId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BuildId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBuildOrder");
                });

            modelBuilder.Entity("Cebulit.API.Models.Auth.User+UserGeneratedBuildOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("UserGeneratedBuildId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserGeneratedBuildId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGeneratedBuildOrder");
                });

            modelBuilder.Entity("Cebulit.API.Models.Auth.User+UserTagMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("MatchLevel")
                        .HasColumnType("REAL");

                    b.Property<int?>("TagId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTagMatch");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Build", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CaseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GraphicsCardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MotherboardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("PowerSupplyId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProcessorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.HasIndex("GraphicsCardId");

                    b.HasIndex("MemoryId");

                    b.HasIndex("MotherboardId");

                    b.HasIndex("PowerSupplyId");

                    b.HasIndex("ProcessorId");

                    b.ToTable("Builds");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Build+BuildTagMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuildId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MatchLevel")
                        .HasColumnType("REAL");

                    b.Property<int?>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BuildId");

                    b.HasIndex("TagId");

                    b.ToTable("BuildTagMatch");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<int>("FormFactor")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Case+CaseTagMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CaseId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MatchLevel")
                        .HasColumnType("REAL");

                    b.Property<int?>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.HasIndex("TagId");

                    b.ToTable("CaseTagMatch");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.GraphicsCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<int>("MemoryCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("GraphicsCards");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.GraphicsCard+GraphicsCardTagMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GraphicsCardId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MatchLevel")
                        .HasColumnType("REAL");

                    b.Property<int?>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GraphicsCardId");

                    b.HasIndex("TagId");

                    b.ToTable("GraphicsCardTagMatch");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Memory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Latency")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Modules")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Speed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Memory");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Memory+MemoryTagMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("MatchLevel")
                        .HasColumnType("REAL");

                    b.Property<int>("MemoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MemoryId");

                    b.HasIndex("TagId");

                    b.ToTable("MemoryTagMatch");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Motherboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<int>("FormFactor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemorySlots")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Socket")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Motherboard+MotherboardTagMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("MatchLevel")
                        .HasColumnType("REAL");

                    b.Property<int>("MotherboardId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MotherboardId");

                    b.HasIndex("TagId");

                    b.ToTable("MotherboardTagMatch");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.PowerSupply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Power")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("PowerSupplies");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.PowerSupply+PowerSupplyTagMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("MatchLevel")
                        .HasColumnType("REAL");

                    b.Property<int>("PowerSupplyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PowerSupplyId");

                    b.HasIndex("TagId");

                    b.ToTable("PowerSupplyTagMatch");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Processor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("BaseClock")
                        .HasColumnType("REAL");

                    b.Property<double>("BoostClock")
                        .HasColumnType("REAL");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<int>("Cores")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Socket")
                        .HasColumnType("TEXT");

                    b.Property<int>("Threads")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Processors");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Processor+ProcessorTagMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("MatchLevel")
                        .HasColumnType("REAL");

                    b.Property<int>("ProcessorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProcessorId");

                    b.HasIndex("TagId");

                    b.ToTable("ProcessorTagMatch");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Interface")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ReadSpeed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserBuildId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WriteSpeed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserBuildId");

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Storage+StorageTagMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("MatchLevel")
                        .HasColumnType("REAL");

                    b.Property<int>("StorageId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.HasIndex("TagId");

                    b.ToTable("StorageTagMatch");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.UserBuild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CaseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("GeneratedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GraphicsCardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MotherboardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("PowerSupplyId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProcessorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.HasIndex("GraphicsCardId");

                    b.HasIndex("MemoryId");

                    b.HasIndex("MotherboardId");

                    b.HasIndex("PowerSupplyId");

                    b.HasIndex("ProcessorId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBuilds");
                });

            modelBuilder.Entity("BuildStorage", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.Build", null)
                        .WithMany()
                        .HasForeignKey("BuildsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Products.PcParts.Storage", null)
                        .WithMany()
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cebulit.API.Models.Auth.User+UserBuildOrder", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.Build", "Build")
                        .WithMany()
                        .HasForeignKey("BuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Auth.User", "User")
                        .WithMany("UserBuildOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Build");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cebulit.API.Models.Auth.User+UserGeneratedBuildOrder", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.UserBuild", "UserGeneratedBuild")
                        .WithMany()
                        .HasForeignKey("UserGeneratedBuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Auth.User", "User")
                        .WithMany("UserGeneratedBuildOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserGeneratedBuild");
                });

            modelBuilder.Entity("Cebulit.API.Models.Auth.User+UserTagMatch", b =>
                {
                    b.HasOne("Cebulit.API.Core.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.HasOne("Cebulit.API.Models.Auth.User", "User")
                        .WithMany("UserTagMatches")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Build", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.Case", "Case")
                        .WithMany("Builds")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Products.PcParts.GraphicsCard", "GraphicsCard")
                        .WithMany("Builds")
                        .HasForeignKey("GraphicsCardId");

                    b.HasOne("Cebulit.API.Models.Products.PcParts.Memory", "Memory")
                        .WithMany("Builds")
                        .HasForeignKey("MemoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Products.PcParts.Motherboard", "Motherboard")
                        .WithMany("Builds")
                        .HasForeignKey("MotherboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Products.PcParts.PowerSupply", "PowerSupply")
                        .WithMany("Builds")
                        .HasForeignKey("PowerSupplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Products.PcParts.Processor", "Processor")
                        .WithMany("Builds")
                        .HasForeignKey("ProcessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("GraphicsCard");

                    b.Navigation("Memory");

                    b.Navigation("Motherboard");

                    b.Navigation("PowerSupply");

                    b.Navigation("Processor");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Build+BuildTagMatch", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.Build", "Build")
                        .WithMany("BuildTagMatches")
                        .HasForeignKey("BuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Core.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.Navigation("Build");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Case+CaseTagMatch", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.Case", "Case")
                        .WithMany("CaseTagMatches")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Core.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.Navigation("Case");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.GraphicsCard+GraphicsCardTagMatch", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.GraphicsCard", "GraphicsCard")
                        .WithMany("GraphicsCardsTagMatches")
                        .HasForeignKey("GraphicsCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Core.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.Navigation("GraphicsCard");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Memory+MemoryTagMatch", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.Memory", "Memory")
                        .WithMany("MemoryTagMatches")
                        .HasForeignKey("MemoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Core.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.Navigation("Memory");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Motherboard+MotherboardTagMatch", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.Motherboard", "Motherboard")
                        .WithMany("MotherboardTagMatches")
                        .HasForeignKey("MotherboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Core.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.Navigation("Motherboard");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.PowerSupply+PowerSupplyTagMatch", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.PowerSupply", "PowerSupply")
                        .WithMany("PowerSupplyTagMatches")
                        .HasForeignKey("PowerSupplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Core.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.Navigation("PowerSupply");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Processor+ProcessorTagMatch", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.Processor", "Processor")
                        .WithMany("ProcessorTagMatches")
                        .HasForeignKey("ProcessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Core.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.Navigation("Processor");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Storage", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.UserBuild", null)
                        .WithMany("Storage")
                        .HasForeignKey("UserBuildId");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Storage+StorageTagMatch", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.Storage", "Storage")
                        .WithMany("StorageTagMatches")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Core.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.Navigation("Storage");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.UserBuild", b =>
                {
                    b.HasOne("Cebulit.API.Models.Products.PcParts.Case", "Case")
                        .WithMany()
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Products.PcParts.GraphicsCard", "GraphicsCard")
                        .WithMany()
                        .HasForeignKey("GraphicsCardId");

                    b.HasOne("Cebulit.API.Models.Products.PcParts.Memory", "Memory")
                        .WithMany()
                        .HasForeignKey("MemoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Products.PcParts.Motherboard", "Motherboard")
                        .WithMany()
                        .HasForeignKey("MotherboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Products.PcParts.PowerSupply", "PowerSupply")
                        .WithMany()
                        .HasForeignKey("PowerSupplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Products.PcParts.Processor", "Processor")
                        .WithMany()
                        .HasForeignKey("ProcessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cebulit.API.Models.Auth.User", "User")
                        .WithMany("GeneratedBuilds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("GraphicsCard");

                    b.Navigation("Memory");

                    b.Navigation("Motherboard");

                    b.Navigation("PowerSupply");

                    b.Navigation("Processor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cebulit.API.Models.Auth.User", b =>
                {
                    b.Navigation("GeneratedBuilds");

                    b.Navigation("UserBuildOrders");

                    b.Navigation("UserGeneratedBuildOrders");

                    b.Navigation("UserTagMatches");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Build", b =>
                {
                    b.Navigation("BuildTagMatches");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Case", b =>
                {
                    b.Navigation("Builds");

                    b.Navigation("CaseTagMatches");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.GraphicsCard", b =>
                {
                    b.Navigation("Builds");

                    b.Navigation("GraphicsCardsTagMatches");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Memory", b =>
                {
                    b.Navigation("Builds");

                    b.Navigation("MemoryTagMatches");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Motherboard", b =>
                {
                    b.Navigation("Builds");

                    b.Navigation("MotherboardTagMatches");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.PowerSupply", b =>
                {
                    b.Navigation("Builds");

                    b.Navigation("PowerSupplyTagMatches");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Processor", b =>
                {
                    b.Navigation("Builds");

                    b.Navigation("ProcessorTagMatches");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.Storage", b =>
                {
                    b.Navigation("StorageTagMatches");
                });

            modelBuilder.Entity("Cebulit.API.Models.Products.PcParts.UserBuild", b =>
                {
                    b.Navigation("Storage");
                });
#pragma warning restore 612, 618
        }
    }
}
