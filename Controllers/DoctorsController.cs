using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.Models;
using cw11.Services;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorDbService _doctorDbService;

        public DoctorsController(IDoctorDbService doctorDbService)
        {
            _doctorDbService = doctorDbService;
        }

        // GET: api/doctors
        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
            return _doctorDbService.GetDoctors();
        }

        // GET api/doctors/2
        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
            return _doctorDbService.GetDoctor(id);
        }

        // POST api/doctors
        [HttpPost]
        public void Post([FromBody]Doctor doctor)
        {
            _doctorDbService.CreateDoctor(doctor);
        }

        // PUT api/doctors/2
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Doctor doctor)
        {
            _doctorDbService.ChangeDoctor(id, doctor);
        }

        // DELETE api/doctors/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _doctorDbService.DeleteDoctor(id);
        }
    }
}
