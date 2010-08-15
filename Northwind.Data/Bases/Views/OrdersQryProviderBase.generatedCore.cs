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
	/// This class is the base class for any <see cref="OrdersQryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class OrdersQryProviderBaseCore : EntityViewProviderBase<OrdersQry>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;OrdersQry&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;OrdersQry&gt;"/></returns>
		protected static VList&lt;OrdersQry&gt; Fill(DataSet dataSet, VList<OrdersQry> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<OrdersQry>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;OrdersQry&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<OrdersQry>"/></returns>
		protected static VList&lt;OrdersQry&gt; Fill(DataTable dataTable, VList<OrdersQry> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					OrdersQry c = new OrdersQry();
					c.OrderId = (Convert.IsDBNull(row["OrderID"]))?(int)0:(System.Int32)row["OrderID"];
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?string.Empty:(System.String)row["CustomerID"];
					c.EmployeeId = (Convert.IsDBNull(row["EmployeeID"]))?(int)0:(System.Int32?)row["EmployeeID"];
					c.OrderDate = (Convert.IsDBNull(row["OrderDate"]))?DateTime.MinValue:(System.DateTime?)row["OrderDate"];
					c.RequiredDate = (Convert.IsDBNull(row["RequiredDate"]))?DateTime.MinValue:(System.DateTime?)row["RequiredDate"];
					c.ShippedDate = (Convert.IsDBNull(row["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)row["ShippedDate"];
					c.ShipVia = (Convert.IsDBNull(row["ShipVia"]))?(int)0:(System.Int32?)row["ShipVia"];
					c.Freight = (Convert.IsDBNull(row["Freight"]))?0:(System.Decimal?)row["Freight"];
					c.ShipName = (Convert.IsDBNull(row["ShipName"]))?string.Empty:(System.String)row["ShipName"];
					c.ShipAddress = (Convert.IsDBNull(row["ShipAddress"]))?string.Empty:(System.String)row["ShipAddress"];
					c.ShipCity = (Convert.IsDBNull(row["ShipCity"]))?string.Empty:(System.String)row["ShipCity"];
					c.ShipRegion = (Convert.IsDBNull(row["ShipRegion"]))?string.Empty:(System.String)row["ShipRegion"];
					c.ShipPostalCode = (Convert.IsDBNull(row["ShipPostalCode"]))?string.Empty:(System.String)row["ShipPostalCode"];
					c.ShipCountry = (Convert.IsDBNull(row["ShipCountry"]))?string.Empty:(System.String)row["ShipCountry"];
					c.CompanyName = (Convert.IsDBNull(row["CompanyName"]))?string.Empty:(System.String)row["CompanyName"];
					c.Address = (Convert.IsDBNull(row["Address"]))?string.Empty:(System.String)row["Address"];
					c.City = (Convert.IsDBNull(row["City"]))?string.Empty:(System.String)row["City"];
					c.Region = (Convert.IsDBNull(row["Region"]))?string.Empty:(System.String)row["Region"];
					c.PostalCode = (Convert.IsDBNull(row["PostalCode"]))?string.Empty:(System.String)row["PostalCode"];
					c.Country = (Convert.IsDBNull(row["Country"]))?string.Empty:(System.String)row["Country"];
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
		/// Fill an <see cref="VList&lt;OrdersQry&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;OrdersQry&gt;"/></returns>
		protected VList<OrdersQry> Fill(IDataReader reader, VList<OrdersQry> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					OrdersQry entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<OrdersQry>("OrdersQry",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new OrdersQry();
					}
					
					entity.SuppressEntityEvents = true;

					entity.OrderId = (System.Int32)reader[((int)OrdersQryColumn.OrderId)];
					//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
					entity.CustomerId = (reader.IsDBNull(((int)OrdersQryColumn.CustomerId)))?null:(System.String)reader[((int)OrdersQryColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?string.Empty:(System.String)reader["CustomerID"];
					entity.EmployeeId = (reader.IsDBNull(((int)OrdersQryColumn.EmployeeId)))?null:(System.Int32?)reader[((int)OrdersQryColumn.EmployeeId)];
					//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?(int)0:(System.Int32?)reader["EmployeeID"];
					entity.OrderDate = (reader.IsDBNull(((int)OrdersQryColumn.OrderDate)))?null:(System.DateTime?)reader[((int)OrdersQryColumn.OrderDate)];
					//entity.OrderDate = (Convert.IsDBNull(reader["OrderDate"]))?DateTime.MinValue:(System.DateTime?)reader["OrderDate"];
					entity.RequiredDate = (reader.IsDBNull(((int)OrdersQryColumn.RequiredDate)))?null:(System.DateTime?)reader[((int)OrdersQryColumn.RequiredDate)];
					//entity.RequiredDate = (Convert.IsDBNull(reader["RequiredDate"]))?DateTime.MinValue:(System.DateTime?)reader["RequiredDate"];
					entity.ShippedDate = (reader.IsDBNull(((int)OrdersQryColumn.ShippedDate)))?null:(System.DateTime?)reader[((int)OrdersQryColumn.ShippedDate)];
					//entity.ShippedDate = (Convert.IsDBNull(reader["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)reader["ShippedDate"];
					entity.ShipVia = (reader.IsDBNull(((int)OrdersQryColumn.ShipVia)))?null:(System.Int32?)reader[((int)OrdersQryColumn.ShipVia)];
					//entity.ShipVia = (Convert.IsDBNull(reader["ShipVia"]))?(int)0:(System.Int32?)reader["ShipVia"];
					entity.Freight = (reader.IsDBNull(((int)OrdersQryColumn.Freight)))?null:(System.Decimal?)reader[((int)OrdersQryColumn.Freight)];
					//entity.Freight = (Convert.IsDBNull(reader["Freight"]))?0:(System.Decimal?)reader["Freight"];
					entity.ShipName = (reader.IsDBNull(((int)OrdersQryColumn.ShipName)))?null:(System.String)reader[((int)OrdersQryColumn.ShipName)];
					//entity.ShipName = (Convert.IsDBNull(reader["ShipName"]))?string.Empty:(System.String)reader["ShipName"];
					entity.ShipAddress = (reader.IsDBNull(((int)OrdersQryColumn.ShipAddress)))?null:(System.String)reader[((int)OrdersQryColumn.ShipAddress)];
					//entity.ShipAddress = (Convert.IsDBNull(reader["ShipAddress"]))?string.Empty:(System.String)reader["ShipAddress"];
					entity.ShipCity = (reader.IsDBNull(((int)OrdersQryColumn.ShipCity)))?null:(System.String)reader[((int)OrdersQryColumn.ShipCity)];
					//entity.ShipCity = (Convert.IsDBNull(reader["ShipCity"]))?string.Empty:(System.String)reader["ShipCity"];
					entity.ShipRegion = (reader.IsDBNull(((int)OrdersQryColumn.ShipRegion)))?null:(System.String)reader[((int)OrdersQryColumn.ShipRegion)];
					//entity.ShipRegion = (Convert.IsDBNull(reader["ShipRegion"]))?string.Empty:(System.String)reader["ShipRegion"];
					entity.ShipPostalCode = (reader.IsDBNull(((int)OrdersQryColumn.ShipPostalCode)))?null:(System.String)reader[((int)OrdersQryColumn.ShipPostalCode)];
					//entity.ShipPostalCode = (Convert.IsDBNull(reader["ShipPostalCode"]))?string.Empty:(System.String)reader["ShipPostalCode"];
					entity.ShipCountry = (reader.IsDBNull(((int)OrdersQryColumn.ShipCountry)))?null:(System.String)reader[((int)OrdersQryColumn.ShipCountry)];
					//entity.ShipCountry = (Convert.IsDBNull(reader["ShipCountry"]))?string.Empty:(System.String)reader["ShipCountry"];
					entity.CompanyName = (System.String)reader[((int)OrdersQryColumn.CompanyName)];
					//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
					entity.Address = (reader.IsDBNull(((int)OrdersQryColumn.Address)))?null:(System.String)reader[((int)OrdersQryColumn.Address)];
					//entity.Address = (Convert.IsDBNull(reader["Address"]))?string.Empty:(System.String)reader["Address"];
					entity.City = (reader.IsDBNull(((int)OrdersQryColumn.City)))?null:(System.String)reader[((int)OrdersQryColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.Region = (reader.IsDBNull(((int)OrdersQryColumn.Region)))?null:(System.String)reader[((int)OrdersQryColumn.Region)];
					//entity.Region = (Convert.IsDBNull(reader["Region"]))?string.Empty:(System.String)reader["Region"];
					entity.PostalCode = (reader.IsDBNull(((int)OrdersQryColumn.PostalCode)))?null:(System.String)reader[((int)OrdersQryColumn.PostalCode)];
					//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
					entity.Country = (reader.IsDBNull(((int)OrdersQryColumn.Country)))?null:(System.String)reader[((int)OrdersQryColumn.Country)];
					//entity.Country = (Convert.IsDBNull(reader["Country"]))?string.Empty:(System.String)reader["Country"];
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
		/// Refreshes the <see cref="OrdersQry"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="OrdersQry"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, OrdersQry entity)
		{
			reader.Read();
			entity.OrderId = (System.Int32)reader[((int)OrdersQryColumn.OrderId)];
			//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
			entity.CustomerId = (reader.IsDBNull(((int)OrdersQryColumn.CustomerId)))?null:(System.String)reader[((int)OrdersQryColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?string.Empty:(System.String)reader["CustomerID"];
			entity.EmployeeId = (reader.IsDBNull(((int)OrdersQryColumn.EmployeeId)))?null:(System.Int32?)reader[((int)OrdersQryColumn.EmployeeId)];
			//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?(int)0:(System.Int32?)reader["EmployeeID"];
			entity.OrderDate = (reader.IsDBNull(((int)OrdersQryColumn.OrderDate)))?null:(System.DateTime?)reader[((int)OrdersQryColumn.OrderDate)];
			//entity.OrderDate = (Convert.IsDBNull(reader["OrderDate"]))?DateTime.MinValue:(System.DateTime?)reader["OrderDate"];
			entity.RequiredDate = (reader.IsDBNull(((int)OrdersQryColumn.RequiredDate)))?null:(System.DateTime?)reader[((int)OrdersQryColumn.RequiredDate)];
			//entity.RequiredDate = (Convert.IsDBNull(reader["RequiredDate"]))?DateTime.MinValue:(System.DateTime?)reader["RequiredDate"];
			entity.ShippedDate = (reader.IsDBNull(((int)OrdersQryColumn.ShippedDate)))?null:(System.DateTime?)reader[((int)OrdersQryColumn.ShippedDate)];
			//entity.ShippedDate = (Convert.IsDBNull(reader["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)reader["ShippedDate"];
			entity.ShipVia = (reader.IsDBNull(((int)OrdersQryColumn.ShipVia)))?null:(System.Int32?)reader[((int)OrdersQryColumn.ShipVia)];
			//entity.ShipVia = (Convert.IsDBNull(reader["ShipVia"]))?(int)0:(System.Int32?)reader["ShipVia"];
			entity.Freight = (reader.IsDBNull(((int)OrdersQryColumn.Freight)))?null:(System.Decimal?)reader[((int)OrdersQryColumn.Freight)];
			//entity.Freight = (Convert.IsDBNull(reader["Freight"]))?0:(System.Decimal?)reader["Freight"];
			entity.ShipName = (reader.IsDBNull(((int)OrdersQryColumn.ShipName)))?null:(System.String)reader[((int)OrdersQryColumn.ShipName)];
			//entity.ShipName = (Convert.IsDBNull(reader["ShipName"]))?string.Empty:(System.String)reader["ShipName"];
			entity.ShipAddress = (reader.IsDBNull(((int)OrdersQryColumn.ShipAddress)))?null:(System.String)reader[((int)OrdersQryColumn.ShipAddress)];
			//entity.ShipAddress = (Convert.IsDBNull(reader["ShipAddress"]))?string.Empty:(System.String)reader["ShipAddress"];
			entity.ShipCity = (reader.IsDBNull(((int)OrdersQryColumn.ShipCity)))?null:(System.String)reader[((int)OrdersQryColumn.ShipCity)];
			//entity.ShipCity = (Convert.IsDBNull(reader["ShipCity"]))?string.Empty:(System.String)reader["ShipCity"];
			entity.ShipRegion = (reader.IsDBNull(((int)OrdersQryColumn.ShipRegion)))?null:(System.String)reader[((int)OrdersQryColumn.ShipRegion)];
			//entity.ShipRegion = (Convert.IsDBNull(reader["ShipRegion"]))?string.Empty:(System.String)reader["ShipRegion"];
			entity.ShipPostalCode = (reader.IsDBNull(((int)OrdersQryColumn.ShipPostalCode)))?null:(System.String)reader[((int)OrdersQryColumn.ShipPostalCode)];
			//entity.ShipPostalCode = (Convert.IsDBNull(reader["ShipPostalCode"]))?string.Empty:(System.String)reader["ShipPostalCode"];
			entity.ShipCountry = (reader.IsDBNull(((int)OrdersQryColumn.ShipCountry)))?null:(System.String)reader[((int)OrdersQryColumn.ShipCountry)];
			//entity.ShipCountry = (Convert.IsDBNull(reader["ShipCountry"]))?string.Empty:(System.String)reader["ShipCountry"];
			entity.CompanyName = (System.String)reader[((int)OrdersQryColumn.CompanyName)];
			//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
			entity.Address = (reader.IsDBNull(((int)OrdersQryColumn.Address)))?null:(System.String)reader[((int)OrdersQryColumn.Address)];
			//entity.Address = (Convert.IsDBNull(reader["Address"]))?string.Empty:(System.String)reader["Address"];
			entity.City = (reader.IsDBNull(((int)OrdersQryColumn.City)))?null:(System.String)reader[((int)OrdersQryColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.Region = (reader.IsDBNull(((int)OrdersQryColumn.Region)))?null:(System.String)reader[((int)OrdersQryColumn.Region)];
			//entity.Region = (Convert.IsDBNull(reader["Region"]))?string.Empty:(System.String)reader["Region"];
			entity.PostalCode = (reader.IsDBNull(((int)OrdersQryColumn.PostalCode)))?null:(System.String)reader[((int)OrdersQryColumn.PostalCode)];
			//entity.PostalCode = (Convert.IsDBNull(reader["PostalCode"]))?string.Empty:(System.String)reader["PostalCode"];
			entity.Country = (reader.IsDBNull(((int)OrdersQryColumn.Country)))?null:(System.String)reader[((int)OrdersQryColumn.Country)];
			//entity.Country = (Convert.IsDBNull(reader["Country"]))?string.Empty:(System.String)reader["Country"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="OrdersQry"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="OrdersQry"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, OrdersQry entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderId = (Convert.IsDBNull(dataRow["OrderID"]))?(int)0:(System.Int32)dataRow["OrderID"];
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?string.Empty:(System.String)dataRow["CustomerID"];
			entity.EmployeeId = (Convert.IsDBNull(dataRow["EmployeeID"]))?(int)0:(System.Int32?)dataRow["EmployeeID"];
			entity.OrderDate = (Convert.IsDBNull(dataRow["OrderDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["OrderDate"];
			entity.RequiredDate = (Convert.IsDBNull(dataRow["RequiredDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["RequiredDate"];
			entity.ShippedDate = (Convert.IsDBNull(dataRow["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["ShippedDate"];
			entity.ShipVia = (Convert.IsDBNull(dataRow["ShipVia"]))?(int)0:(System.Int32?)dataRow["ShipVia"];
			entity.Freight = (Convert.IsDBNull(dataRow["Freight"]))?0:(System.Decimal?)dataRow["Freight"];
			entity.ShipName = (Convert.IsDBNull(dataRow["ShipName"]))?string.Empty:(System.String)dataRow["ShipName"];
			entity.ShipAddress = (Convert.IsDBNull(dataRow["ShipAddress"]))?string.Empty:(System.String)dataRow["ShipAddress"];
			entity.ShipCity = (Convert.IsDBNull(dataRow["ShipCity"]))?string.Empty:(System.String)dataRow["ShipCity"];
			entity.ShipRegion = (Convert.IsDBNull(dataRow["ShipRegion"]))?string.Empty:(System.String)dataRow["ShipRegion"];
			entity.ShipPostalCode = (Convert.IsDBNull(dataRow["ShipPostalCode"]))?string.Empty:(System.String)dataRow["ShipPostalCode"];
			entity.ShipCountry = (Convert.IsDBNull(dataRow["ShipCountry"]))?string.Empty:(System.String)dataRow["ShipCountry"];
			entity.CompanyName = (Convert.IsDBNull(dataRow["CompanyName"]))?string.Empty:(System.String)dataRow["CompanyName"];
			entity.Address = (Convert.IsDBNull(dataRow["Address"]))?string.Empty:(System.String)dataRow["Address"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?string.Empty:(System.String)dataRow["City"];
			entity.Region = (Convert.IsDBNull(dataRow["Region"]))?string.Empty:(System.String)dataRow["Region"];
			entity.PostalCode = (Convert.IsDBNull(dataRow["PostalCode"]))?string.Empty:(System.String)dataRow["PostalCode"];
			entity.Country = (Convert.IsDBNull(dataRow["Country"]))?string.Empty:(System.String)dataRow["Country"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region OrdersQryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrdersQry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersQryFilterBuilder : SqlFilterBuilder<OrdersQryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersQryFilterBuilder class.
		/// </summary>
		public OrdersQryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersQryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersQryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersQryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersQryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersQryFilterBuilder

	#region OrdersQryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrdersQry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersQryParameterBuilder : ParameterizedSqlFilterBuilder<OrdersQryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersQryParameterBuilder class.
		/// </summary>
		public OrdersQryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersQryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersQryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersQryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersQryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersQryParameterBuilder
	
	#region OrdersQrySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrdersQry"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class OrdersQrySortBuilder : SqlSortBuilder<OrdersQryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersQrySqlSortBuilder class.
		/// </summary>
		public OrdersQrySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion OrdersQrySortBuilder

} // end namespace
