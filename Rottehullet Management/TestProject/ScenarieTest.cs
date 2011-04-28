using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ScenarieTest and is intended
    ///to contain all ScenarieTest Unit Tests
    ///</summary>
	[TestClass()]
	public class ScenarieTest
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
		///A test for Scenarie Constructor
		///</summary>
		[TestMethod()]
		public void ScenarieConstructorTest()
		{
			long id = 0;
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
			Scenarie target = new Scenarie(id, titel, beskrivelse, tid, sted, pris, overnatning, spisning, spisningTvungen, overnatningTvungen, andetInfo);
			Assert.AreEqual(id, target.Id);
			Assert.AreEqual(titel, target.Titel);
			Assert.AreEqual(beskrivelse, target.Beskrivelse);
			Assert.AreEqual(tid, target.Tid);
			Assert.AreEqual(sted, target.Sted);
			Assert.AreEqual(overnatning, target.Overnatning);
			Assert.AreEqual(spisning, target.Spisning);
			Assert.AreEqual(spisningTvungen, target.SpisningTvungen);
			Assert.AreEqual(overnatningTvungen, target.OvernatningTvungen);
			Assert.AreEqual(andetInfo, target.AndetInfo);

			titel = "ny titel";
			beskrivelse = "ny beskrivelse";
			tid = new DateTime(2011, 6, 5);
			sted = "et nyt sted";
			pris = 11.11;
			overnatning = 1;
			spisning = false;
			spisningTvungen = false;
			overnatningTvungen = false;
			andetInfo = "alt info";
			target.AndetInfo = andetInfo;
			target.Beskrivelse = beskrivelse;
			target.Overnatning = overnatning;
			target.OvernatningTvungen = overnatningTvungen;
			target.Pris = pris;
			target.Spisning = spisning;
			target.SpisningTvungen = spisningTvungen;
			target.Sted = sted;
			target.Tid = tid;
			target.Titel = titel;
			Assert.AreEqual(titel, target.Titel);
			Assert.AreEqual(beskrivelse, target.Beskrivelse);
			Assert.AreEqual(tid, target.Tid);
			Assert.AreEqual(sted, target.Sted);
			Assert.AreEqual(overnatning, target.Overnatning);
			Assert.AreEqual(spisning, target.Spisning);
			Assert.AreEqual(spisningTvungen, target.SpisningTvungen);
			Assert.AreEqual(overnatningTvungen, target.OvernatningTvungen);
			Assert.AreEqual(andetInfo, target.AndetInfo);
		}
	}
}
