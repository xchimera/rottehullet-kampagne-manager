﻿using System;
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
        public long Login(string email, string kodeord)
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
            

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    brugerid = (long)reader["brugerID"];
                    navn = (string)reader["navn"];
                }
                conn.Close();
                reader.Dispose();

                HentAlleBrugere();
                CheckRettighed(brugerid);
                if (brugerid > 0)
                {
                    return brugerid;
                }
                return 0;
            }
            catch(SqlException)
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            return 0;
            }
        }

        public bool Logud(string brugernavn)
        {
            //TODO: lav logud
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
            par.Value = brugerid;
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

        public void HentAlleBrugere()
        {
            string email, navn;
            DateTime fødselsdag;
            long tlf, nød_tlf, brugerID;
            bool vegetar, veganer;

            cmd.CommandText = "HentAlleBrugere";
            cmd.Parameters.Clear();
            SqlDataReader reader;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    navn = (string)reader["navn"];
                    email = (string)reader["email"];
                    fødselsdag = (DateTime)reader["fødselsdag"];
                    tlf = (long)reader["tlf"];
                    nød_tlf = (long)reader["nød_tlf"];
                    brugerID = (long)reader["brugerID"];
                    vegetar = (bool)reader["vegetar"];
                    veganer = (bool)reader["veganer"];

                    kampagnemanager.TilføjBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer);
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
        }

		public bool HentBrugereTilKampagne(long kamID)
		{
			long brugerID, tlf, nød_tlf;
			string email, navn;
			DateTime fødselsdag;
			bool vegetar, veganer;

			cmd.CommandText = "HentBrugereTilKampagne";
			cmd.Parameters.Clear();
			SqlParameter par;
			SqlDataReader reader;

			par = new SqlParameter("@kamID", SqlDbType.BigInt);
			par.Value = kamID;
			cmd.Parameters.Add(par);

			try
			{
				conn.Open();
				reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					brugerID = (long)reader["brugerID"];
					email = (string)reader["email"];
					navn = (string)reader["navn"];
					fødselsdag = (DateTime)reader["fødselsdag"];
					tlf = (long)reader["tlf"];
					nød_tlf = (long)reader["nød_tlf"];
					vegetar = (bool)reader["vegetar"];
					veganer = (bool)reader["veganer"];

					if (!kampagnemanager.Opretbruger(brugerID, email, "", navn, fødselsdag, tlf, nød_tlf, vegetar, veganer))
					{
						return false;
					}
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
				return false;
			}
			return true;
		}

		public bool HentKampagne(long kamID)
		{
			//Opretning af selve kampagnen
			string navn;
			string beskrivelse = "";
			string hjemmeside = "";
			long topbrugerID;
			
			cmd.CommandText = "HentKampagne";
			cmd.Parameters.Clear();
			SqlParameter par;
			SqlDataReader reader;

			par = new SqlParameter("@kamID", SqlDbType.BigInt);
			par.Value = kamID;
			cmd.Parameters.Add(par);

			try
			{
				conn.Open();
				reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					navn = (string)reader["navn"];
					beskrivelse = (string)reader["beskrivelse"];
					hjemmeside = (string)reader["hjemmeside"];
					topbrugerID = (long)reader["topbrugerID"];

					if (!kampagnemanager.GenopretKampagne(topbrugerID, navn, beskrivelse, hjemmeside, topbrugerID))
					{
						return false;
					}
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
				return false;
			}

			////Hentning af attributter på kampagnen
			//string attID, infotype, position;
			////string navn; allerede defineret ovenfor
			//List<string[]> attributliste = new List<string[]>();

			//cmd.CommandText = "HentAttributter";
			//cmd.Parameters.Clear();

			//par = new SqlParameter("@kamID", SqlDbType.BigInt);
			//par.Value = kamID;
			//cmd.Parameters.Add(par);

			//try
			//{
			//    conn.Open();
			//    reader = cmd.ExecuteReader();

			//    while (reader.Read())
			//    {
			//        attID = Convert.ToString(reader["attID"]);
			//        navn = (string)reader["navn"];
			//        infotype = Convert.ToString(reader["infotype"]);
			//        position = Convert.ToString(reader["position"]);
			//        string[] attributarray = {position, attID, navn, infotype};
			//        attributliste.Add(attributarray);
			//    }
			//    attributliste.Sort();
				
			//    reader.Dispose();
			//    conn.Close();
			//}
			//catch (SqlException)
			//{
			//    if (conn.State == ConnectionState.Open)
			//    {
			//        conn.Close();
			//    }
			//}

			//foreach (string[] attribut in attributliste)
			//{
			//    //Opsætning af attributter på kampagne
			//    if (attribut[3] == "0")
			//    {
			//        GenopretSingleAttributter(attribut[1], attribut[2], attribut[3], attribut[0])
			//    }
			//    //Opsætning af entries på multiattributter på kampagne
			//    string attID, infotype, position;
			//    //string navn; allerede defineret ovenfor
			//    List<string[]> attributliste = new List<string[]>();

			//    cmd.CommandText = "HentAttributter";
			//    cmd.Parameters.Clear();

			//    par = new SqlParameter("@kamID", SqlDbType.BigInt);
			//    par.Value = kamID;
			//    cmd.Parameters.Add(par);

			//    try
			//    {
			//        conn.Open();
			//        reader = cmd.ExecuteReader();

			//        while (reader.Read())
			//        {
			//            attID = Convert.ToString(reader["attID"]);
			//            navn = (string)reader["navn"];
			//            infotype = Convert.ToString(reader["infotype"]);
			//            position = Convert.ToString(reader["position"]);
			//            string[] attributarray = { position, attID, navn, infotype };
			//            attributliste.Add(attributarray);
			//        }
			//        attributliste.Sort();

			//        reader.Dispose();
			//        conn.Close();
			//    }
			//    catch (SqlException)
			//    {
			//        if (conn.State == ConnectionState.Open)
			//        {
			//            conn.Close();
			//        }
			//    }
			//}
			return true;
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
                    kampagneid = Convert.ToString(reader["kamID"]);
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
        public long OpretKampagne(string navn, long topbrugerID)
        {
            cmd.CommandText = "OpretKampagne";
            cmd.Parameters.Clear();
            SqlParameter par;
            
            long kampagneid = 0;
            string tempid;

            par = new SqlParameter("@navn", SqlDbType.NVarChar);
            par.Value = navn;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@topbrugerID", SqlDbType.BigInt);
            par.Value = topbrugerID;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@id", SqlDbType.BigInt);
            par.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(par);

            

            try
            {

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return (long)par.Value;
               

                //conn.Open();
                //reader = cmd.ExecuteReader();

                //while (reader.Read())
                //{
                //    kampagneid = (int)reader["id"];
                //}
                //reader.Dispose();
                //conn.Close();
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

            SqlDataReader reader;

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
                //cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                
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

        /// <summary>
        /// bruges til at tilknytte en bruger som superbruger til en kampagne
        /// </summary>
        /// <param name="brugerID">brugerens id</param>
        /// <param name="kampagneID">kampagnens id der skal rettes på</param>
        /// <returns>returnerer true hvis brugeren er tilknyttet, ellers false</returns>
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

        /// <summary>
        /// bruges til at rette et kampagnenavn
        /// </summary>
        /// <param name="navn">kampagnens navn</param>
        /// <param name="kampagneID">kampagnens id der skal rettes på</param>
        /// <returns>returnerer true hvis kampagnens navn er rettet, ellers false</returns>
        public bool RetKampagneNavn(string navn, long kampagneID)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "RetKampagneNavn";
            SqlParameter par;

            par = new SqlParameter("@navn", SqlDbType.NVarChar);
            par.Value = navn;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@kamID", SqlDbType.BigInt);
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

        /// <summary>
        /// bruges til at rette kampagnens beskrivelse
        /// </summary>
        /// <param name="beskrivelse">kampagnens beskrivelse</param>
        /// <param name="kampagneID">kampagnens id der skal rettes på</param>
        /// <returns>returnerer true hvis kampagnens beskrivelse er rettet, ellers false</returns>
        public bool RetKampagneBeskrivelse(string beskrivelse, long kampagneID)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "RetKampagneBeskrivelse";
            SqlParameter par;

            par = new SqlParameter("@beskrivelse", SqlDbType.NVarChar);
            par.Value = beskrivelse;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@kamID", SqlDbType.BigInt);
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

        /// <summary>
        /// bruges til at rette kampagnens hjemmeside adresse
        /// </summary>
        /// <param name="hjemmeside">kampagnens hjemmeside adresse</param>
        /// <param name="kampagneID">kampagnens id der skal rettes på</param>
        /// <returns>returnerer true hvis kampagnens hjemmeside adresse er rettet, ellers false</returns>
        public bool RetKampagneHjemmeside(string hjemmeside, long kampagneID)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "RetKampagneHjemmeside";
            SqlParameter par;

            par = new SqlParameter("@hjemmeside", SqlDbType.NVarChar);
            par.Value = hjemmeside;
            cmd.Parameters.Add(par);

            par = new SqlParameter("@kamID", SqlDbType.BigInt);
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

		public long OpretKampagneSingleAttribut(string navn, int type, long kampagneID, int position)
		{
			cmd.Parameters.Clear();
			cmd.CommandText = "OpretAttribut";
			SqlParameter par;

			par = new SqlParameter("@kamID", SqlDbType.BigInt);
			par.Value = kampagneID;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@navn", SqlDbType.NVarChar);
			par.Value = navn;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@infotype", SqlDbType.Int);
			par.Value = type;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@position", SqlDbType.Int);
			par.Value = position;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@id", SqlDbType.BigInt);
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
				return -1;
			}
		}

		public long OpretKampagneMultiAttributEntry(long attributID, string værdi)
		{
			cmd.Parameters.Clear();
			cmd.CommandText = "OpretMultiAttributEntry";
			SqlParameter par;

			par = new SqlParameter("@attID", SqlDbType.BigInt);
			par.Value = attributID;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@værdi", SqlDbType.NVarChar);
			par.Value = værdi;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@id", SqlDbType.BigInt);
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
				return -1;
			}
		}
    }
}