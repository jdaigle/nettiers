#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Northwind.Entities;
using Northwind.Data;

#endregion

namespace Northwind.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="InvoicesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class InvoicesProviderBaseCore : EntityViewProviderBase<Invoices>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Invoices&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Invoices&gt;"/></returns>
		protected static VList&lt;Invoices&gt; Fill(DataSet dataSet, VList<Invoices> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Invoices>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Invoices&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Invoices>"/></returns>
		protected static VList&lt;Invoices&gt; Fill(DataTable dataTable, VList<Invoices> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Invoices c = new Invoices();
					c.ShipName = (Convert.IsDBNull(row["ShipName"]))?string.Empty:(System.String)row["ShipName"];
					c.ShipAddress = (Convert.IsDBNull(row["ShipAddress"]))?string.Empty:(System.String)row["ShipAddress"];
					c.ShipCity = (Convert.IsDBNull(row["ShipCity"]))?string.Empty:(System.String)row["ShipCity"];
					c.ShipRegion = (Convert.IsDBNull(row["ShipRegion"]))?string.Empty:(System.String)row["ShipRegion"];
					c.ShipPostalCode = (Convert.IsDBNull(row["ShipPostalCode"]))?string.Empty:(System.String)row["ShipPostalCode"];
					c.ShipCountry = (Convert.IsDBNull(row["ShipCountry"]))?string.Empty:(System.String)row["ShipCountry"];
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?string.Empty:(System.String)row["CustomerID"];
					c.CustomerName = (Convert.IsDBNull(row["CustomerName"]))?string.Empty:(System.String)row["CustomerName"];
					c.Address = (Convert.IsDBNull(row["Address"]))?string.Empty:(System.String)row["Address"];
					c.City = (Convert.IsDBNull(row["City"]))?string.Empty:(System.String)row["City"];
					c.Region = (Convert.IsDBNull(row["Region"]))?string.Empty:(System.String)row["Region"];
					c.PostalCode = (Convert.IsDBNull(row["PostalCode"]))?string.Empty:(System.String)row["PostalCode"];
					c.Country = (Convert.IsDBNull(row["Country"]))?string.Empty:(System.String)row["Country"];
					c.Salesperson = (Convert.IsDBNull(row["Salesperson"]))?string.Empty:(System.String)row["Salesperson"];
					c.OrderId = (Convert.IsDBNull(row["OrderID"]))?(int)0:(System.Int32)row["OrderID"];
					c.OrderDate = (Convert.IsDBNull(row["OrderDate"]))?DateTime.MinValue:(System.DateTime?)row["OrderDate"];
					c.RequiredDate = (Convert.IsDBNull(row["RequiredDate"]))?DateTime.MinValue:(System.DateTime?)row["RequiredDate"];
					c.ShippedDate = (Convert.IsDBNull(row["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)row["ShippedDate"];
					c.ShipperName = (Convert.IsDBNull(row["ShipperName"]))?string.Empty:(System.String)row["ShipperName"];
					c.ProductId = (Convert.IsDBNull(row["ProductID"]))?(int)0:(System.Int32)row["ProductID"];
					c.ProductName = (Convert.IsDBNull(row["ProductName"]))?string.Empty:(System.String)row["ProductName"];
					c.UnitPrice = (Convert.IsDBNull(row["UnitPrice"]))?0:(System.Decimal)row["UnitPrice"];
					c.Quantity = (Convert.IsDBNull(row["Quantity"]))?(short)0:(System.Int16)row["Quantity"];
					c.Discount = (Convert.IsDBNull(row["Discount"]))?0.0F:(System.Single)row["Discount"];
					c.ExtendedPrice = (Convert.IsDBNull(row["ExtendedPrice"]))?0:(System.Decimal?)row["ExtendedPrice"];
					c.Freight = (Convert.IsDBNull(row["Freight"]))?0:(System.Decimal?)row["Freight"];
					c.AcceptChanges();
					rows.Add(c);
					pagelen -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		*/	
						
		///<summary>
		/// Fill an <see cref="VList&lt;Invoices&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Invoices&gt;"/></returns>
		protected VList<Invoices> Fill(IDataReader reader, VList<Invoices> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Invoices entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Invoices>("Invoices",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Invoices();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ShipName = (reader.IsDBNull(((int)InvoicesColumn.ShipName)))?null:(System.String)reader[((int)InvoicesColumn.ShipName)];
					//entity.ShipName = (Convert.IsDBNull(reader["ShipName"]))?string.Empty:(System.String)reader["ShipName"];
					entity.ShipAddress = (reader.IsDBNull(((int)InvoicesColumn.ShipAddress)))?null:(System.String)reader[((int)InvoicesColumn.ShipAddress)];
					//entity.ShipAddress = (Convert.IsDBNull(reader["ShipAddress"]))?string.Empty:(System.String)reader["ShipAddress"];
					entity.ShipCity = (reader.IsDBNull(((int)InvoicesColumn.ShipCity)))?null:(System.String)reader[((int)InvoicesColumn.ShipCity)];
					//entity.ShipCity = (Convert.IsDBNull(reader["ShipCity"]))?string.Empty:(System.String)reader["ShipCity"];
					entity.ShipRegion = (reader.IsDBNull(((int)InvoicesColumn.ShipRegion)))?null:(System.String)reader[((int)InvoicesColumn.ShipRegion)];
					//entity.ShipRegion = (Convert.IsDBNull(reader["ShipRegion"]))?string.Empty:(System.String)reader["ShipRegion"];
					entity.ShipPostalCode = (reader.IsDBNull(((int)InvoicesColumn.ShipPostalCode)))?null:(System.String)reader[((int)InvoicesColumn.ShipPostalCode)];
					//entity.ShipPostalCode = (Convert.IsDBNull(reader["ShipPostalCode"]))?string.Empty:(System.String)reader["ShipPostalCode"];
					entity.ShipCountry = (reader.IsDBNull(((int)InvoicesColumn.ShipCountry)))?null:(System.String)reader[((int)InvoicesColumn.ShipCountry)];
					//entity.ShipCountry = (Convert.IsDBNull(reader["ShipCountry"]))?string.Empty:(System.String)reader["ShipCountry"];
					entity.CustomerId = (reader.IsDBNull(((int)InvoicesColumn.CustomerId)))?null:(System.String)reader[((int)InvoicesColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?string.Empty:(System.String)reader["CustomerID"];
					entity.CustomerName = (System.String)reader[((int)InvoicesColumn.CustomerName)];
					//entity.CustomerName = (Convert.IsDBNull(reader["CustomerName"]))?string.Empty:(System.String)reader["CustomerName"];
					entity.Address = (reader.IsDBNull(((int)InvoicesColumn.Address)))?null:(System.String)reader[((int)InvoicesColumn.Address)];
					//entity.Address = (Convert.IsDBNull(reader["Address"]))?string.Empty:(System.String)reader["Address"];
					entity.City = (reader.IsDBNull(((int)InvoicesColumn.City)))?null:(System.String)reader[((int)InvoicesColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.Region = (reader.IsDBNull(((int)InvoicesColumn.Region)))?null:(System.String)reader[((int)InvoicesColumn.Region)];
					//entity.Region = (Convert.IsDBNull(reader["Region"]))?string.Empty:(System.String)reader["Region"];
					entity.PostalCode = (reader.IsDBNull(((int)InvoicesColumn.PostalCode)))?null:(System.String)reader[((int)InvoicesColumn.PostalCode)];
					//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
					entity.Country = (reader.IsDBNull(((int)InvoicesColumn.Country)))?null:(System.String)reader[((int)InvoicesColumn.Country)];
					//entity.Country = (Convert.IsDBNull(reader["Country"]))?string.Empty:(System.String)reader["Country"];
					entity.Salesperson = (System.String)reader[((int)InvoicesColumn.Salesperson)];
					//entity.Salesperson = (Convert.IsDBNull(reader["Salesperson"]))?string.Empty:(System.String)reader["Salesperson"];
					entity.OrderId = (System.Int32)reader[((int)InvoicesColumn.OrderId)];
					//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
					entity.OrderDate = (reader.IsDBNull(((int)InvoicesColumn.OrderDate)))?null:(System.DateTime?)reader[((int)InvoicesColumn.OrderDate)];
					//entity.OrderDate = (Convert.IsDBNull(reader["OrderDate"]))?DateTime.MinValue:(System.DateTime?)reader["OrderDate"];
					entity.RequiredDate = (reader.IsDBNull(((int)InvoicesColumn.RequiredDate)))?null:(System.DateTime?)reader[((int)InvoicesColumn.RequiredDate)];
					//entity.RequiredDate = (Convert.IsDBNull(reader["RequiredDate"]))?DateTime.MinValue:(System.DateTime?)reader["RequiredDate"];
					entity.ShippedDate = (reader.IsDBNull(((int)InvoicesColumn.ShippedDate)))?null:(System.DateTime?)reader[((int)InvoicesColumn.ShippedDate)];
					//entity.ShippedDate = (Convert.IsDBNull(reader["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)reader["ShippedDate"];
					entity.ShipperName = (System.String)reader[((int)InvoicesColumn.ShipperName)];
					//entity.ShipperName = (Convert.IsDBNull(reader["ShipperName"]))?string.Empty:(System.String)reader["ShipperName"];
					entity.ProductId = (System.Int32)reader[((int)InvoicesColumn.ProductId)];
					//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
					entity.ProductName = (System.String)reader[((int)InvoicesColumn.ProductName)];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					entity.UnitPrice = (System.Decimal)reader[((int)InvoicesColumn.UnitPrice)];
					//entity.UnitPrice = (Convert.IsDBNull(reader["UnitPrice"]))?0:(System.Decimal)reader["UnitPrice"];
					entity.Quantity = (System.Int16)reader[((int)InvoicesColumn.Quantity)];
					//entity.Quantity = (Convert.IsDBNull(reader["Quantity"]))?(short)0:(System.Int16)reader["Quantity"];
					entity.Discount = (System.Single)reader[((int)InvoicesColumn.Discount)];
					//entity.Discount = (Convert.IsDBNull(reader["Discount"]))?0.0F:(System.Single)reader["Discount"];
					entity.ExtendedPrice = (reader.IsDBNull(((int)InvoicesColumn.ExtendedPrice)))?null:(System.Decimal?)reader[((int)InvoicesColumn.ExtendedPrice)];
					//entity.ExtendedPrice = (Convert.IsDBNull(reader["ExtendedPrice"]))?0:(System.Decimal?)reader["ExtendedPrice"];
					entity.Freight = (reader.IsDBNull(((int)InvoicesColumn.Freight)))?null:(System.Decimal?)reader[((int)InvoicesColumn.Freight)];
					//entity.Freight = (Convert.IsDBNull(reader["Freight"]))?0:(System.Decimal?)reader["Freight"];
					entity.AcceptChanges();
					entity.SuppressEntityEvents = false;
					
					rows.Add(entity);
					pageLength -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="Invoices"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Invoices"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Invoices entity)
		{
			reader.Read();
			entity.ShipName = (reader.IsDBNull(((int)InvoicesColumn.ShipName)))?null:(System.String)reader[((int)InvoicesColumn.ShipName)];
			//entity.ShipName = (Convert.IsDBNull(reader["ShipName"]))?string.Empty:(System.String)reader["ShipName"];
			entity.ShipAddress = (reader.IsDBNull(((int)InvoicesColumn.ShipAddress)))?null:(System.String)reader[((int)InvoicesColumn.ShipAddress)];
			//entity.ShipAddress = (Convert.IsDBNull(reader["ShipAddress"]))?string.Empty:(System.String)reader["ShipAddress"];
			entity.ShipCity = (reader.IsDBNull(((int)InvoicesColumn.ShipCity)))?null:(System.String)reader[((int)InvoicesColumn.ShipCity)];
			//entity.ShipCity = (Convert.IsDBNull(reader["ShipCity"]))?string.Empty:(System.String)reader["ShipCity"];
			entity.ShipRegion = (reader.IsDBNull(((int)InvoicesColumn.ShipRegion)))?null:(System.String)reader[((int)InvoicesColumn.ShipRegion)];
			//entity.ShipRegion = (Convert.IsDBNull(reader["ShipRegion"]))?string.Empty:(System.String)reader["ShipRegion"];
			entity.ShipPostalCode = (reader.IsDBNull(((int)InvoicesColumn.ShipPostalCode)))?null:(System.String)reader[((int)InvoicesColumn.ShipPostalCode)];
			//entity.ShipPostalCode = (Convert.IsDBNull(reader["ShipPostalCode"]))?string.Empty:(System.String)reader["ShipPostalCode"];
			entity.ShipCountry = (reader.IsDBNull(((int)InvoicesColumn.ShipCountry)))?null:(System.String)reader[((int)InvoicesColumn.ShipCountry)];
			//entity.ShipCountry = (Convert.IsDBNull(reader["ShipCountry"]))?string.Empty:(System.String)reader["ShipCountry"];
			entity.CustomerId = (reader.IsDBNull(((int)InvoicesColumn.CustomerId)))?null:(System.String)reader[((int)InvoicesColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?string.Empty:(System.String)reader["CustomerID"];
			entity.CustomerName = (System.String)reader[((int)InvoicesColumn.CustomerName)];
			//entity.CustomerName = (Convert.IsDBNull(reader["CustomerName"]))?string.Empty:(System.String)reader["CustomerName"];
			entity.Address = (reader.IsDBNull(((int)InvoicesColumn.Address)))?null:(System.String)reader[((int)InvoicesColumn.Address)];
			//entity.Address = (Convert.IsDBNull(reader["Address"]))?string.Empty:(System.String)reader["Address"];
			entity.City = (reader.IsDBNull(((int)InvoicesColumn.City)))?null:(System.String)reader[((int)InvoicesColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.Region = (reader.IsDBNull(((int)InvoicesColumn.Region)))?null:(System.String)reader[((int)InvoicesColumn.Region)];
			//entity.Region = (Convert.IsDBNull(reader["Region"]))?string.Empty:(System.String)reader["Region"];
			entity.PostalCode = (reader.IsDBNull(((int)InvoicesColumn.PostalCode)))?null:(System.String)reader[((int)InvoicesColumn.PostalCode)];
			//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
			entity.Country = (reader.IsDBNull(((int)InvoicesColumn.Country)))?null:(System.String)reader[((int)InvoicesColumn.Country)];
			//entity.Country = (Convert.IsDBNull(reader["Country"]))?string.Empty:(System.String)reader["Country"];
			entity.Salesperson = (System.String)reader[((int)InvoicesColumn.Salesperson)];
			//entity.Salesperson = (Convert.IsDBNull(reader["Salesperson"]))?string.Empty:(System.String)reader["Salesperson"];
			entity.OrderId = (System.Int32)reader[((int)InvoicesColumn.OrderId)];
			//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
			entity.OrderDate = (reader.IsDBNull(((int)InvoicesColumn.OrderDate)))?null:(System.DateTime?)reader[((int)InvoicesColumn.OrderDate)];
			//entity.OrderDate = (Convert.IsDBNull(reader["OrderDate"]))?DateTime.MinValue:(System.DateTime?)reader["OrderDate"];
			entity.RequiredDate = (reader.IsDBNull(((int)InvoicesColumn.RequiredDate)))?null:(System.DateTime?)reader[((int)InvoicesColumn.RequiredDate)];
			//entity.RequiredDate = (Convert.IsDBNull(reader["RequiredDate"]))?DateTime.MinValue:(System.DateTime?)reader["RequiredDate"];
			entity.ShippedDate = (reader.IsDBNull(((int)InvoicesColumn.ShippedDate)))?null:(System.DateTime?)reader[((int)InvoicesColumn.ShippedDate)];
			//entity.ShippedDate = (Convert.IsDBNull(reader["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)reader["ShippedDate"];
			entity.ShipperName = (System.String)reader[((int)InvoicesColumn.ShipperName)];
			//entity.ShipperName = (Convert.IsDBNull(reader["ShipperName"]))?string.Empty:(System.String)reader["ShipperName"];
			entity.ProductId = (System.Int32)reader[((int)InvoicesColumn.ProductId)];
			//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
			entity.ProductName = (System.String)reader[((int)InvoicesColumn.ProductName)];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			entity.UnitPrice = (System.Decimal)reader[((int)InvoicesColumn.UnitPrice)];
			//entity.UnitPrice = (Convert.IsDBNull(reader["UnitPrice"]))?0:(System.Decimal)reader["UnitPrice"];
			entity.Quantity = (System.Int16)reader[((int)InvoicesColumn.Quantity)];
			//entity.Quantity = (Convert.IsDBNull(reader["Quantity"]))?(short)0:(System.Int16)reader["Quantity"];
			entity.Discount = (System.Single)reader[((int)InvoicesColumn.Discount)];
			//entity.Discount = (Convert.IsDBNull(reader["Discount"]))?0.0F:(System.Single)reader["Discount"];
			entity.ExtendedPrice = (reader.IsDBNull(((int)InvoicesColumn.ExtendedPrice)))?null:(System.Decimal?)reader[((int)InvoicesColumn.ExtendedPrice)];
			//entity.ExtendedPrice = (Convert.IsDBNull(reader["ExtendedPrice"]))?0:(System.Decimal?)reader["ExtendedPrice"];
			entity.Freight = (reader.IsDBNull(((int)InvoicesColumn.Freight)))?null:(System.Decimal?)reader[((int)InvoicesColumn.Freight)];
			//entity.Freight = (Convert.IsDBNull(reader["Freight"]))?0:(System.Decimal?)reader["Freight"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Invoices"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Invoices"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Invoices entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ShipName = (Convert.IsDBNull(dataRow["ShipName"]))?string.Empty:(System.String)dataRow["ShipName"];
			entity.ShipAddress = (Convert.IsDBNull(dataRow["ShipAddress"]))?string.Empty:(System.String)dataRow["ShipAddress"];
			entity.ShipCity = (Convert.IsDBNull(dataRow["ShipCity"]))?string.Empty:(System.String)dataRow["ShipCity"];
			entity.ShipRegion = (Convert.IsDBNull(dataRow["ShipRegion"]))?string.Empty:(System.String)dataRow["ShipRegion"];
			entity.ShipPostalCode = (Convert.IsDBNull(dataRow["ShipPostalCode"]))?string.Empty:(System.String)dataRow["ShipPostalCode"];
			entity.ShipCountry = (Convert.IsDBNull(dataRow["ShipCountry"]))?string.Empty:(System.String)dataRow["ShipCountry"];
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?string.Empty:(System.String)dataRow["CustomerID"];
			entity.CustomerName = (Convert.IsDBNull(dataRow["CustomerName"]))?string.Empty:(System.String)dataRow["CustomerName"];
			entity.Address = (Convert.IsDBNull(dataRow["Address"]))?string.Empty:(System.String)dataRow["Address"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?string.Empty:(System.String)dataRow["City"];
			entity.Region = (Convert.IsDBNull(dataRow["Region"]))?string.Empty:(System.String)dataRow["Region"];
			entity.PostalCode = (Convert.IsDBNull(dataRow["PostalCode"]))?string.Empty:(System.String)dataRow["PostalCode"];
			entity.Country = (Convert.IsDBNull(dataRow["Country"]))?string.Empty:(System.String)dataRow["Country"];
			entity.Salesperson = (Convert.IsDBNull(dataRow["Salesperson"]))?string.Empty:(System.String)dataRow["Salesperson"];
			entity.OrderId = (Convert.IsDBNull(dataRow["OrderID"]))?(int)0:(System.Int32)dataRow["OrderID"];
			entity.OrderDate = (Convert.IsDBNull(dataRow["OrderDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["OrderDate"];
			entity.RequiredDate = (Convert.IsDBNull(dataRow["RequiredDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["RequiredDate"];
			entity.ShippedDate = (Convert.IsDBNull(dataRow["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["ShippedDate"];
			entity.ShipperName = (Convert.IsDBNull(dataRow["ShipperName"]))?string.Empty:(System.String)dataRow["ShipperName"];
			entity.ProductId = (Convert.IsDBNull(dataRow["ProductID"]))?(int)0:(System.Int32)dataRow["ProductID"];
			entity.ProductName = (Convert.IsDBNull(dataRow["ProductName"]))?string.Empty:(System.String)dataRow["ProductName"];
			entity.UnitPrice = (Convert.IsDBNull(dataRow["UnitPrice"]))?0:(System.Decimal)dataRow["UnitPrice"];
			entity.Quantity = (Convert.IsDBNull(dataRow["Quantity"]))?(short)0:(System.Int16)dataRow["Quantity"];
			entity.Discount = (Convert.IsDBNull(dataRow["Discount"]))?0.0F:(System.Single)dataRow["Discount"];
			entity.ExtendedPrice = (Convert.IsDBNull(dataRow["ExtendedPrice"]))?0:(System.Decimal?)dataRow["ExtendedPrice"];
			entity.Freight = (Convert.IsDBNull(dataRow["Freight"]))?0:(System.Decimal?)dataRow["Freight"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region InvoicesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Invoices"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoicesFilterBuilder : SqlFilterBuilder<InvoicesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoicesFilterBuilder class.
		/// </summary>
		public InvoicesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoicesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoicesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoicesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoicesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoicesFilterBuilder

	#region InvoicesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Invoices"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoicesParameterBuilder : ParameterizedSqlFilterBuilder<InvoicesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoicesParameterBuilder class.
		/// </summary>
		public InvoicesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoicesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoicesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoicesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoicesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoicesParameterBuilder
	
	#region InvoicesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Invoices"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class InvoicesSortBuilder : SqlSortBuilder<InvoicesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoicesSqlSortBuilder class.
		/// </summary>
		public InvoicesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion InvoicesSortBuilder

} // end namespace
