using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Utils
{
    public class DataHelper
    {
        private static DataHelper? _instance;
        private  SqlConnection _connection;

        private DataHelper() 
        {
            _connection = new SqlConnection("Data Source=DESKTOP-T90FC10;Initial Catalog=FacturacionApp;Integrated Security=True;");
        }
        public static DataHelper GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }
        public DataTable? ExecuteSPQuery(string sp, List<ParameterSQL>? parametros)
        {
            DataTable? t = new DataTable();
            SqlCommand? cmd = null;

            try
            {
                _connection.Open();
                cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                t.Load(cmd.ExecuteReader());
            }
            catch (SqlException)
            {
                t = null;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return t;
        }
        public int ExecuteSPDML(string sp, List<ParameterSQL>? parametros)
        {
            int rows;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                rows = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return rows;
        }
        public int ExecuteSPDMLR(string sp, List<ParameterSQL>? parametros)
        {
            int id;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }
                SqlParameter outputIdParam = new SqlParameter("@NuevaFacturaID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);
                cmd.ExecuteNonQuery();
                id = (int)outputIdParam.Value;
                _connection.Close();
            }
            catch (SqlException)
            {
                id = 0;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return id;
        }
        public bool ExecuteSPDML(string sp, List<ParameterSQL>? parametros, SqlTransaction t)
        {
            bool commitable = true;
            if (t != null)
            {
                try
                {
                    var cmd = new SqlCommand(sp, _connection);
                    cmd.Transaction = t;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parametros != null)
                    {
                        foreach (var param in parametros)
                            cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    commitable = false;
                    t.Rollback();
                    t.Dispose();
                }
            }
            return commitable;
        }
        public SqlConnection GetConnection()
        {
            return _connection;
        }
        

    }
}
