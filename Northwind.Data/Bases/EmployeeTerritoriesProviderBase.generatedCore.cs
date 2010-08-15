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
	/// This class is the base class for any <see cref="EmployeeTerritoriesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmployeeTerritoriesProviderBaseCore : EntityProviderBase<Northwind.Entities.EmployeeTerritories, Northwind.Entities.EmployeeTerritoriesKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Northwind.Entities.EmployeeTerritoriesKey key)
		{
			return Delete(transactionManager, key.EmployeeId, key.TerritoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_employeeId">. Primary Key.</param>
		/// <param name="_territoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _employeeId, System.String _territoryId)
		{
			return Delete(null, _employeeId, _territoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">. Primary Key.</param>
		/// <param name="_territoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _employeeId, System.String _territoryId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Employees key.
		///		FK_EmployeeTerritories_Employees Description: 
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		public TList<EmployeeTerritories> GetByEmployeeId(System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(_employeeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Employees key.
		///		FK_EmployeeTerritories_Employees Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		/// <remarks></remarks>
		public TList<EmployeeTerritories> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Employees key.
		///		FK_EmployeeTerritories_Employees Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		public TList<EmployeeTerritories> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Employees key.
		///		fkEmployeeTerritoriesEmployees Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		public TList<EmployeeTerritories> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Employees key.
		///		fkEmployeeTerritoriesEmployees Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		public TList<EmployeeTerritories> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength,out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Employees key.
		///		FK_EmployeeTerritories_Employees Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		public abstract TList<EmployeeTerritories> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Territories key.
		///		FK_EmployeeTerritories_Territories Description: 
		/// </summary>
		/// <param name="_territoryId"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		public TList<EmployeeTerritories> GetByTerritoryId(System.String _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(_territoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Territories key.
		///		FK_EmployeeTerritories_Territories Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		/// <remarks></remarks>
		public TList<EmployeeTerritories> GetByTerritoryId(TransactionManager transactionManager, System.String _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Territories key.
		///		FK_EmployeeTerritories_Territories Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		public TList<EmployeeTerritories> GetByTerritoryId(TransactionManager transactionManager, System.String _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Territories key.
		///		fkEmployeeTerritoriesTerritories Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_territoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		public TList<EmployeeTerritories> GetByTerritoryId(System.String _territoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTerritoryId(null, _territoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Territories key.
		///		fkEmployeeTerritoriesTerritories Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_territoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		public TList<EmployeeTerritories> GetByTerritoryId(System.String _territoryId, int start, int pageLength,out int count)
		{
			return GetByTerritoryId(null, _territoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeTerritories_Territories key.
		///		FK_EmployeeTerritories_Territories Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Northwind.Entities.EmployeeTerritories objects.</returns>
		public abstract TList<EmployeeTerritories> GetByTerritoryId(TransactionManager transactionManager, System.String _territoryId, int start, int pageLength, out int count);
		
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
		public override Northwind.Entities.EmployeeTerritories Get(TransactionManager transactionManager, Northwind.Entities.EmployeeTerritoriesKey key, int start, int pageLength)
		{
			return GetByEmployeeIdTerritoryId(transactionManager, key.EmployeeId, key.TerritoryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_EmployeeTerritories index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <param name="_territoryId"></param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.EmployeeTerritories"/> class.</returns>
		public Northwind.Entities.EmployeeTerritories GetByEmployeeIdTerritoryId(System.Int32 _employeeId, System.String _territoryId)
		{
			int count = -1;
			return GetByEmployeeIdTerritoryId(null,_employeeId, _territoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeTerritories index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.EmployeeTerritories"/> class.</returns>
		public Northwind.Entities.EmployeeTerritories GetByEmployeeIdTerritoryId(System.Int32 _employeeId, System.String _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeIdTerritoryId(null, _employeeId, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeTerritories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="_territoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.EmployeeTerritories"/> class.</returns>
		public Northwind.Entities.EmployeeTerritories GetByEmployeeIdTerritoryId(TransactionManager transactionManager, System.Int32 _employeeId, System.String _territoryId)
		{
			int count = -1;
			return GetByEmployeeIdTerritoryId(transactionManager, _employeeId, _territoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeTerritories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.EmployeeTerritories"/> class.</returns>
		public Northwind.Entities.EmployeeTerritories GetByEmployeeIdTerritoryId(TransactionManager transactionManager, System.Int32 _employeeId, System.String _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeIdTerritoryId(transactionManager, _employeeId, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeTerritories index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.EmployeeTerritories"/> class.</returns>
		public Northwind.Entities.EmployeeTerritories GetByEmployeeIdTerritoryId(System.Int32 _employeeId, System.String _territoryId, int start, int pageLength, out int count)
		{
			return GetByEmployeeIdTerritoryId(null, _employeeId, _territoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeTerritories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.EmployeeTerritories"/> class.</returns>
		public abstract Northwind.Entities.EmployeeTerritories GetByEmployeeIdTerritoryId(TransactionManager transactionManager, System.Int32 _employeeId, System.String _territoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;EmployeeTerritories&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;EmployeeTerritories&gt;"/></returns>
		public static TList<EmployeeTerritories> Fill(IDataReader reader, TList<EmployeeTerritories> rows, int start, int pageLength)
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
				
				Northwind.Entities.EmployeeTerritories c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("EmployeeTerritories")
					.Append("|").Append((System.Int32)reader[((int)EmployeeTerritoriesColumn.EmployeeId - 1)])
					.Append("|").Append((System.String)reader[((int)EmployeeTerritoriesColumn.TerritoryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<EmployeeTerritories>(
					key.ToString(), // EntityTrackingKey
					"EmployeeTerritories",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Northwind.Entities.EmployeeTerritories();
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
					c.EmployeeId = (System.Int32)reader[((int)EmployeeTerritoriesColumn.EmployeeId - 1)];
					c.OriginalEmployeeId = c.EmployeeId;
					c.TerritoryId = (System.String)reader[((int)EmployeeTerritoriesColumn.TerritoryId - 1)];
					c.OriginalTerritoryId = c.TerritoryId;
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.EmployeeTerritories"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.EmployeeTerritories"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Northwind.Entities.EmployeeTerritories entity)
		{
			if (!reader.Read()) return;
			
			entity.EmployeeId = (System.Int32)reader[((int)EmployeeTerritoriesColumn.EmployeeId - 1)];
			entity.OriginalEmployeeId = (System.Int32)reader["EmployeeID"];
			entity.TerritoryId = (System.String)reader[((int)EmployeeTerritoriesColumn.TerritoryId - 1)];
			entity.OriginalTerritoryId = (System.String)reader["TerritoryID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.EmployeeTerritories"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.EmployeeTerritories"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Northwind.Entities.EmployeeTerritories entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmployeeId = (System.Int32)dataRow["EmployeeID"];
			entity.OriginalEmployeeId = (System.Int32)dataRow["EmployeeID"];
			entity.TerritoryId = (System.String)dataRow["TerritoryID"];
			entity.OriginalTerritoryId = (System.String)dataRow["TerritoryID"];
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
		/// <param name="entity">The <see cref="Northwind.Entities.EmployeeTerritories"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Northwind.Entities.EmployeeTerritories Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Northwind.Entities.EmployeeTerritories entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region EmployeeIdSource	
			if (CanDeepLoad(entity, "Employees|EmployeeIdSource", deepLoadType, innerList) 
				&& entity.EmployeeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.EmployeeId;
				Employees tmpEntity = EntityManager.LocateEntity<Employees>(EntityLocator.ConstructKeyFromPkItems(typeof(Employees), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EmployeeIdSource = tmpEntity;
				else
					entity.EmployeeIdSource = DataRepository.EmployeesProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.EmployeeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmployeesProvider.DeepLoad(transactionManager, entity.EmployeeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion EmployeeIdSource

			#region TerritoryIdSource	
			if (CanDeepLoad(entity, "Territories|TerritoryIdSource", deepLoadType, innerList) 
				&& entity.TerritoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.TerritoryId;
				Territories tmpEntity = EntityManager.LocateEntity<Territories>(EntityLocator.ConstructKeyFromPkItems(typeof(Territories), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TerritoryIdSource = tmpEntity;
				else
					entity.TerritoryIdSource = DataRepository.TerritoriesProvider.GetByTerritoryId(transactionManager, entity.TerritoryId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TerritoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TerritoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TerritoriesProvider.DeepLoad(transactionManager, entity.TerritoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TerritoryIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the Northwind.Entities.EmployeeTerritories object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Northwind.Entities.EmployeeTerritories instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Northwind.Entities.EmployeeTerritories Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Northwind.Entities.EmployeeTerritories entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region EmployeeIdSource
			if (CanDeepSave(entity, "Employees|EmployeeIdSource", deepSaveType, innerList) 
				&& entity.EmployeeIdSource != null)
			{
				DataRepository.EmployeesProvider.Save(transactionManager, entity.EmployeeIdSource);
				entity.EmployeeId = entity.EmployeeIdSource.EmployeeId;
			}
			#endregion 
			
			#region TerritoryIdSource
			if (CanDeepSave(entity, "Territories|TerritoryIdSource", deepSaveType, innerList) 
				&& entity.TerritoryIdSource != null)
			{
				DataRepository.TerritoriesProvider.Save(transactionManager, entity.TerritoryIdSource);
				entity.TerritoryId = entity.TerritoryIdSource.TerritoryId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
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
	
	#region EmployeeTerritoriesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Northwind.Entities.EmployeeTerritories</c>
	///</summary>
	public enum EmployeeTerritoriesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Employees</c> at EmployeeIdSource
		///</summary>
		[ChildEntityType(typeof(Employees))]
		Employees,
			
		///<summary>
		/// Composite Property for <c>Territories</c> at TerritoryIdSource
		///</summary>
		[ChildEntityType(typeof(Territories))]
		Territories,
		}
	
	#endregion EmployeeTerritoriesChildEntityTypes
	
	#region EmployeeTerritoriesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmployeeTerritoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeTerritories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeTerritoriesFilterBuilder : SqlFilterBuilder<EmployeeTerritoriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesFilterBuilder class.
		/// </summary>
		public EmployeeTerritoriesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeTerritoriesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeTerritoriesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeTerritoriesFilterBuilder
	
	#region EmployeeTerritoriesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmployeeTerritoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeTerritories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeTerritoriesParameterBuilder : ParameterizedSqlFilterBuilder<EmployeeTerritoriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesParameterBuilder class.
		/// </summary>
		public EmployeeTerritoriesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeTerritoriesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeTerritoriesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeTerritoriesParameterBuilder
	
	#region EmployeeTerritoriesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EmployeeTerritoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeTerritories"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EmployeeTerritoriesSortBuilder : SqlSortBuilder<EmployeeTerritoriesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesSqlSortBuilder class.
		/// </summary>
		public EmployeeTerritoriesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EmployeeTerritoriesSortBuilder
	
} // end namespace
