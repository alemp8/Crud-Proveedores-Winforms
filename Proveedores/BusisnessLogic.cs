using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proveedores
{
    internal class BusisnessLogic
    {
        private DataAccess AccesoDatos;

        public BusisnessLogic()
        {
            AccesoDatos = new DataAccess();
        }
        public Proveedores SaveProveedor(Proveedores proveedor)
        {
            if (proveedor.idProveedor == 0)
            {
                AccesoDatos.InsertProvedor(proveedor);
            }
            else 
            {
                AccesoDatos.UpdateProveedor(proveedor);
            }
            return proveedor;
        }

        public List<Proveedores> GetProveedores(string search = null) 
        {
           return  AccesoDatos.GetProvedores(search);
        }

        public void DeleteProveedor(int idProveedor)
        {
            AccesoDatos.DeleteProveedor(idProveedor);
        }
    }
}
