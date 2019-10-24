using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TPFinal.Models
{
    public class BD
    {
        public static string conexión = "Server=.;Database=TP-FINAL;Trusted_Connection=True;";

        private static SqlConnection Conectar()
        {
            SqlConnection Conn = new SqlConnection(conexión);
            Conn.Open();
            return Conn;
        }

        public static void Desconectar(SqlConnection Conexion)
        {
            Conexion.Close();
        }

        public static void AgregarResumen(int idUsuario, int Materia, string Titulo, string Texto, string Foto)
        {
            bool aceptado = false;
            SqlConnection Conectado = Conectar();

            SqlCommand Consulta = Conectado.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "INSERT INTO Resumenes(idUsuario, Aceptado, Materia, Titulo, Texto, Foto) values (" + idUsuario + ", " + aceptado + ", " + Materia + ", " + Texto + ", " + Foto + " )";
            Desconectar(Conectado);
        }
        public static List<Materia> ListarMaterias()
        {
            List<Materia> Lista = new List<Materia>();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "SELECT * FROM Materias order by Nombre_Materia";
            Consulta.CommandType = System.Data.CommandType.Text;
            SqlDataReader dataReader = Consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int idMateria = Convert.ToInt32(dataReader["idMateria"]);
                string Nombre_Materia = dataReader["Nombre_Materia"].ToString();
                int Puntos_Materia = Convert.ToInt32(dataReader["Puntos_Materia"]);
                Materia nuevo = new Materia(idMateria, Nombre_Materia, Puntos_Materia);
                Lista.Add(nuevo);
            }
            Desconectar(Conexion);
            return Lista;
        }
        public static List<Usuario> ListarTOP3()
        {
            List<Usuario> Lista = new List<Usuario>();

            SqlConnection Conectado = Conectar();
            SqlCommand cmd = new SqlCommand("sp_TraerTop3Usuarios", Conectado);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int idUsuario = Convert.ToInt32(dataReader["idUsuario"]);
                string Nombre = dataReader["Nombre"].ToString();
                string Mail = dataReader["Mail"].ToString();
                string Contraseña = dataReader["Contraseña"].ToString();
                int Puntos = Convert.ToInt32(dataReader["Puntos"]);
                int Experiencia = Convert.ToInt32(dataReader["Experiencia"]);
                string Descripcion = dataReader["Descripcion"].ToString();
                bool Moderador = Convert.ToBoolean(dataReader["Moderador"]);

                Usuario nuevo = new Usuario(idUsuario, Nombre, Mail, Contraseña, Puntos, Experiencia, Descripcion, Moderador);
                Lista.Add(nuevo);
            }
            Desconectar(Conectado);
            return Lista;
        }
        static public bool VerificarUsuario(string unMail, string unaContraseña)
        {
            bool usuarioEncontrado = false;

            string eMail = unMail;
            string eContraseña = unaContraseña;

            Usuario nuevoUsuario = new Usuario();
            List<Usuario> ListaUsuarios = new List<Usuario>();

            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "SELECT * FROM Usuarios";
            SqlDataReader dataReader = Consulta.ExecuteReader();
            while (dataReader.Read())
            {
                string Mail = dataReader["Mail"].ToString();
                string Contraseña = dataReader["Contraseña"].ToString();
                nuevoUsuario = new Usuario(Mail, Contraseña);
                ListaUsuarios.Add(nuevoUsuario);
            }
            dataReader.Close();
            Desconectar(Conexion);

            foreach (Usuario unUsuario in ListaUsuarios)
            {
                if ((eMail == unUsuario.Mail1) && (eContraseña == unUsuario.Contrasena1))
                {
                    usuarioEncontrado = true;
                    break;
                }
            }
            return usuarioEncontrado;
        }
        static public Usuario TraerDatosUsuario(string unMail, string unaContraseña)
        {
            Usuario nuevo = new Usuario();

            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "SELECT * FROM Usuarios WHERE Mail='" + unMail + "' AND Contraseña = '" + unaContraseña + "'";
            SqlDataReader dataReader = Consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int idUsuario = Convert.ToInt32(dataReader["idUsuario"]);
                string Nombre = dataReader["Nombre"].ToString();
                string Mail = dataReader["Mail"].ToString();
                string Contraseña = dataReader["Contraseña"].ToString();
                int Puntos = Convert.ToInt32(dataReader["Puntos"]);
                int Experiencia = Convert.ToInt32(dataReader["Experiencia"]);
                string Descripcion = dataReader["Descripcion"].ToString();
                bool Moderador = Convert.ToBoolean(dataReader["Moderador"]);

                nuevo = new Usuario(idUsuario, Nombre, Mail, Contraseña, Puntos, Experiencia, Descripcion, Moderador);
            }
            dataReader.Close();
            Desconectar(Conexion);
            return nuevo;
        }
    }
}