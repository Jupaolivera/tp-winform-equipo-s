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
using negocio;

namespace winform_app
{
    public partial class frmFiltroArticulo : Form
    {
        private List<Articulo> listaArticulos;

        public frmFiltroArticulo()
        {
            InitializeComponent();
        }

        private void frmFiltroArticulo_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            string textoFiltro = txtFiltro.Text.Trim();

            try
            {
                if (string.IsNullOrEmpty(textoFiltro))
                {
                    dgvResultado.DataSource = negocio.listar();
                }
                else
                {
                    dgvResultado.DataSource = negocio.filtrar(textoFiltro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.ToString());
            }
        }

        private void cargarGrilla()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.listar();
                dgvResultado.DataSource = listaArticulos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.ToString());
            }
        }
    }
}