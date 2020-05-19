using System;
using System.Collections.Generic;
using cw11.Configurations;
using Microsoft.EntityFrameworkCore;

namespace cw11.Models
{
    public class CodeFirstContext : DbContext
    {

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

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

            var doctors = new List<Doctor>();
            var doctor1 = new Doctor
            {
                FirstName = "Kacper",
                LastName = "Groszek",
                Email = "kacper@groshek.com"
            };
            var doctor2 = new Doctor
            {
                FirstName = "Kuba",
                LastName = "Ziemniak",
                Email = "kuba@ziemniak.com"
            };
            var doctor3 = new Doctor
            {
                FirstName = "Rafał",
                LastName = "Balut",
                Email = "rafal@balut.com"
            };

            var patients = new List<Patient>();
            var patient1 = new Patient
            {
                FirstName = "Julian",
                LastName = "Mikołajczyk",
                Birthdate = DateTime.Parse("20-05-1990")
            };
            var patient2 = new Patient
            {
                FirstName = "Julian",
                LastName = "Mikołajczyk",
                Birthdate = DateTime.Parse("02-01-1995")
            };
            var patient3 = new Patient
            {
                FirstName = "Julian",
                LastName = "Mikołajczyk",
                Birthdate = DateTime.Parse("14-10-2000")
            };

            var medicaments = new List<Medicament>();
            var medicament1 = new Medicament
            {
                Name = "Paracetamol",
                Description = "Antivirus",
                Type = "Liquid"
            };
            var medicament2 = new Medicament
            {
                Name = "Amol",
                Description = "Antivirus",
                Type = "Liquid"
            };
            var medicament3 = new Medicament
            {
                Name = "Strepsils",
                Description = "Antivirus",
                Type = "Liquid"
            };

            var prescriptions = new List<Prescription>();
            var prescription1 = new Prescription
            {
                Date = DateTime.Parse("14-05-2020"),
                DueDate = DateTime.Parse("14-08-2020"),
                Doctor = doctor1,
                Patient = patient1
            };
            var prescription2 = new Prescription
            {
                Date = DateTime.Parse("10-01-2020"),
                DueDate = DateTime.Parse("10-06-2020"),
                Doctor = doctor3,
                Patient = patient2
            };
            var prescription3 = new Prescription
            {
                Date = DateTime.Parse("05-08-2019"),
                DueDate = DateTime.Parse("05-02-2020"),
                Doctor = doctor2,
                Patient = patient3
            };

            var prescriptionMedicaments = new List<PrescriptionMedicament>();
            var prescriptionMedicament1 = new PrescriptionMedicament
            {
                Dose = 10,
                Details = "2 razy dziennie",
                Medicament = medicament2,
                Prescription = prescription3
            };
            var prescriptionMedicament2 = new PrescriptionMedicament
            {

                Dose = 3,
                Details = "4 razy dziennie",
                Medicament = medicament3,
                Prescription = prescription1
            };
            var prescriptionMedicament3 = new PrescriptionMedicament
            {
                Dose = 1,
                Details = "3 razy dziennie",
                Medicament = medicament1,
                Prescription = prescription2
            };

            doctors.Add(doctor1);
            doctors.Add(doctor2);
            doctors.Add(doctor3);

            patients.Add(patient1);
            patients.Add(patient2);
            patients.Add(patient3);

            medicaments.Add(medicament1);
            medicaments.Add(medicament2);
            medicaments.Add(medicament3);

            prescriptions.Add(prescription1);
            prescriptions.Add(prescription2);
            prescriptions.Add(prescription3);

            prescriptionMedicaments.Add(prescriptionMedicament1);
            prescriptionMedicaments.Add(prescriptionMedicament2);
            prescriptionMedicaments.Add(prescriptionMedicament3);

            modelbuilder.Entity<Doctor>().HasData(doctors);

            modelbuilder.Entity<Patient>().HasData(patients);

            modelbuilder.Entity<Medicament>().HasData(medicaments);

            modelbuilder.Entity<Prescription>().HasData(prescriptions);

            modelbuilder.Entity<PrescriptionMedicament>().HasData(prescriptionMedicaments);
        }
    }
}
