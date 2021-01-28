using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductivityTools.TrainingLog.Contract;
using System;

namespace ProductivityTools.TrainingLog.Database
{
    public class TrainingDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public TrainingDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Training> Training { get; set; }
       // public DbSet<TrainingRaw> TrainingRaw { get; set; }

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                   builder.AddConsole()
                          .AddFilter(DbLoggerCategory.Database.Command.Name,
                                     LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("PTTrainingLog"));
                optionsBuilder.UseLoggerFactory(GetLoggerFactory());
                optionsBuilder.EnableSensitiveDataLogging();
                base.OnConfiguring(optionsBuilder);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new EnumToStringConverter<TrainingType>();

            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Training>().ToTable("Training").HasKey(x => x.TrainingId);
            modelBuilder.Entity<Training>().Property(x => x.Sport).HasConversion(converter);

            base.OnModelCreating(modelBuilder);
        }
    }
}
