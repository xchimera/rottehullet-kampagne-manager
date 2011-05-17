using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Database
{
	class DatabaseController
	{
		//Lavet af Thorbjørn
		public bool RetDatabaseFil(string databasestreng)
		{
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
	}
}
