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
	/// This class is the base class for any <see cref="OrdersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrdersProviderBaseCore : EntityProviderBase<Northwind.Entities.Orders, Northwind.Entities.OrdersKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByProductIdFromOrderDetails
		
		/// <summary>
		///		Gets Orders objects from the datasource by ProductID in the
		///		Order Details table. Table Orders is related to table Products
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="_productId"></param>
		/// <returns>Returns a typed collection of Orders objects.</returns>
		public TList<Orders> GetByProductIdFromOrderDetails(System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromOrderDetails(null,_productId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Northwind.Entities.Orders objects from the datasource by ProductID in the
		///		Order Details table. Table Orders is related to table Products
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Orders objects.</returns>
		public TList<Orders> GetByProductIdFromOrderDetails(System.Int32 _productId, int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromOrderDetails(null, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Orders objects from the datasource by ProductID in the
		///		Order Details table. Table Orders is related to table Products
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Orders objects.</returns>
		public TList<Orders> GetByProductIdFromOrderDetails(TransactionManager transactionManager, System.Int32 _productId)
		{
			int count = -1;
			return GetByProductIdFromOrderDetails(transactionManager, _productId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Orders objects from the datasource by ProductID in the
		///		Order Details table. Table Orders is related to table Products
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Orders objects.</returns>
		public TList<Orders> GetByProductIdFromOrderDetails(TransactionManager transactionManager, System.Int32 _productId,int start, int pageLength)
		{
			int count = -1;
			return GetByProductIdFromOrderDetails(transactionManager, _productId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Orders objects from the datasource by ProductID in the
		///		Order Details table. Table Orders is related to table Products
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="_productId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Orders objects.</returns>
		public TList<Orders> GetByProductIdFromOrderDetails(System.Int32 _productId,int start, int pageLength, out int count)
		{
			
			return GetByProductIdFromOrderDetails(null, _productId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Orders objects from the datasource by ProductID in the
		///		Order Details table. Table Orders is related to table Products
		///		through the (M:N) relationship defined in the Order Details table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_productId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Orders objects.</returns>
		public abstract TList<Orders> GetByProductIdFromOrderDetails(TransactionManager transactionManager,System.Int32 _productId, int start, int pageLength, out int count);
		
		#endregion GetByProductIdFromOrderDetails
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Northwind.Entities.OrdersKey key)
		{
			return Delete(transactionManager, key.OrderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_orderId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _orderId)
		{
			return Delete(null, _orderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _orderId);		
		
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
		public override Northwind.Entities.Orders Get(TransactionManager transactionManager, Northwind.Entities.OrdersKey key, int start, int pageLength)
		{
			return GetByOrderId(transactionManager, key.OrderId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByCustomerId(System.String _customerId)
		{
			int count = -1;
			return GetByCustomerId(null,_customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByCustomerId(System.String _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByCustomerId(TransactionManager transactionManager, System.String _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByCustomerId(TransactionManager transactionManager, System.String _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerID index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByCustomerId(System.String _customerId, int start, int pageLength, out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public abstract TList<Orders> GetByCustomerId(TransactionManager transactionManager, System.String _customerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key EmployeeID index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByEmployeeId(System.Int32? _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(null,_employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmployeeID index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByEmployeeId(System.Int32? _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the EmployeeID index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByEmployeeId(System.Int32? _employeeId, int start, int pageLength, out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the EmployeeID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public abstract TList<Orders> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key OrderDate index.
		/// </summary>
		/// <param name="_orderDate"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByOrderDate(System.DateTime? _orderDate)
		{
			int count = -1;
			return GetByOrderDate(null,_orderDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the OrderDate index.
		/// </summary>
		/// <param name="_orderDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByOrderDate(System.DateTime? _orderDate, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderDate(null, _orderDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the OrderDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByOrderDate(TransactionManager transactionManager, System.DateTime? _orderDate)
		{
			int count = -1;
			return GetByOrderDate(transactionManager, _orderDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the OrderDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByOrderDate(TransactionManager transactionManager, System.DateTime? _orderDate, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderDate(transactionManager, _orderDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the OrderDate index.
		/// </summary>
		/// <param name="_orderDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByOrderDate(System.DateTime? _orderDate, int start, int pageLength, out int count)
		{
			return GetByOrderDate(null, _orderDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the OrderDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public abstract TList<Orders> GetByOrderDate(TransactionManager transactionManager, System.DateTime? _orderDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Orders index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Orders"/> class.</returns>
		public Northwind.Entities.Orders GetByOrderId(System.Int32 _orderId)
		{
			int count = -1;
			return GetByOrderId(null,_orderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Orders index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Orders"/> class.</returns>
		public Northwind.Entities.Orders GetByOrderId(System.Int32 _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(null, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Orders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Orders"/> class.</returns>
		public Northwind.Entities.Orders GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Orders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Orders"/> class.</returns>
		public Northwind.Entities.Orders GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Orders index.
		/// </summary>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Orders"/> class.</returns>
		public Northwind.Entities.Orders GetByOrderId(System.Int32 _orderId, int start, int pageLength, out int count)
		{
			return GetByOrderId(null, _orderId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Orders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Orders"/> class.</returns>
		public abstract Northwind.Entities.Orders GetByOrderId(TransactionManager transactionManager, System.Int32 _orderId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ShippedDate index.
		/// </summary>
		/// <param name="_shippedDate"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShippedDate(System.DateTime? _shippedDate)
		{
			int count = -1;
			return GetByShippedDate(null,_shippedDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShippedDate index.
		/// </summary>
		/// <param name="_shippedDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShippedDate(System.DateTime? _shippedDate, int start, int pageLength)
		{
			int count = -1;
			return GetByShippedDate(null, _shippedDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShippedDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shippedDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShippedDate(TransactionManager transactionManager, System.DateTime? _shippedDate)
		{
			int count = -1;
			return GetByShippedDate(transactionManager, _shippedDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShippedDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shippedDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShippedDate(TransactionManager transactionManager, System.DateTime? _shippedDate, int start, int pageLength)
		{
			int count = -1;
			return GetByShippedDate(transactionManager, _shippedDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShippedDate index.
		/// </summary>
		/// <param name="_shippedDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShippedDate(System.DateTime? _shippedDate, int start, int pageLength, out int count)
		{
			return GetByShippedDate(null, _shippedDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ShippedDate index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shippedDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public abstract TList<Orders> GetByShippedDate(TransactionManager transactionManager, System.DateTime? _shippedDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ShippersOrders index.
		/// </summary>
		/// <param name="_shipVia"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShipVia(System.Int32? _shipVia)
		{
			int count = -1;
			return GetByShipVia(null,_shipVia, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShippersOrders index.
		/// </summary>
		/// <param name="_shipVia"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShipVia(System.Int32? _shipVia, int start, int pageLength)
		{
			int count = -1;
			return GetByShipVia(null, _shipVia, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShippersOrders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipVia"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShipVia(TransactionManager transactionManager, System.Int32? _shipVia)
		{
			int count = -1;
			return GetByShipVia(transactionManager, _shipVia, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShippersOrders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipVia"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShipVia(TransactionManager transactionManager, System.Int32? _shipVia, int start, int pageLength)
		{
			int count = -1;
			return GetByShipVia(transactionManager, _shipVia, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShippersOrders index.
		/// </summary>
		/// <param name="_shipVia"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShipVia(System.Int32? _shipVia, int start, int pageLength, out int count)
		{
			return GetByShipVia(null, _shipVia, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ShippersOrders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipVia"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public abstract TList<Orders> GetByShipVia(TransactionManager transactionManager, System.Int32? _shipVia, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ShipPostalCode index.
		/// </summary>
		/// <param name="_shipPostalCode"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShipPostalCode(System.String _shipPostalCode)
		{
			int count = -1;
			return GetByShipPostalCode(null,_shipPostalCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShipPostalCode index.
		/// </summary>
		/// <param name="_shipPostalCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShipPostalCode(System.String _shipPostalCode, int start, int pageLength)
		{
			int count = -1;
			return GetByShipPostalCode(null, _shipPostalCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShipPostalCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipPostalCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShipPostalCode(TransactionManager transactionManager, System.String _shipPostalCode)
		{
			int count = -1;
			return GetByShipPostalCode(transactionManager, _shipPostalCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShipPostalCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipPostalCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShipPostalCode(TransactionManager transactionManager, System.String _shipPostalCode, int start, int pageLength)
		{
			int count = -1;
			return GetByShipPostalCode(transactionManager, _shipPostalCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ShipPostalCode index.
		/// </summary>
		/// <param name="_shipPostalCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public TList<Orders> GetByShipPostalCode(System.String _shipPostalCode, int start, int pageLength, out int count)
		{
			return GetByShipPostalCode(null, _shipPostalCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ShipPostalCode index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipPostalCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Orders&gt;"/> class.</returns>
		public abstract TList<Orders> GetByShipPostalCode(TransactionManager transactionManager, System.String _shipPostalCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Orders&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Orders&gt;"/></returns>
		public static TList<Orders> Fill(IDataReader reader, TList<Orders> rows, int start, int pageLength)
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
				
				Northwind.Entities.Orders c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Orders")
					.Append("|").Append((System.Int32)reader[((int)OrdersColumn.OrderId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Orders>(
					key.ToString(), // EntityTrackingKey
					"Orders",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Northwind.Entities.Orders();
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
					c.CustomerId = reader.IsDBNull(reader.GetOrdinal("CustomerID")) ? null : (System.String)reader["CustomerID"];
					c.EmployeeId = reader.IsDBNull(reader.GetOrdinal("EmployeeID")) ? null : (System.Int32?)reader["EmployeeID"];
					c.OrderDate = reader.IsDBNull(reader.GetOrdinal("OrderDate")) ? null : (System.DateTime?)reader["OrderDate"];
					c.RequiredDate = reader.IsDBNull(reader.GetOrdinal("RequiredDate")) ? null : (System.DateTime?)reader["RequiredDate"];
					c.ShippedDate = reader.IsDBNull(reader.GetOrdinal("ShippedDate")) ? null : (System.DateTime?)reader["ShippedDate"];
					c.ShipVia = reader.IsDBNull(reader.GetOrdinal("ShipVia")) ? null : (System.Int32?)reader["ShipVia"];
					c.Freight = reader.IsDBNull(reader.GetOrdinal("Freight")) ? null : (System.Decimal?)reader["Freight"];
					c.ShipName = reader.IsDBNull(reader.GetOrdinal("ShipName")) ? null : (System.String)reader["ShipName"];
					c.ShipAddress = reader.IsDBNull(reader.GetOrdinal("ShipAddress")) ? null : (System.String)reader["ShipAddress"];
					c.ShipCity = reader.IsDBNull(reader.GetOrdinal("ShipCity")) ? null : (System.String)reader["ShipCity"];
					c.ShipRegion = reader.IsDBNull(reader.GetOrdinal("ShipRegion")) ? null : (System.String)reader["ShipRegion"];
					c.ShipPostalCode = reader.IsDBNull(reader.GetOrdinal("ShipPostalCode")) ? null : (System.String)reader["ShipPostalCode"];
					c.ShipCountry = reader.IsDBNull(reader.GetOrdinal("ShipCountry")) ? null : (System.String)reader["ShipCountry"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Orders"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Orders"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Northwind.Entities.Orders entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderId = (System.Int32)reader["OrderID"];
			entity.CustomerId = reader.IsDBNull(reader.GetOrdinal("CustomerID")) ? null : (System.String)reader["CustomerID"];
			entity.EmployeeId = reader.IsDBNull(reader.GetOrdinal("EmployeeID")) ? null : (System.Int32?)reader["EmployeeID"];
			entity.OrderDate = reader.IsDBNull(reader.GetOrdinal("OrderDate")) ? null : (System.DateTime?)reader["OrderDate"];
			entity.RequiredDate = reader.IsDBNull(reader.GetOrdinal("RequiredDate")) ? null : (System.DateTime?)reader["RequiredDate"];
			entity.ShippedDate = reader.IsDBNull(reader.GetOrdinal("ShippedDate")) ? null : (System.DateTime?)reader["ShippedDate"];
			entity.ShipVia = reader.IsDBNull(reader.GetOrdinal("ShipVia")) ? null : (System.Int32?)reader["ShipVia"];
			entity.Freight = reader.IsDBNull(reader.GetOrdinal("Freight")) ? null : (System.Decimal?)reader["Freight"];
			entity.ShipName = reader.IsDBNull(reader.GetOrdinal("ShipName")) ? null : (System.String)reader["ShipName"];
			entity.ShipAddress = reader.IsDBNull(reader.GetOrdinal("ShipAddress")) ? null : (System.String)reader["ShipAddress"];
			entity.ShipCity = reader.IsDBNull(reader.GetOrdinal("ShipCity")) ? null : (System.String)reader["ShipCity"];
			entity.ShipRegion = reader.IsDBNull(reader.GetOrdinal("ShipRegion")) ? null : (System.String)reader["ShipRegion"];
			entity.ShipPostalCode = reader.IsDBNull(reader.GetOrdinal("ShipPostalCode")) ? null : (System.String)reader["ShipPostalCode"];
			entity.ShipCountry = reader.IsDBNull(reader.GetOrdinal("ShipCountry")) ? null : (System.String)reader["ShipCountry"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Orders"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Orders"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Northwind.Entities.Orders entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderId = (System.Int32)dataRow["OrderID"];
			entity.CustomerId = Convert.IsDBNull(dataRow["CustomerID"]) ? null : (System.String)dataRow["CustomerID"];
			entity.EmployeeId = Convert.IsDBNull(dataRow["EmployeeID"]) ? null : (System.Int32?)dataRow["EmployeeID"];
			entity.OrderDate = Convert.IsDBNull(dataRow["OrderDate"]) ? null : (System.DateTime?)dataRow["OrderDate"];
			entity.RequiredDate = Convert.IsDBNull(dataRow["RequiredDate"]) ? null : (System.DateTime?)dataRow["RequiredDate"];
			entity.ShippedDate = Convert.IsDBNull(dataRow["ShippedDate"]) ? null : (System.DateTime?)dataRow["ShippedDate"];
			entity.ShipVia = Convert.IsDBNull(dataRow["ShipVia"]) ? null : (System.Int32?)dataRow["ShipVia"];
			entity.Freight = Convert.IsDBNull(dataRow["Freight"]) ? null : (System.Decimal?)dataRow["Freight"];
			entity.ShipName = Convert.IsDBNull(dataRow["ShipName"]) ? null : (System.String)dataRow["ShipName"];
			entity.ShipAddress = Convert.IsDBNull(dataRow["ShipAddress"]) ? null : (System.String)dataRow["ShipAddress"];
			entity.ShipCity = Convert.IsDBNull(dataRow["ShipCity"]) ? null : (System.String)dataRow["ShipCity"];
			entity.ShipRegion = Convert.IsDBNull(dataRow["ShipRegion"]) ? null : (System.String)dataRow["ShipRegion"];
			entity.ShipPostalCode = Convert.IsDBNull(dataRow["ShipPostalCode"]) ? null : (System.String)dataRow["ShipPostalCode"];
			entity.ShipCountry = Convert.IsDBNull(dataRow["ShipCountry"]) ? null : (System.String)dataRow["ShipCountry"];
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
		/// <param name="entity">The <see cref="Northwind.Entities.Orders"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Northwind.Entities.Orders Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Northwind.Entities.Orders entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CustomerIdSource	
			if (CanDeepLoad(entity, "Customers|CustomerIdSource", deepLoadType, innerList) 
				&& entity.CustomerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CustomerId ?? string.Empty);
				Customers tmpEntity = EntityManager.LocateEntity<Customers>(EntityLocator.ConstructKeyFromPkItems(typeof(Customers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerIdSource = tmpEntity;
				else
					entity.CustomerIdSource = DataRepository.CustomersProvider.GetByCustomerId(transactionManager, (entity.CustomerId ?? string.Empty));		
				
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

			#region EmployeeIdSource	
			if (CanDeepLoad(entity, "Employees|EmployeeIdSource", deepLoadType, innerList) 
				&& entity.EmployeeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.EmployeeId ?? (int)0);
				Employees tmpEntity = EntityManager.LocateEntity<Employees>(EntityLocator.ConstructKeyFromPkItems(typeof(Employees), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EmployeeIdSource = tmpEntity;
				else
					entity.EmployeeIdSource = DataRepository.EmployeesProvider.GetByEmployeeId(transactionManager, (entity.EmployeeId ?? (int)0));		
				
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

			#region ShipViaSource	
			if (CanDeepLoad(entity, "Shippers|ShipViaSource", deepLoadType, innerList) 
				&& entity.ShipViaSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ShipVia ?? (int)0);
				Shippers tmpEntity = EntityManager.LocateEntity<Shippers>(EntityLocator.ConstructKeyFromPkItems(typeof(Shippers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ShipViaSource = tmpEntity;
				else
					entity.ShipViaSource = DataRepository.ShippersProvider.GetByShipperId(transactionManager, (entity.ShipVia ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ShipViaSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ShipViaSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ShippersProvider.DeepLoad(transactionManager, entity.ShipViaSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ShipViaSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByOrderId methods when available
			
			#region ProductIdProductsCollection_From_OrderDetails
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Products>|ProductIdProductsCollection_From_OrderDetails", deepLoadType, innerList))
			{
				entity.ProductIdProductsCollection_From_OrderDetails = DataRepository.ProductsProvider.GetByOrderIdFromOrderDetails(transactionManager, entity.OrderId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProductIdProductsCollection_From_OrderDetails' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ProductIdProductsCollection_From_OrderDetails != null)
				{
					deepHandles.Add("ProductIdProductsCollection_From_OrderDetails",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Products >) DataRepository.ProductsProvider.DeepLoad,
						new object[] { transactionManager, entity.ProductIdProductsCollection_From_OrderDetails, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region OrderDetailsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<OrderDetails>|OrderDetailsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrderDetailsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.OrderDetailsCollection = DataRepository.OrderDetailsProvider.GetByOrderId(transactionManager, entity.OrderId);

				if (deep && entity.OrderDetailsCollection.Count > 0)
				{
					deepHandles.Add("OrderDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<OrderDetails>) DataRepository.OrderDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.OrderDetailsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Northwind.Entities.Orders object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Northwind.Entities.Orders instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Northwind.Entities.Orders Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Northwind.Entities.Orders entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "Customers|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomersProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.CustomerId;
			}
			#endregion 
			
			#region EmployeeIdSource
			if (CanDeepSave(entity, "Employees|EmployeeIdSource", deepSaveType, innerList) 
				&& entity.EmployeeIdSource != null)
			{
				DataRepository.EmployeesProvider.Save(transactionManager, entity.EmployeeIdSource);
				entity.EmployeeId = entity.EmployeeIdSource.EmployeeId;
			}
			#endregion 
			
			#region ShipViaSource
			if (CanDeepSave(entity, "Shippers|ShipViaSource", deepSaveType, innerList) 
				&& entity.ShipViaSource != null)
			{
				DataRepository.ShippersProvider.Save(transactionManager, entity.ShipViaSource);
				entity.ShipVia = entity.ShipViaSource.ShipperId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region ProductIdProductsCollection_From_OrderDetails>
			if (CanDeepSave(entity.ProductIdProductsCollection_From_OrderDetails, "List<Products>|ProductIdProductsCollection_From_OrderDetails", deepSaveType, innerList))
			{
				if (entity.ProductIdProductsCollection_From_OrderDetails.Count > 0 || entity.ProductIdProductsCollection_From_OrderDetails.DeletedItems.Count > 0)
				{
					DataRepository.ProductsProvider.Save(transactionManager, entity.ProductIdProductsCollection_From_OrderDetails); 
					deepHandles.Add("ProductIdProductsCollection_From_OrderDetails",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Products>) DataRepository.ProductsProvider.DeepSave,
						new object[] { transactionManager, entity.ProductIdProductsCollection_From_OrderDetails, deepSaveType, childTypes, innerList }
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
						if(child.OrderIdSource != null)
						{
								child.OrderId = child.OrderIdSource.OrderId;
						}

						if(child.ProductIdSource != null)
						{
								child.ProductId = child.ProductIdSource.ProductId;
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
	
	#region OrdersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Northwind.Entities.Orders</c>
	///</summary>
	public enum OrdersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Customers</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customers))]
		Customers,
			
		///<summary>
		/// Composite Property for <c>Employees</c> at EmployeeIdSource
		///</summary>
		[ChildEntityType(typeof(Employees))]
		Employees,
			
		///<summary>
		/// Composite Property for <c>Shippers</c> at ShipViaSource
		///</summary>
		[ChildEntityType(typeof(Shippers))]
		Shippers,
	
		///<summary>
		/// Collection of <c>Orders</c> as ManyToMany for ProductsCollection_From_OrderDetails
		///</summary>
		[ChildEntityType(typeof(TList<Products>))]
		ProductIdProductsCollection_From_OrderDetails,

		///<summary>
		/// Collection of <c>Orders</c> as OneToMany for OrderDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<OrderDetails>))]
		OrderDetailsCollection,
	}
	
	#endregion OrdersChildEntityTypes
	
	#region OrdersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;OrdersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersFilterBuilder : SqlFilterBuilder<OrdersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersFilterBuilder class.
		/// </summary>
		public OrdersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersFilterBuilder
	
	#region OrdersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;OrdersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersParameterBuilder : ParameterizedSqlFilterBuilder<OrdersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersParameterBuilder class.
		/// </summary>
		public OrdersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersParameterBuilder
	
	#region OrdersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;OrdersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class OrdersSortBuilder : SqlSortBuilder<OrdersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersSqlSortBuilder class.
		/// </summary>
		public OrdersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion OrdersSortBuilder
	
} // end namespace
