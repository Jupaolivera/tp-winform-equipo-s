using System;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmCategorias : Form
    {
        private CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        private int idSeleccionado = 0;

        public frmCategorias()
        {
            InitializeComponent();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            dgvCategorias.DataSource = categoriaNegocio.listar();
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
                return;

            Categoria seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            idSeleccionado = seleccionada.Id;
            txtDescripcion.Text = seleccionada.Descripcion;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.Descripcion = txtDescripcion.Text;

                categoriaNegocio.agregar(categoria);
                cargarGrilla();
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná una categoría de la grilla primero.");
                return;
            }

            try
            {
                Categoria categoria = new Categoria();
                categoria.Id = idSeleccionado;
                categoria.Descripcion = txtDescripcion.Text;

                categoriaNegocio.modificar(categoria);
                cargarGrilla();
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná una categoría de la grilla primero.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Eliminar la categoría seleccionada?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                categoriaNegocio.eliminar(idSeleccionado);
                cargarGrilla();
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            idSeleccionado = 0;
            txtDescripcion.Text = "";
        }
    }
}
