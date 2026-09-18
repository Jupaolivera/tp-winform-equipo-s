using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;

namespace winform_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //mi part archulo 1 y 2 se borran ya que son de prueba
            /* List<Articulo> listaPrueba = new List<Articulo>();

             Articulo articulo1 = new Articulo();
             articulo1.Nombre = "PlayStation 5";
             articulo1.Descripcion = "Consola de videojuegos";
             articulo1.Precio = 500000;

             Articulo articulo2 = new Articulo();
             articulo2.Nombre = "Mouse Inalámbrico";
             articulo2.Descripcion = "Mouse para PC";
             articulo2.Precio = 25000;

             listaPrueba.Add(articulo1);
             listaPrueba.Add(articulo2);

             dgvArticulos.DataSource = listaPrueba; */

            negocio.ArticuloNegocio negocio = new negocio.ArticuloNegocio();
            dgvArticulos.DataSource = negocio.listar();
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo ventanaAlta = new frmAltaArticulo();
            ventanaAlta.ShowDialog();
        }
    }
}