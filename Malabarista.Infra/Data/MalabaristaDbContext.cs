using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Malabarista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malabarista.Domain.ValueObjects;

namespace Malabarista.Infra.Data
{
    public class MalabaristaDbContext: IdentityDbContext
    
    {
        //Sessão do banco de dados
        public MalabaristaDbContext(DbContextOptions<MalabaristaDbContext> options) : base(options) { }
        //DbContextOptions é configurada em Startup

        //Mapeamento das entidades em tabelas
        public DbSet<Buy> Buys { get; set; }
        public DbSet<Grain> Grains { get; set; }
        public DbSet<Taste> Tastes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //            builder.Entity<GrainChar>().HasNoKey();
            //builder.Entity<Grain>().HasKey(n => n.Id);

            //builder.Entity<GrainChar>().HasNoKey();

            var grain = builder.Entity<Grain>();
            var taste = builder.Entity<Taste>();

            grain.OwnsOne(typeof(GrainChar), "GrainChar");
            taste.OwnsOne(typeof(GrainNotes),"GrainNotes");

            builder.Entity<Grain>().HasOne(b=>b.Taste)
                .WithMany(a=>a.Grains).OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey("TasteId");
                

            builder.Entity<Grain>().Property(n => n.Weight).HasColumnType("decimal(5,2)");





            builder.Entity<IdentityUser>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(85));
            builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(85));

            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(85));

            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));

            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));

            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(85));

            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));
        }


    }
}
