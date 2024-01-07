﻿// <auto-generated />
using System;
using GameHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameHub.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240107002231_Region")]
    partial class Region
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("ProductCategoryContract", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriesId = 1,
                            ProductsId = 1
                        },
                        new
                        {
                            CategoriesId = 5,
                            ProductsId = 1
                        },
                        new
                        {
                            CategoriesId = 3,
                            ProductsId = 2
                        },
                        new
                        {
                            CategoriesId = 6,
                            ProductsId = 2
                        },
                        new
                        {
                            CategoriesId = 3,
                            ProductsId = 3
                        },
                        new
                        {
                            CategoriesId = 3,
                            ProductsId = 4
                        },
                        new
                        {
                            CategoriesId = 7,
                            ProductsId = 5
                        },
                        new
                        {
                            CategoriesId = 2,
                            ProductsId = 6
                        });
                });

            modelBuilder.Entity("GameHub.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "RPG"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Third Person Shooter"
                        },
                        new
                        {
                            Id = 6,
                            Name = "First Person Shooter"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Racing"
                        });
                });

            modelBuilder.Entity("GameHub.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "PlayStation 5"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PlayStation 4"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Xbox Series X/S"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Nintendo Switch"
                        },
                        new
                        {
                            Id = 5,
                            Name = "PC"
                        });
                });

            modelBuilder.Entity("GameHub.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvailableLanguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MinGraphic")
                        .HasColumnType("int");

                    b.Property<int?>("MinOperatingSystem")
                        .HasColumnType("int");

                    b.Property<int?>("MinProcessor")
                        .HasColumnType("int");

                    b.Property<int?>("MinRam")
                        .HasColumnType("int");

                    b.Property<string>("MultiplayerInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecommendedAge")
                        .HasColumnType("int");

                    b.Property<int?>("RecommendedGraphic")
                        .HasColumnType("int");

                    b.Property<int?>("RecommendedOperatingSystem")
                        .HasColumnType("int");

                    b.Property<int?>("RecommendedProcessor")
                        .HasColumnType("int");

                    b.Property<int?>("RecommendedRam")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int?>("StorageMemory")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Video")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.HasIndex("RegionId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableLanguages = "[\"English\",\"French\",\"German\",\"Japanese\"]",
                            Description = "Gotcha! Coming in 2025 only for Ps5",
                            Image = "https://cdn.images.express.co.uk/img/dynamic/143/590x/secondary/GTA-6-trailer-Grand-Theft-Auto-6-gameplay-reveal-5098949.jpg?r=1701793274244",
                            MultiplayerInfo = "Co-op: 1-30 players",
                            PlatformId = 1,
                            Price = 90.0,
                            Producer = "Rockstar",
                            RegionId = 2,
                            ReleaseDate = "12 october 2025",
                            Stock = 0,
                            StorageMemory = 100,
                            Title = "GTA 6",
                            Video = "https://www.youtube.com/embed/QdBZY2fkU-0?si=xAkI1IZSKdli1kjn"
                        },
                        new
                        {
                            Id = 2,
                            AvailableLanguages = "[\"English\",\"French\",\"German\"]",
                            Description = "This game is not a metro simulator",
                            MultiplayerInfo = "only single player",
                            PlatformId = 3,
                            Price = 30.0,
                            Producer = "Deep Silver",
                            RegionId = 1,
                            ReleaseDate = "30 june 2019",
                            Stock = 23,
                            StorageMemory = 60,
                            Title = "Metro Exodus",
                            Video = "https://www.youtube.com/embed/fbbqlvuovQ0?si=5D3_u86XU3mCToDA"
                        },
                        new
                        {
                            Id = 3,
                            AvailableLanguages = "[\"English\",\"French\",\"German\"]",
                            Description = "The goat",
                            Image = "https://upload.wikimedia.org/wikipedia/en/thumb/4/41/Assassin%27s_Creed_Unity_cover.jpg/220px-Assassin%27s_Creed_Unity_cover.jpg",
                            MultiplayerInfo = "Co-op: 2-4 players",
                            PlatformId = 2,
                            Price = 20.0,
                            Producer = "Ubisoft Connect",
                            RegionId = 1,
                            ReleaseDate = "2 may 2014",
                            Stock = 13,
                            StorageMemory = 50,
                            Title = "Assassin's Creed Unity",
                            Video = "https://www.youtube.com/embed/xzCEdSKMkdU?si=5CNvTX67tXPcOD00"
                        },
                        new
                        {
                            Id = 4,
                            AvailableLanguages = "[\"English\",\"French\",\"German\",\"Japanese\",\"Turkish\"]",
                            Description = "The second best assassin's creed game",
                            Image = "https://upload.wikimedia.org/wikipedia/en/4/4a/Assassin%27s_Creed_Origins_Cover_Art.png",
                            MultiplayerInfo = "only single player",
                            PlatformId = 4,
                            Price = 40.0,
                            Producer = "Ubisoft Connect",
                            RegionId = 1,
                            ReleaseDate = "18 december 2017",
                            Stock = 10,
                            StorageMemory = 89,
                            Title = "Assassin's Creed Origin",
                            Video = "https://www.youtube.com/embed/cK4iAjzAoas?si=7QKTeylLWgXXMRQT"
                        },
                        new
                        {
                            Id = 5,
                            AvailableLanguages = "[\"English\",\"French\",\"German\",\"Japanese\",\"Turkish\"]",
                            Description = "Racing game",
                            Image = "https://image.api.playstation.com/cdn/EP0001/CUSA00161_00/f0kLJbch2vDawClFcF6k9LzZ7Ohi9a7n.png",
                            MinGraphic = 2,
                            MinOperatingSystem = 1,
                            MinProcessor = 2,
                            MinRam = 16,
                            MultiplayerInfo = "Co-op: up to 32 players",
                            PlatformId = 5,
                            Price = 15.0,
                            Producer = "Ubisoft",
                            RegionId = 1,
                            ReleaseDate = "22 july 2020",
                            Stock = 23,
                            StorageMemory = 88,
                            Title = "The Crew",
                            Video = "https://www.youtube.com/embed/LVDUbfdfBPk?si=sI9E-UYEqfx1FSmG"
                        },
                        new
                        {
                            Id = 6,
                            AvailableLanguages = "[\"English\"]",
                            Description = "This doesn't need a description",
                            MinGraphic = 1,
                            MinOperatingSystem = 1,
                            MinProcessor = 4,
                            MinRam = 8,
                            MultiplayerInfo = "Public server",
                            PlatformId = 5,
                            Price = 25.0,
                            Producer = "Sandbox",
                            RegionId = 1,
                            ReleaseDate = "8 january 2010",
                            Stock = 6,
                            StorageMemory = 7,
                            Title = "Minecraft"
                        });
                });

            modelBuilder.Entity("GameHub.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Europe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "USA"
                        });
                });

            modelBuilder.Entity("GameHub.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("GameHub.Models.ShoppingCartProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCartProducts");
                });

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GameHub.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("GameHub.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameHub.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameHub.Models.Product", b =>
                {
                    b.HasOne("GameHub.Models.Platform", "Platform")
                        .WithMany("Products")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameHub.Models.Region", "Region")
                        .WithMany("Products")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("GameHub.Models.ShoppingCart", b =>
                {
                    b.HasOne("GameHub.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("GameHub.Models.ShoppingCartProduct", b =>
                {
                    b.HasOne("GameHub.Models.Product", "Product")
                        .WithMany("ShoppingCartProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameHub.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("Products")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingCart");
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

            modelBuilder.Entity("GameHub.Models.Platform", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GameHub.Models.Product", b =>
                {
                    b.Navigation("ShoppingCartProducts");
                });

            modelBuilder.Entity("GameHub.Models.Region", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GameHub.Models.ShoppingCart", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}