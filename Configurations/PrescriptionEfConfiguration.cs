using System;
using Microsoft.EntityFrameworkCore;
using cw11.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw11.Configurations
{
    public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public PrescriptionEfConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription)
                .HasName("Prescription_PK");

            builder.Property(e => e.Date)
                .IsRequired();

            builder.Property(e => e.DueDate)
                .IsRequired();

            builder.Property(e => e.IdPatient)
                .IsRequired();

            builder.HasOne(d => d.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Patient");

            builder.HasOne(d => d.Doctor)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Doctor");
        }
    }
}
