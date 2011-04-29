using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using Model;
using Enum;
using System.Windows.Forms;

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
        public long Login(string email, string kodeord)
        {
            long brugerid = 0;
            string navn;
            DateTime fødselsdag;
            long tlf;
            long nød_tlf;
            bool vegetar;
            bool veganer;
            string allergi;
            string andet;

            cmd.CommandText = "KlientLogin";
            cmd.Parameters.Clear();
            SqlParameter par;
            SqlDataReader reader;

            par = new SqlParameter("@email", SqlDbType.NVarChar);
            par.Value = email;
            cmd.Parameters.Add(par);

            par = new SqlParameter("kodeord", SqlDbType.NVarChar);
            par.Value = kodeord;
            cmd.Parameters.Add(par);




            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    brugerid = (long)reader["brugerID"];
                    navn = (string)reader["navn"];
                    fødselsdag = (DateTime)reader["fødselsdag"];
                    tlf = (long)reader["tlf"];
                    nød_tlf = (long)reader["nød_tlf"];
                    vegetar = (bool)reader["vegetar"];
                    veganer = (bool)reader["veganer"];
                    allergi = (string)reader["allergi"];
                    andet = (string)reader["andet"];
                    brugerklient.GenopretBruger(brugerid, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, allergi, andet);
                }
                conn.Close();
                reader.Dispose();

                if (brugerid > 0)
                {
                    HentAlleKampagner();
                    HentKarakterer(brugerid);
                    return brugerid;
                }
                return 0;
            }
            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                return -1;
            }
        }

        public bool HentAlleKampagner()
        {
            cmd.CommandText = "HentAlleKampagner";
            cmd.Parameters.Clear();
            SqlDataReader reader;
            long tempID = 0;
            long tempkampagneID = 0;
            KampagneMultiAttribut multiattribut = null;

            long kampagneID;
            string navn;
            string beskrivelse;
            string hjemmeside;
            long topbrugerID;
            KampagneStatus status;

            long attributID;
            string attributnavn;
            KampagneAttributType kamtype;
            List<string[]> valgmuligheder = new List<string[]>();
            int position;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    kampagneID = Convert.ToInt64(reader["kamID"]);
                    navn = (string)reader["navn"];
                    beskrivelse = (string)reader["beskrivelse"];
                    hjemmeside = (string)reader["hjemmeside"];
                    topbrugerID = Convert.ToInt64(reader["topbrugerID"]);
                    status = (KampagneStatus)reader["status"];
                    if (kampagneID != tempkampagneID)
                    {
                        brugerklient.GenopretKampagne(kampagneID, navn, beskrivelse, hjemmeside, status);
                        tempkampagneID = kampagneID;
                    }

                    if (status == KampagneStatus.Åben)
                    {

                        kamtype = (KampagneAttributType)reader["infotype"];
                        attributnavn = (string)reader["attnavn"];
                        attributID = Convert.ToInt64(reader["attID"]);
                        position = (int)reader["position"];

                        if (kamtype == KampagneAttributType.Singleline)
                        {
                            brugerklient.GenopretAttribut(kampagneID, attributID, attributnavn, kamtype, position);
                        }

                        else if (kamtype == KampagneAttributType.Combo)
                        {
                            if (tempID != attributID)   //tjek om det er en valgmulighed
                            {
                                multiattribut = brugerklient.GenopretMultiAttribut(kampagneID, attributID, attributnavn, kamtype, position);
                            }
                            if (reader["værdi"] != System.DBNull.Value && reader["entryID"] != System.DBNull.Value)
                            {
                                KampagneMultiAttributValgmulighed valg = new KampagneMultiAttributValgmulighed((long)reader["entryID"], (string)reader["værdi"]);
                                multiattribut.TilføjValgmulighed(valg);
                            }
                        }
                        tempID = attributID;
                    }
                }
                conn.Close();
                reader.Dispose();
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

        public bool HentKarakterer(long brugerID)
        {
            SqlDataReader reader;
            SqlParameter par;
            cmd.CommandText = "HentAlleBrugersKarakterer";
            cmd.Parameters.Clear();
            long kampagneID, karakterID, attributID, multiattributID, multiattributentryID;
            string værdi;

            par = new SqlParameter("brugerID", SqlDbType.BigInt);
            par.Value = brugerID;
            cmd.Parameters.Add(par);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                long tmpKarakterID = 0;
                while (reader.Read())
                {
                    kampagneID = (long)reader["kampagneID"];
                    karakterID = (long)reader["karakterID"];

                    if (tmpKarakterID != karakterID)
                    {
                        brugerklient.GenopretKarakter(karakterID, kampagneID);
                    }

                    if (reader["attributID"] != System.DBNull.Value)
                    {
                        attributID = (long)reader["attributID"];
                        værdi = (string)reader["værdi"];
                        brugerklient.GenopretAttributVærdi(karakterID, kampagneID, attributID, værdi);
                    }

                    if (reader["multiattributID"] != System.DBNull.Value)
                    {
                        multiattributID = (long)reader["multiattributID"];
                        multiattributentryID = (long)reader["multiAttributEntryID"];
                        brugerklient.GenopretMultiattributVærdi(karakterID, kampagneID, multiattributID, multiattributentryID);
                    }

                    tmpKarakterID = karakterID;
                }
                conn.Close();
                reader.Dispose();
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
        public long OpretBruger(string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string allergi, string andet)
        {
            //string sqlfejl = null;

            //string tempBrugerID;
            //long brugerID = 0;
            cmd.CommandText = "OpretBruger";
            cmd.Parameters.Clear();

            SqlParameter par;
            //SqlDataReader reader;

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

            par = new SqlParameter("@allergi", SqlDbType.NVarChar);
            par.Value = allergi;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@andet", SqlDbType.NVarChar);
            par.Value = andet;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@brugerID", SqlDbType.BigInt);
            par.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(par);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return (long)par.Value;
            }

            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return (long)par.Value;
            }
        }


        public bool NyKarakter(IEnumerator værdiiterator, long kampagneID, long brugerID)
        {
            cmd.Parameters.Clear();
            SqlParameter par;
            long karakterID;
            long karakterattributID;
            cmd.CommandText = "OpretKarakter";

            par = new SqlParameter("@kampagneID", SqlDbType.BigInt);
            par.Value = kampagneID;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@brugerID", SqlDbType.BigInt);
            par.Value = brugerID;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@karakterID", SqlDbType.BigInt);
            par.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(par);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                karakterID = (long)par.Value;
                brugerklient.GenopretKarakter(karakterID, kampagneID);

                værdiiterator.Reset();

                while (værdiiterator.MoveNext())
                {
                    Control control = (Control)værdiiterator.Current;
                    cmd.Parameters.Clear();
                    if (control is TextBox)
                    {
                        TextBox textbox = (TextBox)control;
                        cmd.CommandText = "OpretKarakterAttribut";

                        par = new SqlParameter("@karakterID", SqlDbType.BigInt);
                        par.Value = karakterID;
                        cmd.Parameters.Add(par);

                        par = new SqlParameter("@attributID", SqlDbType.BigInt);
                        par.Value = Convert.ToInt64(textbox.Name);
                        cmd.Parameters.Add(par);

                        par = new SqlParameter("@værdi", SqlDbType.NVarChar);
                        par.Value = textbox.Text;
                        cmd.Parameters.Add(par);

                        par = new SqlParameter("@karakterAttributID", SqlDbType.BigInt);
                        par.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(par);

                        cmd.ExecuteNonQuery();
                        karakterattributID = (long)par.Value;
                        
                        brugerklient.GenopretAttributVærdi(karakterID, kampagneID, Convert.ToInt64(textbox.Name), textbox.Text);
                    }
                    else if (control is ComboBox)
                    {
                        ComboBox combobox = (ComboBox)control;
                        cmd.CommandText = "OpretKarakterMultiAttribut";

                        par = new SqlParameter("@karakterID", SqlDbType.BigInt);
                        par.Value = karakterID;
                        cmd.Parameters.Add(par);

                        par = new SqlParameter("@attributID", SqlDbType.BigInt);
                        par.Value = Convert.ToInt64(combobox.Name);
                        cmd.Parameters.Add(par);

                        par = new SqlParameter("@multiAttributEntryID", SqlDbType.BigInt);
                        par.Value = (long)combobox.SelectedIndex;
                        cmd.Parameters.Add(par);

                        par = new SqlParameter("@karakterAttributID", SqlDbType.BigInt);
                        par.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(par);

                        cmd.ExecuteNonQuery();
                        karakterattributID = (long)par.Value;

                        brugerklient.GenopretMultiattributVærdi(karakterID, kampagneID, Convert.ToInt64(combobox.Name), (long)combobox.SelectedIndex);
                    }
                }
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