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
	/// This class is the base class for any <see cref="CategoriesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CategoriesProviderBaseCore : EntityProviderBase<Northwind.Entities.Categories, Northwind.Entities.CategoriesKey>
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
		public override bool Delete(TransactionManager transactionManager, Northwind.Entities.CategoriesKey key)
		{
			return Delete(transactionManager, key.CategoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_categoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _categoryId)
		{
			return Delete(null, _categoryId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _categoryId);		
		
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
		public override Northwind.Entities.Categories Get(TransactionManager transactionManager, Northwind.Entities.CategoriesKey key, int start, int pageLength)
		{
			return GetByCategoryId(transactionManager, key.CategoryId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CategoryName index.
		/// </summary>
		/// <param name="_categoryName"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Categories&gt;"/> class.</returns>
		public TList<Categories> GetByCategoryName(System.String _categoryName)
		{
			int count = -1;
			return GetByCategoryName(null,_categoryName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CategoryName index.
		/// </summary>
		/// <param name="_categoryName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Categories&gt;"/> class.</returns>
		public TList<Categories> GetByCategoryName(System.String _categoryName, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryName(null, _categoryName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CategoryName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Categories&gt;"/> class.</returns>
		public TList<Categories> GetByCategoryName(TransactionManager transactionManager, System.String _categoryName)
		{
			int count = -1;
			return GetByCategoryName(transactionManager, _categoryName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CategoryName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Categories&gt;"/> class.</returns>
		public TList<Categories> GetByCategoryName(TransactionManager transactionManager, System.String _categoryName, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryName(transactionManager, _categoryName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CategoryName index.
		/// </summary>
		/// <param name="_categoryName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Categories&gt;"/> class.</returns>
		public TList<Categories> GetByCategoryName(System.String _categoryName, int start, int pageLength, out int count)
		{
			return GetByCategoryName(null, _categoryName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CategoryName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Categories&gt;"/> class.</returns>
		public abstract TList<Categories> GetByCategoryName(TransactionManager transactionManager, System.String _categoryName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Categories index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Categories"/> class.</returns>
		public Northwind.Entities.Categories GetByCategoryId(System.Int32 _categoryId)
		{
			int count = -1;
			return GetByCategoryId(null,_categoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Categories index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Categories"/> class.</returns>
		public Northwind.Entities.Categories GetByCategoryId(System.Int32 _categoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryId(null, _categoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Categories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Categories"/> class.</returns>
		public Northwind.Entities.Categories GetByCategoryId(TransactionManager transactionManager, System.Int32 _categoryId)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Categories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Categories"/> class.</returns>
		public Northwind.Entities.Categories GetByCategoryId(TransactionManager transactionManager, System.Int32 _categoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Categories index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Categories"/> class.</returns>
		public Northwind.Entities.Categories GetByCategoryId(System.Int32 _categoryId, int start, int pageLength, out int count)
		{
			return GetByCategoryId(null, _categoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Categories index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Categories"/> class.</returns>
		public abstract Northwind.Entities.Categories GetByCategoryId(TransactionManager transactionManager, System.Int32 _categoryId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Categories&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Categories&gt;"/></returns>
		public static TList<Categories> Fill(IDataReader reader, TList<Categories> rows, int start, int pageLength)
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
				
				Northwind.Entities.Categories c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Categories")
					.Append("|").Append((System.Int32)reader[((int)CategoriesColumn.CategoryId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Categories>(
					key.ToString(), // EntityTrackingKey
					"Categories",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Northwind.Entities.Categories();
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
					c.CategoryId = (System.Int32)reader["CategoryID"];
					c.CategoryName = (System.String)reader["CategoryName"];
					c.Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : (System.String)reader["Description"];
					c.Picture = reader.IsDBNull(reader.GetOrdinal("Picture")) ? null : (System.Byte[])reader["Picture"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Categories"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Categories"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Northwind.Entities.Categories entity)
		{
			if (!reader.Read()) return;
			
			entity.CategoryId = (System.Int32)reader["CategoryID"];
			entity.CategoryName = (System.String)reader["CategoryName"];
			entity.Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : (System.String)reader["Description"];
			entity.Picture = reader.IsDBNull(reader.GetOrdinal("Picture")) ? null : (System.Byte[])reader["Picture"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Categories"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Categories"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Northwind.Entities.Categories entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CategoryId = (System.Int32)dataRow["CategoryID"];
			entity.CategoryName = (System.String)dataRow["CategoryName"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.Picture = Convert.IsDBNull(dataRow["Picture"]) ? null : (System.Byte[])dataRow["Picture"];
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
		/// <param name="entity">The <see cref="Northwind.Entities.Categories"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Northwind.Entities.Categories Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Northwind.Entities.Categories entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCategoryId methods when available
			
			#region ProductsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Products>|ProductsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProductsCollection = DataRepository.ProductsProvider.GetByCategoryId(transactionManager, entity.CategoryId);

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
		/// Deep Save the entire object graph of the Northwind.Entities.Categories object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Northwind.Entities.Categories instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Northwind.Entities.Categories Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Northwind.Entities.Categories entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.CategoryIdSource != null)
						{
							child.CategoryId = child.CategoryIdSource.CategoryId;
						}
						else
						{
							child.CategoryId = entity.CategoryId;
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
	
	#region CategoriesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Northwind.Entities.Categories</c>
	///</summary>
	public enum CategoriesChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Categories</c> as OneToMany for ProductsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Products>))]
		ProductsCollection,
	}
	
	#endregion CategoriesChildEntityTypes
	
	#region CategoriesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CategoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Categories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategoriesFilterBuilder : SqlFilterBuilder<CategoriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoriesFilterBuilder class.
		/// </summary>
		public CategoriesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategoriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategoriesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategoriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategoriesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategoriesFilterBuilder
	
	#region CategoriesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CategoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Categories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategoriesParameterBuilder : ParameterizedSqlFilterBuilder<CategoriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoriesParameterBuilder class.
		/// </summary>
		public CategoriesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategoriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategoriesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategoriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategoriesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategoriesParameterBuilder
	
	#region CategoriesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CategoriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Categories"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CategoriesSortBuilder : SqlSortBuilder<CategoriesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoriesSqlSortBuilder class.
		/// </summary>
		public CategoriesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CategoriesSortBuilder
	
} // end namespace
