﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file ProductsAboveAveragePriceTest.cs instead.
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
    /// Provides tests for the and <see cref="ProductsAboveAveragePrice"/> objects (entity, collection and repository).
    /// </summary>
    public partial class ProductsAboveAveragePriceTest
    {
    	// the ProductsAboveAveragePrice instance used to test the repository.
		private ProductsAboveAveragePrice mock;
		
		// the VList<ProductsAboveAveragePrice> instance used to test the repository.
		private VList<ProductsAboveAveragePrice> mockCollection;		

        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        static private void Init_Generated()
        {
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the ProductsAboveAveragePrice Entity with the {0} --", Northwind.Data.DataRepository.Provider.Name);
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
		/// Selects a page of ProductsAboveAveragePrice objects from the database.
		/// </summary>
		private void Step_1_SelectAll_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.ProductsAboveAveragePriceProvider.GetPaged(null, 0, 10, out count);
			Assert.IsTrue(count >= 0, "Select Query Failed with GetPaged");
			System.Console.WriteLine("DataRepository.ProductsAboveAveragePriceProvider.GetPaged():");			
			System.Console.WriteLine(mockCollection);			
		}
		
		/// <summary>
		/// Searches some ProductsAboveAveragePrice objects from the database.
		/// </summary>
		private void Step_2_Search_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.ProductsAboveAveragePriceProvider.Find(null, null, "", 0, 10, out count);
			Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
			
			System.Console.WriteLine("DataRepository.ProductsAboveAveragePriceProvider.Find():");			
			System.Console.WriteLine(mockCollection);
					
		}
		 //Find
			
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock ProductsAboveAveragePrice entity into a temporary file.
		/// </summary>
		private void Step_6_SerializeEntity_Generated()
		{
			string fileName = "temp_ProductsAboveAveragePrice.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(ProductsAboveAveragePrice)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mock); 
			myWriter.Close();
			System.Console.WriteLine("mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock ProductsAboveAveragePrice entity from a temporary file.
		/// </summary>
		private void Step_7_DeserializeEntity_Generated()
		{
			string fileName = "temp_ProductsAboveAveragePrice.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(ProductsAboveAveragePrice)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			mock = (ProductsAboveAveragePrice) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a ProductsAboveAveragePrice collection into a temporary file.
		/// </summary>
		private void Step_8_SerializeCollection_Generated()
		{
			string fileName = "temp_ProductsAboveAveragePriceCollection.xml";
		
			VList<ProductsAboveAveragePrice> mockCollection = new VList<ProductsAboveAveragePrice>();
			mockCollection.Add(mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<ProductsAboveAveragePrice>)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("VList<ProductsAboveAveragePrice> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a ProductsAboveAveragePrice collection from a temporary file.
		/// </summary>
		private void Step_9_DeserializeCollection_Generated()
		{
			string fileName = "temp_ProductsAboveAveragePriceCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<ProductsAboveAveragePrice>)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			VList<ProductsAboveAveragePrice> mockCollection = (VList<ProductsAboveAveragePrice>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("VList<ProductsAboveAveragePrice> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		#region Mock Instance
		///<summary>
		///  Returns a Typed ProductsAboveAveragePrice Entity with mock values.
		///</summary>
		static public ProductsAboveAveragePrice CreateMockInstance()
		{		
			ProductsAboveAveragePrice mock = new ProductsAboveAveragePrice();
						
			mock.ProductName = TestUtility.Instance.RandomString(19, false);;
			mock.UnitPrice = TestUtility.Instance.RandomShort();
		   return (ProductsAboveAveragePrice)mock;
		}
		

		#endregion
    }
}
