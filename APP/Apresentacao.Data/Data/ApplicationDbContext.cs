using Apresentacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Apresentacao.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Airplane>(config =>
            {
                config.ToTable("Airplane");
                config.HasKey(x => x.Id);
                config.Property(x => x.Id).ValueGeneratedOnAdd();
                config.Property(x => x.CodeAirplane).HasMaxLength(255);
                config.Property(x => x.DateRegister).IsRequired();
            });


            builder.Entity<User>(config => {
                config.ToTable("User");
                config.HasKey(x => x.Id);
                config.Property(x => x.Id).ValueGeneratedOnAdd();
                config.Property(x => x.Password).HasMaxLength(255);
                config.Property(x => x.Username).HasMaxLength(255);
                config.Property(x => x.Fullname).HasMaxLength(255);
                config.Property(x => x.DateRegister);
            });

            builder.Entity<User>().HasData(new User() {
                Id = 1,
                Email = "romy.moura23@gmail.com",
                Fullname = "Romy G. Moura",
                DateRegister = DateTime.Now,
                Password = "teste123",
                Username = "romy.moura"
            });


            base.OnModelCreating(builder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        
    }
}