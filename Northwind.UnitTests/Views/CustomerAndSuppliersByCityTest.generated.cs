﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file CustomerAndSuppliersByCityTest.cs instead.
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
    /// Provides tests for the and <see cref="CustomerAndSuppliersByCity"/> objects (entity, collection and repository).
    /// </summary>
    public partial class CustomerAndSuppliersByCityTest
    {
    	// the CustomerAndSuppliersByCity instance used to test the repository.
		private CustomerAndSuppliersByCity mock;
		
		// the VList<CustomerAndSuppliersByCity> instance used to test the repository.
		private VList<CustomerAndSuppliersByCity> mockCollection;		

        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        static private void Init_Generated()
        {
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the CustomerAndSuppliersByCity Entity with the {0} --", Northwind.Data.DataRepository.Provider.Name);
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
		/// Selects a page of CustomerAndSuppliersByCity objects from the database.
		/// </summary>
		private void Step_1_SelectAll_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.CustomerAndSuppliersByCityProvider.GetPaged(null, 0, 10, out count);
			Assert.IsTrue(count >= 0, "Select Query Failed with GetPaged");
			System.Console.WriteLine("DataRepository.CustomerAndSuppliersByCityProvider.GetPaged():");			
			System.Console.WriteLine(mockCollection);			
		}
		
		/// <summary>
		/// Searches some CustomerAndSuppliersByCity objects from the database.
		/// </summary>
		private void Step_2_Search_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.CustomerAndSuppliersByCityProvider.Find(null, null, "", 0, 10, out count);
			Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
			
			System.Console.WriteLine("DataRepository.CustomerAndSuppliersByCityProvider.Find():");			
			System.Console.WriteLine(mockCollection);
					
		}
		 //Find
			
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock CustomerAndSuppliersByCity entity into a temporary file.
		/// </summary>
		private void Step_6_SerializeEntity_Generated()
		{
			string fileName = "temp_CustomerAndSuppliersByCity.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(CustomerAndSuppliersByCity)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mock); 
			myWriter.Close();
			System.Console.WriteLine("mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock CustomerAndSuppliersByCity entity from a temporary file.
		/// </summary>
		private void Step_7_DeserializeEntity_Generated()
		{
			string fileName = "temp_CustomerAndSuppliersByCity.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(CustomerAndSuppliersByCity)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			mock = (CustomerAndSuppliersByCity) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a CustomerAndSuppliersByCity collection into a temporary file.
		/// </summary>
		private void Step_8_SerializeCollection_Generated()
		{
			string fileName = "temp_CustomerAndSuppliersByCityCollection.xml";
		
			VList<CustomerAndSuppliersByCity> mockCollection = new VList<CustomerAndSuppliersByCity>();
			mockCollection.Add(mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<CustomerAndSuppliersByCity>)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("VList<CustomerAndSuppliersByCity> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a CustomerAndSuppliersByCity collection from a temporary file.
		/// </summary>
		private void Step_9_DeserializeCollection_Generated()
		{
			string fileName = "temp_CustomerAndSuppliersByCityCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<CustomerAndSuppliersByCity>)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			VList<CustomerAndSuppliersByCity> mockCollection = (VList<CustomerAndSuppliersByCity>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("VList<CustomerAndSuppliersByCity> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		#region Mock Instance
		///<summary>
		///  Returns a Typed CustomerAndSuppliersByCity Entity with mock values.
		///</summary>
		static public CustomerAndSuppliersByCity CreateMockInstance()
		{		
			CustomerAndSuppliersByCity mock = new CustomerAndSuppliersByCity();
						
			mock.City = TestUtility.Instance.RandomString(6, false);;
			mock.CompanyName = TestUtility.Instance.RandomString(19, false);;
			mock.ContactName = TestUtility.Instance.RandomString(14, false);;
			mock.Relationship = TestUtility.Instance.RandomString(9, false);;
		   return (CustomerAndSuppliersByCity)mock;
		}
		

		#endregion
    }
}
