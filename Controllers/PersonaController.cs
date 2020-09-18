using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DiarsT1.DataBase;
using DiarsT1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiarsT1.Controllers
{
    public class PersonaController : Controller
    {
        public SimuladorContext cnx = new SimuladorContext();
        public IActionResult Index()
        {
            var persona = cnx.Personas.ToList();
            return View(persona);
        }

        public IActionResult Create()
        {
            var city = cnx.Ciudades.ToList();
            ViewBag.Ciudades = city;
            return View(new Persona());
        }

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            Validate(persona);
            var city = cnx.Ciudades.ToList();
            ViewBag.Ciudades = city;
            if (ModelState.IsValid)
            {
                cnx.Personas.Add(persona);
                cnx.SaveChanges();
                return View("Index");
            }
            return View(persona);
        }

        public IActionResult Update(int id)
        {
            var city = cnx.Ciudades.ToList();
            ViewBag.Ciudades = city;
            var persona = cnx.Personas.Where(o => o.IdPersona == id).First();
            return View(persona);
        }
        [HttpPost]
        public ActionResult Update(Persona persona)
        {
            var city = cnx.Ciudades.ToList();
            ViewBag.Ciudades = city;
            var _persona = cnx.Personas.Where(o => o.IdPersona == persona.IdPersona).First();

            _persona.IdPersona = persona.IdPersona;
            _persona.NombrePersona = persona.NombrePersona;
            _persona.ApellidoPersona = persona.ApellidoPersona;
            _persona.FechaNacimiento = persona.FechaNacimiento;
            _persona.Dni = persona.Dni;
            _persona.Genero = persona.Genero;
            _persona.Direccion = persona.Direccion;
            _persona.Email = persona.Email;
            _persona.Ciudad = persona.Ciudad;
            _persona.Username = persona.Username;
            _persona.Password = persona.Password;

            cnx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var persona = cnx.Personas.Where(o => o.IdPersona == id).FirstOrDefault();

            cnx.Remove(persona);
            cnx.SaveChanges();

            return RedirectToAction("Index");
        }

        public void Validate(Persona persona)
        {
            //Validacion de Nombre y apellido
            if (persona.NombrePersona == null || persona.NombrePersona == "")
            {
                ModelState.AddModelError("Nombre", "Debe completar este campo");
            }
           
            if (persona.ApellidoPersona == null || persona.ApellidoPersona == "")
            {
                ModelState.AddModelError("Apellido", "Debe completar este campo");
            }
            
            //Validacion de Fecha de nacimiento
            if(persona.FechaNacimiento.ToString() == null || persona.FechaNacimiento.ToString() == "")
            {
                ModelState.AddModelError("FechaNacimiento", "Debe completar este campo");
            }
            //Validacion de Dni
            if (persona.Dni == null || persona.Dni == "")
            {
                ModelState.AddModelError("Dni", "Debe completar este campo");
            }
           
            //Validar Email
            if (persona.Email == null || persona.Email == "")
            {
                ModelState.AddModelError("Email", "Debe completar este campo");
            }
            //Validar Username
            if (persona.Username == null || persona.Username == "")
            {
                ModelState.AddModelError("Username", "Debe completar este campo");
            }
            //Validar Password
            if (persona.Password == null || persona.Password == "")
            {
                ModelState.AddModelError("Password", "Debe completar este campo");
            }
        }

        public bool NumberValidate(string numero)
        {
            char[] arreglo = numero.ToCharArray();
            foreach (char n in arreglo)
            {
                if (!char.IsNumber(n))
                    return false;
            }
            return true;
        }
    }
}
