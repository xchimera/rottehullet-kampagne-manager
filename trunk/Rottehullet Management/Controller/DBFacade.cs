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
                return true;
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
        /// <param name="brugernavn">brugerens id</param>
        /// <returns>returnerer true hvis brugeren er admin ellers false</returns>
        public bool CheckAdminRettighed(long brugerid)
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
        /// <summary>
        /// her tjekkes om brugeren er topbruger eller superbruger på nogen kampagner
        /// </summary>
        /// <param name="brugerID">brugerens id</param>
        public void CheckRettighed(long brugerID)
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
                    brugertype = "0"; //senere lav en enum?

                    kampagnemanager.IndsætRettighed(kampagneid, kampagnenavn, brugertype);
                }
                reader.Dispose();
                conn.Close();
            }
            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            cmd.CommandText = "CheckOmSuperbruger";

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    kampagneid = (string)reader["KamID"];
                    kampagnenavn = (string)reader["navn"];
                    brugertype = "1"; //senere lav en enum?

                    kampagnemanager.IndsætRettighed(kampagneid, kampagnenavn, brugertype);
                }
                reader.Dispose();
                conn.Close();
            }
            catch(SqlException)
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// bruges til at oprette en kampagne i databasen, lavet af Søren
        /// </summary>
        /// <param name="navn">kampagnens navn</param>
        /// <param name="topbrugerID">topbrugerens id, altså den person der ejer kampagnen</param>
        /// <returns>returnerer kampagnens id som int, eller 0 hvis der skete en fejl</returns>
        public int OpretKampagne(string navn, long topbrugerID)
        {
            cmd.CommandText = "OpretKampagne";
            cmd.Parameters.Clear();
            SqlParameter par;
            SqlDataReader reader;
            int kampagneid = 0;

            par = new SqlParameter("@navn", SqlDbType.NVarChar);
            par.Value = navn;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@topbrugerID", SqlDbType.BigInt);
            par.Value = topbrugerID;
            cmd.Parameters.Add(par);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    kampagneid = (int)reader["id"];
                }
                reader.Dispose();
                conn.Close();
                return kampagneid;
            }
            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return kampagneid;
            }
        }
        /// <summary>
        /// tilføj en bruger til databasen, lavet af Denny og Søren
        /// </summary>
        /// <param name="email">brugerens email, bruges også til login</param>
        /// <param name="navn">brugerens navn</param>
        /// <param name="fødselsdag">brugerens fødselsdag</param>
        /// <param name="tlf">brugerens almindelige telefon nummer</param>
        /// <param name="nød_tlf">brugerens telefon nummer i tilfælde af en ulykke eller lignende</param>
        /// <param name="vegetar">om brugeren er vegetar</param>
        /// <param name="veganer">om brugeren er veganer</param>
        /// <returns>returnerer true hvis brugeren er oprettet, ellers false</returns>
        public bool TilføjBruger(string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "TilføjBruger";
            SqlParameter par;

            par = new SqlParameter("@email", SqlDbType.NVarChar);
            par.Value = email;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@navn", SqlDbType.NVarChar);
            par.Value = navn;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@fødselsdag", SqlDbType.Date);
            par.Value = fødselsdag;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@tlf", SqlDbType.BigInt);
            par.Value = tlf;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@nød_tlf", SqlDbType.BigInt);
            par.Value = nød_tlf;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@vegetar", SqlDbType.Bit);
            par.Value = vegetar;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@veganer", SqlDbType.Bit);
            par.Value = veganer;
            cmd.Parameters.Add(par);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }

            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return false;
            }
        }


        public bool TilknytSuperbruger(long brugerID, long kampagneID)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "TilknytSuperbruger";
            SqlParameter par;

            par = new SqlParameter("@brugerID", SqlDbType.BigInt);
            par.Value = brugerID;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@kampagneID", SqlDbType.BigInt);
            par.Value = kampagneID;
            cmd.Parameters.Add(par);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return false;
            }
        }


    }
}
