using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MissionSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Xml;
using MissionSystem.Core.Models.Project;
using System.Reflection;
using MissionSystem.Core.Consts;

namespace MissionSystem.EF
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {   
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserMission>()
                 .HasKey(e => new { e.UserId, e.MissionId });
            builder.Entity<Answer>()
                .HasKey(e => new { e.UserId, e.MissionId });

            builder.Entity<Answer>()
                  .HasOne(e => e.User)
                  .WithMany(s => s.Answers)
                  .HasForeignKey(e => e.UserId);

            builder.Entity<Answer>()
                .HasOne(e => e.Mission)
                .WithMany(c => c.Answers)
                .HasForeignKey(e => e.MissionId);

            builder.Entity<UserMission>()
             .HasOne(e => e.User)
             .WithMany(s => s.UserMission)
             .HasForeignKey(e => e.UserId);

            builder.Entity<UserMission>()
                .HasOne(e => e.Mission)
                .WithMany(c => c.userMissions)
                .HasForeignKey(e => e.MissionId);

            builder.Entity<TypeMission>()
                .HasMany(o => o.Missions)
                .WithOne(oi => oi.TypeMission)
                .HasForeignKey(oi => oi.TypeMissionId);
        }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<UserMission> UserMissions { get; set; }
        public DbSet<TypeMission> TypeMissions { get; set; }
  
    }
}
