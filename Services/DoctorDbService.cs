using System;
using System.Collections.Generic;
using System.Linq;
using cw11.Models;

namespace cw11.Services
{
    public class DoctorDbService: IDoctorDbService
    {
        private readonly CodeFirstContext _codeFirstContext;

        public DoctorDbService(CodeFirstContext codeFirstContext)
        {
            _codeFirstContext = codeFirstContext;
        }

        public void ChangeDoctor(int id, Doctor doctor)
        {
            var d = GetDoctor(id);
            d.FirstName = doctor.FirstName;
            d.LastName = doctor.LastName;
            d.Email = doctor.Email;
            _codeFirstContext.SaveChanges();
        }

        public void CreateDoctor(Doctor doctor)
        {
            _codeFirstContext.Doctors.Add(doctor);
            _codeFirstContext.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doctor = GetDoctor(id);
            _codeFirstContext.Doctors.Remove(doctor);
            _codeFirstContext.SaveChanges();
        }

        public Doctor GetDoctor(int id)
        {
            return _codeFirstContext.Doctors.Where(d => d.IdDoctor == id).SingleOrDefault();
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _codeFirstContext.Doctors.ToList();
        }
    }
}
