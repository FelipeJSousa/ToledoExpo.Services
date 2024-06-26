﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToledoExpo.Services.Infraestructure.Data.Contexts;

#nullable disable

namespace ToledoExpo.Services.Infraestructure.Migrations
{
    [DbContext(typeof(ToledoCWContext))]
    partial class ToledoCWContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ToledoExpo.Services.Domain.Entities.Atendente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Ativo")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<long>("Estabelecimento")
                        .HasColumnType("bigint")
                        .HasColumnName("estabelecimentoId");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.Property<double>("TempoAtendimentoMinimo")
                        .HasColumnType("double")
                        .HasColumnName("tempo_atend_minimo");

                    b.HasKey("Id");

                    b.HasIndex("Estabelecimento");

                    b.ToTable("atendente", (string)null);
                });

            modelBuilder.Entity("ToledoExpo.Services.Domain.Entities.Atendimento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("Atendente")
                        .HasColumnType("bigint");

                    b.Property<string>("Ativo")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<long>("Cliente")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataChegada")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_chegada");

                    b.Property<DateTime>("DataFimAtendimento")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_fim_atendimento");

                    b.Property<DateTime>("DataInicioAtendimento")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_inicio_atendimento");

                    b.HasKey("Id");

                    b.ToTable("atendimento", (string)null);
                });

            modelBuilder.Entity("ToledoExpo.Services.Domain.Entities.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Ativo")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<double>("CapacidadeCognitiva")
                        .HasColumnType("double")
                        .HasColumnName("capacidade_cognitiva");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("VelocidadeMovimento")
                        .HasColumnType("double")
                        .HasColumnName("velocidade_movimento");

                    b.HasKey("Id");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("ToledoExpo.Services.Domain.Entities.Estabelecimento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Ativo")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime>("DataCricao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Proprietario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("estabelecimento", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Ativo = "S",
                            DataCricao = new DateTime(2024, 4, 13, 17, 46, 30, 28, DateTimeKind.Local).AddTicks(9194),
                            Descricao = "Descrição de teste.",
                            Nome = "Estabelecimento 1",
                            Proprietario = "Felipe Sousa"
                        });
                });

            modelBuilder.Entity("ToledoExpo.Services.Domain.Entities.Atendente", b =>
                {
                    b.HasOne("ToledoExpo.Services.Domain.Entities.Estabelecimento", "EstabelecimentoObj")
                        .WithMany()
                        .HasForeignKey("Estabelecimento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToledoExpo.Services.Domain.Entities.Atendimento", null)
                        .WithOne("AtendenteObj")
                        .HasForeignKey("ToledoExpo.Services.Domain.Entities.Atendente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstabelecimentoObj");
                });

            modelBuilder.Entity("ToledoExpo.Services.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("ToledoExpo.Services.Domain.Entities.Atendimento", null)
                        .WithOne("ClienteObj")
                        .HasForeignKey("ToledoExpo.Services.Domain.Entities.Cliente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ToledoExpo.Services.Domain.Entities.Atendimento", b =>
                {
                    b.Navigation("AtendenteObj");

                    b.Navigation("ClienteObj");
                });
#pragma warning restore 612, 618
        }
    }
}
