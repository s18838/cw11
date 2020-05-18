using System;
using cw11.Configurations;
using Microsoft.EntityFrameworkCore;

namespace cw11.Models
{
    public class CodeFirstContext : DbContext
    {

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }

        public CodeFirstContext() 
        {

        }

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new PatientEfConfiguration());
            modelbuilder.ApplyConfiguration(new DoctorEfConfiguration());
            modelbuilder.ApplyConfiguration(new MedicamentEfConfiguration());
            modelbuilder.ApplyConfiguration(new PrescriptionEfConfiguration());
            modelbuilder.ApplyConfiguration(new PrescriptionMedicamentEfConfiguration());
        }
    }
}
