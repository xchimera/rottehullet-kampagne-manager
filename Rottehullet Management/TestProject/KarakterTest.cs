using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Enum;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for KarakterTest and is intended
    ///to contain all KarakterTest Unit Tests
    ///</summary>
	[TestClass()]
	public class KarakterTest
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
		///A test for Karakter Constructor
		///</summary>
		[TestMethod()]
		public void KarakterConstructorTest()
		{
			//Oprettelse af kampagne
			string kampagneNavn = "TestKampagne";
			long kampagneID = 0;

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
			int position = 1;
			kampagne.TilføjSingleAttribut(navn1, type, kampagneSingleAttributID, position);


			//Oprettelse af multiattribut
			navn1 = "TestVariabel";
			type = KampagneAttributType.Combo;
			KampagneMultiAttributValgmulighed entry1 = new KampagneMultiAttributValgmulighed(0, "Entry1");
			KampagneMultiAttributValgmulighed entry2 = new KampagneMultiAttributValgmulighed(1, "Entry2");
			KampagneMultiAttributValgmulighed entry3 = new KampagneMultiAttributValgmulighed(2, "Entry3");
			List<KampagneMultiAttributValgmulighed> valgmuligheder = new List<KampagneMultiAttributValgmulighed> { entry1, entry2, entry3 };
			long kampagneMultiAttributID = 1;
			position = 0;
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

			long karakterID = 2; // TODO: Initialize to an appropriate value
			KarakterStatus status = KarakterStatus.Nyoprettet; // TODO: Initialize to an appropriate value
			Karakter target = new Karakter(karakterID, kampagne, status);
			string navn = "Thorleif";
			target.TilføjVærdi(kampagne.FindAttribut(kampagneSingleAttributID), navn, 1);
			target.TilføjVærdi(kampagne.FindAttribut(kampagneMultiAttributID), entry2, 0);

			Assert.AreEqual(karakterID, target.KarakterID);
			Assert.AreEqual(status, target.Status);
			Assert.AreEqual(navn, target["Navn"]);
			Assert.AreEqual(entry2.Værdi, target[navn1]);
		}
	}
}
