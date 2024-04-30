using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace modul10_1302223090.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        public class Mahasiswa
        {
            public string Name { get; set; }
            public string NIM { get; set; }
            public List<string> Course {  get; set; }
         
            public int Year { get; set; }
        }
        
        private static List<Mahasiswa> mahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa{ Name = "Fersya Zufar Muhara", NIM = "1302223090", Course = ["matdis"], Year = 2022},
            new Mahasiswa{ Name = "Raphael Permana Barus", NIM = "1302220140", Course = ["Logmat"], Year = 2022},
            new Mahasiswa{ Name = "Darryl Frizzangelo", NIM = "1302223154", Course = ["AKA"], Year = 2022},
            new Mahasiswa{ Name = "Dafa Raimi Suandi", NIM = "1302223156", Course = ["BasDat"], Year = 2022},
            new Mahasiswa{ Name = "Haikal Risnandar", NIM = "1302221050", Course = ["PBO"], Year = 2022},
            new Mahasiswa{ Name = "Mahesa Athaya Zain", NIM = "1302220105", Course = ["KPL"], Year = 2022}
        };
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetMahasiswa()
        {
            return new OkObjectResult(mahasiswa);
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetMahasiswaByid(int id)
        {
            if( id >= 0 && id < mahasiswa.Count)
            {
                return Ok(mahasiswa[id]);
            }
            return NotFound();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Mahasiswa value)
        {
            mahasiswa.Add(value);
            return CreatedAtAction(nameof(GetMahasiswa), value);
        }

     
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMahasiswaByIndex(int id)
        {
            if(id >= 0 && (id < mahasiswa.Count)) 
            {
                mahasiswa.RemoveAt(id);
                return NoContent();
            }
            return NotFound(id);
        }
    }
}
