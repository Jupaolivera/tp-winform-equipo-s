using System;
using System.Windows.Forms;
using dominio;

namespace winform_app
{
    public partial class frmDetalleArticulo : Form
    {
        private Articulo articulo;

        public frmDetalleArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void frmDetalleArticulo_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = articulo.Codigo;
            txtNombre.Text = articulo.Nombre;
            txtDescripcion.Text = articulo.Descripcion;
            txtMarca.Text = articulo.Marca.Descripcion;
            txtCategoria.Text = articulo.Categoria.Descripcion;
            txtPrecio.Text = articulo.Precio.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
