#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using Northwind.Entities;
using Northwind.Data;

#endregion

namespace Northwind.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="EmployeesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmployeesProviderBaseCore : EntityProviderBase<Northwind.Entities.Employees, Northwind.Entities.EmployeesKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByTerritoryIdFromEmployeeTerritories
		
		/// <summary>
		///		Gets Employees objects from the datasource by TerritoryID in the
		///		EmployeeTerritories table. Table Employees is related to table Territories
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="_territoryId"></param>
		/// <returns>Returns a typed collection of Employees objects.</returns>
		public TList<Employees> GetByTerritoryIdFromEmployeeTerritories(System.String _territoryId)
		{
			int count = -1;
			return GetByTerritoryIdFromEmployeeTerritories(null,_territoryId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Northwind.Entities.Employees objects from the datasource by TerritoryID in the
		///		EmployeeTerritories table. Table Employees is related to table Territories
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_territoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Employees objects.</returns>
		public TList<Employees> GetByTerritoryIdFromEmployeeTerritories(System.String _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryIdFromEmployeeTerritories(null, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Employees objects from the datasource by TerritoryID in the
		///		EmployeeTerritories table. Table Employees is related to table Territories
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Employees objects.</returns>
		public TList<Employees> GetByTerritoryIdFromEmployeeTerritories(TransactionManager transactionManager, System.String _territoryId)
		{
			int count = -1;
			return GetByTerritoryIdFromEmployeeTerritories(transactionManager, _territoryId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Employees objects from the datasource by TerritoryID in the
		///		EmployeeTerritories table. Table Employees is related to table Territories
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Employees objects.</returns>
		public TList<Employees> GetByTerritoryIdFromEmployeeTerritories(TransactionManager transactionManager, System.String _territoryId,int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryIdFromEmployeeTerritories(transactionManager, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Employees objects from the datasource by TerritoryID in the
		///		EmployeeTerritories table. Table Employees is related to table Territories
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Employees objects.</returns>
		public TList<Employees> GetByTerritoryIdFromEmployeeTerritories(System.String _territoryId,int start, int pageLength, out int count)
		{
			
			return GetByTerritoryIdFromEmployeeTerritories(null, _territoryId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Employees objects from the datasource by TerritoryID in the
		///		EmployeeTerritories table. Table Employees is related to table Territories
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_territoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Employees objects.</returns>
		public abstract TList<Employees> GetByTerritoryIdFromEmployeeTerritories(TransactionManager transactionManager,System.String _territoryId, int start, int pageLength, out int count);
		
		#endregion GetByTerritoryIdFromEmployeeTerritories
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Northwind.Entities.EmployeesKey key)
		{
			return Delete(transactionManager, key.EmployeeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_employeeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _employeeId)
		{
			return Delete(null, _employeeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _employeeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employees_Employees key.
		///		FK_Employees_Employees Description: 
		/// </summary>
		/// <param name="_reportsTo"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.Employees objects.</returns>
		public TList<Employees> GetByReportsTo(System.Int32? _reportsTo)
		{
			int count = -1;
			return GetByReportsTo(_reportsTo, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employees_Employees key.
		///		FK_Employees_Employees Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reportsTo"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.Employees objects.</returns>
		/// <remarks></remarks>
		public TList<Employees> GetByReportsTo(TransactionManager transactionManager, System.Int32? _reportsTo)
		{
			int count = -1;
			return GetByReportsTo(transactionManager, _reportsTo, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employees_Employees key.
		///		FK_Employees_Employees Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reportsTo"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.Employees objects.</returns>
		public TList<Employees> GetByReportsTo(TransactionManager transactionManager, System.Int32? _reportsTo, int start, int pageLength)
		{
			int count = -1;
			return GetByReportsTo(transactionManager, _reportsTo, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employees_Employees key.
		///		fkEmployeesEmployees Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_reportsTo"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.Employees objects.</returns>
		public TList<Employees> GetByReportsTo(System.Int32? _reportsTo, int start, int pageLength)
		{
			int count =  -1;
			return GetByReportsTo(null, _reportsTo, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employees_Employees key.
		///		fkEmployeesEmployees Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_reportsTo"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.Employees objects.</returns>
		public TList<Employees> GetByReportsTo(System.Int32? _reportsTo, int start, int pageLength,out int count)
		{
			return GetByReportsTo(null, _reportsTo, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Employees_Employees key.
		///		FK_Employees_Employees Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_reportsTo"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Northwind.Entities.Employees objects.</returns>
		public abstract TList<Employees> GetByReportsTo(TransactionManager transactionManager, System.Int32? _reportsTo, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override Northwind.Entities.Employees Get(TransactionManager transactionManager, Northwind.Entities.EmployeesKey key, int start, int pageLength)
		{
			return GetByEmployeeId(transactionManager, key.EmployeeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key LastName index.
		/// </summary>
		/// <param name="_lastName"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public TList<Employees> GetByLastName(System.String _lastName)
		{
			int count = -1;
			return GetByLastName(null,_lastName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LastName index.
		/// </summary>
		/// <param name="_lastName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public TList<Employees> GetByLastName(System.String _lastName, int start, int pageLength)
		{
			int count = -1;
			return GetByLastName(null, _lastName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LastName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public TList<Employees> GetByLastName(TransactionManager transactionManager, System.String _lastName)
		{
			int count = -1;
			return GetByLastName(transactionManager, _lastName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LastName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public TList<Employees> GetByLastName(TransactionManager transactionManager, System.String _lastName, int start, int pageLength)
		{
			int count = -1;
			return GetByLastName(transactionManager, _lastName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the LastName index.
		/// </summary>
		/// <param name="_lastName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public TList<Employees> GetByLastName(System.String _lastName, int start, int pageLength, out int count)
		{
			return GetByLastName(null, _lastName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the LastName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_lastName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public abstract TList<Employees> GetByLastName(TransactionManager transactionManager, System.String _lastName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Employees index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Employees"/> class.</returns>
		public Northwind.Entities.Employees GetByEmployeeId(System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(null,_employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employees index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Employees"/> class.</returns>
		public Northwind.Entities.Employees GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employees index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Employees"/> class.</returns>
		public Northwind.Entities.Employees GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employees index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Employees"/> class.</returns>
		public Northwind.Entities.Employees GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employees index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Employees"/> class.</returns>
		public Northwind.Entities.Employees GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength, out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employees index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Employees"/> class.</returns>
		public abstract Northwind.Entities.Employees GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PostalCode index.
		/// </summary>
		/// <param name="_postalCode"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public TList<Employees> GetByPostalCode(System.String _postalCode)
		{
			int count = -1;
			return GetByPostalCode(null,_postalCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PostalCode index.
		/// </summary>
		/// <param name="_postalCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public TList<Employees> GetByPostalCode(System.String _postalCode, int start, int pageLength)
		{
			int count = -1;
			return GetByPostalCode(null, _postalCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PostalCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_postalCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public TList<Employees> GetByPostalCode(TransactionManager transactionManager, System.String _postalCode)
		{
			int count = -1;
			return GetByPostalCode(transactionManager, _postalCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PostalCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_postalCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public TList<Employees> GetByPostalCode(TransactionManager transactionManager, System.String _postalCode, int start, int pageLength)
		{
			int count = -1;
			return GetByPostalCode(transactionManager, _postalCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PostalCode index.
		/// </summary>
		/// <param name="_postalCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public TList<Employees> GetByPostalCode(System.String _postalCode, int start, int pageLength, out int count)
		{
			return GetByPostalCode(null, _postalCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PostalCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_postalCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Employees&gt;"/> class.</returns>
		public abstract TList<Employees> GetByPostalCode(TransactionManager transactionManager, System.String _postalCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Employees&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Employees&gt;"/></returns>
		public static TList<Employees> Fill(IDataReader reader, TList<Employees> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				Northwind.Entities.Employees c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Employees")
					.Append("|").Append((System.Int32)reader[((int)EmployeesColumn.EmployeeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Employees>(
					key.ToString(), // EntityTrackingKey
					"Employees",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Northwind.Entities.Employees();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.EmployeeId = (System.Int32)reader[((int)EmployeesColumn.EmployeeId - 1)];
					c.LastName = (System.String)reader[((int)EmployeesColumn.LastName - 1)];
					c.FirstName = (System.String)reader[((int)EmployeesColumn.FirstName - 1)];
					c.Title = (reader.IsDBNull(((int)EmployeesColumn.Title - 1)))?null:(System.String)reader[((int)EmployeesColumn.Title - 1)];
					c.TitleOfCourtesy = (reader.IsDBNull(((int)EmployeesColumn.TitleOfCourtesy - 1)))?null:(System.String)reader[((int)EmployeesColumn.TitleOfCourtesy - 1)];
					c.BirthDate = (reader.IsDBNull(((int)EmployeesColumn.BirthDate - 1)))?null:(System.DateTime?)reader[((int)EmployeesColumn.BirthDate - 1)];
					c.HireDate = (reader.IsDBNull(((int)EmployeesColumn.HireDate - 1)))?null:(System.DateTime?)reader[((int)EmployeesColumn.HireDate - 1)];
					c.Address = (reader.IsDBNull(((int)EmployeesColumn.Address - 1)))?null:(System.String)reader[((int)EmployeesColumn.Address - 1)];
					c.City = (reader.IsDBNull(((int)EmployeesColumn.City - 1)))?null:(System.String)reader[((int)EmployeesColumn.City - 1)];
					c.Region = (reader.IsDBNull(((int)EmployeesColumn.Region - 1)))?null:(System.String)reader[((int)EmployeesColumn.Region - 1)];
					c.PostalCode = (reader.IsDBNull(((int)EmployeesColumn.PostalCode - 1)))?null:(System.String)reader[((int)EmployeesColumn.PostalCode - 1)];
					c.Country = (reader.IsDBNull(((int)EmployeesColumn.Country - 1)))?null:(System.String)reader[((int)EmployeesColumn.Country - 1)];
					c.HomePhone = (reader.IsDBNull(((int)EmployeesColumn.HomePhone - 1)))?null:(System.String)reader[((int)EmployeesColumn.HomePhone - 1)];
					c.Extension = (reader.IsDBNull(((int)EmployeesColumn.Extension - 1)))?null:(System.String)reader[((int)EmployeesColumn.Extension - 1)];
					c.Photo = (reader.IsDBNull(((int)EmployeesColumn.Photo - 1)))?null:(System.Byte[])reader[((int)EmployeesColumn.Photo - 1)];
					c.Notes = (reader.IsDBNull(((int)EmployeesColumn.Notes - 1)))?null:(System.String)reader[((int)EmployeesColumn.Notes - 1)];
					c.ReportsTo = (reader.IsDBNull(((int)EmployeesColumn.ReportsTo - 1)))?null:(System.Int32?)reader[((int)EmployeesColumn.ReportsTo - 1)];
					c.PhotoPath = (reader.IsDBNull(((int)EmployeesColumn.PhotoPath - 1)))?null:(System.String)reader[((int)EmployeesColumn.PhotoPath - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Employees"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Employees"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Northwind.Entities.Employees entity)
		{
			if (!reader.Read()) return;
			
			entity.EmployeeId = (System.Int32)reader[((int)EmployeesColumn.EmployeeId - 1)];
			entity.LastName = (System.String)reader[((int)EmployeesColumn.LastName - 1)];
			entity.FirstName = (System.String)reader[((int)EmployeesColumn.FirstName - 1)];
			entity.Title = (reader.IsDBNull(((int)EmployeesColumn.Title - 1)))?null:(System.String)reader[((int)EmployeesColumn.Title - 1)];
			entity.TitleOfCourtesy = (reader.IsDBNull(((int)EmployeesColumn.TitleOfCourtesy - 1)))?null:(System.String)reader[((int)EmployeesColumn.TitleOfCourtesy - 1)];
			entity.BirthDate = (reader.IsDBNull(((int)EmployeesColumn.BirthDate - 1)))?null:(System.DateTime?)reader[((int)EmployeesColumn.BirthDate - 1)];
			entity.HireDate = (reader.IsDBNull(((int)EmployeesColumn.HireDate - 1)))?null:(System.DateTime?)reader[((int)EmployeesColumn.HireDate - 1)];
			entity.Address = (reader.IsDBNull(((int)EmployeesColumn.Address - 1)))?null:(System.String)reader[((int)EmployeesColumn.Address - 1)];
			entity.City = (reader.IsDBNull(((int)EmployeesColumn.City - 1)))?null:(System.String)reader[((int)EmployeesColumn.City - 1)];
			entity.Region = (reader.IsDBNull(((int)EmployeesColumn.Region - 1)))?null:(System.String)reader[((int)EmployeesColumn.Region - 1)];
			entity.PostalCode = (reader.IsDBNull(((int)EmployeesColumn.PostalCode - 1)))?null:(System.String)reader[((int)EmployeesColumn.PostalCode - 1)];
			entity.Country = (reader.IsDBNull(((int)EmployeesColumn.Country - 1)))?null:(System.String)reader[((int)EmployeesColumn.Country - 1)];
			entity.HomePhone = (reader.IsDBNull(((int)EmployeesColumn.HomePhone - 1)))?null:(System.String)reader[((int)EmployeesColumn.HomePhone - 1)];
			entity.Extension = (reader.IsDBNull(((int)EmployeesColumn.Extension - 1)))?null:(System.String)reader[((int)EmployeesColumn.Extension - 1)];
			entity.Photo = (reader.IsDBNull(((int)EmployeesColumn.Photo - 1)))?null:(System.Byte[])reader[((int)EmployeesColumn.Photo - 1)];
			entity.Notes = (reader.IsDBNull(((int)EmployeesColumn.Notes - 1)))?null:(System.String)reader[((int)EmployeesColumn.Notes - 1)];
			entity.ReportsTo = (reader.IsDBNull(((int)EmployeesColumn.ReportsTo - 1)))?null:(System.Int32?)reader[((int)EmployeesColumn.ReportsTo - 1)];
			entity.PhotoPath = (reader.IsDBNull(((int)EmployeesColumn.PhotoPath - 1)))?null:(System.String)reader[((int)EmployeesColumn.PhotoPath - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Employees"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Employees"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Northwind.Entities.Employees entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmployeeId = (System.Int32)dataRow["EmployeeID"];
			entity.LastName = (System.String)dataRow["LastName"];
			entity.FirstName = (System.String)dataRow["FirstName"];
			entity.Title = Convert.IsDBNull(dataRow["Title"]) ? null : (System.String)dataRow["Title"];
			entity.TitleOfCourtesy = Convert.IsDBNull(dataRow["TitleOfCourtesy"]) ? null : (System.String)dataRow["TitleOfCourtesy"];
			entity.BirthDate = Convert.IsDBNull(dataRow["BirthDate"]) ? null : (System.DateTime?)dataRow["BirthDate"];
			entity.HireDate = Convert.IsDBNull(dataRow["HireDate"]) ? null : (System.DateTime?)dataRow["HireDate"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (System.String)dataRow["City"];
			entity.Region = Convert.IsDBNull(dataRow["Region"]) ? null : (System.String)dataRow["Region"];
			entity.PostalCode = Convert.IsDBNull(dataRow["PostalCode"]) ? null : (System.String)dataRow["PostalCode"];
			entity.Country = Convert.IsDBNull(dataRow["Country"]) ? null : (System.String)dataRow["Country"];
			entity.HomePhone = Convert.IsDBNull(dataRow["HomePhone"]) ? null : (System.String)dataRow["HomePhone"];
			entity.Extension = Convert.IsDBNull(dataRow["Extension"]) ? null : (System.String)dataRow["Extension"];
			entity.Photo = Convert.IsDBNull(dataRow["Photo"]) ? null : (System.Byte[])dataRow["Photo"];
			entity.Notes = Convert.IsDBNull(dataRow["Notes"]) ? null : (System.String)dataRow["Notes"];
			entity.ReportsTo = Convert.IsDBNull(dataRow["ReportsTo"]) ? null : (System.Int32?)dataRow["ReportsTo"];
			entity.PhotoPath = Convert.IsDBNull(dataRow["PhotoPath"]) ? null : (System.String)dataRow["PhotoPath"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Employees"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Northwind.Entities.Employees Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Northwind.Entities.Employees entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ReportsToSource	
			if (CanDeepLoad(entity, "Employees|ReportsToSource", deepLoadType, innerList) 
				&& entity.ReportsToSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ReportsTo ?? (int)0);
				Employees tmpEntity = EntityManager.LocateEntity<Employees>(EntityLocator.ConstructKeyFromPkItems(typeof(Employees), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ReportsToSource = tmpEntity;
				else
					entity.ReportsToSource = DataRepository.EmployeesProvider.GetByEmployeeId(transactionManager, (entity.ReportsTo ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ReportsToSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ReportsToSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmployeesProvider.DeepLoad(transactionManager, entity.ReportsToSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ReportsToSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByEmployeeId methods when available
			
			#region EmployeesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Employees>|EmployeesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeesCollection = DataRepository.EmployeesProvider.GetByReportsTo(transactionManager, entity.EmployeeId);

				if (deep && entity.EmployeesCollection.Count > 0)
				{
					deepHandles.Add("EmployeesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Employees>) DataRepository.EmployeesProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region OrdersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Orders>|OrdersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrdersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.OrdersCollection = DataRepository.OrdersProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.OrdersCollection.Count > 0)
				{
					deepHandles.Add("OrdersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Orders>) DataRepository.OrdersProvider.DeepLoad,
						new object[] { transactionManager, entity.OrdersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EmployeeTerritoriesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeeTerritories>|EmployeeTerritoriesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeTerritoriesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeTerritoriesCollection = DataRepository.EmployeeTerritoriesProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.EmployeeTerritoriesCollection.Count > 0)
				{
					deepHandles.Add("EmployeeTerritoriesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeeTerritories>) DataRepository.EmployeeTerritoriesProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeTerritoriesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region TerritoryIdTerritoriesCollection_From_EmployeeTerritories
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Territories>|TerritoryIdTerritoriesCollection_From_EmployeeTerritories", deepLoadType, innerList))
			{
				entity.TerritoryIdTerritoriesCollection_From_EmployeeTerritories = DataRepository.TerritoriesProvider.GetByEmployeeIdFromEmployeeTerritories(transactionManager, entity.EmployeeId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TerritoryIdTerritoriesCollection_From_EmployeeTerritories' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TerritoryIdTerritoriesCollection_From_EmployeeTerritories != null)
				{
					deepHandles.Add("TerritoryIdTerritoriesCollection_From_EmployeeTerritories",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Territories >) DataRepository.TerritoriesProvider.DeepLoad,
						new object[] { transactionManager, entity.TerritoryIdTerritoriesCollection_From_EmployeeTerritories, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the Northwind.Entities.Employees object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Northwind.Entities.Employees instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Northwind.Entities.Employees Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Northwind.Entities.Employees entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ReportsToSource
			if (CanDeepSave(entity, "Employees|ReportsToSource", deepSaveType, innerList) 
				&& entity.ReportsToSource != null)
			{
				DataRepository.EmployeesProvider.Save(transactionManager, entity.ReportsToSource);
				entity.ReportsTo = entity.ReportsToSource.EmployeeId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region TerritoryIdTerritoriesCollection_From_EmployeeTerritories>
			if (CanDeepSave(entity.TerritoryIdTerritoriesCollection_From_EmployeeTerritories, "List<Territories>|TerritoryIdTerritoriesCollection_From_EmployeeTerritories", deepSaveType, innerList))
			{
				if (entity.TerritoryIdTerritoriesCollection_From_EmployeeTerritories.Count > 0 || entity.TerritoryIdTerritoriesCollection_From_EmployeeTerritories.DeletedItems.Count > 0)
				{
					DataRepository.TerritoriesProvider.Save(transactionManager, entity.TerritoryIdTerritoriesCollection_From_EmployeeTerritories); 
					deepHandles.Add("TerritoryIdTerritoriesCollection_From_EmployeeTerritories",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Territories>) DataRepository.TerritoriesProvider.DeepSave,
						new object[] { transactionManager, entity.TerritoryIdTerritoriesCollection_From_EmployeeTerritories, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<Employees>
				if (CanDeepSave(entity.EmployeesCollection, "List<Employees>|EmployeesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Employees child in entity.EmployeesCollection)
					{
						if(child.ReportsToSource != null)
						{
							child.ReportsTo = child.ReportsToSource.EmployeeId;
						}
						else
						{
							child.ReportsTo = entity.EmployeeId;
						}

					}

					if (entity.EmployeesCollection.Count > 0 || entity.EmployeesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmployeesProvider.Save(transactionManager, entity.EmployeesCollection);
						
						deepHandles.Add("EmployeesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Employees >) DataRepository.EmployeesProvider.DeepSave,
							new object[] { transactionManager, entity.EmployeesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Orders>
				if (CanDeepSave(entity.OrdersCollection, "List<Orders>|OrdersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Orders child in entity.OrdersCollection)
					{
						if(child.EmployeeIdSource != null)
						{
							child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}
						else
						{
							child.EmployeeId = entity.EmployeeId;
						}

					}

					if (entity.OrdersCollection.Count > 0 || entity.OrdersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.OrdersProvider.Save(transactionManager, entity.OrdersCollection);
						
						deepHandles.Add("OrdersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Orders >) DataRepository.OrdersProvider.DeepSave,
							new object[] { transactionManager, entity.OrdersCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<EmployeeTerritories>
				if (CanDeepSave(entity.EmployeeTerritoriesCollection, "List<EmployeeTerritories>|EmployeeTerritoriesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmployeeTerritories child in entity.EmployeeTerritoriesCollection)
					{
						if(child.EmployeeIdSource != null)
						{
								child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}

						if(child.TerritoryIdSource != null)
						{
								child.TerritoryId = child.TerritoryIdSource.TerritoryId;
						}

					}

					if (entity.EmployeeTerritoriesCollection.Count > 0 || entity.EmployeeTerritoriesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmployeeTerritoriesProvider.Save(transactionManager, entity.EmployeeTerritoriesCollection);
						
						deepHandles.Add("EmployeeTerritoriesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmployeeTerritories >) DataRepository.EmployeeTerritoriesProvider.DeepSave,
							new object[] { transactionManager, entity.EmployeeTerritoriesCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region EmployeesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Northwind.Entities.Employees</c>
	///</summary>
	public enum EmployeesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Employees</c> at ReportsToSource
		///</summary>
		[ChildEntityType(typeof(Employees))]
		Employees,
	
		///<summary>
		/// Collection of <c>Employees</c> as OneToMany for EmployeesCollection
		///</summary>
		[ChildEntityType(typeof(TList<Employees>))]
		EmployeesCollection,

		///<summary>
		/// Collection of <c>Employees</c> as OneToMany for OrdersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Orders>))]
		OrdersCollection,

		///<summary>
		/// Collection of <c>Employees</c> as OneToMany for EmployeeTerritoriesCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeTerritories>))]
		EmployeeTerritoriesCollection,

		///<summary>
		/// Collection of <c>Employees</c> as ManyToMany for TerritoriesCollection_From_EmployeeTerritories
		///</summary>
		[ChildEntityType(typeof(TList<Territories>))]
		TerritoryIdTerritoriesCollection_From_EmployeeTerritories,
	}
	
	#endregion EmployeesChildEntityTypes
	
	#region EmployeesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmployeesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employees"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeesFilterBuilder : SqlFilterBuilder<EmployeesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeesFilterBuilder class.
		/// </summary>
		public EmployeesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeesFilterBuilder
	
	#region EmployeesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmployeesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employees"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeesParameterBuilder : ParameterizedSqlFilterBuilder<EmployeesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeesParameterBuilder class.
		/// </summary>
		public EmployeesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeesParameterBuilder
	
	#region EmployeesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EmployeesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employees"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EmployeesSortBuilder : SqlSortBuilder<EmployeesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeesSqlSortBuilder class.
		/// </summary>
		public EmployeesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EmployeesSortBuilder
	
} // end namespace
