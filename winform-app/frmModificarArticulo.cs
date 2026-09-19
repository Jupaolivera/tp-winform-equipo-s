using System;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmModificarArticulo : Form
    {
        private Articulo articulo;
        private ImagenNegocio imagenNegocio = new ImagenNegocio();

        public frmModificarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void frmModificarArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtPrecio.Text = articulo.Precio.ToString();
                cboMarca.SelectedValue = articulo.Marca.Id;
                cboCategoria.SelectedValue = articulo.Categoria.Id;

                cargarImagenes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarImagenes()
        {
            lstImagenes.DataSource = imagenNegocio.listar(articulo.Id);
            lstImagenes.DisplayMember = "ImagenUrl";
            pbImagen.Image = null;
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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNuevaImagen.Text))
                return;

            try
            {
                Imagen nueva = new Imagen();
                nueva.IdArticulo = articulo.Id;
                nueva.ImagenUrl = txtNuevaImagen.Text.Trim();

                imagenNegocio.agregar(nueva);
                txtNuevaImagen.Text = "";
                cargarImagenes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            Imagen seleccionada = (Imagen)lstImagenes.SelectedItem;
            if (seleccionada == null)
                return;

            try
            {
                imagenNegocio.eliminar(seleccionada.Id);
                cargarImagenes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                articuloNegocio.modificar(articulo);

                MessageBox.Show("Artículo modificado");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
