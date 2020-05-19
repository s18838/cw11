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
                IdDoctor = 3,
                FirstName = "Kacper",
                LastName = "Groszek",
                Email = "kacper@groshek.com"
            };
            var doctor2 = new Doctor
            {
                IdDoctor = 1,
                FirstName = "Kuba",
                LastName = "Ziemniak",
                Email = "kuba@ziemniak.com"
            };
            var doctor3 = new Doctor
            {
                IdDoctor = 2,
                FirstName = "Rafał",
                LastName = "Balut",
                Email = "rafal@balut.com"
            };

            var patients = new List<Patient>();
            var patient1 = new Patient
            {
                IdPatient = 3,
                FirstName = "Julian",
                LastName = "Mikołajczyk",
                Birthdate = DateTime.Parse("20-05-1990")
            };
            var patient2 = new Patient
            {
                IdPatient = 1,
                FirstName = "Julian",
                LastName = "Mikołajczyk",
                Birthdate = DateTime.Parse("02-01-1995")
            };
            var patient3 = new Patient
            {
                IdPatient = 2,
                FirstName = "Julian",
                LastName = "Mikołajczyk",
                Birthdate = DateTime.Parse("14-10-2000")
            };

            var medicaments = new List<Medicament>();
            var medicament1 = new Medicament
            {
                IdMedicament = 1,
                Name = "Paracetamol",
                Description = "Antivirus",
                Type = "Liquid"
            };
            var medicament2 = new Medicament
            {
                IdMedicament = 2,
                Name = "Amol",
                Description = "Antivirus",
                Type = "Liquid"
            };
            var medicament3 = new Medicament
            {
                IdMedicament = 3,
                Name = "Strepsils",
                Description = "Antivirus",
                Type = "Liquid"
            };

            var prescriptions = new List<Prescription>();
            var prescription1 = new Prescription
            {
                IdPrescription = 2,
                Date = DateTime.Parse("14-05-2020"),
                DueDate = DateTime.Parse("14-08-2020"),
                IdDoctor = doctor1.IdDoctor,
                IdPatient = patient1.IdPatient
            };
            var prescription2 = new Prescription
            {
                IdPrescription = 3,
                Date = DateTime.Parse("10-01-2020"),
                DueDate = DateTime.Parse("10-06-2020"),
                IdDoctor = doctor3.IdDoctor,
                IdPatient = patient2.IdPatient
            };
            var prescription3 = new Prescription
            {
                IdPrescription = 1,
                Date = DateTime.Parse("05-08-2019"),
                DueDate = DateTime.Parse("05-02-2020"),
                IdDoctor = doctor2.IdDoctor,
                IdPatient = patient3.IdPatient
            };

            var prescriptionMedicaments = new List<PrescriptionMedicament>();
            var prescriptionMedicament1 = new PrescriptionMedicament
            {
                Dose = 10,
                Details = "2 razy dziennie",
                IdMedicament = medicament2.IdMedicament,
                IdPrescription = prescription3.IdPrescription
            };
            var prescriptionMedicament2 = new PrescriptionMedicament
            {

                Dose = 3,
                Details = "4 razy dziennie",
                IdMedicament = medicament3.IdMedicament,
                IdPrescription = prescription1.IdPrescription
            };
            var prescriptionMedicament3 = new PrescriptionMedicament
            {
                Dose = 1,
                Details = "3 razy dziennie",
                IdMedicament = medicament1.IdMedicament,
                IdPrescription = prescription2.IdPrescription
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
