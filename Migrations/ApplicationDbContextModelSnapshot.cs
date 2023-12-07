﻿// <auto-generated />
using GameHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameHub.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Category");

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
                        });
                });

            modelBuilder.Entity("GameHub.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Gotcha! Coming in 2025 only for Ps5",
                            Image = "https://cdn.images.express.co.uk/img/dynamic/143/590x/secondary/GTA-6-trailer-Grand-Theft-Auto-6-gameplay-reveal-5098949.jpg?r=1701793274244",
                            Price = 90.0,
                            Title = "GTA 6"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This game is not a metro simulator",
                            Price = 30.0,
                            Title = "Metro Exodus"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The goat",
                            Image = "https://upload.wikimedia.org/wikipedia/en/thumb/4/41/Assassin%27s_Creed_Unity_cover.jpg/220px-Assassin%27s_Creed_Unity_cover.jpg",
                            Price = 20.0,
                            Title = "Assassin's Creed Unity"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The second best assassin's creed game",
                            Image = "https://upload.wikimedia.org/wikipedia/en/4/4a/Assassin%27s_Creed_Origins_Cover_Art.png",
                            Price = 40.0,
                            Title = "Assassin's Creed Origin"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Racing game",
                            Image = "https://image.api.playstation.com/cdn/EP0001/CUSA00161_00/f0kLJbch2vDawClFcF6k9LzZ7Ohi9a7n.png",
                            Price = 15.0,
                            Title = "The Crew"
                        },
                        new
                        {
                            Id = 6,
                            Description = "This doesn't need a description",
                            Price = 25.0,
                            Title = "Minecraft"
                        });
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
#pragma warning restore 612, 618
        }
    }
}
