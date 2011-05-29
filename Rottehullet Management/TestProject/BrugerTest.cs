using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Enum;
using Interfaces;

namespace TestProject
{


	/// <summary>
	///This is a test class for BrugerTest and is intended
	///to contain all BrugerTest Unit Tests
	///</summary>
	[TestClass()]
	public class BrugerTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for Bruger Constructor
		///</summary>
		[TestMethod()]
		public void BrugerConstructorTest()
		{
			long brugerID = 1; // TODO: Initialize to an appropriate value
			string email = "navn@mail.dk"; // TODO: Initialize to an appropriate value
			string navn = "Frans Pedersen"; // TODO: Initialize to an appropriate value
			DateTime fødselsdag = new DateTime(1967, 11, 20); // TODO: Initialize to an appropriate value
			long tlf = 20202020; // TODO: Initialize to an appropriate value
			long nød_tlf = 30303030; // TODO: Initialize to an appropriate value
			bool vegetar = false; // TODO: Initialize to an appropriate value
			bool veganer = true; // TODO: Initialize to an appropriate value
			string andet = "aragnofobi"; // TODO: Initialize to an appropriate value
			string allergi = "latex"; // TODO: Initialize to an appropriate value
			Bruger target = new Bruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, andet, allergi);
			Assert.AreEqual(brugerID, target.BrugerID);
			Assert.AreEqual(email, target.Email);
			Assert.AreEqual(navn, target.Navn);
			Assert.AreEqual(fødselsdag, target.Fødselsdag);
			Assert.AreEqual(tlf, target.Tlf);
			Assert.AreEqual(nød_tlf, target.NødTlf);
			Assert.AreEqual(vegetar, target.Vegetar);
			Assert.AreEqual(veganer, target.Veganer);
			Assert.AreEqual(andet, target.Andet);
			Assert.AreEqual(allergi, target.Allergi);

			//Oprettelse af kampagne
			string kampagneNavn = "TestKampagne";
			long kampagneID = 1;

			KampagneStatus kampagneStatus = KampagneStatus.Åben;
			Kampagne kampagne = new Kampagne(kampagneNavn, kampagneID, kampagneStatus);

			//Test af opsætning af kampagne
			string actualnavn = kampagne.Navn;
			Assert.AreEqual(kampagneNavn, actualnavn);
			long actualID = kampagne.KampagneID;
			Assert.AreEqual(kampagneID, actualID);

			// Oprettelse af single attribut
			string navn1 = "Navn";
			KampagneAttributType type = KampagneAttributType.Singleline;
			long kampagneSingleAttributID = 0;
			int position = 0;
			kampagne.TilføjSingleAttribut(navn1, type, kampagneSingleAttributID, position);


			//Oprettelse af multiattribut
			navn1 = "TestVariabel";
			type = KampagneAttributType.Combo;
			KampagneMultiAttributValgmulighed entry1 = new KampagneMultiAttributValgmulighed(0, "Entry1");
			KampagneMultiAttributValgmulighed entry2 = new KampagneMultiAttributValgmulighed(1, "Entry2");
			KampagneMultiAttributValgmulighed entry3 = new KampagneMultiAttributValgmulighed(2, "Entry3");
			List<KampagneMultiAttributValgmulighed> valgmuligheder = new List<KampagneMultiAttributValgmulighed> { entry1, entry2, entry3 };
			long kampagneMultiAttributID = 1;
			position = 1;
			kampagne.TilføjMultiAttribut(navn1, type, valgmuligheder, kampagneMultiAttributID, position);

			//Test af opsætning af skabelse af multiattribut
			int id = 1;
			KampagneMultiAttribut actualAttribut;
			actualAttribut = (KampagneMultiAttribut)(kampagne.FindAttribut(id));
			actualnavn = actualAttribut.Navn;
			Assert.AreEqual(navn1, actualnavn);
			KampagneAttributType actualtype = actualAttribut.Type;
			Assert.AreEqual(type, actualtype);
			KampagneMultiAttributValgmulighed actualentry = actualAttribut.Valgmuligheder[0];
			Assert.AreEqual(entry1, actualentry);
			actualentry = actualAttribut.Valgmuligheder[1];
			Assert.AreEqual(entry2, actualentry);
			actualentry = actualAttribut.Valgmuligheder[2];
			Assert.AreEqual(entry3, actualentry);

			
			long scenarieID = 0;
			string titel = "Scenarie";
			string beskrivelse = "Dette er et scenarie";
			DateTime tid = DateTime.Now;
			string sted = "et sted";
			double pris = 15.24;
			int overnatning = 2;
			bool spisning = true;
			bool spisningTvungen = true;
			bool overnatningTvungen = true;
			string andetInfo = "mere info";
			Scenarie scenarie = kampagne.TilføjScenarie(scenarieID, titel, beskrivelse, tid, sted, pris, overnatning, spisning, spisningTvungen, overnatningTvungen, andetInfo);

			long karakterID = 1; // TODO: Initialize to an appropriate value
			target.TilføjKarakter(karakterID, kampagne);

			long karakterID2 = 2;
			target.TilføjKarakter(karakterID2, kampagne);

			Karakter karakter = target.FindKarakter(1);
			Assert.AreEqual(karakterID, karakter.KarakterID);
			string karakterNavn = "Thorleif";
			karakter.TilføjVærdi(kampagne.FindAttribut(kampagneSingleAttributID), karakterNavn, 1);
			Assert.AreEqual(karakterNavn, karakter["Navn"]);
			karakter.TilføjVærdi(kampagne.FindAttribut(kampagneMultiAttributID), entry2, 0);
			Assert.AreEqual(entry2.Værdi, karakter[navn1]);
			Assert.AreEqual(kampagne.Navn, karakter.Kampagne.Navn);


			karakter = target.FindKarakter(2);
			Assert.AreEqual(karakterID2, karakter.KarakterID);
			karakterNavn = "Bogeyman";
			karakter.TilføjVærdi(kampagne.FindAttribut(kampagneSingleAttributID), karakterNavn, 1);
			Assert.AreEqual(karakterNavn, karakter["Navn"]);
			karakter.TilføjVærdi(kampagne.FindAttribut(kampagneMultiAttributID), entry3, 0);
			Assert.AreEqual(entry3.Værdi, karakter[navn1]);

			target.TilmeldKarakterTilScenarie(karakterID2, scenarie, true, 2);
			Assert.AreEqual(true, target.TjekOmTilmeldtTilScenarie(scenarie));

			Assert.AreEqual(1, scenarie.AntalDeltagere);
			List<IKarakter> karakterListe = scenarie.HentDeltagere();
			Assert.AreEqual(karakterID2, karakterListe[0].KarakterID);

			karakter = target.FindKarakter(karakterID2);
			Assert.AreEqual(true, karakter.ErTilmeldtTilScenarie(scenarie));
		}
	}
}
