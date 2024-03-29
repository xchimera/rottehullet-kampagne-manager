﻿using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using Enum;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for KampagneTest and is intended
    ///to contain all KampagneTest Unit Tests
    ///</summary>
	[TestClass()]
	public class KampagneTest
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
		///A test for RetMultiAttribut
		///</summary>
		[TestMethod()]
		public void MultiAttributTest()
		{
			//Oprettelse af kampagne
			string navn = "TestKampagne";
			long kampagneID = 0;

			KampagneStatus status = KampagneStatus.Åben;
			Kampagne target = new Kampagne(navn, kampagneID, status);

			
			//Test af opsætning af kampagne
			string actualnavn = target.Navn;
			Assert.AreEqual(navn, actualnavn);
			long actualID = target.KampagneID;
			Assert.AreEqual(kampagneID, actualID);

			// Oprettelse af single attribut
			string singleNavn = "Navn";
			KampagneAttributType singleType = KampagneAttributType.Singleline;
			long kampagneSingleAttributID = 1;
			int singlePosition = 0;
			target.TilføjSingleAttribut(singleNavn, singleType, kampagneSingleAttributID, singlePosition);
			
			//Oprettelse af multiattribut
			string MultiNavn = "TestVariabel";
			KampagneAttributType type = KampagneAttributType.Combo;
			KampagneMultiAttributValgmulighed entry1 = new KampagneMultiAttributValgmulighed(0, "Entry1");
			KampagneMultiAttributValgmulighed entry2 = new KampagneMultiAttributValgmulighed(1, "Entry2");
			KampagneMultiAttributValgmulighed entry3 = new KampagneMultiAttributValgmulighed(2, "Entry3");
			List<KampagneMultiAttributValgmulighed> valgmuligheder = new List<KampagneMultiAttributValgmulighed> { entry1, entry2, entry3 };
			long kampagneAttributID = 0;
			int position = 1;
			target.TilføjMultiAttribut(MultiNavn, type, valgmuligheder, kampagneAttributID, position);

			//Test af opsætning af skabelse af multiattribut
			int id = 0;
			KampagneMultiAttribut actualAttribut;
			actualAttribut = (KampagneMultiAttribut)(target.FindAttribut(id));
			actualnavn = actualAttribut.Navn;
			Assert.AreEqual(MultiNavn, actualnavn);
			KampagneAttributType actualtype = actualAttribut.Type;
			Assert.AreEqual(type, actualtype);
			KampagneMultiAttributValgmulighed actualentry = actualAttribut.Valgmuligheder[0];
			Assert.AreEqual(entry1, actualentry);
			actualentry = actualAttribut.Valgmuligheder[1];
			Assert.AreEqual(entry2, actualentry);
			actualentry = actualAttribut.Valgmuligheder[2];
			Assert.AreEqual(entry3, actualentry);

			//Test af singleattribut
			KampagneAttribut attribut = (KampagneAttribut)target.FindAttribut(kampagneSingleAttributID);
			Assert.AreEqual(singleNavn, attribut.Navn);
			Assert.AreEqual(kampagneSingleAttributID, attribut.KampagneAttributID);
			Assert.AreEqual(singleType, attribut.Type);

			//Ændring af entry
			id = 0;
			type = KampagneAttributType.Combo;
			entry2.Værdi = "ChangedEntry2";
			valgmuligheder = new List<KampagneMultiAttributValgmulighed> { entry1, entry2, entry3 };
			position = 0;
			target.RetMultiAttribut(id, type, valgmuligheder, position);

			//Test af ændret entry
			id = 0;
			actualAttribut = (KampagneMultiAttribut)(target.FindAttribut(id));
			actualentry = actualAttribut.Valgmuligheder[0];
			Assert.AreEqual(entry1, actualentry);
			actualentry = actualAttribut.Valgmuligheder[1];
			Assert.AreEqual(entry2, actualentry);
			actualentry = actualAttribut.Valgmuligheder[2];
			Assert.AreEqual(entry3, actualentry);
		}

	}
}
