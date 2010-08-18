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
	/// This class is the base class for any <see cref="OrderDetailsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrderDetailsProviderBaseCore : EntityProviderBase<Northwind.Entities.OrderDetails, Northwind.Entities.OrderDetailsKey>
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
		public override bool Delete(TransactionManager transactionManager, Northwind.Entities.OrderDetailsKey key)
		{
			return Delete(transactionManager, key.OrderId, key.ProductId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_orderId">. Primary Key.</param>
		/// <param name="_productId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _orderId, System.Int32 _productId)
		{
			return Delete(null, _orderId, _productId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId">. Primary Key.</param>
		/// <param name="_productId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _orderId, System.Int32 _productId);		
		
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
		public override Northwind.Entities.OrderDetails Get(TransactionManager transactionManager, Northwind.Entities.OrderDetailsKey key, int start, int pageLength)
		{
			return GetByOrderIdProductId(transactionManager, key.OrderId, key.ProductId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key OrderID index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public TList<OrderDetails> GetByOrderId(System.Int32 _orderId)
		{
			int count = -1;
			return GetByOrderId(null,_orderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the OrderID index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public TList<OrderDetails> GetByOrderId(System.Int32 _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(null, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the OrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public TList<OrderDetails> GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the OrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public TList<OrderDetails> GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the OrderID index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public TList<OrderDetails> GetByOrderId(System.Int32 _orderId, int start, int pageLength, out int count)
		{
			return GetByOrderId(null, _orderId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the OrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public abstract TList<OrderDetails> GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Order_Details index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="_productId"></param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.OrderDetails"/> class.</returns>
		public Northwind.Entities.OrderDetails GetByOrderIdProductId(System.Int32 _orderId, System.Int32 _productId)
		{
			int count = -1;
			return GetByOrderIdProductId(null,_orderId, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Order_Details index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.OrderDetails"/> class.</returns>
		public Northwind.Entities.OrderDetails GetByOrderIdProductId(System.Int32 _orderId, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderIdProductId(null, _orderId, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Order_Details index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.OrderDetails"/> class.</returns>
		public Northwind.Entities.OrderDetails GetByOrderIdProductId(TransactionManager transactionManager, System.Int32 _orderId, System.Int32 _productId)
		{
			int count = -1;
			return GetByOrderIdProductId(transactionManager, _orderId, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Order_Details index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.OrderDetails"/> class.</returns>
		public Northwind.Entities.OrderDetails GetByOrderIdProductId(TransactionManager transactionManager, System.Int32 _orderId, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderIdProductId(transactionManager, _orderId, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Order_Details index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.OrderDetails"/> class.</returns>
		public Northwind.Entities.OrderDetails GetByOrderIdProductId(System.Int32 _orderId, System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByOrderIdProductId(null, _orderId, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Order_Details index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.OrderDetails"/> class.</returns>
		public abstract Northwind.Entities.OrderDetails GetByOrderIdProductId(TransactionManager transactionManager, System.Int32 _orderId, System.Int32 _productId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ProductID index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public TList<OrderDetails> GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(null,_productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductID index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public TList<OrderDetails> GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public TList<OrderDetails> GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public TList<OrderDetails> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductID index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public TList<OrderDetails> GetByProductId(System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;OrderDetails&gt;"/> class.</returns>
		public abstract TList<OrderDetails> GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;OrderDetails&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;OrderDetails&gt;"/></returns>
		public static TList<OrderDetails> Fill(IDataReader reader, TList<OrderDetails> rows, int start, int pageLength)
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
				
				Northwind.Entities.OrderDetails c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("OrderDetails")
					.Append("|").Append((System.Int32)reader[((int)OrderDetailsColumn.OrderId - 1)])
					.Append("|").Append((System.Int32)reader[((int)OrderDetailsColumn.ProductId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<OrderDetails>(
					key.ToString(), // EntityTrackingKey
					"OrderDetails",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Northwind.Entities.OrderDetails();
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
					c.OrderId = (System.Int32)reader["OrderID"];
					c.OriginalOrderId = c.OrderId;
					c.ProductId = (System.Int32)reader["ProductID"];
					c.OriginalProductId = c.ProductId;
					c.UnitPrice = (System.Decimal)reader["UnitPrice"];
					c.Quantity = (System.Int16)reader["Quantity"];
					c.Discount = (System.Single)reader["Discount"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.OrderDetails"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.OrderDetails"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Northwind.Entities.OrderDetails entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderId = (System.Int32)reader["OrderID"];
			entity.OriginalOrderId = (System.Int32)reader["OrderID"];
			entity.ProductId = (System.Int32)reader["ProductID"];
			entity.OriginalProductId = (System.Int32)reader["ProductID"];
			entity.UnitPrice = (System.Decimal)reader["UnitPrice"];
			entity.Quantity = (System.Int16)reader["Quantity"];
			entity.Discount = (System.Single)reader["Discount"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.OrderDetails"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.OrderDetails"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Northwind.Entities.OrderDetails entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderId = (System.Int32)dataRow["OrderID"];
			entity.OriginalOrderId = (System.Int32)dataRow["OrderID"];
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.OriginalProductId = (System.Int32)dataRow["ProductID"];
			entity.UnitPrice = (System.Decimal)dataRow["UnitPrice"];
			entity.Quantity = (System.Int16)dataRow["Quantity"];
			entity.Discount = (System.Single)dataRow["Discount"];
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
		/// <param name="entity">The <see cref="Northwind.Entities.OrderDetails"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Northwind.Entities.OrderDetails Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Northwind.Entities.OrderDetails entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region OrderIdSource	
			if (CanDeepLoad(entity, "Orders|OrderIdSource", deepLoadType, innerList) 
				&& entity.OrderIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.OrderId;
				Orders tmpEntity = EntityManager.LocateEntity<Orders>(EntityLocator.ConstructKeyFromPkItems(typeof(Orders), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OrderIdSource = tmpEntity;
				else
					entity.OrderIdSource = DataRepository.OrdersProvider.GetByOrderId(transactionManager, entity.OrderId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrderIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.OrderIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.OrdersProvider.DeepLoad(transactionManager, entity.OrderIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion OrderIdSource

			#region ProductIdSource	
			if (CanDeepLoad(entity, "Products|ProductIdSource", deepLoadType, innerList) 
				&& entity.ProductIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ProductId;
				Products tmpEntity = EntityManager.LocateEntity<Products>(EntityLocator.ConstructKeyFromPkItems(typeof(Products), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ProductIdSource = tmpEntity;
				else
					entity.ProductIdSource = DataRepository.ProductsProvider.GetByProductId(transactionManager, entity.ProductId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProductsProvider.DeepLoad(transactionManager, entity.ProductIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ProductIdSource
			
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
		/// Deep Save the entire object graph of the Northwind.Entities.OrderDetails object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Northwind.Entities.OrderDetails instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Northwind.Entities.OrderDetails Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Northwind.Entities.OrderDetails entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region OrderIdSource
			if (CanDeepSave(entity, "Orders|OrderIdSource", deepSaveType, innerList) 
				&& entity.OrderIdSource != null)
			{
				DataRepository.OrdersProvider.Save(transactionManager, entity.OrderIdSource);
				entity.OrderId = entity.OrderIdSource.OrderId;
			}
			#endregion 
			
			#region ProductIdSource
			if (CanDeepSave(entity, "Products|ProductIdSource", deepSaveType, innerList) 
				&& entity.ProductIdSource != null)
			{
				DataRepository.ProductsProvider.Save(transactionManager, entity.ProductIdSource);
				entity.ProductId = entity.ProductIdSource.ProductId;
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
	
	#region OrderDetailsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Northwind.Entities.OrderDetails</c>
	///</summary>
	public enum OrderDetailsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Orders</c> at OrderIdSource
		///</summary>
		[ChildEntityType(typeof(Orders))]
		Orders,
			
		///<summary>
		/// Composite Property for <c>Products</c> at ProductIdSource
		///</summary>
		[ChildEntityType(typeof(Products))]
		Products,
		}
	
	#endregion OrderDetailsChildEntityTypes
	
	#region OrderDetailsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;OrderDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsFilterBuilder : SqlFilterBuilder<OrderDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilterBuilder class.
		/// </summary>
		public OrderDetailsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsFilterBuilder
	
	#region OrderDetailsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;OrderDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsParameterBuilder : ParameterizedSqlFilterBuilder<OrderDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsParameterBuilder class.
		/// </summary>
		public OrderDetailsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsParameterBuilder
	
	#region OrderDetailsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;OrderDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class OrderDetailsSortBuilder : SqlSortBuilder<OrderDetailsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsSqlSortBuilder class.
		/// </summary>
		public OrderDetailsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion OrderDetailsSortBuilder
	
} // end namespace
