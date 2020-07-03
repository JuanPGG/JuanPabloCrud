using crudA.Controllers;
using crudA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudA.Views
{
    public partial class Form2 : Form
    {
        private string idUsuario = null;
        private bool Editar = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void btnGuardar_click(object sender, EventArgs e)
        {
            
            if (Editar == false)
            {
                try
                {
                    var user = new Users();
                    user.Nombres = txtNombres.Text;
                    user.Apellidos = txtApellidos.Text;
                    user.Telefono = txtTelefono.Text;
                    user.Correo = txtCorreo.Text;

                    var controller = new Controller();
                    controller.Insertar(user.Nombres, user.Apellidos, user.Telefono, user.Correo);
                    dataGridView1.DataSource = controller.Mostrar();
                    MessageBox.Show("Insertado con exito");
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            if (Editar == true)
            {

                try
                {
                    var user = new Users();
                    user.Nombres = txtNombres.Text;
                    user.Apellidos = txtApellidos.Text;
                    user.Telefono = txtTelefono.Text;
                    user.Correo = txtCorreo.Text;

                    var controller = new Controller();
                    controller.Editar(user.Nombres, user.Apellidos, user.Telefono, user.Correo, idUsuario);
                    dataGridView1.DataSource = controller.Mostrar();
                    MessageBox.Show("Actualizado con exito");
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos por: " + ex);
                }
            }
        }
        public void limpiar()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listar();
        }


        private void listar()
        {
            var controller = new Controller();
            dataGridView1.DataSource = controller.Mostrar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombres.Text = dataGridView1.CurrentRow.Cells["Nombres"].Value.ToString();
                txtApellidos.Text = dataGridView1.CurrentRow.Cells["Apellidos"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                idUsuario = dataGridView1.CurrentRow.Cells["idUsuario"].Value.ToString();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idUsuario = dataGridView1.CurrentRow.Cells["idUsuario"].Value.ToString();
                var controller = new Controller();
                controller.Eliminar(idUsuario);
                dataGridView1.DataSource = controller.Mostrar();
                MessageBox.Show("Eliminado con exito");
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
}
