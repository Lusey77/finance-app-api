using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FinanceApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Infrastructure.Data
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<LineItem> LineItems { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ItemTag> ItemTags { get; set; }

        public DbSet<TagType> TagTypes { get; set; }

        public DbSet<TransactionTag> TransactionTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type[] types = typeof(EntityTypeConfiguration<>).GetTypeInfo().Assembly.GetTypes();

            IEnumerable<Type> typesToRegister = types
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                               type.GetTypeInfo().BaseType != null &&
                               type.GetTypeInfo().BaseType.GetTypeInfo().IsGenericType &&
                               type.GetTypeInfo().BaseType.GetGenericTypeDefinition() ==
                               typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                ModelBuilderExtensions.AddConfiguration(modelBuilder, configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
