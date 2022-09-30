using bettingsoccerscoresapi.Domains.SoccerTeamService.SoccerTeamPage;
using bettingsoccerscoresapi.Domains.UserService.UserPage;
using Microsoft.EntityFrameworkCore;
using System;

namespace bettingsoccerscoresapi.Infraestructure
{
    public static class DbContextFluentApi
    {
        public static void SoccerTeamConfiguration(this ModelBuilder builder)
        {
            builder.Entity<SoccerTeam>(entity =>
            {
                entity.ToTable("SoccerTeams");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id).IsUnique();
                entity.Property(e => e.TeamCode).IsRequired().HasMaxLength(5);
                entity.Property(e => e.TeamName).IsRequired().HasMaxLength(20);
            });
        }
        public static void SoccerGameConfiguration(this ModelBuilder builder)
        {
            builder.Entity<SoccerGame>(entity =>
            {
                entity.ToTable("SoccerGames");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id).IsUnique();
                entity.Property(e => e.TeamAId).IsRequired().HasMaxLength(36);
                entity.Property(e => e.TeamBId).IsRequired().HasMaxLength(36);

                entity.Property(e => e.ScoreTeamA).IsRequired().HasMaxLength(10);
                entity.Property(e => e.ScoreTeamB).IsRequired().HasMaxLength(10);
                entity.Property(e => e.DateGame).IsRequired();                
            });
        }
    }
}
