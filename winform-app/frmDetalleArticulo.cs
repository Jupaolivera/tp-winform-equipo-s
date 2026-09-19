using System;
using System.Windows.Forms;
using dominio;
using negocio;

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

            ImagenNegocio imagenNegocio = new ImagenNegocio();
            lstImagenes.DataSource = imagenNegocio.listar(articulo.Id);
            lstImagenes.DisplayMember = "ImagenUrl";
        }

        private void lstImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Imagen seleccionada = (Imagen)lstImagenes.SelectedItem;
            if (seleccionada == null)
                return;

            try
            {
                pbImagen.Load(seleccionada.ImagenUrl);
            }
            catch (Exception)
            {
                pbImagen.Image = null;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
