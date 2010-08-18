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
	/// This class is the base class for any <see cref="CustomerDemographicsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerDemographicsProviderBaseCore : EntityProviderBase<Northwind.Entities.CustomerDemographics, Northwind.Entities.CustomerDemographicsKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByCustomerIdFromCustomerCustomerDemo
		
		/// <summary>
		///		Gets CustomerDemographics objects from the datasource by CustomerID in the
		///		CustomerCustomerDemo table. Table CustomerDemographics is related to table Customers
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of CustomerDemographics objects.</returns>
		public TList<CustomerDemographics> GetByCustomerIdFromCustomerCustomerDemo(System.String _customerId)
		{
			int count = -1;
			return GetByCustomerIdFromCustomerCustomerDemo(null,_customerId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Northwind.Entities.CustomerDemographics objects from the datasource by CustomerID in the
		///		CustomerCustomerDemo table. Table CustomerDemographics is related to table Customers
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of CustomerDemographics objects.</returns>
		public TList<CustomerDemographics> GetByCustomerIdFromCustomerCustomerDemo(System.String _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdFromCustomerCustomerDemo(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets CustomerDemographics objects from the datasource by CustomerID in the
		///		CustomerCustomerDemo table. Table CustomerDemographics is related to table Customers
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CustomerDemographics objects.</returns>
		public TList<CustomerDemographics> GetByCustomerIdFromCustomerCustomerDemo(TransactionManager transactionManager, System.String _customerId)
		{
			int count = -1;
			return GetByCustomerIdFromCustomerCustomerDemo(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets CustomerDemographics objects from the datasource by CustomerID in the
		///		CustomerCustomerDemo table. Table CustomerDemographics is related to table Customers
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CustomerDemographics objects.</returns>
		public TList<CustomerDemographics> GetByCustomerIdFromCustomerCustomerDemo(TransactionManager transactionManager, System.String _customerId,int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdFromCustomerCustomerDemo(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets CustomerDemographics objects from the datasource by CustomerID in the
		///		CustomerCustomerDemo table. Table CustomerDemographics is related to table Customers
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CustomerDemographics objects.</returns>
		public TList<CustomerDemographics> GetByCustomerIdFromCustomerCustomerDemo(System.String _customerId,int start, int pageLength, out int count)
		{
			
			return GetByCustomerIdFromCustomerCustomerDemo(null, _customerId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets CustomerDemographics objects from the datasource by CustomerID in the
		///		CustomerCustomerDemo table. Table CustomerDemographics is related to table Customers
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of CustomerDemographics objects.</returns>
		public abstract TList<CustomerDemographics> GetByCustomerIdFromCustomerCustomerDemo(TransactionManager transactionManager,System.String _customerId, int start, int pageLength, out int count);
		
		#endregion GetByCustomerIdFromCustomerCustomerDemo
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Northwind.Entities.CustomerDemographicsKey key)
		{
			return Delete(transactionManager, key.CustomerTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customerTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _customerTypeId)
		{
			return Delete(null, _customerTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _customerTypeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override Northwind.Entities.CustomerDemographics Get(TransactionManager transactionManager, Northwind.Entities.CustomerDemographicsKey key, int start, int pageLength)
		{
			return GetByCustomerTypeId(transactionManager, key.CustomerTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CustomerDemographics index.
		/// </summary>
		/// <param name="_customerTypeId"></param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerDemographics"/> class.</returns>
		public Northwind.Entities.CustomerDemographics GetByCustomerTypeId(System.String _customerTypeId)
		{
			int count = -1;
			return GetByCustomerTypeId(null,_customerTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerDemographics index.
		/// </summary>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerDemographics"/> class.</returns>
		public Northwind.Entities.CustomerDemographics GetByCustomerTypeId(System.String _customerTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerTypeId(null, _customerTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerDemographics index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerDemographics"/> class.</returns>
		public Northwind.Entities.CustomerDemographics GetByCustomerTypeId(TransactionManager transactionManager, System.String _customerTypeId)
		{
			int count = -1;
			return GetByCustomerTypeId(transactionManager, _customerTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerDemographics index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerDemographics"/> class.</returns>
		public Northwind.Entities.CustomerDemographics GetByCustomerTypeId(TransactionManager transactionManager, System.String _customerTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerTypeId(transactionManager, _customerTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerDemographics index.
		/// </summary>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerDemographics"/> class.</returns>
		public Northwind.Entities.CustomerDemographics GetByCustomerTypeId(System.String _customerTypeId, int start, int pageLength, out int count)
		{
			return GetByCustomerTypeId(null, _customerTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerDemographics index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.CustomerDemographics"/> class.</returns>
		public abstract Northwind.Entities.CustomerDemographics GetByCustomerTypeId(TransactionManager transactionManager, System.String _customerTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CustomerDemographics&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CustomerDemographics&gt;"/></returns>
		public static TList<CustomerDemographics> Fill(IDataReader reader, TList<CustomerDemographics> rows, int start, int pageLength)
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
				
				Northwind.Entities.CustomerDemographics c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomerDemographics")
					.Append("|").Append((System.String)reader[((int)CustomerDemographicsColumn.CustomerTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CustomerDemographics>(
					key.ToString(), // EntityTrackingKey
					"CustomerDemographics",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Northwind.Entities.CustomerDemographics();
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
					c.CustomerTypeId = (System.String)reader["CustomerTypeID"];
					c.OriginalCustomerTypeId = c.CustomerTypeId;
					c.CustomerDesc = reader.IsDBNull(reader.GetOrdinal("CustomerDesc")) ? null : (System.String)reader["CustomerDesc"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.CustomerDemographics"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.CustomerDemographics"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Northwind.Entities.CustomerDemographics entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomerTypeId = (System.String)reader["CustomerTypeID"];
			entity.OriginalCustomerTypeId = (System.String)reader["CustomerTypeID"];
			entity.CustomerDesc = reader.IsDBNull(reader.GetOrdinal("CustomerDesc")) ? null : (System.String)reader["CustomerDesc"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.CustomerDemographics"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.CustomerDemographics"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Northwind.Entities.CustomerDemographics entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerTypeId = (System.String)dataRow["CustomerTypeID"];
			entity.OriginalCustomerTypeId = (System.String)dataRow["CustomerTypeID"];
			entity.CustomerDesc = Convert.IsDBNull(dataRow["CustomerDesc"]) ? null : (System.String)dataRow["CustomerDesc"];
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
		/// <param name="entity">The <see cref="Northwind.Entities.CustomerDemographics"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Northwind.Entities.CustomerDemographics Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Northwind.Entities.CustomerDemographics entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCustomerTypeId methods when available
			
			#region CustomerIdCustomersCollection_From_CustomerCustomerDemo
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Customers>|CustomerIdCustomersCollection_From_CustomerCustomerDemo", deepLoadType, innerList))
			{
				entity.CustomerIdCustomersCollection_From_CustomerCustomerDemo = DataRepository.CustomersProvider.GetByCustomerTypeIdFromCustomerCustomerDemo(transactionManager, entity.CustomerTypeId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdCustomersCollection_From_CustomerCustomerDemo' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdCustomersCollection_From_CustomerCustomerDemo != null)
				{
					deepHandles.Add("CustomerIdCustomersCollection_From_CustomerCustomerDemo",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Customers >) DataRepository.CustomersProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerIdCustomersCollection_From_CustomerCustomerDemo, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region CustomerCustomerDemoCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerCustomerDemo>|CustomerCustomerDemoCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerCustomerDemoCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerCustomerDemoCollection = DataRepository.CustomerCustomerDemoProvider.GetByCustomerTypeId(transactionManager, entity.CustomerTypeId);

				if (deep && entity.CustomerCustomerDemoCollection.Count > 0)
				{
					deepHandles.Add("CustomerCustomerDemoCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerCustomerDemo>) DataRepository.CustomerCustomerDemoProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerCustomerDemoCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Northwind.Entities.CustomerDemographics object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Northwind.Entities.CustomerDemographics instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Northwind.Entities.CustomerDemographics Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Northwind.Entities.CustomerDemographics entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region CustomerIdCustomersCollection_From_CustomerCustomerDemo>
			if (CanDeepSave(entity.CustomerIdCustomersCollection_From_CustomerCustomerDemo, "List<Customers>|CustomerIdCustomersCollection_From_CustomerCustomerDemo", deepSaveType, innerList))
			{
				if (entity.CustomerIdCustomersCollection_From_CustomerCustomerDemo.Count > 0 || entity.CustomerIdCustomersCollection_From_CustomerCustomerDemo.DeletedItems.Count > 0)
				{
					DataRepository.CustomersProvider.Save(transactionManager, entity.CustomerIdCustomersCollection_From_CustomerCustomerDemo); 
					deepHandles.Add("CustomerIdCustomersCollection_From_CustomerCustomerDemo",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Customers>) DataRepository.CustomersProvider.DeepSave,
						new object[] { transactionManager, entity.CustomerIdCustomersCollection_From_CustomerCustomerDemo, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<CustomerCustomerDemo>
				if (CanDeepSave(entity.CustomerCustomerDemoCollection, "List<CustomerCustomerDemo>|CustomerCustomerDemoCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerCustomerDemo child in entity.CustomerCustomerDemoCollection)
					{
						if(child.CustomerTypeIdSource != null)
						{
								child.CustomerTypeId = child.CustomerTypeIdSource.CustomerTypeId;
						}

						if(child.CustomerIdSource != null)
						{
								child.CustomerId = child.CustomerIdSource.CustomerId;
						}

					}

					if (entity.CustomerCustomerDemoCollection.Count > 0 || entity.CustomerCustomerDemoCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerCustomerDemoProvider.Save(transactionManager, entity.CustomerCustomerDemoCollection);
						
						deepHandles.Add("CustomerCustomerDemoCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomerCustomerDemo >) DataRepository.CustomerCustomerDemoProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerCustomerDemoCollection, deepSaveType, childTypes, innerList }
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
	
	#region CustomerDemographicsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Northwind.Entities.CustomerDemographics</c>
	///</summary>
	public enum CustomerDemographicsChildEntityTypes
	{

		///<summary>
		/// Collection of <c>CustomerDemographics</c> as ManyToMany for CustomersCollection_From_CustomerCustomerDemo
		///</summary>
		[ChildEntityType(typeof(TList<Customers>))]
		CustomerIdCustomersCollection_From_CustomerCustomerDemo,

		///<summary>
		/// Collection of <c>CustomerDemographics</c> as OneToMany for CustomerCustomerDemoCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerCustomerDemo>))]
		CustomerCustomerDemoCollection,
	}
	
	#endregion CustomerDemographicsChildEntityTypes
	
	#region CustomerDemographicsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerDemographicsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDemographicsFilterBuilder : SqlFilterBuilder<CustomerDemographicsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsFilterBuilder class.
		/// </summary>
		public CustomerDemographicsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDemographicsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDemographicsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDemographicsFilterBuilder
	
	#region CustomerDemographicsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerDemographicsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDemographicsParameterBuilder : ParameterizedSqlFilterBuilder<CustomerDemographicsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsParameterBuilder class.
		/// </summary>
		public CustomerDemographicsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDemographicsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDemographicsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDemographicsParameterBuilder
	
	#region CustomerDemographicsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CustomerDemographicsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDemographics"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomerDemographicsSortBuilder : SqlSortBuilder<CustomerDemographicsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsSqlSortBuilder class.
		/// </summary>
		public CustomerDemographicsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomerDemographicsSortBuilder
	
} // end namespace
