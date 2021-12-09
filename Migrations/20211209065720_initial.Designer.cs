﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ligtasUnaAPI.Models;

namespace ligtasUnaAPI.Migrations
{
    [DbContext(typeof(ProjectDBContext))]
    [Migration("20211209065720_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ligtasUnaAPI.Models.Bookmark", b =>
                {
                    b.Property<int>("Bookmark_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Bookmark_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("FaidPR_ID")
                        .HasColumnType("int");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Bookmark_ID");

                    b.HasIndex("FaidPR_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Category", b =>
                {
                    b.Property<int>("Cat_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cat_Name")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("FaidPR_ID")
                        .HasColumnType("int");

                    b.HasKey("Cat_ID");

                    b.HasIndex("FaidPR_ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Feedback", b =>
                {
                    b.Property<int>("Feed_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FaidPR_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Feed_Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Feed_Descrp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Feed_ID");

                    b.HasIndex("FaidPR_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Firstaid", b =>
                {
                    b.Property<int>("FaidPR_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("FaidPR_Des")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaidPR_Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Views")
                        .HasColumnType("integer");

                    b.HasKey("FaidPR_ID");

                    b.ToTable("Firstaids");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Image", b =>
                {
                    b.Property<int>("FaidPR_ImgID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FaidPR_ID")
                        .HasColumnType("int");

                    b.Property<string>("FaidPR_ImgName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaidPR_ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FaidPR_ImgID");

                    b.HasIndex("FaidPR_ID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Report", b =>
                {
                    b.Property<int>("Report_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("BIT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Report_Feedback")
                        .HasColumnType("BIT");

                    b.Property<bool>("Report_Subc")
                        .HasColumnType("BIT");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Report_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Subscription", b =>
                {
                    b.Property<int>("Sub_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Sub_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Sub_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.User", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location_Lat")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Location_Long")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ogranization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Secret")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_ConNum")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("User_CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("User_Fname")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("User_Lname")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("User_Type")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("User_UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Video", b =>
                {
                    b.Property<int>("FaidPR_VidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FaidPR_ID")
                        .HasColumnType("int");

                    b.Property<string>("FaidPR_VidName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaidPR_VidUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FaidPR_VidID");

                    b.HasIndex("FaidPR_ID");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Bookmark", b =>
                {
                    b.HasOne("ligtasUnaAPI.Models.Firstaid", "Firstaids")
                        .WithMany()
                        .HasForeignKey("FaidPR_ID");

                    b.HasOne("ligtasUnaAPI.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("User_ID");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Category", b =>
                {
                    b.HasOne("ligtasUnaAPI.Models.Firstaid", "Firstaids")
                        .WithMany()
                        .HasForeignKey("FaidPR_ID");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Feedback", b =>
                {
                    b.HasOne("ligtasUnaAPI.Models.Firstaid", "Firstaids")
                        .WithMany()
                        .HasForeignKey("FaidPR_ID");

                    b.HasOne("ligtasUnaAPI.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("User_ID");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Image", b =>
                {
                    b.HasOne("ligtasUnaAPI.Models.Firstaid", "Firstaids")
                        .WithMany()
                        .HasForeignKey("FaidPR_ID");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Report", b =>
                {
                    b.HasOne("ligtasUnaAPI.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("User_ID");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Subscription", b =>
                {
                    b.HasOne("ligtasUnaAPI.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("User_ID");
                });

            modelBuilder.Entity("ligtasUnaAPI.Models.Video", b =>
                {
                    b.HasOne("ligtasUnaAPI.Models.Firstaid", "Firstaids")
                        .WithMany()
                        .HasForeignKey("FaidPR_ID");
                });
#pragma warning restore 612, 618
        }
    }
}