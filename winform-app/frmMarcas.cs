using System;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmMarcas : Form
    {
        private MarcaNegocio marcaNegocio = new MarcaNegocio();
        private int idSeleccionado = 0;

        public frmMarcas()
        {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            dgvMarcas.DataSource = marcaNegocio.listar();
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null)
                return;

            Marca seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
            idSeleccionado = seleccionada.Id;
            txtDescripcion.Text = seleccionada.Descripcion;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Marca marca = new Marca();
                marca.Descripcion = txtDescripcion.Text;

                marcaNegocio.agregar(marca);
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
                MessageBox.Show("Seleccioná una marca de la grilla primero.");
                return;
            }

            try
            {
                Marca marca = new Marca();
                marca.Id = idSeleccionado;
                marca.Descripcion = txtDescripcion.Text;

                marcaNegocio.modificar(marca);
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
                MessageBox.Show("Seleccioná una marca de la grilla primero.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Eliminar la marca seleccionada?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                marcaNegocio.eliminar(idSeleccionado);
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

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
