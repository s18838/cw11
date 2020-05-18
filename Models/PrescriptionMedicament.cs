using System;
namespace cw11.Models
{
    public class PrescriptionMedicament
    {
        public PrescriptionMedicament()
        {
        }

        public int Dose { get; set; }
        public string Details { get; set; }

        public int IdPrescription { get; set; }
        public int IdMedicament { get; set; }

        public virtual Prescription Prescription { get; set; }
        public virtual Medicament Medicament { get; set; }
    }
}
