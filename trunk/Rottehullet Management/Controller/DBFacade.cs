using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using Enum;
using Model;

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
		/// 

		#region Login/Logout

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
			catch (SqlException)
			{
				if (conn.State == ConnectionState.Open)
				{
					conn.Close();
				}
			}
		}

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

				while (reader.Read())
				{
					brugerid = (long)reader["brugerID"];
					navn = (string)reader["navn"];
				}
				conn.Close();
				reader.Dispose();

				CheckRettighed(brugerid);
				if (brugerid > 0)
				{
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

        public bool HentBrugereTilAdmin()
        {
            SqlDataReader reader;
            cmd.Parameters.Clear();
            cmd.CommandText = "HentAlleBrugere";

            long brugerID;
            string navn;


            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    brugerID = (long)reader["brugerID"];
                    navn = (string)reader["navn"];
                    kampagnemanager.OpretBruger(brugerID, navn);
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



		#endregion

		#region Kampagne

		public bool HentKampagne(long kamID)
		{
			//Opretning af selve kampagnen
			string navn;
			string beskrivelse = "";
			string hjemmeside = "";
			long topbrugerID;
			KampagneStatus status;
			Kampagne kampagne = null;

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
					status = (KampagneStatus)reader["status"];
					kampagne = kampagnemanager.GenopretKampagne(kamID, navn, beskrivelse, hjemmeside, status);
					if (kampagne == null)
					{
						conn.Close();
						return false;
					}
				}

				reader.Dispose();
				conn.Close();
				HentScenarierTilKampagne(kamID);
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

		public bool HentBrugereOgKaraktererTilKampagne(Kampagne kampagne)
		{
			cmd.CommandText = "HentBrugereOgKaraktererTilKampagne";
			cmd.Parameters.Clear();
			SqlParameter par;
			SqlDataReader reader;

			par = new SqlParameter("@kamID", SqlDbType.BigInt);
			par.Value = kampagne.KampagneID;
			cmd.Parameters.Add(par);

			long brugerID;
			string email, navn;
			DateTime fødselsdag;
			long tlf, nød_tlf;
			bool vegetar, veganer;
			string allergi, andet;
			KarakterStatus karstatus;
			long karakterID, attributID, karakterAttributID;
			string værdi;
			long nuværendeBrugerID = 0;
			long nuværendeKarakterID = 0;
			Bruger nuværendeBruger = null;
			Karakter nuværendeKarakter = null;

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
					allergi = (string)reader["allergi"];
					andet = (string)reader["andet"];

					if (brugerID != nuværendeBrugerID)
					{
						nuværendeBruger = kampagnemanager.TilføjBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, andet, allergi);
					}

					if (reader["karakterID"] != DBNull.Value)
					{
						karakterID = (long)reader["karakterID"];
						karstatus = (KarakterStatus)reader["karstatus"];
						if (nuværendeKarakterID != karakterID)
						{
							nuværendeKarakter = nuværendeBruger.GenopretKarakter(karakterID, kampagne);
						}

						if (reader["attributID"] != DBNull.Value)
						{
							attributID = (long)reader["attributID"];
							karakterAttributID = (long)reader["karakterattributID"];
							værdi = (string)reader["værdi"];

							KampagneAttribut attribut = kampagne.FindAttribut(attributID);

							nuværendeKarakter.TilføjVærdi(attribut, værdi, karakterAttributID);
						}
						nuværendeKarakterID = karakterID;
					}
					nuværendeBrugerID = brugerID;
				}
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

		public bool HentMultiAttributterTilKarakterer(List<Karakter> karakterer, Kampagne kampagne)
		{
			cmd.CommandText = "HentAlleKampagnensKarakteresMultiAttributter";
			cmd.Parameters.Clear();
			SqlParameter par;
			SqlDataReader reader;
			Karakter nuværendeKarakter = null;
			long nuværendeKarakterID = 0;
			long karakterID = 0;

			par = new SqlParameter("@kampagneID", SqlDbType.BigInt);
			par.Value = kampagne.KampagneID;
			cmd.Parameters.Add(par);

			try
			{
				conn.Open();
				reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					karakterID = (long)reader["karakterID"];
					if (karakterID != nuværendeKarakterID)
					{
						foreach (Karakter karakter in karakterer)
						{
							if (karakter.KarakterID == karakterID)
							{
								nuværendeKarakter = karakter;
								nuværendeKarakterID = karakterID;
							}
						}
					}

					KampagneMultiAttribut attribut = (KampagneMultiAttribut)kampagne.FindAttribut((long)reader["attributID"]);
					nuværendeKarakter.TilføjVærdi(attribut, attribut.FindValgmulighed((long)reader["multiAttributEntryID"]), (long)reader["karakterAttributID"]);
				}

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

			par = new SqlParameter("@navn", SqlDbType.NVarChar);
			par.Value = navn;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@topbrugerID", SqlDbType.BigInt);
			par.Value = topbrugerID;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@status", SqlDbType.Int);
			par.Value = KampagneStatus.Oprettet;
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
				return kampagneid;
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

		public bool RetKampagneStatus(long id, KampagneStatus status)
		{
			cmd.Parameters.Clear();
			cmd.CommandText = "RetKampagneStatus";
			SqlParameter par;

			par = new SqlParameter("@kamID", SqlDbType.BigInt);
			par.Value = id;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@status", SqlDbType.Int);
			par.Value = status;
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
		/// bruges til at tilknytte en bruger som superbruger til en kampagne
		/// </summary>
		/// <param name="brugerID">brugerens id</param>
		/// <param name="kampagneID">kampagnens id der skal rettes på</param>
		/// <returns>returnerer true hvis brugeren er tilknyttet, ellers false</returns>
		public bool TilknytSuperbruger(long brugerID, long kampagneID)
		{
			cmd.Parameters.Clear();
			cmd.CommandText = "OpretSuperbruger";
			SqlParameter par;

			par = new SqlParameter("@brugerID", SqlDbType.BigInt);
			par.Value = brugerID;
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

		#endregion

		#region scenarie
		public bool HentScenarierTilKampagne(long kampagneID)
		{
			cmd.CommandText = "HentScenarierTilKampagne";
			cmd.Parameters.Clear();
			SqlParameter par;
			SqlDataReader reader;

			par = new SqlParameter("@kampagneID", SqlDbType.BigInt);
			par.Value = kampagneID;
			cmd.Parameters.Add(par);

			try
			{
				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					long id = (long)reader["scenarieID"];
					string titel = (string)reader["titel"];
					string beskrivelse = (string)reader["beskrivelse"];
					string sted = (string)reader["sted"];
					string andetInfo = (string)reader["andetInfo"];
					double pris = Convert.ToDouble(reader["pris"]);
					DateTime tid = (DateTime)reader["dato"];
					int overnatning = (int)reader["overnatning"];
					bool spisning = (bool)reader["spisning"];
					bool spisningTvungen = (bool)reader["spisningTvungen"];
					bool overnatningTvungen = (bool)reader["overnatningTvungen"];
					kampagnemanager.GenopretScenarie(id, titel, beskrivelse, tid, sted, pris, overnatning, spisning, spisningTvungen, overnatningTvungen, andetInfo);
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

		public bool RetScenarie(string titel, string beskrivelse, DateTime tid, string sted, double pris, int overnatning, bool spisning, bool spisningTvungen, bool overnatningTvungen, string andetInfo, long scenarieID)
		{
			cmd.CommandText = "RetScenarie";
			cmd.Parameters.Clear();
			SqlParameter par;

			par = new SqlParameter("@titel", SqlDbType.NVarChar);
			par.Value = titel;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@beskrivelse", SqlDbType.NVarChar);
			par.Value = beskrivelse;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@dato", SqlDbType.DateTime);
			par.Value = tid;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@sted", SqlDbType.NVarChar);
			par.Value = sted;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@pris", SqlDbType.Float);
			par.Value = pris;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@overnatning", SqlDbType.Int);
			par.Value = overnatning;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@overnatningTvungen", SqlDbType.Bit);
			par.Value = overnatningTvungen;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@spisning", SqlDbType.Bit);
			par.Value = spisning;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@spisningTvungen", SqlDbType.Bit);
			par.Value = spisningTvungen;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@andetInfo", SqlDbType.NVarChar);
			par.Value = andetInfo;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@scenarieID", SqlDbType.BigInt);
			par.Value = scenarieID;
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

		public long TilføjScenarie(string titel, string beskrivelse, DateTime tid, string sted, double pris, int overnatning, bool spisning, bool spisningTvungen, bool overnatningTvungen, string andetInfo, long kampagneID)
		{
			cmd.CommandText = "OpretScenarie";
			cmd.Parameters.Clear();
			SqlParameter par;

			par = new SqlParameter("@titel", SqlDbType.NVarChar);
			par.Value = titel;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@beskrivelse", SqlDbType.NVarChar);
			par.Value = beskrivelse;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@dato", SqlDbType.DateTime);
			par.Value = tid;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@sted", SqlDbType.NVarChar);
			par.Value = sted;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@pris", SqlDbType.Decimal);
			par.Value = pris;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@overnatning", SqlDbType.Int);
			par.Value = overnatning;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@overnatningTvungen", SqlDbType.Bit);
			par.Value = overnatningTvungen;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@spisning", SqlDbType.Bit);
			par.Value = spisning;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@spisningTvungen", SqlDbType.Bit);
			par.Value = spisningTvungen;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@andetInfo", SqlDbType.NVarChar);
			par.Value = andetInfo;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@kampagneID", SqlDbType.BigInt);
			par.Value = kampagneID;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@scenarieID", SqlDbType.BigInt);
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
		#endregion

		#region Brugere
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
		public bool OpretBruger(string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string allergi, string andet)
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

			par = new SqlParameter("@allergi", SqlDbType.NVarChar);
			par.Value = allergi;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@andet", SqlDbType.NVarChar);
			par.Value = andet;
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

		#endregion

		#region Attributter
		public bool HentAttributter(long kamID)
		{
			SqlParameter par;
			SqlDataReader reader;
			cmd.CommandText = "HentKampagneAttributter";
			cmd.Parameters.Clear();

			long attributID;
			string navn;
			KampagneAttributType type;
			List<string[]> valgmuligheder = new List<string[]>();
			int position;
			KampagneMultiAttribut attribut = null;


			par = new SqlParameter("@kamID", SqlDbType.BigInt);
			par.Value = kamID;
			cmd.Parameters.Add(par);
			int tempid = 0;
			try
			{
				conn.Open();
				reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					type = (KampagneAttributType)reader["infotype"];
					navn = (string)reader["navn"];
					attributID = (long)reader["attID"];
					position = (int)reader["position"];



					if (type == KampagneAttributType.Singleline)
					{
						kampagnemanager.GenopretAttribut(kamID, attributID, navn, type, position);
					}
					else if (type == KampagneAttributType.Combo)
					{
						if (tempid != attributID)
						{
							attribut = kampagnemanager.GenopretMultiAttribut(kamID, attributID, navn, type, position);
						}
						if (reader["værdi"] != System.DBNull.Value)
						{
							KampagneMultiAttributValgmulighed valg = new KampagneMultiAttributValgmulighed((long)reader["entryID"], (string)reader["værdi"]);
							attribut.TilføjValgmulighed(valg);
						}

					}
					tempid = (int)attributID;

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

		public long OpretKampagneAttribut(string navn, int type, long kampagneID, int position)
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
				if (conn.State == ConnectionState.Open)
				{
					conn.Close();
				}
				return -1;
			}
		}

		public bool RetAttribut(long attID, string navn, int type, long kampagneID, int position)
		{
			cmd.Parameters.Clear();
			cmd.CommandText = "RetAttribut";
			SqlParameter par;

			par = new SqlParameter("@attID", SqlDbType.BigInt);
			par.Value = attID;
			cmd.Parameters.Add(par);

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

		public bool RetKampagneMultiAttributEntry(long id, long attributID, string værdi)
		{
			cmd.Parameters.Clear();
			cmd.CommandText = "RetMultiAttributEntry";
			SqlParameter par;

			par = new SqlParameter("@entryID", SqlDbType.BigInt);
			par.Value = id;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@attID", SqlDbType.BigInt);
			par.Value = attributID;
			cmd.Parameters.Add(par);

			par = new SqlParameter("@værdi", SqlDbType.NVarChar);
			par.Value = værdi;
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

		public bool SletAttribut(long attID)
		{
			cmd.Parameters.Clear();
			cmd.CommandText = "SletAttribut";
			SqlParameter par;

			par = new SqlParameter("@attID", SqlDbType.BigInt);
			par.Value = attID;
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

		public bool SletMultiAttributEntry(long entryId)
		{
			cmd.Parameters.Clear();
			cmd.CommandText = "SletMultiAttribut";
			SqlParameter par;

			par = new SqlParameter("@entryID", SqlDbType.BigInt);
			par.Value = entryId;
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

		#endregion
	}
}