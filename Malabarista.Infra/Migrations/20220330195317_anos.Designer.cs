﻿// <auto-generated />
using System;
using Malabarista.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Malabarista.Infra.Migrations
{
    [DbContext(typeof(MalabaristaDbContext))]
    [Migration("20220330195317_anos")]
    partial class anos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("Malabarista.Domain.Entities.Buy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("GrainId")
                        .HasColumnType("int");

                    b.Property<int>("LoteNumber")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("RoasteDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Shippiment")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("GrainId");

                    b.ToTable("Buys");
                });

            modelBuilder.Entity("Malabarista.Domain.Entities.Grain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Process")
                        .HasColumnType("int");

                    b.Property<string>("Producer")
                        .HasColumnType("longtext");

                    b.Property<string>("Roaster")
                        .HasColumnType("longtext");

                    b.Property<int>("RoasterProfile")
                        .HasColumnType("int");

                    b.Property<int?>("TasteId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("TasteId");

                    b.ToTable("Grains");
                });

            modelBuilder.Entity("Malabarista.Domain.Entities.Taste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PronouncedNote")
                        .HasColumnType("longtext");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tastes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85)
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85)
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("RoleId")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("Name")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Malabarista.Domain.Entities.Buy", b =>
                {
                    b.HasOne("Malabarista.Domain.Entities.Grain", "Grain")
                        .WithMany()
                        .HasForeignKey("GrainId");

                    b.Navigation("Grain");
                });

            modelBuilder.Entity("Malabarista.Domain.Entities.Grain", b =>
                {
                    b.HasOne("Malabarista.Domain.Entities.Taste", "Taste")
                        .WithMany("Grains")
                        .HasForeignKey("TasteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Malabarista.Domain.ValueObjects.GrainChar", "GrainChar", b1 =>
                        {
                            b1.Property<int>("GrainId")
                                .HasColumnType("int");

                            b1.Property<int>("Altitude")
                                .HasColumnType("int");

                            b1.Property<string>("Description")
                                .HasColumnType("longtext");

                            b1.Property<string>("Origin")
                                .HasColumnType("longtext");

                            b1.Property<string>("Variety")
                                .HasColumnType("longtext");

                            b1.HasKey("GrainId");

                            b1.ToTable("Grains");

                            b1.WithOwner()
                                .HasForeignKey("GrainId");
                        });

                    b.Navigation("GrainChar");

                    b.Navigation("Taste");
                });

            modelBuilder.Entity("Malabarista.Domain.Entities.Taste", b =>
                {
                    b.OwnsOne("Malabarista.Domain.ValueObjects.GrainNotes", "GrainNotes", b1 =>
                        {
                            b1.Property<int>("TasteId")
                                .HasColumnType("int");

                            b1.Property<string>("PrimaryNote")
                                .HasColumnType("longtext");

                            b1.Property<string>("SecondaryNote")
                                .HasColumnType("longtext");

                            b1.Property<string>("TerciaryNote")
                                .HasColumnType("longtext");

                            b1.HasKey("TasteId");

                            b1.ToTable("Tastes");

                            b1.WithOwner()
                                .HasForeignKey("TasteId");
                        });

                    b.Navigation("GrainNotes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Malabarista.Domain.Entities.Taste", b =>
                {
                    b.Navigation("Grains");
                });
#pragma warning restore 612, 618
        }
    }
}
