﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file EmployeesTest.cs instead.
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
    /// Provides tests for the and <see cref="Employees"/> objects (entity, collection and repository).
    /// </summary>
   public partial class EmployeesTest
    {
    	// the Employees instance used to test the repository.
		protected Employees mock;
		
		// the TList<Employees> instance used to test the repository.
		protected TList<Employees> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the Employees Entity with the {0} --", Northwind.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock Employees entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.EmployeesProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.EmployeesProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all Employees objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.EmployeesProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.EmployeesProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.EmployeesProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all Employees children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.EmployeesProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.EmployeesProvider.DeepLoading += new EntityProviderBaseCore<Employees, EmployeesKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.EmployeesProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("Employees instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.EmployeesProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock Employees entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Employees mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.EmployeesProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.EmployeesProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.EmployeesProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock Employees entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (Employees)CreateMockInstance(tm);
				DataRepository.EmployeesProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.EmployeesProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.EmployeesProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Employees entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Employees.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock Employees entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Employees.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<Employees>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Employees collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_EmployeesCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<Employees> mockCollection = new TList<Employees>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<Employees> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a Employees collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_EmployeesCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Employees>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<Employees> mockCollection = (TList<Employees>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<Employees> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Employees entity = CreateMockInstance(tm);
				bool result = DataRepository.EmployeesProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
				TList<Employees> t0 = DataRepository.EmployeesProvider.GetByReportsTo(tm, entity.ReportsTo, 0, 10);
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Employees entity = CreateMockInstance(tm);
				bool result = DataRepository.EmployeesProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				TList<Employees> t0 = DataRepository.EmployeesProvider.GetByLastName(tm, entity.LastName);
				Employees t1 = DataRepository.EmployeesProvider.GetByEmployeeId(tm, entity.EmployeeId);
				TList<Employees> t2 = DataRepository.EmployeesProvider.GetByPostalCode(tm, entity.PostalCode);
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
				
				Employees entity = mock.Copy() as Employees;
				entity = (Employees)mock.Clone();
				Assert.IsTrue(Employees.ValueEquals(entity, mock), "Clone is not working");
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
				Employees mock = CreateMockInstance(tm);
				bool result = DataRepository.EmployeesProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				EmployeesQuery query = new EmployeesQuery();
			
				query.AppendEquals(EmployeesColumn.EmployeeId, mock.EmployeeId.ToString());
				query.AppendEquals(EmployeesColumn.LastName, mock.LastName.ToString());
				query.AppendEquals(EmployeesColumn.FirstName, mock.FirstName.ToString());
				if(mock.Title != null)
					query.AppendEquals(EmployeesColumn.Title, mock.Title.ToString());
				if(mock.TitleOfCourtesy != null)
					query.AppendEquals(EmployeesColumn.TitleOfCourtesy, mock.TitleOfCourtesy.ToString());
				if(mock.BirthDate != null)
					query.AppendEquals(EmployeesColumn.BirthDate, mock.BirthDate.ToString());
				if(mock.HireDate != null)
					query.AppendEquals(EmployeesColumn.HireDate, mock.HireDate.ToString());
				if(mock.Address != null)
					query.AppendEquals(EmployeesColumn.Address, mock.Address.ToString());
				if(mock.City != null)
					query.AppendEquals(EmployeesColumn.City, mock.City.ToString());
				if(mock.Region != null)
					query.AppendEquals(EmployeesColumn.Region, mock.Region.ToString());
				if(mock.PostalCode != null)
					query.AppendEquals(EmployeesColumn.PostalCode, mock.PostalCode.ToString());
				if(mock.Country != null)
					query.AppendEquals(EmployeesColumn.Country, mock.Country.ToString());
				if(mock.HomePhone != null)
					query.AppendEquals(EmployeesColumn.HomePhone, mock.HomePhone.ToString());
				if(mock.Extension != null)
					query.AppendEquals(EmployeesColumn.Extension, mock.Extension.ToString());
				if(mock.ReportsTo != null)
					query.AppendEquals(EmployeesColumn.ReportsTo, mock.ReportsTo.ToString());
				if(mock.PhotoPath != null)
					query.AppendEquals(EmployeesColumn.PhotoPath, mock.PhotoPath.ToString());
				
				TList<Employees> results = DataRepository.EmployeesProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Employees Entity with mock values.
		///</summary>
		static public Employees CreateMockInstance_Generated(TransactionManager tm)
		{		
			Employees mock = new Employees();
						
			mock.LastName = TestUtility.Instance.RandomString(9, false);;
			mock.FirstName = TestUtility.Instance.RandomString(10, false);;
			mock.Title = TestUtility.Instance.RandomString(14, false);;
			mock.TitleOfCourtesy = TestUtility.Instance.RandomString(11, false);;
			mock.BirthDate = TestUtility.Instance.RandomDateTime();
			mock.HireDate = TestUtility.Instance.RandomDateTime();
			mock.Address = TestUtility.Instance.RandomString(29, false);;
			mock.City = TestUtility.Instance.RandomString(6, false);;
			mock.Region = TestUtility.Instance.RandomString(6, false);;
			mock.PostalCode = TestUtility.Instance.RandomString(10, false);;
			mock.Country = TestUtility.Instance.RandomString(6, false);;
			mock.HomePhone = TestUtility.Instance.RandomString(11, false);;
			mock.Extension = TestUtility.Instance.RandomString(4, false);;
			mock.Photo = new byte[] { TestUtility.Instance.RandomByte() };
			mock.Notes = TestUtility.Instance.RandomString(2, false);;
			mock.PhotoPath = TestUtility.Instance.RandomString(126, false);;
			
			int count0 = 0;
			TList<Employees> _collection0 = DataRepository.EmployeesProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.ReportsTo = _collection0[0].EmployeeId;
						
			}
		
			// create a temporary collection and add the item to it
			TList<Employees> tempMockCollection = new TList<Employees>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Employees)mock;
		}
		
		
		///<summary>
		///  Update the Typed Employees Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, Employees mock)
		{
			mock.LastName = TestUtility.Instance.RandomString(9, false);;
			mock.FirstName = TestUtility.Instance.RandomString(10, false);;
			mock.Title = TestUtility.Instance.RandomString(14, false);;
			mock.TitleOfCourtesy = TestUtility.Instance.RandomString(11, false);;
			mock.BirthDate = TestUtility.Instance.RandomDateTime();
			mock.HireDate = TestUtility.Instance.RandomDateTime();
			mock.Address = TestUtility.Instance.RandomString(29, false);;
			mock.City = TestUtility.Instance.RandomString(6, false);;
			mock.Region = TestUtility.Instance.RandomString(6, false);;
			mock.PostalCode = TestUtility.Instance.RandomString(10, false);;
			mock.Country = TestUtility.Instance.RandomString(6, false);;
			mock.HomePhone = TestUtility.Instance.RandomString(11, false);;
			mock.Extension = TestUtility.Instance.RandomString(4, false);;
			mock.Photo = new byte[] { TestUtility.Instance.RandomByte() };
			mock.Notes = TestUtility.Instance.RandomString(2, false);;
			mock.PhotoPath = TestUtility.Instance.RandomString(126, false);;
			
			int count0 = 0;
			TList<Employees> _collection0 = DataRepository.EmployeesProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.ReportsTo = _collection0[0].EmployeeId;
			}
		}
		#endregion
    }
}
