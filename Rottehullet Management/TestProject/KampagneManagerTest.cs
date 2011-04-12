using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Interfaces;
using System.Collections;
using Enum;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for KampagneManagerTest and is intended
    ///to contain all KampagneManagerTest Unit Tests
    ///</summary>
	[TestClass()]
	public class KampagneManagerTest
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
		///A test for GenopretKampagne
		///</summary>
		[TestMethod()]
		public void GenopretKampagneTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			long kamID = 0; // TODO: Initialize to an appropriate value
			string navn = string.Empty; // TODO: Initialize to an appropriate value
			string beskrivelse = string.Empty; // TODO: Initialize to an appropriate value
			string hjemmeside = string.Empty; // TODO: Initialize to an appropriate value
			long topbrugerID = 0; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.GenopretKampagne(kamID, navn, beskrivelse, hjemmeside, topbrugerID);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for HentKampagneFraDatabase
		///</summary>
		[TestMethod()]
		public void HentKampagneFraDatabaseTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			long kamID = 0; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.HentKampagneFraDatabase(kamID);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for OpretKampagne
		///</summary>
		[TestMethod()]
		public void OpretKampagneTest()
		{
			KampagneManager target = new KampagneManager();
			string navn = "Test Kampagne";
			long topbrugerID = 3; //sope08@gmail.com
			bool expected = true;
			bool actual;
			actual = target.OpretKampagne(navn, topbrugerID);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Login, finder IDet for sope08@gmail.com
		///</summary>
		[TestMethod()]
		public void LoginTest()
		{
			KampagneManager target = new KampagneManager();
			string email = "sope08@gmail.com";
			string kodeord = "root";
			long expected = 3;
			long actual;
			actual = target.Login(email, kodeord);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for RetAttribut
		///</summary>
		[TestMethod()]
		public void RetAttributTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			string navn = string.Empty; // TODO: Initialize to an appropriate value
			KampagneType type = new KampagneType(); // TODO: Initialize to an appropriate value
			int position = 0; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.RetAttribut(navn, type, position);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for RetKampagneBeskrivelse
		///</summary>
		[TestMethod()]
		public void RetKampagneBeskrivelseTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			string beskrivelse = string.Empty; // TODO: Initialize to an appropriate value
			long kampagneID = 0; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.RetKampagneBeskrivelse(beskrivelse, kampagneID);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for RetKampagneHjemmeside
		///</summary>
		[TestMethod()]
		public void RetKampagneHjemmesideTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			string hjemmeside = string.Empty; // TODO: Initialize to an appropriate value
			long kampagneID = 0; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.RetKampagneHjemmeside(hjemmeside, kampagneID);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for RetKampagneMultiAttributEntry
		///</summary>
		[TestMethod()]
		public void RetKampagneMultiAttributEntryTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			long id = 0; // TODO: Initialize to an appropriate value
			long attributID = 0; // TODO: Initialize to an appropriate value
			string værdi = string.Empty; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.RetKampagneMultiAttributEntry(id, attributID, værdi);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for RetKampagneNavn
		///</summary>
		[TestMethod()]
		public void RetKampagneNavnTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			string navn = string.Empty; // TODO: Initialize to an appropriate value
			long kampagneID = 0; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.RetKampagneNavn(navn, kampagneID);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for RetKampagneliste
		///</summary>
		[TestMethod()]
		public void RetKampagnelisteTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			long kampagneID = 0; // TODO: Initialize to an appropriate value
			string navn = string.Empty; // TODO: Initialize to an appropriate value
			target.RetKampagneliste(kampagneID, navn);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for TilføjBruger
		///</summary>
		[TestMethod()]
		public void TilføjBrugerTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			long brugerID = 0; // TODO: Initialize to an appropriate value
			string email = string.Empty; // TODO: Initialize to an appropriate value
			string navn = string.Empty; // TODO: Initialize to an appropriate value
			DateTime fødselsdag = new DateTime(); // TODO: Initialize to an appropriate value
			long tlf = 0; // TODO: Initialize to an appropriate value
			long nød_tlf = 0; // TODO: Initialize to an appropriate value
			bool vegetar = false; // TODO: Initialize to an appropriate value
			bool veganer = false; // TODO: Initialize to an appropriate value
			target.TilføjBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for TilføjMultiAttribut
		///</summary>
		[TestMethod()]
		public void TilføjMultiAttributTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			string navn = string.Empty; // TODO: Initialize to an appropriate value
			KampagneType type = new KampagneType(); // TODO: Initialize to an appropriate value
			int position = 0; // TODO: Initialize to an appropriate value
			List<string> valgmuligheder = null; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.TilføjMultiAttribut(navn, type, position, valgmuligheder);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for TilføjSingleAttribut
		///</summary>
		[TestMethod()]
		public void TilføjSingleAttributTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			string navn = string.Empty; // TODO: Initialize to an appropriate value
			KampagneType type = new KampagneType(); // TODO: Initialize to an appropriate value
			int position = 0; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.TilføjSingleAttribut(navn, type, position);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for TilknytSuperbruger
		///</summary>
		[TestMethod()]
		public void TilknytSuperbrugerTest()
		{
			KampagneManager target = new KampagneManager(); // TODO: Initialize to an appropriate value
			long brugerID = 0; // TODO: Initialize to an appropriate value
			long kampagneID = 0; // TODO: Initialize to an appropriate value
			bool expected = false; // TODO: Initialize to an appropriate value
			bool actual;
			actual = target.TilknytSuperbruger(brugerID, kampagneID);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
