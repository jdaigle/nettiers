﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file ProductsTest.cs instead.
*/

#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Northwind.Entities;
using Northwind.Data;
using Northwind.Data.Bases;

#endregion

namespace Northwind.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="Products"/> objects (entity, collection and repository).
    /// </summary>
   public partial class ProductsTest
    {
    	// the Products instance used to test the repository.
		protected Products mock;
		
		// the TList<Products> instance used to test the repository.
		protected TList<Products> mockCollection;
		
		protected static TransactionManager CreateTransaction()
		{
			TransactionManager transactionManager = null;
			if (DataRepository.Provider.IsTransactionSupported)
			{
				transactionManager = DataRepository.Provider.CreateTransaction();
				transactionManager.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
			}			
			return transactionManager;
		}
		       
        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>        
        static public void Init_Generated()
        {		
        	System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the Products Entity with the {0} --", Northwind.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
		static public void CleanUp_Generated()
        {   		
			System.Console.WriteLine("All Tests Completed");
			System.Console.WriteLine();
        }
    
    
		/// <summary>
		/// Inserts a mock Products entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ProductsProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.ProductsProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all Products objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.ProductsProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.ProductsProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.ProductsProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all Products children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.ProductsProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.ProductsProvider.DeepLoading += new EntityProviderBaseCore<Products, ProductsKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.ProductsProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("Products instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.ProductsProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock Products entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Products mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.ProductsProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.ProductsProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.ProductsProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock Products entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (Products)CreateMockInstance(tm);
				DataRepository.ProductsProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.ProductsProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.ProductsProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Products entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Products.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock Products entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Products.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<Products>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Products collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProductsCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<Products> mockCollection = new TList<Products>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<Products> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a Products collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_ProductsCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Products>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<Products> mockCollection = (TList<Products>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<Products> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Products entity = CreateMockInstance(tm);
				bool result = DataRepository.ProductsProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Products entity = CreateMockInstance(tm);
				bool result = DataRepository.ProductsProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				TList<Products> t0 = DataRepository.ProductsProvider.GetByCategoryId(tm, entity.CategoryId);
				Products t2 = DataRepository.ProductsProvider.GetByProductId(tm, entity.ProductId);
				TList<Products> t3 = DataRepository.ProductsProvider.GetByProductName(tm, entity.ProductName);
				TList<Products> t4 = DataRepository.ProductsProvider.GetBySupplierId(tm, entity.SupplierId);
			}
		}
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		private void Step_20_TestEntityHelper_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				
				Products entity = mock.Copy() as Products;
				entity = (Products)mock.Clone();
				Assert.IsTrue(Products.ValueEquals(entity, mock), "Clone is not working");
			}
		}
		
		/// <summary>
		/// Test Find using the Query class
		/// </summary>
		private void Step_30_TestFindByQuery_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Insert Mock Instance
				Products mock = CreateMockInstance(tm);
				bool result = DataRepository.ProductsProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				ProductsQuery query = new ProductsQuery();
			
				query.AppendEquals(ProductsColumn.ProductId, mock.ProductId.ToString());
				query.AppendEquals(ProductsColumn.ProductName, mock.ProductName.ToString());
				if(mock.SupplierId != null)
					query.AppendEquals(ProductsColumn.SupplierId, mock.SupplierId.ToString());
				if(mock.CategoryId != null)
					query.AppendEquals(ProductsColumn.CategoryId, mock.CategoryId.ToString());
				if(mock.QuantityPerUnit != null)
					query.AppendEquals(ProductsColumn.QuantityPerUnit, mock.QuantityPerUnit.ToString());
				if(mock.UnitPrice != null)
					query.AppendEquals(ProductsColumn.UnitPrice, mock.UnitPrice.ToString());
				if(mock.UnitsInStock != null)
					query.AppendEquals(ProductsColumn.UnitsInStock, mock.UnitsInStock.ToString());
				if(mock.UnitsOnOrder != null)
					query.AppendEquals(ProductsColumn.UnitsOnOrder, mock.UnitsOnOrder.ToString());
				if(mock.ReorderLevel != null)
					query.AppendEquals(ProductsColumn.ReorderLevel, mock.ReorderLevel.ToString());
				query.AppendEquals(ProductsColumn.Discontinued, mock.Discontinued.ToString());
				
				TList<Products> results = DataRepository.ProductsProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Products Entity with mock values.
		///</summary>
		static public Products CreateMockInstance_Generated(TransactionManager tm)
		{		
			Products mock = new Products();
						
			mock.ProductName = TestUtility.Instance.RandomString(19, false);;
			mock.QuantityPerUnit = TestUtility.Instance.RandomString(9, false);;
			mock.UnitPrice = TestUtility.Instance.RandomShort();
			mock.UnitsInStock = TestUtility.Instance.RandomShort();
			mock.UnitsOnOrder = TestUtility.Instance.RandomShort();
			mock.ReorderLevel = TestUtility.Instance.RandomShort();
			mock.Discontinued = TestUtility.Instance.RandomBoolean();
			
			int count0 = 0;
			TList<Categories> _collection0 = DataRepository.CategoriesProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.CategoryId = _collection0[0].CategoryId;
						
			}
			int count1 = 0;
			TList<Suppliers> _collection1 = DataRepository.SuppliersProvider.GetPaged(tm, 0, 10, out count1);
			//_collection1.Shuffle();
			if (_collection1.Count > 0)
			{
				mock.SupplierId = _collection1[0].SupplierId;
						
			}
		
			// create a temporary collection and add the item to it
			TList<Products> tempMockCollection = new TList<Products>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Products)mock;
		}
		
		
		///<summary>
		///  Update the Typed Products Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, Products mock)
		{
			mock.ProductName = TestUtility.Instance.RandomString(19, false);;
			mock.QuantityPerUnit = TestUtility.Instance.RandomString(9, false);;
			mock.UnitPrice = TestUtility.Instance.RandomShort();
			mock.UnitsInStock = TestUtility.Instance.RandomShort();
			mock.UnitsOnOrder = TestUtility.Instance.RandomShort();
			mock.ReorderLevel = TestUtility.Instance.RandomShort();
			mock.Discontinued = TestUtility.Instance.RandomBoolean();
			
			int count0 = 0;
			TList<Categories> _collection0 = DataRepository.CategoriesProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.CategoryId = _collection0[0].CategoryId;
			}
			int count1 = 0;
			TList<Suppliers> _collection1 = DataRepository.SuppliersProvider.GetPaged(tm, 0, 10, out count1);
			//_collection1.Shuffle();
			if (_collection1.Count > 0)
			{
				mock.SupplierId = _collection1[0].SupplierId;
			}
		}
		#endregion
    }
}
