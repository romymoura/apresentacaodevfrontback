﻿// <auto-generated />
using System;
using Apresentacao.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Apresentacao.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190412201226_Apresentacao")]
    partial class Apresentacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Apresentacao.Domain.Entities.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeAirplane")
                        .HasMaxLength(255);

                    b.Property<int>("CountPassengers");

                    b.Property<DateTime>("DateRegister");

                    b.HasKey("Id");

                    b.ToTable("Airplane");
                });

            modelBuilder.Entity("Apresentacao.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegister");

                    b.Property<string>("Email");

                    b.Property<string>("Fullname")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .HasMaxLength(255);

                    b.Property<string>("Username")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new { Id = 1, DateRegister = new DateTime(2019, 4, 12, 17, 12, 26, 104, DateTimeKind.Local), Email = "romy.moura23@gmail.com", Fullname = "Romy G. Moura", Password = "teste123", Username = "romy.moura" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
