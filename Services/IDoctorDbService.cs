using System;
using System.Collections.Generic;
using cw11.Models;

namespace cw11.Services
{
    public interface IDoctorDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor GetDoctor(int id);
        public void CreateDoctor(Doctor doctor);
        public void ChangeDoctor(int id, Doctor doctor);
        public void DeleteDoctor(int id);
    }
}
