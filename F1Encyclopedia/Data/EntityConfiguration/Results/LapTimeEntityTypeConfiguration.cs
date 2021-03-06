﻿using F1Encyclopedia.Data.Models.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace F1Encyclopedia.Data.EntityConfiguration.Results
{
    public class LapTimeEntityTypeConfiguration : IEntityTypeConfiguration<LapTime>
    {
        public void Configure(EntityTypeBuilder<LapTime> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.RaceWeekend)
                .WithMany()
                .HasForeignKey(x => x.RaceWeekendId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Driver)
                .WithMany()
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Position)
                .HasMaxLength(2);

            builder.Property(x => x.Time)
                .HasConversion(new TimeSpanToTicksConverter());
        }
    }
}
