using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFinal.Models
{
    public class Resumen
    {
        private int idResumen;
        private int Materia;
        private string Titulo;
        private string Texto;
        private string Foto;

        public int IdResumen { get => idResumen; set => idResumen = value; }
        public int Materia1 { get => Materia; set => Materia = value; }
        public string Titulo1 { get => Titulo; set => Titulo = value; }
        public string Texto1 { get => Texto; set => Texto = value; }
        public string Foto1 { get => Foto; set => Foto = value; }

        public Resumen(int idResumen, int materia, string titulo, string texto, string foto)
        {
            this.idResumen = idResumen;
            Materia = materia;
            Titulo = titulo;
            Texto = texto;
            Foto1 = foto;
        }

        public Resumen()
        {

        }
    }
}