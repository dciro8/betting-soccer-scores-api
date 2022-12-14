// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using betting.soccer.scores.api.Infraestructure;

#nullable disable

namespace bettingsoccerscoresapi.Migrations
{
    [DbContext(typeof(SqlServerDataContext))]
    [Migration("20221002145451_updateSoccerGame")]
    partial class updateSoccerGame
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage.SoccerGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateGame")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<byte?>("ScoreTeamA")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("tinyint");

                    b.Property<byte?>("ScoreTeamB")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("tinyint");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamAId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("TeamBId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("SoccerGames", (string)null);
                });

            modelBuilder.Entity("bettingsoccerscoresapi.Domains.UserService.UserPage.SoccerTeam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TeamCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("SoccerTeams", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
