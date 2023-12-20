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
    public partial class Proveedor : Form

    {
        private BusisnessLogic _busisnessLogic;
        private Proveedores _proveedor;
        public Proveedor()
        {
            InitializeComponent();
            _busisnessLogic = new BusisnessLogic();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            this.Close();
            ((MainProveedores)this.Owner).CargarProveedores();
        }
        private void Guardar()
        {
            Proveedores proveedor = new Proveedores();
            proveedor.RTN = tbId.Text;
            proveedor.NombreEmpresa = tbNombre.Text;
            proveedor.Contacto = tbContacto.Text;
            proveedor.Email = tbEmail.Text;
            proveedor.Telefono = tbTelefono.Text;
            proveedor.Direccion = tbDireccion.Text;
            proveedor.TipoPago = cbPago.Text;
            proveedor.idProveedor = _proveedor != null ? _proveedor.idProveedor : 0;
            _busisnessLogic.SaveProveedor(proveedor);
        }

        public void LoadProveedores (Proveedores proveedor)
        {
            _proveedor = proveedor;
            if(proveedor != null)
            {
                LimpiarFormulario();

                tbId.Text = proveedor.RTN;
                tbNombre.Text = proveedor.NombreEmpresa;
                tbContacto.Text = proveedor.Contacto;
                tbEmail.Text = proveedor.Email;
                tbTelefono.Text = proveedor.Telefono;
                tbDireccion.Text = proveedor.Direccion;
                cbPago.Text= proveedor.TipoPago;
            }
        }

        private void LimpiarFormulario()
        {
            tbId.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbContacto.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbTelefono.Text = string.Empty;
            tbDireccion.Text = string.Empty;
            cbPago.Text = string.Empty;
        }
    }
}
