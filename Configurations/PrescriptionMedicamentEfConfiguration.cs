using System;
using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cw11.Configurations
{
    public class PrescriptionMedicamentEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public PrescriptionMedicamentEfConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable("Prescription_Medicament");

            builder.HasKey(e => new { e.IdPrescription, e.IdMedicament })
                .HasName("Prescription_Medicament_PK");

            builder.Property(e => e.Details)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(d => d.Prescription)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(d => d.IdPrescription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PrescriptionMedicament_Prescription");

            builder.HasOne(d => d.Medicament)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(d => d.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PrescriptionMedicament_Medicament");
        }
    }
}
