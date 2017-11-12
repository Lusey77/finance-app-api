﻿// <auto-generated />
using FinanceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FinanceApp.Infrastructure.Data.Migrations
{
    [DbContext(typeof(FinanceAppContext))]
    partial class FinanceAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinanceApp.Domain.Entity.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("FinanceApp.Domain.Entity.ItemTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("LineItemId");

                    b.Property<long>("TagTypeId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("LineItemId");

                    b.HasIndex("TagTypeId");

                    b.ToTable("ItemTags");
                });

            modelBuilder.Entity("FinanceApp.Domain.Entity.LineItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("Description");

                    b.Property<long>("TransactionId");

                    b.Property<long>("TransactionTypeId");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("FinanceApp.Domain.Entity.TagType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("TagTypes");
                });

            modelBuilder.Entity("FinanceApp.Domain.Entity.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AccountId");

                    b.Property<byte[]>("Attachement");

                    b.Property<DateTimeOffset>("Date");

                    b.Property<string>("Description");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("FinanceApp.Domain.Entity.TransactionTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("TagTypeId");

                    b.Property<long?>("TransactionId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("TagTypeId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionTags");
                });

            modelBuilder.Entity("FinanceApp.Domain.Entity.TransactionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("FinanceApp.Domain.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FinanceApp.Domain.Entity.ItemTag", b =>
                {
                    b.HasOne("FinanceApp.Domain.Entity.LineItem")
                        .WithMany("ItemTags")
                        .HasForeignKey("LineItemId");

                    b.HasOne("FinanceApp.Domain.Entity.TagType", "TagType")
                        .WithMany()
                        .HasForeignKey("TagTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinanceApp.Domain.Entity.LineItem", b =>
                {
                    b.HasOne("FinanceApp.Domain.Entity.Transaction", "Transaction")
                        .WithMany("LineItems")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinanceApp.Domain.Entity.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinanceApp.Domain.Entity.Transaction", b =>
                {
                    b.HasOne("FinanceApp.Domain.Entity.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinanceApp.Domain.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinanceApp.Domain.Entity.TransactionTag", b =>
                {
                    b.HasOne("FinanceApp.Domain.Entity.TagType", "TagType")
                        .WithMany()
                        .HasForeignKey("TagTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinanceApp.Domain.Entity.Transaction")
                        .WithMany("TransactionTags")
                        .HasForeignKey("TransactionId");
                });
#pragma warning restore 612, 618
        }
    }
}
