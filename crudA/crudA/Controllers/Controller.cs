using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using crudA.Models;
using System.Windows.Forms;

namespace crudA.Controllers
{
    class Controller
    {
        private Conexion con = new Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();

        public DataTable Mostrar()
        {
            string query = "select * from usuario";
            SqlCommand comando = new SqlCommand(query, con.AbrirConexion());
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            con.CerrarConexion();
            return tabla;

        }

        public void Insertar(string nombres, string apellidos, string telefono, string correo)
        {
            //PROCEDIMNIENTO
            string query = "insert into usuario(Nombres, Apellidos, Telefono, Correo) values(@nombres, @apellidos, @telefono, @correo)";
            SqlCommand comand = new SqlCommand(query, con.AbrirConexion());
            comand.Parameters.AddWithValue("@nombres", nombres);
            comand.Parameters.AddWithValue("@apellidos", apellidos);
            comand.Parameters.AddWithValue("@telefono", telefono);
            comand.Parameters.AddWithValue("@correo", correo);
            comand.ExecuteNonQuery();
            comand.Parameters.Clear();

        }

        public void Editar(string nombres, string apellidos, string telefono, string correo, string id)
        {
            //PROCEDIMNIENTO
            string query = "UPDATE usuario SET Nombres=@nombres,Apellidos=@apellidos,Telefono=@Telefono,Correo=@correo WHERE idUsuario=@id";
            SqlCommand comand = new SqlCommand(query, con.AbrirConexion());
            comand.Parameters.AddWithValue("@nombres", nombres);
            comand.Parameters.AddWithValue("@apellidos", apellidos);
            comand.Parameters.AddWithValue("@telefono", telefono);
            comand.Parameters.AddWithValue("@correo", correo);
            comand.Parameters.AddWithValue("@id", id);
            comand.ExecuteNonQuery();
            comand.Parameters.Clear();

        }

        public void Eliminar(string id)
        {
            string query = "delete from usuario where idUsuario = @id";
            SqlCommand comando = new SqlCommand(query, con.AbrirConexion());

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

    }
}
