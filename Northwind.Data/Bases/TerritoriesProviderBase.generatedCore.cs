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
	/// This class is the base class for any <see cref="TerritoriesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TerritoriesProviderBaseCore : EntityProviderBase<Northwind.Entities.Territories, Northwind.Entities.TerritoriesKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByEmployeeIdFromEmployeeTerritories
		
		/// <summary>
		///		Gets Territories objects from the datasource by EmployeeID in the
		///		EmployeeTerritories table. Table Territories is related to table Employees
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <returns>Returns a typed collection of Territories objects.</returns>
		public TList<Territories> GetByEmployeeIdFromEmployeeTerritories(System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeIdFromEmployeeTerritories(null,_employeeId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Northwind.Entities.Territories objects from the datasource by EmployeeID in the
		///		EmployeeTerritories table. Table Territories is related to table Employees
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Territories objects.</returns>
		public TList<Territories> GetByEmployeeIdFromEmployeeTerritories(System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeIdFromEmployeeTerritories(null, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Territories objects from the datasource by EmployeeID in the
		///		EmployeeTerritories table. Table Territories is related to table Employees
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Territories objects.</returns>
		public TList<Territories> GetByEmployeeIdFromEmployeeTerritories(TransactionManager transactionManager, System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeIdFromEmployeeTerritories(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Territories objects from the datasource by EmployeeID in the
		///		EmployeeTerritories table. Table Territories is related to table Employees
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Territories objects.</returns>
		public TList<Territories> GetByEmployeeIdFromEmployeeTerritories(TransactionManager transactionManager, System.Int32 _employeeId,int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeIdFromEmployeeTerritories(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Territories objects from the datasource by EmployeeID in the
		///		EmployeeTerritories table. Table Territories is related to table Employees
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Territories objects.</returns>
		public TList<Territories> GetByEmployeeIdFromEmployeeTerritories(System.Int32 _employeeId,int start, int pageLength, out int count)
		{
			
			return GetByEmployeeIdFromEmployeeTerritories(null, _employeeId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Territories objects from the datasource by EmployeeID in the
		///		EmployeeTerritories table. Table Territories is related to table Employees
		///		through the (M:N) relationship defined in the EmployeeTerritories table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_employeeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Territories objects.</returns>
		public abstract TList<Territories> GetByEmployeeIdFromEmployeeTerritories(TransactionManager transactionManager,System.Int32 _employeeId, int start, int pageLength, out int count);
		
		#endregion GetByEmployeeIdFromEmployeeTerritories
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Northwind.Entities.TerritoriesKey key)
		{
			return Delete(transactionManager, key.TerritoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_territoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _territoryId)
		{
			return Delete(null, _territoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _territoryId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Territories_Region key.
		///		FK_Territories_Region Description: 
		/// </summary>
		/// <param name="_regionId"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.Territories objects.</returns>
		public TList<Territories> GetByRegionId(System.Int32 _regionId)
		{
			int count = -1;
			return GetByRegionId(_regionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Territories_Region key.
		///		FK_Territories_Region Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_regionId"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.Territories objects.</returns>
		/// <remarks></remarks>
		public TList<Territories> GetByRegionId(TransactionManager transactionManager, System.Int32 _regionId)
		{
			int count = -1;
			return GetByRegionId(transactionManager, _regionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Territories_Region key.
		///		FK_Territories_Region Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_regionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.Territories objects.</returns>
		public TList<Territories> GetByRegionId(TransactionManager transactionManager, System.Int32 _regionId, int start, int pageLength)
		{
			int count = -1;
			return GetByRegionId(transactionManager, _regionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Territories_Region key.
		///		fkTerritoriesRegion Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_regionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.Territories objects.</returns>
		public TList<Territories> GetByRegionId(System.Int32 _regionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByRegionId(null, _regionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Territories_Region key.
		///		fkTerritoriesRegion Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_regionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.Territories objects.</returns>
		public TList<Territories> GetByRegionId(System.Int32 _regionId, int start, int pageLength,out int count)
		{
			return GetByRegionId(null, _regionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Territories_Region key.
		///		FK_Territories_Region Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_regionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Northwind.Entities.Territories objects.</returns>
		public abstract TList<Territories> GetByRegionId(TransactionManager transactionManager, System.Int32 _regionId, int start, int pageLength, out int count);
		
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
		public override Northwind.Entities.Territories Get(TransactionManager transactionManager, Northwind.Entities.TerritoriesKey key, int start, int pageLength)
		{
			return GetByTerritoryId(transactionManager, key.TerritoryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Territories index.
		/// </summary>
		/// <param name="_territoryId"></param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Territories"/> class.</returns>
		public Northwind.Entities.Territories GetByTerritoryId(System.String _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(null,_territoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Territories index.
		/// </summary>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Territories"/> class.</returns>
		public Northwind.Entities.Territories GetByTerritoryId(System.String _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryId(null, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Territories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Territories"/> class.</returns>
		public Northwind.Entities.Territories GetByTerritoryId(TransactionManager transactionManager, System.String _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Territories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Territories"/> class.</returns>
		public Northwind.Entities.Territories GetByTerritoryId(TransactionManager transactionManager, System.String _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Territories index.
		/// </summary>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Territories"/> class.</returns>
		public Northwind.Entities.Territories GetByTerritoryId(System.String _territoryId, int start, int pageLength, out int count)
		{
			return GetByTerritoryId(null, _territoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Territories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Territories"/> class.</returns>
		public abstract Northwind.Entities.Territories GetByTerritoryId(TransactionManager transactionManager, System.String _territoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Territories&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Territories&gt;"/></returns>
		public static TList<Territories> Fill(IDataReader reader, TList<Territories> rows, int start, int pageLength)
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
				
				Northwind.Entities.Territories c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Territories")
					.Append("|").Append((System.String)reader[((int)TerritoriesColumn.TerritoryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Territories>(
					key.ToString(), // EntityTrackingKey
					"Territories",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Northwind.Entities.Territories();
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
					c.TerritoryId = (System.String)reader["TerritoryID"];
					c.OriginalTerritoryId = c.TerritoryId;
					c.TerritoryDescription = (System.String)reader["TerritoryDescription"];
					c.RegionId = (System.Int32)reader["RegionID"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Territories"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Territories"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Northwind.Entities.Territories entity)
		{
			if (!reader.Read()) return;
			
			entity.TerritoryId = (System.String)reader["TerritoryID"];
			entity.OriginalTerritoryId = (System.String)reader["TerritoryID"];
			entity.TerritoryDescription = (System.String)reader["TerritoryDescription"];
			entity.RegionId = (System.Int32)reader["RegionID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Territories"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Territories"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Northwind.Entities.Territories entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TerritoryId = (System.String)dataRow["TerritoryID"];
			entity.OriginalTerritoryId = (System.String)dataRow["TerritoryID"];
			entity.TerritoryDescription = (System.String)dataRow["TerritoryDescription"];
			entity.RegionId = (System.Int32)dataRow["RegionID"];
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
		/// <param name="entity">The <see cref="Northwind.Entities.Territories"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Northwind.Entities.Territories Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Northwind.Entities.Territories entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region RegionIdSource	
			if (CanDeepLoad(entity, "Region|RegionIdSource", deepLoadType, innerList) 
				&& entity.RegionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.RegionId;
				Region tmpEntity = EntityManager.LocateEntity<Region>(EntityLocator.ConstructKeyFromPkItems(typeof(Region), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.RegionIdSource = tmpEntity;
				else
					entity.RegionIdSource = DataRepository.RegionProvider.GetByRegionId(transactionManager, entity.RegionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RegionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.RegionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.RegionProvider.DeepLoad(transactionManager, entity.RegionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion RegionIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByTerritoryId methods when available
			
			#region EmployeeIdEmployeesCollection_From_EmployeeTerritories
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Employees>|EmployeeIdEmployeesCollection_From_EmployeeTerritories", deepLoadType, innerList))
			{
				entity.EmployeeIdEmployeesCollection_From_EmployeeTerritories = DataRepository.EmployeesProvider.GetByTerritoryIdFromEmployeeTerritories(transactionManager, entity.TerritoryId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeIdEmployeesCollection_From_EmployeeTerritories' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.EmployeeIdEmployeesCollection_From_EmployeeTerritories != null)
				{
					deepHandles.Add("EmployeeIdEmployeesCollection_From_EmployeeTerritories",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Employees >) DataRepository.EmployeesProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeIdEmployeesCollection_From_EmployeeTerritories, deep, deepLoadType, childTypes, innerList }
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

				entity.EmployeeTerritoriesCollection = DataRepository.EmployeeTerritoriesProvider.GetByTerritoryId(transactionManager, entity.TerritoryId);

				if (deep && entity.EmployeeTerritoriesCollection.Count > 0)
				{
					deepHandles.Add("EmployeeTerritoriesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeeTerritories>) DataRepository.EmployeeTerritoriesProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeTerritoriesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Northwind.Entities.Territories object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Northwind.Entities.Territories instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Northwind.Entities.Territories Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Northwind.Entities.Territories entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region RegionIdSource
			if (CanDeepSave(entity, "Region|RegionIdSource", deepSaveType, innerList) 
				&& entity.RegionIdSource != null)
			{
				DataRepository.RegionProvider.Save(transactionManager, entity.RegionIdSource);
				entity.RegionId = entity.RegionIdSource.RegionId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region EmployeeIdEmployeesCollection_From_EmployeeTerritories>
			if (CanDeepSave(entity.EmployeeIdEmployeesCollection_From_EmployeeTerritories, "List<Employees>|EmployeeIdEmployeesCollection_From_EmployeeTerritories", deepSaveType, innerList))
			{
				if (entity.EmployeeIdEmployeesCollection_From_EmployeeTerritories.Count > 0 || entity.EmployeeIdEmployeesCollection_From_EmployeeTerritories.DeletedItems.Count > 0)
				{
					DataRepository.EmployeesProvider.Save(transactionManager, entity.EmployeeIdEmployeesCollection_From_EmployeeTerritories); 
					deepHandles.Add("EmployeeIdEmployeesCollection_From_EmployeeTerritories",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Employees>) DataRepository.EmployeesProvider.DeepSave,
						new object[] { transactionManager, entity.EmployeeIdEmployeesCollection_From_EmployeeTerritories, deepSaveType, childTypes, innerList }
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
						if(child.TerritoryIdSource != null)
						{
								child.TerritoryId = child.TerritoryIdSource.TerritoryId;
						}

						if(child.EmployeeIdSource != null)
						{
								child.EmployeeId = child.EmployeeIdSource.EmployeeId;
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
	
	#region TerritoriesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Northwind.Entities.Territories</c>
	///</summary>
	public enum TerritoriesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Region</c> at RegionIdSource
		///</summary>
		[ChildEntityType(typeof(Region))]
		Region,
	
		///<summary>
		/// Collection of <c>Territories</c> as ManyToMany for EmployeesCollection_From_EmployeeTerritories
		///</summary>
		[ChildEntityType(typeof(TList<Employees>))]
		EmployeeIdEmployeesCollection_From_EmployeeTerritories,

		///<summary>
		/// Collection of <c>Territories</c> as OneToMany for EmployeeTerritoriesCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeTerritories>))]
		EmployeeTerritoriesCollection,
	}
	
	#endregion TerritoriesChildEntityTypes
	
	#region TerritoriesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TerritoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Territories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TerritoriesFilterBuilder : SqlFilterBuilder<TerritoriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TerritoriesFilterBuilder class.
		/// </summary>
		public TerritoriesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TerritoriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TerritoriesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TerritoriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TerritoriesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TerritoriesFilterBuilder
	
	#region TerritoriesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TerritoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Territories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TerritoriesParameterBuilder : ParameterizedSqlFilterBuilder<TerritoriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TerritoriesParameterBuilder class.
		/// </summary>
		public TerritoriesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TerritoriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TerritoriesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TerritoriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TerritoriesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TerritoriesParameterBuilder
	
	#region TerritoriesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TerritoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Territories"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TerritoriesSortBuilder : SqlSortBuilder<TerritoriesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TerritoriesSqlSortBuilder class.
		/// </summary>
		public TerritoriesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TerritoriesSortBuilder
	
} // end namespace
