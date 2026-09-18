using System;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmModificarArticulo : Form
    {
        private Articulo articulo;

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
