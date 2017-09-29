using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.INFRA
{
    public class DBUtil
    {

        public SqlConnection Conexao()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ToString());
        }
        public DataSet Lista(SqlParameter[] P, string StoredProcedure)
        {
            var Con = (SqlConnection)Conexao();
            SqlDataAdapter Da;
            DataSet Ds = new DataSet();
            SqlCommand Comm;

            try
            {
                Comm = new SqlCommand(StoredProcedure, Con);
                Comm.Parameters.AddRange(P);
                Comm.CommandType = CommandType.StoredProcedure;

                Con.Open();

                Da = new SqlDataAdapter(Comm);
                Da.Fill(Ds, "Lista");
                return Ds;
            }
            catch
            {
                return new DataSet();
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }
        public DataSet ListaSQL(SqlParameter[] P, string SQL)
        {
            var Con = (SqlConnection)Conexao();
            SqlDataAdapter Da;
            DataSet Ds = new DataSet();
            SqlCommand Comm;

            try
            {
                Con.Open();
                Comm = new SqlCommand(SQL, Con);
                Comm.Parameters.AddRange(P);
                Comm.CommandType = CommandType.Text;

                Da = new SqlDataAdapter(Comm);
                Da.Fill(Ds, "Lista");
                return Ds;
            }
            catch
            {
                return new DataSet();
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }
        public DataRow GetByID(string SP, int ID)
        {
            var Con = Conexao();

            Con.Open();
            using (SqlCommand cmd = Con.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = SP;
                cmd.Parameters.Add(new SqlParameter("@ID", ID));
                SqlDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable DT = new DataTable();
                DT.Load(Reader);
                return DT.Rows[0];
            }



        }

        public Boolean ExecSP(String StoredProcedure, SqlParameter[] P)
        {
            var Con = (SqlConnection)Conexao();
            SqlCommand Comm;

            try
            {
                Comm = new SqlCommand(StoredProcedure, Con);
                Comm.Parameters.AddRange(P);
                Comm.CommandType = CommandType.StoredProcedure;

                Con.Open();

                Comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }


        }
        public Boolean ExecSP(String StoredProcedure)
        {
            var Con = (SqlConnection)Conexao();
            SqlCommand Comm;

            try
            {
                Comm = new SqlCommand(StoredProcedure, Con);
                Comm.CommandType = CommandType.StoredProcedure;

                Con.Open();

                Comm.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }
    }
}