using F1Encyclopedia.Data.Models.Tracks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data.EntityConfiguration.Tracks
{
    public class TrackEntityTypeConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(75);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.Country)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Lat)
                .IsRequired()
                .HasColumnName("Lattitude");

            builder.Property(x => x.Long)
                .IsRequired()
                .HasColumnName("Longitude");

            builder.Property(x => x.Alt)
                .IsRequired()
                .HasColumnName("Altitude");
        }
    }
}
