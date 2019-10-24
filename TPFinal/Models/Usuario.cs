using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFinal.Models
{
    public class Usuario
    {
        private int idUsuario;
        private string Nombre;
        private string Mail;
        private string Contrasena;
        private int Puntos;
        private int Experiencia;
        private string Descripcion;
        private bool Moderador;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Mail1 { get => Mail; set => Mail = value; }
        public string Contrasena1 { get => Contrasena; set => Contrasena = value; }
        public int Puntos1 { get => Puntos; set => Puntos = value; }
        public int Experiencia1 { get => Experiencia; set => Experiencia = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public bool Moderador1 { get => Moderador; set => Moderador = value; }

        public Usuario(int idUsuario, string nombre, string mail, string contraseña, int puntos, int experiencia, string descripcion, bool moderador)
        {
            this.idUsuario = idUsuario;
            Nombre = nombre;
            Mail = mail;
            Contrasena = contraseña;
            Puntos = puntos;
            Experiencia = experiencia;
            Descripcion = descripcion;
            Moderador = moderador;
        }

        public Usuario()
        {

        }
        public Usuario(string unMail, string unaContraseña)
        {
            Mail1 = unMail;
            Contrasena = unaContraseña;
        }
    }
}