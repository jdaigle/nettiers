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
	/// This class is the base class for any <see cref="CustomerCustomerDemoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerCustomerDemoProviderBaseCore : EntityProviderBase<Northwind.Entities.CustomerCustomerDemo, Northwind.Entities.CustomerCustomerDemoKey>
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
		public override bool Delete(TransactionManager transactionManager, Northwind.Entities.CustomerCustomerDemoKey key)
		{
			return Delete(transactionManager, key.CustomerId, key.CustomerTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customerId">. Primary Key.</param>
		/// <param name="_customerTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _customerId, System.String _customerTypeId)
		{
			return Delete(null, _customerId, _customerTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">. Primary Key.</param>
		/// <param name="_customerTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _customerId, System.String _customerTypeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo key.
		///		FK_CustomerCustomerDemo Description: 
		/// </summary>
		/// <param name="_customerTypeId"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		public TList<CustomerCustomerDemo> GetByCustomerTypeId(System.String _customerTypeId)
		{
			int count = -1;
			return GetByCustomerTypeId(_customerTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo key.
		///		FK_CustomerCustomerDemo Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTypeId"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		/// <remarks></remarks>
		public TList<CustomerCustomerDemo> GetByCustomerTypeId(TransactionManager transactionManager, System.String _customerTypeId)
		{
			int count = -1;
			return GetByCustomerTypeId(transactionManager, _customerTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo key.
		///		FK_CustomerCustomerDemo Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		public TList<CustomerCustomerDemo> GetByCustomerTypeId(TransactionManager transactionManager, System.String _customerTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerTypeId(transactionManager, _customerTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo key.
		///		fkCustomerCustomerDemo Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		public TList<CustomerCustomerDemo> GetByCustomerTypeId(System.String _customerTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerTypeId(null, _customerTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo key.
		///		fkCustomerCustomerDemo Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		public TList<CustomerCustomerDemo> GetByCustomerTypeId(System.String _customerTypeId, int start, int pageLength,out int count)
		{
			return GetByCustomerTypeId(null, _customerTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo key.
		///		FK_CustomerCustomerDemo Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		public abstract TList<CustomerCustomerDemo> GetByCustomerTypeId(TransactionManager transactionManager, System.String _customerTypeId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo_Customers key.
		///		FK_CustomerCustomerDemo_Customers Description: 
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		public TList<CustomerCustomerDemo> GetByCustomerId(System.String _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo_Customers key.
		///		FK_CustomerCustomerDemo_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		/// <remarks></remarks>
		public TList<CustomerCustomerDemo> GetByCustomerId(TransactionManager transactionManager, System.String _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo_Customers key.
		///		FK_CustomerCustomerDemo_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		public TList<CustomerCustomerDemo> GetByCustomerId(TransactionManager transactionManager, System.String _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo_Customers key.
		///		fkCustomerCustomerDemoCustomers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		public TList<CustomerCustomerDemo> GetByCustomerId(System.String _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo_Customers key.
		///		fkCustomerCustomerDemoCustomers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		public TList<CustomerCustomerDemo> GetByCustomerId(System.String _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerCustomerDemo_Customers key.
		///		FK_CustomerCustomerDemo_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Northwind.Entities.CustomerCustomerDemo objects.</returns>
		public abstract TList<CustomerCustomerDemo> GetByCustomerId(TransactionManager transactionManager, System.String _customerId, int start, int pageLength, out int count);
		
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
		public override Northwind.Entities.CustomerCustomerDemo Get(TransactionManager transactionManager, Northwind.Entities.CustomerCustomerDemoKey key, int start, int pageLength)
		{
			return GetByCustomerIdCustomerTypeId(transactionManager, key.CustomerId, key.CustomerTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CustomerCustomerDemo index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_customerTypeId"></param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerCustomerDemo"/> class.</returns>
		public Northwind.Entities.CustomerCustomerDemo GetByCustomerIdCustomerTypeId(System.String _customerId, System.String _customerTypeId)
		{
			int count = -1;
			return GetByCustomerIdCustomerTypeId(null,_customerId, _customerTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerCustomerDemo index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerCustomerDemo"/> class.</returns>
		public Northwind.Entities.CustomerCustomerDemo GetByCustomerIdCustomerTypeId(System.String _customerId, System.String _customerTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdCustomerTypeId(null, _customerId, _customerTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerCustomerDemo index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_customerTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerCustomerDemo"/> class.</returns>
		public Northwind.Entities.CustomerCustomerDemo GetByCustomerIdCustomerTypeId(TransactionManager transactionManager, System.String _customerId, System.String _customerTypeId)
		{
			int count = -1;
			return GetByCustomerIdCustomerTypeId(transactionManager, _customerId, _customerTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerCustomerDemo index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerCustomerDemo"/> class.</returns>
		public Northwind.Entities.CustomerCustomerDemo GetByCustomerIdCustomerTypeId(TransactionManager transactionManager, System.String _customerId, System.String _customerTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdCustomerTypeId(transactionManager, _customerId, _customerTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerCustomerDemo index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerCustomerDemo"/> class.</returns>
		public Northwind.Entities.CustomerCustomerDemo GetByCustomerIdCustomerTypeId(System.String _customerId, System.String _customerTypeId, int start, int pageLength, out int count)
		{
			return GetByCustomerIdCustomerTypeId(null, _customerId, _customerTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerCustomerDemo index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerCustomerDemo"/> class.</returns>
		public abstract Northwind.Entities.CustomerCustomerDemo GetByCustomerIdCustomerTypeId(TransactionManager transactionManager, System.String _customerId, System.String _customerTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CustomerCustomerDemo&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CustomerCustomerDemo&gt;"/></returns>
		public static TList<CustomerCustomerDemo> Fill(IDataReader reader, TList<CustomerCustomerDemo> rows, int start, int pageLength)
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
				
				Northwind.Entities.CustomerCustomerDemo c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomerCustomerDemo")
					.Append("|").Append((System.String)reader[((int)CustomerCustomerDemoColumn.CustomerId - 1)])
					.Append("|").Append((System.String)reader[((int)CustomerCustomerDemoColumn.CustomerTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CustomerCustomerDemo>(
					key.ToString(), // EntityTrackingKey
					"CustomerCustomerDemo",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Northwind.Entities.CustomerCustomerDemo();
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
					c.CustomerId = (System.String)reader[((int)CustomerCustomerDemoColumn.CustomerId - 1)];
					c.OriginalCustomerId = c.CustomerId;
					c.CustomerTypeId = (System.String)reader[((int)CustomerCustomerDemoColumn.CustomerTypeId - 1)];
					c.OriginalCustomerTypeId = c.CustomerTypeId;
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.CustomerCustomerDemo"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.CustomerCustomerDemo"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Northwind.Entities.CustomerCustomerDemo entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomerId = (System.String)reader[((int)CustomerCustomerDemoColumn.CustomerId - 1)];
			entity.OriginalCustomerId = (System.String)reader["CustomerID"];
			entity.CustomerTypeId = (System.String)reader[((int)CustomerCustomerDemoColumn.CustomerTypeId - 1)];
			entity.OriginalCustomerTypeId = (System.String)reader["CustomerTypeID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.CustomerCustomerDemo"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.CustomerCustomerDemo"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Northwind.Entities.CustomerCustomerDemo entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (System.String)dataRow["CustomerID"];
			entity.OriginalCustomerId = (System.String)dataRow["CustomerID"];
			entity.CustomerTypeId = (System.String)dataRow["CustomerTypeID"];
			entity.OriginalCustomerTypeId = (System.String)dataRow["CustomerTypeID"];
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
		/// <param name="entity">The <see cref="Northwind.Entities.CustomerCustomerDemo"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Northwind.Entities.CustomerCustomerDemo Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Northwind.Entities.CustomerCustomerDemo entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CustomerTypeIdSource	
			if (CanDeepLoad(entity, "CustomerDemographics|CustomerTypeIdSource", deepLoadType, innerList) 
				&& entity.CustomerTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CustomerTypeId;
				CustomerDemographics tmpEntity = EntityManager.LocateEntity<CustomerDemographics>(EntityLocator.ConstructKeyFromPkItems(typeof(CustomerDemographics), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerTypeIdSource = tmpEntity;
				else
					entity.CustomerTypeIdSource = DataRepository.CustomerDemographicsProvider.GetByCustomerTypeId(transactionManager, entity.CustomerTypeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomerDemographicsProvider.DeepLoad(transactionManager, entity.CustomerTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomerTypeIdSource

			#region CustomerIdSource	
			if (CanDeepLoad(entity, "Customers|CustomerIdSource", deepLoadType, innerList) 
				&& entity.CustomerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CustomerId;
				Customers tmpEntity = EntityManager.LocateEntity<Customers>(EntityLocator.ConstructKeyFromPkItems(typeof(Customers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerIdSource = tmpEntity;
				else
					entity.CustomerIdSource = DataRepository.CustomersProvider.GetByCustomerId(transactionManager, entity.CustomerId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomersProvider.DeepLoad(transactionManager, entity.CustomerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomerIdSource
			
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
		/// Deep Save the entire object graph of the Northwind.Entities.CustomerCustomerDemo object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Northwind.Entities.CustomerCustomerDemo instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Northwind.Entities.CustomerCustomerDemo Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Northwind.Entities.CustomerCustomerDemo entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CustomerTypeIdSource
			if (CanDeepSave(entity, "CustomerDemographics|CustomerTypeIdSource", deepSaveType, innerList) 
				&& entity.CustomerTypeIdSource != null)
			{
				DataRepository.CustomerDemographicsProvider.Save(transactionManager, entity.CustomerTypeIdSource);
				entity.CustomerTypeId = entity.CustomerTypeIdSource.CustomerTypeId;
			}
			#endregion 
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "Customers|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomersProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.CustomerId;
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
	
	#region CustomerCustomerDemoChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Northwind.Entities.CustomerCustomerDemo</c>
	///</summary>
	public enum CustomerCustomerDemoChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CustomerDemographics</c> at CustomerTypeIdSource
		///</summary>
		[ChildEntityType(typeof(CustomerDemographics))]
		CustomerDemographics,
			
		///<summary>
		/// Composite Property for <c>Customers</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customers))]
		Customers,
		}
	
	#endregion CustomerCustomerDemoChildEntityTypes
	
	#region CustomerCustomerDemoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerCustomerDemoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerCustomerDemo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerCustomerDemoFilterBuilder : SqlFilterBuilder<CustomerCustomerDemoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoFilterBuilder class.
		/// </summary>
		public CustomerCustomerDemoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerCustomerDemoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerCustomerDemoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerCustomerDemoFilterBuilder
	
	#region CustomerCustomerDemoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerCustomerDemoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerCustomerDemo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerCustomerDemoParameterBuilder : ParameterizedSqlFilterBuilder<CustomerCustomerDemoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoParameterBuilder class.
		/// </summary>
		public CustomerCustomerDemoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerCustomerDemoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerCustomerDemoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerCustomerDemoParameterBuilder
	
	#region CustomerCustomerDemoSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CustomerCustomerDemoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerCustomerDemo"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomerCustomerDemoSortBuilder : SqlSortBuilder<CustomerCustomerDemoColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoSqlSortBuilder class.
		/// </summary>
		public CustomerCustomerDemoSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomerCustomerDemoSortBuilder
	
} // end namespace
