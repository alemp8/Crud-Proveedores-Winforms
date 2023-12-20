using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proveedores
{
    public partial class MainProveedores : Form
    {
        private BusisnessLogic BusisnessLogic;
        public MainProveedores()
        {
            InitializeComponent();
            BusisnessLogic = new BusisnessLogic();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedor proveedorregistro = new Proveedor();
            proveedorregistro.ShowDialog(this);
        }

        private void MainProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        public void CargarProveedores(string search = null)
        {
            List<Proveedores> proveedor = BusisnessLogic.GetProveedores(search);
            dataGridViewProveedores.DataSource = proveedor;
        }

        private void dataGridViewProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)dataGridViewProveedores.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value.ToString() == "Editar")
            {
                Proveedor frmproveedor = new Proveedor();
                frmproveedor.LoadProveedores(new Proveedores
                {
                    idProveedor = int.Parse((dataGridViewProveedores.Rows[e.RowIndex].Cells[0].Value.ToString())),
                    RTN = dataGridViewProveedores.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    NombreEmpresa = dataGridViewProveedores.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    Contacto = dataGridViewProveedores.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Telefono = dataGridViewProveedores.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    Email = dataGridViewProveedores.Rows[e.RowIndex].Cells[5].Value.ToString(),
                    Direccion = dataGridViewProveedores.Rows[e.RowIndex].Cells[6].Value.ToString(),
                    TipoPago = dataGridViewProveedores.Rows[e.RowIndex].Cells[7].Value.ToString()
                });
                frmproveedor.ShowDialog(this);
            } else if(cell.Value.ToString() == "Eliminar")
            {
                DeleteProveedor(int.Parse((dataGridViewProveedores.Rows[e.RowIndex].Cells[0].Value.ToString())));
                CargarProveedores();
            }
        }

        private void DeleteProveedor(int idProveedor)
        {
            BusisnessLogic.DeleteProveedor(idProveedor);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProveedores(tbBuscar.Text);
            tbBuscar.Text = string.Empty;
        }
    }
}
