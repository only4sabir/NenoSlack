﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NenoSlack.Models;

namespace NenoSlack.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20180730044129_InitialCreate1011")]
    partial class InitialCreate1011
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NenoSlack.Models.ChatDetail", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("FromUserId");

                    b.Property<bool>("IsRead");

                    b.Property<string>("Message");

                    b.Property<int>("ToUserId");

                    b.Property<int>("UserId");

                    b.HasKey("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatDetail");
                });

            modelBuilder.Entity("NenoSlack.Models.UserDetail", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("UserDetail");
                });

            modelBuilder.Entity("NenoSlack.Models.ChatDetail", b =>
                {
                    b.HasOne("NenoSlack.Models.UserDetail", "userDetails")
                        .WithMany("ChatDetails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
