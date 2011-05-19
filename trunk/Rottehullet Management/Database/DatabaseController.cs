using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Database
{
	class DatabaseController
	{
		DBFacade dbFacade;

		public DatabaseController()
		{
			dbFacade = new DBFacade(this);
		}

		//Lavet af Thorbjørn
		public static string Dekrypt(string streng)
		{
			byte[] resultat;
			UTF8Encoding utf8 = new UTF8Encoding();
			byte[] nøgle = utf8.GetBytes("4D92199549E0F2EF009B4160");

			TripleDESCryptoServiceProvider algoritme = new TripleDESCryptoServiceProvider();
			algoritme.Key = nøgle;
			algoritme.Mode = CipherMode.ECB;//Vi vil kun kode en gang
			algoritme.Padding = PaddingMode.PKCS7;//padding for extra bytes i hver blok

			byte[] data = Convert.FromBase64String(streng);

			try
			{
				ICryptoTransform dekryption = algoritme.CreateDecryptor();
				resultat = dekryption.TransformFinalBlock(data, 0, data.Length);
			}
			finally
			{
				algoritme.Clear();
			}
			return utf8.GetString(resultat);
		}

		//Lavet af Thorbjørn
		public static string Enkrypt(string streng)
		{
			byte[] resultat;
			UTF8Encoding utf8 = new UTF8Encoding();
			byte[] nøgle = utf8.GetBytes("4D92199549E0F2EF009B4160");

			TripleDESCryptoServiceProvider algoritme = new TripleDESCryptoServiceProvider();
			algoritme.Key = nøgle;
			algoritme.Mode = CipherMode.ECB;//Vi vil kun kode en gang
			algoritme.Padding = PaddingMode.PKCS7;//padding for extra bytes i hver blok

			byte[] data = utf8.GetBytes(streng);

			try
			{
				ICryptoTransform enkryption = algoritme.CreateEncryptor();
				resultat = enkryption.TransformFinalBlock(data, 0, data.Length);
			}
			finally
			{
				algoritme.Clear();
			}
			return Convert.ToBase64String(resultat);
		}

		//Lavet af Thorbjørn
		public int FyldDatabase(string datasource, string catalogue, string userid, string password)
		{
			return dbFacade.FyldDatabase(datasource,catalogue,userid,password);
		}

		//Henter database-accessstrengen, og hiver de enkelte variable
		//datasource, catalogue, user id og password us af den
		//Lavet af Thorbjørn
		public string[] HentDatabaseVariable()
		{
			string input;
			int først; 
			int sidst = 0;
			string[] output = new string[4];
			string[] søgeord = { "Data Source= ", ";Initial Catalog=", ";User Id=", ";Password=" };

			//Nedenstående henter selve strengen og opbevarer den i "input"
			try
			{
				StreamReader hentdata = File.OpenText("data.dat");
				input = hentdata.ReadLine();
				hentdata.Dispose();
				hentdata.Close();
			}
			catch (Exception)
			{
				return null;
			}

			//filen er jo krypteret, så filen skal lige dekrypteres
			input = Dekrypt(input);

			//Hvorefter vi finder lokaliteten af hver variabel i strengen, og henter dem ud i "output"
			for (int i = 0; i < 3; i++)
			{
				først = søgeord[i].Length + input.IndexOf(søgeord[i]);
				sidst = input.LastIndexOf(søgeord[i + 1]);
				output[i] = input.Substring(først, sidst - først);
			}
			først = søgeord[3].Length + sidst;
			sidst = input.Length;
			output[3] = input.Substring(først, sidst - først);

			//endelig sendes output tilbage
			return output;
		}

		//Lavet af Thorbjørn
		public bool RetDatabaseFil(string datasource, string catalogue, string userid, string password)
		{
			string databasestreng = "Data Source= " + datasource + ";Initial Catalog=" + catalogue + ";User Id=" + userid + ";Password=" + password;
				
			try
			{
				databasestreng = Enkrypt(databasestreng);
				System.IO.StreamWriter fil = new System.IO.StreamWriter("data.dat");
				fil.WriteLine(databasestreng);
				fil.Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
	}
}
