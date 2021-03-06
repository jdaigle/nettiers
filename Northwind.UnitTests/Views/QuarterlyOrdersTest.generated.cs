﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file QuarterlyOrdersTest.cs instead.
*/
#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Northwind.Entities;
using Northwind.Data;

#endregion

namespace Northwind.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="QuarterlyOrders"/> objects (entity, collection and repository).
    /// </summary>
    public partial class QuarterlyOrdersTest
    {
    	// the QuarterlyOrders instance used to test the repository.
		private QuarterlyOrders mock;
		
		// the VList<QuarterlyOrders> instance used to test the repository.
		private VList<QuarterlyOrders> mockCollection;		

        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        static private void Init_Generated()
        {
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the QuarterlyOrders Entity with the {0} --", Northwind.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
        static private void CleanUp_Generated()
        {       	
			System.Console.WriteLine();
			System.Console.WriteLine();
        }
		
		/// <summary>
		/// Selects a page of QuarterlyOrders objects from the database.
		/// </summary>
		private void Step_1_SelectAll_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.QuarterlyOrdersProvider.GetPaged(null, 0, 10, out count);
			Assert.IsTrue(count >= 0, "Select Query Failed with GetPaged");
			System.Console.WriteLine("DataRepository.QuarterlyOrdersProvider.GetPaged():");			
			System.Console.WriteLine(mockCollection);			
		}
		
		/// <summary>
		/// Searches some QuarterlyOrders objects from the database.
		/// </summary>
		private void Step_2_Search_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.QuarterlyOrdersProvider.Find(null, null, "", 0, 10, out count);
			Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
			
			System.Console.WriteLine("DataRepository.QuarterlyOrdersProvider.Find():");			
			System.Console.WriteLine(mockCollection);
					
		}
		 //Find
			
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock QuarterlyOrders entity into a temporary file.
		/// </summary>
		private void Step_6_SerializeEntity_Generated()
		{
			string fileName = "temp_QuarterlyOrders.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(QuarterlyOrders)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mock); 
			myWriter.Close();
			System.Console.WriteLine("mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock QuarterlyOrders entity from a temporary file.
		/// </summary>
		private void Step_7_DeserializeEntity_Generated()
		{
			string fileName = "temp_QuarterlyOrders.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(QuarterlyOrders)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			mock = (QuarterlyOrders) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a QuarterlyOrders collection into a temporary file.
		/// </summary>
		private void Step_8_SerializeCollection_Generated()
		{
			string fileName = "temp_QuarterlyOrdersCollection.xml";
		
			VList<QuarterlyOrders> mockCollection = new VList<QuarterlyOrders>();
			mockCollection.Add(mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<QuarterlyOrders>)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("VList<QuarterlyOrders> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a QuarterlyOrders collection from a temporary file.
		/// </summary>
		private void Step_9_DeserializeCollection_Generated()
		{
			string fileName = "temp_QuarterlyOrdersCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<QuarterlyOrders>)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			VList<QuarterlyOrders> mockCollection = (VList<QuarterlyOrders>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("VList<QuarterlyOrders> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		#region Mock Instance
		///<summary>
		///  Returns a Typed QuarterlyOrders Entity with mock values.
		///</summary>
		static public QuarterlyOrders CreateMockInstance()
		{		
			QuarterlyOrders mock = new QuarterlyOrders();
						
			mock.CustomerId = TestUtility.Instance.RandomString(5, false);;
			mock.CompanyName = TestUtility.Instance.RandomString(19, false);;
			mock.City = TestUtility.Instance.RandomString(6, false);;
			mock.Country = TestUtility.Instance.RandomString(6, false);;
		   return (QuarterlyOrders)mock;
		}
		

		#endregion
    }
}
