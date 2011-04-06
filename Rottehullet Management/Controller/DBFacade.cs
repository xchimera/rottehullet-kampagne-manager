using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace Controller
{
    public class DBFacade
    {
        #region constructor og globale variabler

        private string sqlconnection = @"Data Source= linux1.tietgen.dk;Initial Catalog=gruppe101.5;User Id=gruppe101.5;Password=9esUdrAc";

        SqlCommand cmd;
        SqlConnection conn;

        KampagneManager kampagnemanager;

        public DBFacade(KampagneManager kampagnemanager)
        {
            cmd = new SqlCommand();
            conn = new SqlConnection(sqlconnection);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            this.kampagnemanager = kampagnemanager;
        }
        #endregion


       
        /// <summary>
        /// bruges til at logge ind som admin, topbruger eller superbruger
        /// </summary>
        /// <param name="email">brugerens brugernavn</param>
        /// <param name="kodeord">brugerens kodeord</param>
        /// <returns>returnerer true hvis brugeren findes, ellers false</returns>
        public bool Login(string email, string kodeord)
        {
            long brugerid;
            string navn;

            cmd.CommandText = "BrugerLogin";
            cmd.Parameters.Clear();
            SqlParameter par;
            SqlDataReader reader;

            par = new SqlParameter("@email", SqlDbType.NVarChar);
            par.Value = email;
            cmd.Parameters.Add(par);

            par = new SqlParameter("kodeord", SqlDbType.NVarChar);
            par.Value = kodeord;
            cmd.Parameters.Add(par);
            //TODO: lav login færdig, modtager brugerid, lav en ny bruger

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    brugerid = (int)reader["brugerID"];
                    navn = (string)reader["navn"];
                }
                conn.Close();
                reader.Dispose();
                
            }
            catch(SqlException)
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            return false;
            }
        }

        public bool Logud(string brugernavn)
        {

            return false;
        }

        /// <summary>
        /// bruges til at tjekke om brugeren er admin
        /// </summary>
        /// <param name="brugernavn">brugerens brugernavn</param>
        /// <returns>returnerer true hvis brugeren er admin ellers false</returns>
        public bool CheckAdminRettighed(string brugernavn)
        {
            cmd.CommandText = "checkadminrettighed";
            cmd.Parameters.Clear();
            SqlParameter par;
            SqlDataReader reader;
            

            par = new SqlParameter("brugernavn", SqlDbType.NVarChar);
            par.Value = brugernavn;
            cmd.Parameters.Add(par);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    conn.Close();
                    reader.Dispose();
                    return true;
                }
                else
                {
                    conn.Close();
                    reader.Dispose();
                    return false;
                }
            }
            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return false; 
        }

        public void CheckRettighed(string brugerID)
        {
            cmd.CommandText = "CheckOmTopbruger";
            cmd.Parameters.Clear();
            SqlParameter par;
            SqlDataReader reader;
            string kampagneid;
            string kampagnenavn;
            string brugertype;

            par = new SqlParameter("@brugerID", SqlDbType.NVarChar);
            par.Value = brugerID;
            cmd.Parameters.Add(par);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    kampagneid = (string)reader["kamID"];
                    kampagnenavn = (string)reader["navn"];
                    brugertype = "0";

                    kampagnemanager.IndsætRettighed(kampagneid, kampagnenavn, brugertype);
                }
            }
            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            cmd.CommandText = "CheckOmSuperbruger";
            
        }

    }
}
