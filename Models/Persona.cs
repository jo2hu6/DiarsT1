using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiarsT1.Models
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public int FechaNacimiento { get; set; }
        public string Dni { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
