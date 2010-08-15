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
	/// This class is the base class for any <see cref="ProductsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProductsProviderBaseCore : EntityProviderBase<Northwind.Entities.Products, Northwind.Entities.ProductsKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByOrderIdFromOrderDetails
		
		/// <summary>
		///		Gets Products objects from the datasource by OrderID in the
		///		Order Details table. Table Products is related to table Orders
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <returns>Returns a typed collection of Products objects.</returns>
		public TList<Products> GetByOrderIdFromOrderDetails(System.Int32 _orderId)
		{
			int count = -1;
			return GetByOrderIdFromOrderDetails(null,_orderId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Northwind.Entities.Products objects from the datasource by OrderID in the
		///		Order Details table. Table Products is related to table Orders
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Products objects.</returns>
		public TList<Products> GetByOrderIdFromOrderDetails(System.Int32 _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderIdFromOrderDetails(null, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Products objects from the datasource by OrderID in the
		///		Order Details table. Table Products is related to table Orders
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Products objects.</returns>
		public TList<Products> GetByOrderIdFromOrderDetails(TransactionManager transactionManager, System.Int32 _orderId)
		{
			int count = -1;
			return GetByOrderIdFromOrderDetails(transactionManager, _orderId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Products objects from the datasource by OrderID in the
		///		Order Details table. Table Products is related to table Orders
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Products objects.</returns>
		public TList<Products> GetByOrderIdFromOrderDetails(TransactionManager transactionManager, System.Int32 _orderId,int start, int pageLength)
		{
			int count = -1;
			return GetByOrderIdFromOrderDetails(transactionManager, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Products objects from the datasource by OrderID in the
		///		Order Details table. Table Products is related to table Orders
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Products objects.</returns>
		public TList<Products> GetByOrderIdFromOrderDetails(System.Int32 _orderId,int start, int pageLength, out int count)
		{
			
			return GetByOrderIdFromOrderDetails(null, _orderId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Products objects from the datasource by OrderID in the
		///		Order Details table. Table Products is related to table Orders
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Products objects.</returns>
		public abstract TList<Products> GetByOrderIdFromOrderDetails(TransactionManager transactionManager,System.Int32 _orderId, int start, int pageLength, out int count);
		
		#endregion GetByOrderIdFromOrderDetails
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Northwind.Entities.ProductsKey key)
		{
			return Delete(transactionManager, key.ProductId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_productId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _productId)
		{
			return Delete(null, _productId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _productId);		
		
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
		public override Northwind.Entities.Products Get(TransactionManager transactionManager, Northwind.Entities.ProductsKey key, int start, int pageLength)
		{
			return GetByProductId(transactionManager, key.ProductId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CategoriesProducts index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetByCategoryId(System.Int32? _categoryId)
		{
			int count = -1;
			return GetByCategoryId(null,_categoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CategoriesProducts index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetByCategoryId(System.Int32? _categoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryId(null, _categoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CategoriesProducts index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetByCategoryId(TransactionManager transactionManager, System.Int32? _categoryId)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CategoriesProducts index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetByCategoryId(TransactionManager transactionManager, System.Int32? _categoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CategoriesProducts index.
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetByCategoryId(System.Int32? _categoryId, int start, int pageLength, out int count)
		{
			return GetByCategoryId(null, _categoryId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CategoriesProducts index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public abstract TList<Products> GetByCategoryId(TransactionManager transactionManager, System.Int32? _categoryId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Products index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Products"/> class.</returns>
		public Northwind.Entities.Products GetByProductId(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(null,_productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Products index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Products"/> class.</returns>
		public Northwind.Entities.Products GetByProductId(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Products index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Products"/> class.</returns>
		public Northwind.Entities.Products GetByProductId(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Products index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Products"/> class.</returns>
		public Northwind.Entities.Products GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductId(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Products index.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Products"/> class.</returns>
		public Northwind.Entities.Products GetByProductId(System.Int32 _productId, int start, int pageLength, out int count)
		{
			return GetByProductId(null, _productId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Products index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Products"/> class.</returns>
		public abstract Northwind.Entities.Products GetByProductId(TransactionManager transactionManager, System.Int32 _productId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ProductName index.
		/// </summary>
		/// <param name="_productName"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetByProductName(System.String _productName)
		{
			int count = -1;
			return GetByProductName(null,_productName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductName index.
		/// </summary>
		/// <param name="_productName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetByProductName(System.String _productName, int start, int pageLength)
		{
			int count = -1;
			return GetByProductName(null, _productName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetByProductName(TransactionManager transactionManager, System.String _productName)
		{
			int count = -1;
			return GetByProductName(transactionManager, _productName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetByProductName(TransactionManager transactionManager, System.String _productName, int start, int pageLength)
		{
			int count = -1;
			return GetByProductName(transactionManager, _productName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductName index.
		/// </summary>
		/// <param name="_productName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetByProductName(System.String _productName, int start, int pageLength, out int count)
		{
			return GetByProductName(null, _productName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ProductName index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public abstract TList<Products> GetByProductName(TransactionManager transactionManager, System.String _productName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key SupplierID index.
		/// </summary>
		/// <param name="_supplierId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetBySupplierId(System.Int32? _supplierId)
		{
			int count = -1;
			return GetBySupplierId(null,_supplierId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SupplierID index.
		/// </summary>
		/// <param name="_supplierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetBySupplierId(System.Int32? _supplierId, int start, int pageLength)
		{
			int count = -1;
			return GetBySupplierId(null, _supplierId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SupplierID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplierId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetBySupplierId(TransactionManager transactionManager, System.Int32? _supplierId)
		{
			int count = -1;
			return GetBySupplierId(transactionManager, _supplierId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SupplierID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetBySupplierId(TransactionManager transactionManager, System.Int32? _supplierId, int start, int pageLength)
		{
			int count = -1;
			return GetBySupplierId(transactionManager, _supplierId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the SupplierID index.
		/// </summary>
		/// <param name="_supplierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public TList<Products> GetBySupplierId(System.Int32? _supplierId, int start, int pageLength, out int count)
		{
			return GetBySupplierId(null, _supplierId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the SupplierID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Products&gt;"/> class.</returns>
		public abstract TList<Products> GetBySupplierId(TransactionManager transactionManager, System.Int32? _supplierId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Products&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Products&gt;"/></returns>
		public static TList<Products> Fill(IDataReader reader, TList<Products> rows, int start, int pageLength)
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
				
				Northwind.Entities.Products c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Products")
					.Append("|").Append((System.Int32)reader[((int)ProductsColumn.ProductId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Products>(
					key.ToString(), // EntityTrackingKey
					"Products",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Northwind.Entities.Products();
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
					c.ProductId = (System.Int32)reader[((int)ProductsColumn.ProductId - 1)];
					c.ProductName = (System.String)reader[((int)ProductsColumn.ProductName - 1)];
					c.SupplierId = (reader.IsDBNull(((int)ProductsColumn.SupplierId - 1)))?null:(System.Int32?)reader[((int)ProductsColumn.SupplierId - 1)];
					c.CategoryId = (reader.IsDBNull(((int)ProductsColumn.CategoryId - 1)))?null:(System.Int32?)reader[((int)ProductsColumn.CategoryId - 1)];
					c.QuantityPerUnit = (reader.IsDBNull(((int)ProductsColumn.QuantityPerUnit - 1)))?null:(System.String)reader[((int)ProductsColumn.QuantityPerUnit - 1)];
					c.UnitPrice = (reader.IsDBNull(((int)ProductsColumn.UnitPrice - 1)))?null:(System.Decimal?)reader[((int)ProductsColumn.UnitPrice - 1)];
					c.UnitsInStock = (reader.IsDBNull(((int)ProductsColumn.UnitsInStock - 1)))?null:(System.Int16?)reader[((int)ProductsColumn.UnitsInStock - 1)];
					c.UnitsOnOrder = (reader.IsDBNull(((int)ProductsColumn.UnitsOnOrder - 1)))?null:(System.Int16?)reader[((int)ProductsColumn.UnitsOnOrder - 1)];
					c.ReorderLevel = (reader.IsDBNull(((int)ProductsColumn.ReorderLevel - 1)))?null:(System.Int16?)reader[((int)ProductsColumn.ReorderLevel - 1)];
					c.Discontinued = (System.Boolean)reader[((int)ProductsColumn.Discontinued - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Products"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Products"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Northwind.Entities.Products entity)
		{
			if (!reader.Read()) return;
			
			entity.ProductId = (System.Int32)reader[((int)ProductsColumn.ProductId - 1)];
			entity.ProductName = (System.String)reader[((int)ProductsColumn.ProductName - 1)];
			entity.SupplierId = (reader.IsDBNull(((int)ProductsColumn.SupplierId - 1)))?null:(System.Int32?)reader[((int)ProductsColumn.SupplierId - 1)];
			entity.CategoryId = (reader.IsDBNull(((int)ProductsColumn.CategoryId - 1)))?null:(System.Int32?)reader[((int)ProductsColumn.CategoryId - 1)];
			entity.QuantityPerUnit = (reader.IsDBNull(((int)ProductsColumn.QuantityPerUnit - 1)))?null:(System.String)reader[((int)ProductsColumn.QuantityPerUnit - 1)];
			entity.UnitPrice = (reader.IsDBNull(((int)ProductsColumn.UnitPrice - 1)))?null:(System.Decimal?)reader[((int)ProductsColumn.UnitPrice - 1)];
			entity.UnitsInStock = (reader.IsDBNull(((int)ProductsColumn.UnitsInStock - 1)))?null:(System.Int16?)reader[((int)ProductsColumn.UnitsInStock - 1)];
			entity.UnitsOnOrder = (reader.IsDBNull(((int)ProductsColumn.UnitsOnOrder - 1)))?null:(System.Int16?)reader[((int)ProductsColumn.UnitsOnOrder - 1)];
			entity.ReorderLevel = (reader.IsDBNull(((int)ProductsColumn.ReorderLevel - 1)))?null:(System.Int16?)reader[((int)ProductsColumn.ReorderLevel - 1)];
			entity.Discontinued = (System.Boolean)reader[((int)ProductsColumn.Discontinued - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Products"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Products"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Northwind.Entities.Products entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductId = (System.Int32)dataRow["ProductID"];
			entity.ProductName = (System.String)dataRow["ProductName"];
			entity.SupplierId = Convert.IsDBNull(dataRow["SupplierID"]) ? null : (System.Int32?)dataRow["SupplierID"];
			entity.CategoryId = Convert.IsDBNull(dataRow["CategoryID"]) ? null : (System.Int32?)dataRow["CategoryID"];
			entity.QuantityPerUnit = Convert.IsDBNull(dataRow["QuantityPerUnit"]) ? null : (System.String)dataRow["QuantityPerUnit"];
			entity.UnitPrice = Convert.IsDBNull(dataRow["UnitPrice"]) ? null : (System.Decimal?)dataRow["UnitPrice"];
			entity.UnitsInStock = Convert.IsDBNull(dataRow["UnitsInStock"]) ? null : (System.Int16?)dataRow["UnitsInStock"];
			entity.UnitsOnOrder = Convert.IsDBNull(dataRow["UnitsOnOrder"]) ? null : (System.Int16?)dataRow["UnitsOnOrder"];
			entity.ReorderLevel = Convert.IsDBNull(dataRow["ReorderLevel"]) ? null : (System.Int16?)dataRow["ReorderLevel"];
			entity.Discontinued = (System.Boolean)dataRow["Discontinued"];
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
		/// <param name="entity">The <see cref="Northwind.Entities.Products"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Northwind.Entities.Products Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Northwind.Entities.Products entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CategoryIdSource	
			if (CanDeepLoad(entity, "Categories|CategoryIdSource", deepLoadType, innerList) 
				&& entity.CategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CategoryId ?? (int)0);
				Categories tmpEntity = EntityManager.LocateEntity<Categories>(EntityLocator.ConstructKeyFromPkItems(typeof(Categories), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CategoryIdSource = tmpEntity;
				else
					entity.CategoryIdSource = DataRepository.CategoriesProvider.GetByCategoryId(transactionManager, (entity.CategoryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CategoriesProvider.DeepLoad(transactionManager, entity.CategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CategoryIdSource

			#region SupplierIdSource	
			if (CanDeepLoad(entity, "Suppliers|SupplierIdSource", deepLoadType, innerList) 
				&& entity.SupplierIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SupplierId ?? (int)0);
				Suppliers tmpEntity = EntityManager.LocateEntity<Suppliers>(EntityLocator.ConstructKeyFromPkItems(typeof(Suppliers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SupplierIdSource = tmpEntity;
				else
					entity.SupplierIdSource = DataRepository.SuppliersProvider.GetBySupplierId(transactionManager, (entity.SupplierId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SupplierIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SupplierIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SuppliersProvider.DeepLoad(transactionManager, entity.SupplierIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SupplierIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByProductId methods when available
			
			#region OrderDetailsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<OrderDetails>|OrderDetailsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrderDetailsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.OrderDetailsCollection = DataRepository.OrderDetailsProvider.GetByProductId(transactionManager, entity.ProductId);

				if (deep && entity.OrderDetailsCollection.Count > 0)
				{
					deepHandles.Add("OrderDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<OrderDetails>) DataRepository.OrderDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.OrderDetailsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region OrderIdOrdersCollection_From_OrderDetails
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Orders>|OrderIdOrdersCollection_From_OrderDetails", deepLoadType, innerList))
			{
				entity.OrderIdOrdersCollection_From_OrderDetails = DataRepository.OrdersProvider.GetByProductIdFromOrderDetails(transactionManager, entity.ProductId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrderIdOrdersCollection_From_OrderDetails' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.OrderIdOrdersCollection_From_OrderDetails != null)
				{
					deepHandles.Add("OrderIdOrdersCollection_From_OrderDetails",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Orders >) DataRepository.OrdersProvider.DeepLoad,
						new object[] { transactionManager, entity.OrderIdOrdersCollection_From_OrderDetails, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Northwind.Entities.Products object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Northwind.Entities.Products instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Northwind.Entities.Products Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Northwind.Entities.Products entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CategoryIdSource
			if (CanDeepSave(entity, "Categories|CategoryIdSource", deepSaveType, innerList) 
				&& entity.CategoryIdSource != null)
			{
				DataRepository.CategoriesProvider.Save(transactionManager, entity.CategoryIdSource);
				entity.CategoryId = entity.CategoryIdSource.CategoryId;
			}
			#endregion 
			
			#region SupplierIdSource
			if (CanDeepSave(entity, "Suppliers|SupplierIdSource", deepSaveType, innerList) 
				&& entity.SupplierIdSource != null)
			{
				DataRepository.SuppliersProvider.Save(transactionManager, entity.SupplierIdSource);
				entity.SupplierId = entity.SupplierIdSource.SupplierId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region OrderIdOrdersCollection_From_OrderDetails>
			if (CanDeepSave(entity.OrderIdOrdersCollection_From_OrderDetails, "List<Orders>|OrderIdOrdersCollection_From_OrderDetails", deepSaveType, innerList))
			{
				if (entity.OrderIdOrdersCollection_From_OrderDetails.Count > 0 || entity.OrderIdOrdersCollection_From_OrderDetails.DeletedItems.Count > 0)
				{
					DataRepository.OrdersProvider.Save(transactionManager, entity.OrderIdOrdersCollection_From_OrderDetails); 
					deepHandles.Add("OrderIdOrdersCollection_From_OrderDetails",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Orders>) DataRepository.OrdersProvider.DeepSave,
						new object[] { transactionManager, entity.OrderIdOrdersCollection_From_OrderDetails, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<OrderDetails>
				if (CanDeepSave(entity.OrderDetailsCollection, "List<OrderDetails>|OrderDetailsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(OrderDetails child in entity.OrderDetailsCollection)
					{
						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
						}

						if(child.OrderIdSource != null)
						{
								child.OrderId = child.OrderIdSource.OrderId;
						}

					}

					if (entity.OrderDetailsCollection.Count > 0 || entity.OrderDetailsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.OrderDetailsProvider.Save(transactionManager, entity.OrderDetailsCollection);
						
						deepHandles.Add("OrderDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< OrderDetails >) DataRepository.OrderDetailsProvider.DeepSave,
							new object[] { transactionManager, entity.OrderDetailsCollection, deepSaveType, childTypes, innerList }
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
	
	#region ProductsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Northwind.Entities.Products</c>
	///</summary>
	public enum ProductsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Categories</c> at CategoryIdSource
		///</summary>
		[ChildEntityType(typeof(Categories))]
		Categories,
			
		///<summary>
		/// Composite Property for <c>Suppliers</c> at SupplierIdSource
		///</summary>
		[ChildEntityType(typeof(Suppliers))]
		Suppliers,
	
		///<summary>
		/// Collection of <c>Products</c> as OneToMany for OrderDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<OrderDetails>))]
		OrderDetailsCollection,

		///<summary>
		/// Collection of <c>Products</c> as ManyToMany for OrdersCollection_From_OrderDetails
		///</summary>
		[ChildEntityType(typeof(TList<Orders>))]
		OrderIdOrdersCollection_From_OrderDetails,
	}
	
	#endregion ProductsChildEntityTypes
	
	#region ProductsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProductsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Products"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsFilterBuilder : SqlFilterBuilder<ProductsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsFilterBuilder class.
		/// </summary>
		public ProductsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsFilterBuilder
	
	#region ProductsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProductsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Products"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsParameterBuilder : ParameterizedSqlFilterBuilder<ProductsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsParameterBuilder class.
		/// </summary>
		public ProductsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsParameterBuilder
	
	#region ProductsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProductsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Products"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductsSortBuilder : SqlSortBuilder<ProductsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsSqlSortBuilder class.
		/// </summary>
		public ProductsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductsSortBuilder
	
} // end namespace
