﻿// <auto-generated />
using System;
using API_Orcamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Orcamento.Migrations
{
    [DbContext(typeof(_DbContext))]
    [Migration("20250309210836_nometabelas")]
    partial class nometabelas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Orcamento.Models.AcaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbAcao");
                });

            modelBuilder.Entity("API_Orcamento.Models.ElementoDespesaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbElementoDespesa");
                });

            modelBuilder.Entity("API_Orcamento.Models.FonteRecursoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbFonteRecurso");
                });

            modelBuilder.Entity("API_Orcamento.Models.GrupoDespesaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbGrupoDespesa");
                });

            modelBuilder.Entity("API_Orcamento.Models.LancamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AcaoId")
                        .HasColumnType("int");

                    b.Property<int>("AnoOrcamento")
                        .HasColumnType("int");

                    b.Property<string>("Contratado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("ElementoDespesaId")
                        .HasColumnType("int");

                    b.Property<int>("FonteRecursoId")
                        .HasColumnType("int");

                    b.Property<string>("GED")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GrupoDespesaId")
                        .HasColumnType("int");

                    b.Property<bool>("LancamentoValido")
                        .HasColumnType("bit");

                    b.Property<int>("ModalidadeAplicacaoId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroLancamento")
                        .HasColumnType("int");

                    b.Property<int>("ObjetivoEstrategicoId")
                        .HasColumnType("int");

                    b.Property<int>("ProgramaId")
                        .HasColumnType("int");

                    b.Property<int>("SolicitanteId")
                        .HasColumnType("int");

                    b.Property<int>("TipoLancamentoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoTransacaoId")
                        .HasColumnType("int");

                    b.Property<int>("UnidadeId")
                        .HasColumnType("int");

                    b.Property<int>("UnidadeOrcamentariaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AcaoId");

                    b.HasIndex("ElementoDespesaId");

                    b.HasIndex("FonteRecursoId");

                    b.HasIndex("GrupoDespesaId");

                    b.HasIndex("ModalidadeAplicacaoId");

                    b.HasIndex("ObjetivoEstrategicoId");

                    b.HasIndex("ProgramaId");

                    b.HasIndex("SolicitanteId");

                    b.HasIndex("TipoLancamentoId");

                    b.HasIndex("TipoTransacaoId");

                    b.HasIndex("UnidadeId");

                    b.HasIndex("UnidadeOrcamentariaId");

                    b.ToTable("tbLancamentos");
                });

            modelBuilder.Entity("API_Orcamento.Models.ModalidadeAplicacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbModalidadeAplicacao");
                });

            modelBuilder.Entity("API_Orcamento.Models.ObjetivoEstrategicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbObjetivoEstrategico");
                });

            modelBuilder.Entity("API_Orcamento.Models.ProgramaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbPrograma");
                });

            modelBuilder.Entity("API_Orcamento.Models.SolicitanteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbSolicitante");
                });

            modelBuilder.Entity("API_Orcamento.Models.TipoLancamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbTipoLancamento");
                });

            modelBuilder.Entity("API_Orcamento.Models.TipoTransacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbTipoTransacao");
                });

            modelBuilder.Entity("API_Orcamento.Models.UnidadeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbUnidade");
                });

            modelBuilder.Entity("API_Orcamento.Models.UnidadeOrcamentariaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DtUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbUnidadeOrcamentaria");
                });

            modelBuilder.Entity("API_Orcamento.Models.LancamentoModel", b =>
                {
                    b.HasOne("API_Orcamento.Models.AcaoModel", "Acao")
                        .WithMany()
                        .HasForeignKey("AcaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Orcamento.Models.ElementoDespesaModel", "ElementoDespesa")
                        .WithMany()
                        .HasForeignKey("ElementoDespesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Orcamento.Models.FonteRecursoModel", "FonteRecurso")
                        .WithMany()
                        .HasForeignKey("FonteRecursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Orcamento.Models.GrupoDespesaModel", "GrupoDespesa")
                        .WithMany()
                        .HasForeignKey("GrupoDespesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Orcamento.Models.ModalidadeAplicacaoModel", "ModalidadeAplicacao")
                        .WithMany()
                        .HasForeignKey("ModalidadeAplicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Orcamento.Models.ObjetivoEstrategicoModel", "ObjetivoEstrategico")
                        .WithMany()
                        .HasForeignKey("ObjetivoEstrategicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Orcamento.Models.ProgramaModel", "Programa")
                        .WithMany()
                        .HasForeignKey("ProgramaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Orcamento.Models.SolicitanteModel", "Solicitante")
                        .WithMany()
                        .HasForeignKey("SolicitanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Orcamento.Models.TipoLancamentoModel", "TipoLancamento")
                        .WithMany()
                        .HasForeignKey("TipoLancamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Orcamento.Models.TipoTransacaoModel", "TipoTransacao")
                        .WithMany()
                        .HasForeignKey("TipoTransacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Orcamento.Models.UnidadeModel", "Unidade")
                        .WithMany()
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Orcamento.Models.UnidadeOrcamentariaModel", "UnidadeOrcamentaria")
                        .WithMany()
                        .HasForeignKey("UnidadeOrcamentariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acao");

                    b.Navigation("ElementoDespesa");

                    b.Navigation("FonteRecurso");

                    b.Navigation("GrupoDespesa");

                    b.Navigation("ModalidadeAplicacao");

                    b.Navigation("ObjetivoEstrategico");

                    b.Navigation("Programa");

                    b.Navigation("Solicitante");

                    b.Navigation("TipoLancamento");

                    b.Navigation("TipoTransacao");

                    b.Navigation("Unidade");

                    b.Navigation("UnidadeOrcamentaria");
                });
#pragma warning restore 612, 618
        }
    }
}
