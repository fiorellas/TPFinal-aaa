using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFinal.Models
{
    public class Materia
    {
        private int idMateria;
        private string Nombre_Materia;
        private int Puntos;

        public int IdMateria { get => idMateria; set => idMateria = value; }
        public string Nombre_Materia1 { get => Nombre_Materia; set => Nombre_Materia = value; }
        public int Puntos1 { get => Puntos; set => Puntos = value; }

        public Materia(int idMateria, string nombre_Materia, int puntos)
        {
            this.idMateria = idMateria;
            Nombre_Materia = nombre_Materia;
            Puntos = puntos;
        }

        public Materia()
        {

        }
    }
}