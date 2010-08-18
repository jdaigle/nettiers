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
	/// This class is the base class for any <see cref="CustomersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomersProviderBaseCore : EntityProviderBase<Northwind.Entities.Customers, Northwind.Entities.CustomersKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByCustomerTypeIdFromCustomerCustomerDemo
		
		/// <summary>
		///		Gets Customers objects from the datasource by CustomerTypeID in the
		///		CustomerCustomerDemo table. Table Customers is related to table CustomerDemographics
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="_customerTypeId"></param>
		/// <returns>Returns a typed collection of Customers objects.</returns>
		public TList<Customers> GetByCustomerTypeIdFromCustomerCustomerDemo(System.String _customerTypeId)
		{
			int count = -1;
			return GetByCustomerTypeIdFromCustomerCustomerDemo(null,_customerTypeId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Northwind.Entities.Customers objects from the datasource by CustomerTypeID in the
		///		CustomerCustomerDemo table. Table Customers is related to table CustomerDemographics
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Customers objects.</returns>
		public TList<Customers> GetByCustomerTypeIdFromCustomerCustomerDemo(System.String _customerTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerTypeIdFromCustomerCustomerDemo(null, _customerTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Customers objects from the datasource by CustomerTypeID in the
		///		CustomerCustomerDemo table. Table Customers is related to table CustomerDemographics
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Customers objects.</returns>
		public TList<Customers> GetByCustomerTypeIdFromCustomerCustomerDemo(TransactionManager transactionManager, System.String _customerTypeId)
		{
			int count = -1;
			return GetByCustomerTypeIdFromCustomerCustomerDemo(transactionManager, _customerTypeId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Customers objects from the datasource by CustomerTypeID in the
		///		CustomerCustomerDemo table. Table Customers is related to table CustomerDemographics
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Customers objects.</returns>
		public TList<Customers> GetByCustomerTypeIdFromCustomerCustomerDemo(TransactionManager transactionManager, System.String _customerTypeId,int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerTypeIdFromCustomerCustomerDemo(transactionManager, _customerTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Customers objects from the datasource by CustomerTypeID in the
		///		CustomerCustomerDemo table. Table Customers is related to table CustomerDemographics
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="_customerTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Customers objects.</returns>
		public TList<Customers> GetByCustomerTypeIdFromCustomerCustomerDemo(System.String _customerTypeId,int start, int pageLength, out int count)
		{
			
			return GetByCustomerTypeIdFromCustomerCustomerDemo(null, _customerTypeId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Customers objects from the datasource by CustomerTypeID in the
		///		CustomerCustomerDemo table. Table Customers is related to table CustomerDemographics
		///		through the (M:N) relationship defined in the CustomerCustomerDemo table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_customerTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Customers objects.</returns>
		public abstract TList<Customers> GetByCustomerTypeIdFromCustomerCustomerDemo(TransactionManager transactionManager,System.String _customerTypeId, int start, int pageLength, out int count);
		
		#endregion GetByCustomerTypeIdFromCustomerCustomerDemo
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Northwind.Entities.CustomersKey key)
		{
			return Delete(transactionManager, key.CustomerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _customerId)
		{
			return Delete(null, _customerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _customerId);		
		
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
		public override Northwind.Entities.Customers Get(TransactionManager transactionManager, Northwind.Entities.CustomersKey key, int start, int pageLength)
		{
			return GetByCustomerId(transactionManager, key.CustomerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key City index.
		/// </summary>
		/// <param name="_city"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByCity(System.String _city)
		{
			int count = -1;
			return GetByCity(null,_city, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the City index.
		/// </summary>
		/// <param name="_city"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByCity(System.String _city, int start, int pageLength)
		{
			int count = -1;
			return GetByCity(null, _city, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the City index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_city"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByCity(TransactionManager transactionManager, System.String _city)
		{
			int count = -1;
			return GetByCity(transactionManager, _city, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the City index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_city"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByCity(TransactionManager transactionManager, System.String _city, int start, int pageLength)
		{
			int count = -1;
			return GetByCity(transactionManager, _city, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the City index.
		/// </summary>
		/// <param name="_city"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByCity(System.String _city, int start, int pageLength, out int count)
		{
			return GetByCity(null, _city, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the City index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_city"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public abstract TList<Customers> GetByCity(TransactionManager transactionManager, System.String _city, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key CompanyName index.
		/// </summary>
		/// <param name="_companyName"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByCompanyName(System.String _companyName)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByCompanyName(System.String _companyName, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByCompanyName(TransactionManager transactionManager, System.String _companyName)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByCompanyName(TransactionManager transactionManager, System.String _companyName, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByCompanyName(System.String _companyName, int start, int pageLength, out int count)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public abstract TList<Customers> GetByCompanyName(TransactionManager transactionManager, System.String _companyName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Customers index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Customers"/> class.</returns>
		public Northwind.Entities.Customers GetByCustomerId(System.String _customerId)
		{
			int count = -1;
			return GetByCustomerId(null,_customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customers index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Customers"/> class.</returns>
		public Northwind.Entities.Customers GetByCustomerId(System.String _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Customers"/> class.</returns>
		public Northwind.Entities.Customers GetByCustomerId(TransactionManager transactionManager, System.String _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Customers"/> class.</returns>
		public Northwind.Entities.Customers GetByCustomerId(TransactionManager transactionManager, System.String _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customers index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Customers"/> class.</returns>
		public Northwind.Entities.Customers GetByCustomerId(System.String _customerId, int start, int pageLength, out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Northwind.Entities.Customers"/> class.</returns>
		public abstract Northwind.Entities.Customers GetByCustomerId(TransactionManager transactionManager, System.String _customerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PostalCode index.
		/// </summary>
		/// <param name="_postalCode"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByPostalCode(System.String _postalCode)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByPostalCode(System.String _postalCode, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByPostalCode(TransactionManager transactionManager, System.String _postalCode)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByPostalCode(TransactionManager transactionManager, System.String _postalCode, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByPostalCode(System.String _postalCode, int start, int pageLength, out int count)
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
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public abstract TList<Customers> GetByPostalCode(TransactionManager transactionManager, System.String _postalCode, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key Region index.
		/// </summary>
		/// <param name="_region"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByRegion(System.String _region)
		{
			int count = -1;
			return GetByRegion(null,_region, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Region index.
		/// </summary>
		/// <param name="_region"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByRegion(System.String _region, int start, int pageLength)
		{
			int count = -1;
			return GetByRegion(null, _region, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Region index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_region"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByRegion(TransactionManager transactionManager, System.String _region)
		{
			int count = -1;
			return GetByRegion(transactionManager, _region, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Region index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_region"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByRegion(TransactionManager transactionManager, System.String _region, int start, int pageLength)
		{
			int count = -1;
			return GetByRegion(transactionManager, _region, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the Region index.
		/// </summary>
		/// <param name="_region"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public TList<Customers> GetByRegion(System.String _region, int start, int pageLength, out int count)
		{
			return GetByRegion(null, _region, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the Region index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_region"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;Customers&gt;"/> class.</returns>
		public abstract TList<Customers> GetByRegion(TransactionManager transactionManager, System.String _region, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Customers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Customers&gt;"/></returns>
		public static TList<Customers> Fill(IDataReader reader, TList<Customers> rows, int start, int pageLength)
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
				
				Northwind.Entities.Customers c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Customers")
					.Append("|").Append((System.String)reader[((int)CustomersColumn.CustomerId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Customers>(
					key.ToString(), // EntityTrackingKey
					"Customers",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Northwind.Entities.Customers();
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
					c.CustomerId = (System.String)reader["CustomerID"];
					c.OriginalCustomerId = c.CustomerId;
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
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Customers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Customers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Northwind.Entities.Customers entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomerId = (System.String)reader["CustomerID"];
			entity.OriginalCustomerId = (System.String)reader["CustomerID"];
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
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Northwind.Entities.Customers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Northwind.Entities.Customers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Northwind.Entities.Customers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (System.String)dataRow["CustomerID"];
			entity.OriginalCustomerId = (System.String)dataRow["CustomerID"];
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
		/// <param name="entity">The <see cref="Northwind.Entities.Customers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Northwind.Entities.Customers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Northwind.Entities.Customers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCustomerId methods when available
			
			#region OrdersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Orders>|OrdersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrdersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.OrdersCollection = DataRepository.OrdersProvider.GetByCustomerId(transactionManager, entity.CustomerId);

				if (deep && entity.OrdersCollection.Count > 0)
				{
					deepHandles.Add("OrdersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Orders>) DataRepository.OrdersProvider.DeepLoad,
						new object[] { transactionManager, entity.OrdersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<CustomerDemographics>|CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo", deepLoadType, innerList))
			{
				entity.CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo = DataRepository.CustomerDemographicsProvider.GetByCustomerIdFromCustomerCustomerDemo(transactionManager, entity.CustomerId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo != null)
				{
					deepHandles.Add("CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< CustomerDemographics >) DataRepository.CustomerDemographicsProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo, deep, deepLoadType, childTypes, innerList }
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

				entity.CustomerCustomerDemoCollection = DataRepository.CustomerCustomerDemoProvider.GetByCustomerId(transactionManager, entity.CustomerId);

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
		/// Deep Save the entire object graph of the Northwind.Entities.Customers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Northwind.Entities.Customers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Northwind.Entities.Customers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Northwind.Entities.Customers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo>
			if (CanDeepSave(entity.CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo, "List<CustomerDemographics>|CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo", deepSaveType, innerList))
			{
				if (entity.CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo.Count > 0 || entity.CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo.DeletedItems.Count > 0)
				{
					DataRepository.CustomerDemographicsProvider.Save(transactionManager, entity.CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo); 
					deepHandles.Add("CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<CustomerDemographics>) DataRepository.CustomerDemographicsProvider.DeepSave,
						new object[] { transactionManager, entity.CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo, deepSaveType, childTypes, innerList }
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
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.CustomerId;
						}
						else
						{
							child.CustomerId = entity.CustomerId;
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
				
	
			#region List<CustomerCustomerDemo>
				if (CanDeepSave(entity.CustomerCustomerDemoCollection, "List<CustomerCustomerDemo>|CustomerCustomerDemoCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerCustomerDemo child in entity.CustomerCustomerDemoCollection)
					{
						if(child.CustomerIdSource != null)
						{
								child.CustomerId = child.CustomerIdSource.CustomerId;
						}

						if(child.CustomerTypeIdSource != null)
						{
								child.CustomerTypeId = child.CustomerTypeIdSource.CustomerTypeId;
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
	
	#region CustomersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Northwind.Entities.Customers</c>
	///</summary>
	public enum CustomersChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Customers</c> as OneToMany for OrdersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Orders>))]
		OrdersCollection,

		///<summary>
		/// Collection of <c>Customers</c> as ManyToMany for CustomerDemographicsCollection_From_CustomerCustomerDemo
		///</summary>
		[ChildEntityType(typeof(TList<CustomerDemographics>))]
		CustomerTypeIdCustomerDemographicsCollection_From_CustomerCustomerDemo,

		///<summary>
		/// Collection of <c>Customers</c> as OneToMany for CustomerCustomerDemoCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerCustomerDemo>))]
		CustomerCustomerDemoCollection,
	}
	
	#endregion CustomersChildEntityTypes
	
	#region CustomersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomersFilterBuilder : SqlFilterBuilder<CustomersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersFilterBuilder class.
		/// </summary>
		public CustomersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomersFilterBuilder
	
	#region CustomersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomersParameterBuilder : ParameterizedSqlFilterBuilder<CustomersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersParameterBuilder class.
		/// </summary>
		public CustomersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomersParameterBuilder
	
	#region CustomersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CustomersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomersSortBuilder : SqlSortBuilder<CustomersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersSqlSortBuilder class.
		/// </summary>
		public CustomersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomersSortBuilder
	
} // end namespace
