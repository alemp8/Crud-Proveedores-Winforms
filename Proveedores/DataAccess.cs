using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proveedores
{
    internal class DataAccess
    {
        private SqlConnection conn = new SqlConnection("TuCadenadeConexion");

        public void InsertProvedor(Proveedores proveedor)
        {
            try
            {
                conn.Open();
                string query = @"
                    INSERT INTO Proveedores (RTN,NombreEmpresa,Contacto,Telefono,Email,Direccion,TipoPago)
                    VALUES (@RTN, @NombreEmpresa, @Contacto, @Telefono, @Email, @Direccion, @TipoPago)";
                SqlParameter RTN = new SqlParameter();
                RTN.ParameterName = "@RTN";
                RTN.Value = proveedor.RTN;
                RTN.DbType = System.Data.DbType.String;

                SqlParameter NombrePersona = new SqlParameter();
                NombrePersona.ParameterName = "@NombreEmpresa";
                NombrePersona.Value = proveedor.NombreEmpresa;
                NombrePersona.DbType = System.Data.DbType.String;

                SqlParameter Contacto = new SqlParameter();
                Contacto.ParameterName = "@Contacto";
                Contacto.Value = proveedor.Contacto;
                Contacto.DbType = System.Data.DbType.String;

                SqlParameter Telefono = new SqlParameter();
                Telefono.ParameterName = "@Telefono";
                Telefono.Value = proveedor.Telefono;
                Telefono.DbType = System.Data.DbType.String;

                SqlParameter Email = new SqlParameter();
                Email.ParameterName = "@Email";
                Email.Value = proveedor.Email;
                Email.DbType = System.Data.DbType.String;

                SqlParameter Direccion = new SqlParameter();
                Direccion.ParameterName = "@Direccion";
                Direccion.Value = proveedor.Direccion;
                Direccion.DbType = System.Data.DbType.String;

                SqlParameter TipoPago = new SqlParameter();
                TipoPago.ParameterName = "@TipoPago";
                TipoPago.Value = proveedor.TipoPago;
                TipoPago.DbType = System.Data.DbType.String;

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(RTN);
                command.Parameters.Add(NombrePersona);
                command.Parameters.Add(Contacto);
                command.Parameters.Add(Telefono);
                command.Parameters.Add(Email);
                command.Parameters.Add(Direccion);
                command.Parameters.Add(TipoPago);

                command.ExecuteNonQuery();
            }
            catch(Exception) 
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Proveedores> GetProvedores(string search = null) 
        {
            List<Proveedores> proveedor = new List<Proveedores>();

            try
            {
                conn.Open();
                string query = @"SELECT IdProveedor, RTN, NombreEmpresa, Contacto, Telefono, Email, Direccion, TipoPago
                                FROM Proveedores";
                SqlCommand command = new SqlCommand();
                if (!string.IsNullOrEmpty(search))
                {
                    query += " WHERE NombreEmpresa LIKE @Search OR RTN LIKE @Search OR Contacto LIKE @Search OR Telefono LIKE @Search OR Email LIKE @Search OR Direccion LIKE @Search ";
                    command.Parameters.Add(new SqlParameter("@Search", $"%{search}%"));
                }
                command.CommandText = query;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    proveedor.Add(new Proveedores
                    {
                        idProveedor = int.Parse(reader["idProveedor"].ToString()),
                        RTN = reader["RTN"].ToString(),
                        NombreEmpresa = reader["NombreEmpresa"].ToString(),
                        Contacto = reader["Contacto"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Email = reader["Email"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        TipoPago = reader["TipoPago"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close(); 
            }
            return proveedor;
        }
        public void UpdateProveedor(Proveedores proveedor)
        {
            try
            {
                conn.Open();
                string query = @"UPDATE Proveedores 
                                SET RTN = @RTN, NombreEmpresa = @NombreEmpresa, Contacto = @Contacto, Telefono = @Telefono,
                                           Email = @Email, Direccion = @Direccion, TipoPago = @TipoPago 
            WHERE IdProveedor = @IdProveedor";
                SqlParameter IdProveedor = new SqlParameter();
                IdProveedor.ParameterName = "@IdProveedor";
                IdProveedor.Value = proveedor.idProveedor;
                IdProveedor.DbType = System.Data.DbType.String;

                SqlParameter RTN = new SqlParameter();
                RTN.ParameterName = "@RTN";
                RTN.Value = proveedor.RTN;
                RTN.DbType = System.Data.DbType.String;

                SqlParameter NombrePersona = new SqlParameter();
                NombrePersona.ParameterName = "@NombreEmpresa";
                NombrePersona.Value = proveedor.NombreEmpresa;
                NombrePersona.DbType = System.Data.DbType.String;

                SqlParameter Contacto = new SqlParameter();
                Contacto.ParameterName = "@Contacto";
                Contacto.Value = proveedor.Contacto;
                Contacto.DbType = System.Data.DbType.String;

                SqlParameter Telefono = new SqlParameter();
                Telefono.ParameterName = "@Telefono";
                Telefono.Value = proveedor.Telefono;
                Telefono.DbType = System.Data.DbType.String;

                SqlParameter Email = new SqlParameter();
                Email.ParameterName = "@Email";
                Email.Value = proveedor.Email;
                Email.DbType = System.Data.DbType.String;

                SqlParameter Direccion = new SqlParameter();
                Direccion.ParameterName = "@Direccion";
                Direccion.Value = proveedor.Direccion;
                Direccion.DbType = System.Data.DbType.String;

                SqlParameter TipoPago = new SqlParameter();
                TipoPago.ParameterName = "@TipoPago";
                TipoPago.Value = proveedor.TipoPago;
                TipoPago.DbType = System.Data.DbType.String;

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(IdProveedor);
                command.Parameters.Add(RTN);
                command.Parameters.Add(NombrePersona);
                command.Parameters.Add(Contacto);
                command.Parameters.Add(Telefono);
                command.Parameters.Add(Email);
                command.Parameters.Add(Direccion);
                command.Parameters.Add(TipoPago);

                command.ExecuteNonQuery();
            }
            catch (Exception) { throw; }
            finally { conn.Close(); }
        }

        public void DeleteProveedor(int idProveedor)
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM Proveedores WHERE IdProveedor = @IdProveedor";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@IdProveedor", idProveedor));
                command.ExecuteNonQuery();

                /*SqlParameter IdProveedor = new SqlParameter();
                IdProveedor.ParameterName = "@IdProveedor";
                IdProveedor.Value = proveedor.idProveedor;
                IdProveedor.DbType = System.Data.DbType.String;*/
            }
            catch (Exception) { }
            finally { conn.Close(); }
        }
    }

}
