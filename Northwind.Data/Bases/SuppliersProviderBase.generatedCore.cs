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
	/// This class is the base class for any <see cref="SuppliersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SuppliersProviderBaseCore : EntityProviderBase<Northwind.Entities.Suppliers, Northwind.Entities.SuppliersKey>
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
		public override bool Delete(TransactionManager transactionManager, Northwind.Entities.SuppliersKey key)
		{
			return Delete(transactionManager, key.SupplierId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_supplierId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _supplierId)
		{
			return Delete(null, _supplierId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplierId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _supplierId);		
		
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
		public override Northwind.Entities.Suppliers Get(TransactionManager transactionManager, Northwind.Entities.SuppliersKey key, int start, int pageLength)
		{
			return GetBySupplierId(transactionManager, key.SupplierId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CompanyName index.
		/// </summary>
		/// <param name="_companyName"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public TList<Suppliers> GetByCompanyName(System.String _companyName)
		{
			int count = -1;
			return GetByCompanyName(null,_companyName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyName index.
		/// </summary>
		/// <param name="_companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public TList<Suppliers> GetByCompanyName(System.String _companyName, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyName(null, _companyName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public TList<Suppliers> GetByCompanyName(TransactionManager transactionManager, System.String _companyName)
		{
			int count = -1;
			return GetByCompanyName(transactionManager, _companyName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public TList<Suppliers> GetByCompanyName(TransactionManager transactionManager, System.String _companyName, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyName(transactionManager, _companyName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyName index.
		/// </summary>
		/// <param name="_companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public TList<Suppliers> GetByCompanyName(System.String _companyName, int start, int pageLength, out int count)
		{
			return GetByCompanyName(null, _companyName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CompanyName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public abstract TList<Suppliers> GetByCompanyName(TransactionManager transactionManager, System.String _companyName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Suppliers index.
		/// </summary>
		/// <param name="_supplierId"></param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Suppliers"/> class.</returns>
		public Northwind.Entities.Suppliers GetBySupplierId(System.Int32 _supplierId)
		{
			int count = -1;
			return GetBySupplierId(null,_supplierId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Suppliers index.
		/// </summary>
		/// <param name="_supplierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Suppliers"/> class.</returns>
		public Northwind.Entities.Suppliers GetBySupplierId(System.Int32 _supplierId, int start, int pageLength)
		{
			int count = -1;
			return GetBySupplierId(null, _supplierId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Suppliers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplierId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Suppliers"/> class.</returns>
		public Northwind.Entities.Suppliers GetBySupplierId(TransactionManager transactionManager, System.Int32 _supplierId)
		{
			int count = -1;
			return GetBySupplierId(transactionManager, _supplierId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Suppliers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Suppliers"/> class.</returns>
		public Northwind.Entities.Suppliers GetBySupplierId(TransactionManager transactionManager, System.Int32 _supplierId, int start, int pageLength)
		{
			int count = -1;
			return GetBySupplierId(transactionManager, _supplierId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Suppliers index.
		/// </summary>
		/// <param name="_supplierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Suppliers"/> class.</returns>
		public Northwind.Entities.Suppliers GetBySupplierId(System.Int32 _supplierId, int start, int pageLength, out int count)
		{
			return GetBySupplierId(null, _supplierId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Suppliers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Suppliers"/> class.</returns>
		public abstract Northwind.Entities.Suppliers GetBySupplierId(TransactionManager transactionManager, System.Int32 _supplierId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PostalCode index.
		/// </summary>
		/// <param name="_postalCode"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public TList<Suppliers> GetByPostalCode(System.String _postalCode)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public TList<Suppliers> GetByPostalCode(System.String _postalCode, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public TList<Suppliers> GetByPostalCode(TransactionManager transactionManager, System.String _postalCode)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public TList<Suppliers> GetByPostalCode(TransactionManager transactionManager, System.String _postalCode, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public TList<Suppliers> GetByPostalCode(System.String _postalCode, int start, int pageLength, out int count)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Suppliers&gt;"/> class.</returns>
		public abstract TList<Suppliers> GetByPostalCode(TransactionManager transactionManager, System.String _postalCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Suppliers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Suppliers&gt;"/></returns>
		public static TList<Suppliers> Fill(IDataReader reader, TList<Suppliers> rows, int start, int pageLength)
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
				
				Northwind.Entities.Suppliers c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Suppliers")
					.Append("|").Append((System.Int32)reader[((int)SuppliersColumn.SupplierId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Suppliers>(
					key.ToString(), // EntityTrackingKey
					"Suppliers",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Northwind.Entities.Suppliers();
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
					c.SupplierId = (System.Int32)reader["SupplierID"];
					c.CompanyName = (System.String)reader["CompanyName"];
					c.ContactName = reader.IsDBNull(reader.GetOrdinal("ContactName")) ? null : (System.String)reader["ContactName"];
					c.ContactTitle = reader.IsDBNull(reader.GetOrdinal("ContactTitle")) ? null : (System.String)reader["ContactTitle"];
					c.Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : (System.String)reader["Address"];
					c.City = reader.IsDBNull(reader.GetOrdinal("City")) ? null : (System.String)reader["City"];
					c.Region = reader.IsDBNull(reader.GetOrdinal("Region")) ? null : (System.String)reader["Region"];
					c.PostalCode = reader.IsDBNull(reader.GetOrdinal("PostalCode")) ? null : (System.String)reader["PostalCode"];
					c.Country = reader.IsDBNull(reader.GetOrdinal("Country")) ? null : (System.String)reader["Country"];
					c.Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : (System.String)reader["Phone"];
					c.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) ? null : (System.String)reader["Fax"];
					c.HomePage = reader.IsDBNull(reader.GetOrdinal("HomePage")) ? null : (System.String)reader["HomePage"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Suppliers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Suppliers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Northwind.Entities.Suppliers entity)
		{
			if (!reader.Read()) return;
			
			entity.SupplierId = (System.Int32)reader["SupplierID"];
			entity.CompanyName = (System.String)reader["CompanyName"];
			entity.ContactName = reader.IsDBNull(reader.GetOrdinal("ContactName")) ? null : (System.String)reader["ContactName"];
			entity.ContactTitle = reader.IsDBNull(reader.GetOrdinal("ContactTitle")) ? null : (System.String)reader["ContactTitle"];
			entity.Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : (System.String)reader["Address"];
			entity.City = reader.IsDBNull(reader.GetOrdinal("City")) ? null : (System.String)reader["City"];
			entity.Region = reader.IsDBNull(reader.GetOrdinal("Region")) ? null : (System.String)reader["Region"];
			entity.PostalCode = reader.IsDBNull(reader.GetOrdinal("PostalCode")) ? null : (System.String)reader["PostalCode"];
			entity.Country = reader.IsDBNull(reader.GetOrdinal("Country")) ? null : (System.String)reader["Country"];
			entity.Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : (System.String)reader["Phone"];
			entity.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) ? null : (System.String)reader["Fax"];
			entity.HomePage = reader.IsDBNull(reader.GetOrdinal("HomePage")) ? null : (System.String)reader["HomePage"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Suppliers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Suppliers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Northwind.Entities.Suppliers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SupplierId = (System.Int32)dataRow["SupplierID"];
			entity.CompanyName = (System.String)dataRow["CompanyName"];
			entity.ContactName = Convert.IsDBNull(dataRow["ContactName"]) ? null : (System.String)dataRow["ContactName"];
			entity.ContactTitle = Convert.IsDBNull(dataRow["ContactTitle"]) ? null : (System.String)dataRow["ContactTitle"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (System.String)dataRow["City"];
			entity.Region = Convert.IsDBNull(dataRow["Region"]) ? null : (System.String)dataRow["Region"];
			entity.PostalCode = Convert.IsDBNull(dataRow["PostalCode"]) ? null : (System.String)dataRow["PostalCode"];
			entity.Country = Convert.IsDBNull(dataRow["Country"]) ? null : (System.String)dataRow["Country"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.String)dataRow["Phone"];
			entity.Fax = Convert.IsDBNull(dataRow["Fax"]) ? null : (System.String)dataRow["Fax"];
			entity.HomePage = Convert.IsDBNull(dataRow["HomePage"]) ? null : (System.String)dataRow["HomePage"];
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
		/// <param name="entity">The <see cref="Northwind.Entities.Suppliers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Northwind.Entities.Suppliers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Northwind.Entities.Suppliers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySupplierId methods when available
			
			#region ProductsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Products>|ProductsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductsCollection = DataRepository.ProductsProvider.GetBySupplierId(transactionManager, entity.SupplierId);

				if (deep && entity.ProductsCollection.Count > 0)
				{
					deepHandles.Add("ProductsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Products>) DataRepository.ProductsProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Northwind.Entities.Suppliers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Northwind.Entities.Suppliers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Northwind.Entities.Suppliers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Northwind.Entities.Suppliers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Products>
				if (CanDeepSave(entity.ProductsCollection, "List<Products>|ProductsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Products child in entity.ProductsCollection)
					{
						if(child.SupplierIdSource != null)
						{
							child.SupplierId = child.SupplierIdSource.SupplierId;
						}
						else
						{
							child.SupplierId = entity.SupplierId;
						}

					}

					if (entity.ProductsCollection.Count > 0 || entity.ProductsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProductsProvider.Save(transactionManager, entity.ProductsCollection);
						
						deepHandles.Add("ProductsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Products >) DataRepository.ProductsProvider.DeepSave,
							new object[] { transactionManager, entity.ProductsCollection, deepSaveType, childTypes, innerList }
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
	
	#region SuppliersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Northwind.Entities.Suppliers</c>
	///</summary>
	public enum SuppliersChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Suppliers</c> as OneToMany for ProductsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Products>))]
		ProductsCollection,
	}
	
	#endregion SuppliersChildEntityTypes
	
	#region SuppliersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SuppliersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Suppliers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SuppliersFilterBuilder : SqlFilterBuilder<SuppliersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SuppliersFilterBuilder class.
		/// </summary>
		public SuppliersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SuppliersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SuppliersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SuppliersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SuppliersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SuppliersFilterBuilder
	
	#region SuppliersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SuppliersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Suppliers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SuppliersParameterBuilder : ParameterizedSqlFilterBuilder<SuppliersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SuppliersParameterBuilder class.
		/// </summary>
		public SuppliersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SuppliersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SuppliersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SuppliersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SuppliersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SuppliersParameterBuilder
	
	#region SuppliersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SuppliersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Suppliers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SuppliersSortBuilder : SqlSortBuilder<SuppliersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SuppliersSqlSortBuilder class.
		/// </summary>
		public SuppliersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SuppliersSortBuilder
	
} // end namespace
