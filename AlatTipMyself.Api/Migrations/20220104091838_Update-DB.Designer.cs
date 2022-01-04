﻿// <auto-generated />
using System;
using AlatTipMyself.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlatTipMyself.Api.Migrations
{
    [DbContext(typeof(TipMySelfContext))]
    [Migration("20220104091838_Update-DB")]
    partial class UpdateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlatTipMyself.Api.Models.TransactionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("TransactionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionDestinationAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionSourceAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionStatus")
                        .HasColumnType("int");

                    b.Property<string>("TransactionUniqueReference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("AlatTipMyself.Api.Models.UserDetail", b =>
                {
                    b.Property<string>("AcctNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("AcctBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("AcctName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcctNumber");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("AlatTipMyself.Api.Models.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcctNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("TipPercent")
                        .HasColumnType("int");

                    b.Property<bool>("TipStatus")
                        .HasColumnType("bit");

                    b.Property<decimal>("WalletBalance")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("WalletId");

                    b.HasIndex("AcctNumber");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("AlatTipMyself.Api.Models.WalletHistory", b =>
                {
                    b.Property<int>("WalletHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcctNumber")
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TipAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipPercent")
                        .HasColumnType("int");

                    b.Property<decimal>("TransactionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("WalletHistoryId");

                    b.HasIndex("AcctNumber");

                    b.HasIndex("WalletId");

                    b.ToTable("WalletHistories");
                });

            modelBuilder.Entity("AlatTipMyself.Api.Models.Wallet", b =>
                {
                    b.HasOne("AlatTipMyself.Api.Models.UserDetail", "UserDetail")
                        .WithMany()
                        .HasForeignKey("AcctNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDetail");
                });

            modelBuilder.Entity("AlatTipMyself.Api.Models.WalletHistory", b =>
                {
                    b.HasOne("AlatTipMyself.Api.Models.UserDetail", "UserDetail")
                        .WithMany()
                        .HasForeignKey("AcctNumber");

                    b.HasOne("AlatTipMyself.Api.Models.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDetail");

                    b.Navigation("Wallet");
                });
#pragma warning restore 612, 618
        }
    }
}
