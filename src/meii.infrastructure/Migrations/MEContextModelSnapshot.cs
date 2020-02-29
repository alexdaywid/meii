﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using meii.infrastrutucture.Context;

namespace meii.infrastructure.Migrations
{
    [DbContext(typeof(MEContext))]
    partial class MEContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("meii.Business.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("meii.Business.Entities.Empreendedor", b =>
                {
                    b.Property<int>("EmpreendedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("EmpreendedorId");

                    b.ToTable("Empreendedores");
                });

            modelBuilder.Entity("meii.Business.Entities.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("EnderecoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("meii.Business.Entities.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefoneCelular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefoneFixo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pessoa");
                });

            modelBuilder.Entity("meii.Business.Entities.PessoaFisica", b =>
                {
                    b.HasBaseType("meii.Business.Entities.Pessoa");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Rg")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PessoaFisica");
                });

            modelBuilder.Entity("meii.Business.Entities.PessoaJuridica", b =>
                {
                    b.HasBaseType("meii.Business.Entities.Pessoa");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InscEstadual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InscMunicipal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PessoaJuridica");
                });

            modelBuilder.Entity("meii.Business.Entities.Cliente", b =>
                {
                    b.HasOne("meii.Business.Entities.Pessoa", "Pessoa")
                        .WithOne("Cliente")
                        .HasForeignKey("meii.Business.Entities.Cliente", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("meii.Business.Entities.Endereco", b =>
                {
                    b.HasOne("meii.Business.Entities.Pessoa", "Pessoa")
                        .WithMany("Endereco")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
