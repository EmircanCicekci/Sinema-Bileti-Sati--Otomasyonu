﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sinema_Bileti_Satış_Otomasyonu.Data;

#nullable disable

namespace Sinema_Bileti_Satış_Otomasyonu.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230612203319_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.Bilet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SeansKoltukId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SeansKoltukId");

                    b.HasIndex("UserId");

                    b.ToTable("Bilets");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.Cart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Koltukno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Miktar")
                        .HasColumnType("int");

                    b.Property<int>("SeansId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("SeansId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.FilmDetaylar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FilmResim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Film_aciklamasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Film_ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FilmDetaylars");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.Koltuk", b =>
                {
                    b.Property<int>("KoltukID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KoltukID"));

                    b.Property<string>("KoltukNumarasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Satir")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sutun")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KoltukID");

                    b.ToTable("Koltuks");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.Rezervasyon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datetopresent")
                        .HasColumnType("datetime2");

                    b.Property<int>("FilmDetaylarId")
                        .HasColumnType("int");

                    b.Property<string>("Koltukno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Miktar")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmDetaylarId");

                    b.ToTable("Rezervasyons");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.Seans", b =>
                {
                    b.Property<int>("SeansId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeansId"));

                    b.Property<int>("FilmDetaylarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FilmSeans")
                        .HasColumnType("datetime2");

                    b.HasKey("SeansId");

                    b.HasIndex("FilmDetaylarId");

                    b.ToTable("Seans");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.SeansKoltuk", b =>
                {
                    b.Property<int>("SeansKoltukID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeansKoltukID"));

                    b.Property<bool>("Dolu")
                        .HasColumnType("bit");

                    b.Property<int>("KoltukID")
                        .HasColumnType("int");

                    b.Property<int>("SeansID")
                        .HasColumnType("int");

                    b.HasKey("SeansKoltukID");

                    b.HasIndex("KoltukID");

                    b.HasIndex("SeansID");

                    b.ToTable("SeansKoltuks");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
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
                    b.HasOne("Sinema_Bileti_Satış_Otomasyonu.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sinema_Bileti_Satış_Otomasyonu.Models.User", null)
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

                    b.HasOne("Sinema_Bileti_Satış_Otomasyonu.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Sinema_Bileti_Satış_Otomasyonu.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.Bilet", b =>
                {
                    b.HasOne("Sinema_Bileti_Satış_Otomasyonu.Models.SeansKoltuk", "seanskoltuk")
                        .WithMany("bilet")
                        .HasForeignKey("SeansKoltukId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sinema_Bileti_Satış_Otomasyonu.Models.User", "user")
                        .WithMany("bilet")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("seanskoltuk");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.Cart", b =>
                {
                    b.HasOne("Sinema_Bileti_Satış_Otomasyonu.Models.Seans", "seans")
                        .WithMany()
                        .HasForeignKey("SeansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("seans");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.Rezervasyon", b =>
                {
                    b.HasOne("Sinema_Bileti_Satış_Otomasyonu.Models.FilmDetaylar", "filmdetaylar")
                        .WithMany("rezervasyon")
                        .HasForeignKey("FilmDetaylarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("filmdetaylar");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.Seans", b =>
                {
                    b.HasOne("Sinema_Bileti_Satış_Otomasyonu.Models.FilmDetaylar", "filmdetaylar")
                        .WithMany("seans")
                        .HasForeignKey("FilmDetaylarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("filmdetaylar");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.SeansKoltuk", b =>
                {
                    b.HasOne("Sinema_Bileti_Satış_Otomasyonu.Models.Koltuk", "koltuk")
                        .WithMany("seanskoltuk")
                        .HasForeignKey("KoltukID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sinema_Bileti_Satış_Otomasyonu.Models.Seans", "seans")
                        .WithMany("seanskoltuk")
                        .HasForeignKey("SeansID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("koltuk");

                    b.Navigation("seans");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.FilmDetaylar", b =>
                {
                    b.Navigation("rezervasyon");

                    b.Navigation("seans");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.Koltuk", b =>
                {
                    b.Navigation("seanskoltuk");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.Seans", b =>
                {
                    b.Navigation("seanskoltuk");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.SeansKoltuk", b =>
                {
                    b.Navigation("bilet");
                });

            modelBuilder.Entity("Sinema_Bileti_Satış_Otomasyonu.Models.User", b =>
                {
                    b.Navigation("bilet");
                });
#pragma warning restore 612, 618
        }
    }
}
