using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace BK_Controller
{
    class BrugerDBFacade
    {
        #region constructor og globale variabler

        private string sqlconnection = @"Data Source= linux1.tietgen.dk;Initial Catalog=gruppe101.5;User Id=gruppe101.5;Password=9esUdrAc";

        SqlCommand cmd;
        SqlConnection conn;

        BrugerKlient brugerklient;

        public BrugerDBFacade(BrugerKlient brugerklient)
        {
            cmd = new SqlCommand();
            conn = new SqlConnection(sqlconnection);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            this.brugerklient = brugerklient;
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
            long brugerid = 0;
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

                //CheckRettighed(brugerid);
                
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
            //TODO: lav logud
            return false;
        }

        /// <summary>
        /// tilføj en bruger til databasen, lavet af Denny og Søren
        /// </summary>
        /// <param name="email">brugerens email, bruges også til login</param>
        /// <param name="kodeord">brugerens kodeord, bruges også til login</param>
        /// <param name="navn">brugerens navn</param>
        /// <param name="fødselsdag">brugerens fødselsdag</param>
        /// <param name="tlf">brugerens almindelige telefon nummer</param>
        /// <param name="nød_tlf">brugerens telefon nummer i tilfælde af en ulykke eller lignende</param>
        /// <param name="vegetar">om brugeren er vegetar</param>
        /// <param name="veganer">om brugeren er veganer</param>
        /// <returns>returnerer true hvis brugeren er oprettet, ellers false</returns>
        public bool OpretBruger(string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer)
        {
            //string sqlfejl = null;

            cmd.CommandText = "OpretBruger";
            cmd.Parameters.Clear();

            SqlParameter par;

            par = new SqlParameter("@email", SqlDbType.NVarChar);
            par.Value = email;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@kodeord", SqlDbType.NVarChar);
            par.Value = kodeord;
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
                //if (e.Number == 2627)
                //{
                //    sqlfejl = "Brugeren findes allerede i systemet";
                //}
                //else
                //{
                //    sqlfejl = "der er sket en fejl under oprettelsen af Bruger" + e.Number;
                //}

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return false;
            }
            //return sqlfejl;
        }
    }
}
