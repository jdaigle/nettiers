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
	/// This class is the base class for any <see cref="OrderDetailsExtendedProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class OrderDetailsExtendedProviderBaseCore : EntityViewProviderBase<OrderDetailsExtended>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;OrderDetailsExtended&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;OrderDetailsExtended&gt;"/></returns>
		protected static VList&lt;OrderDetailsExtended&gt; Fill(DataSet dataSet, VList<OrderDetailsExtended> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<OrderDetailsExtended>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;OrderDetailsExtended&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<OrderDetailsExtended>"/></returns>
		protected static VList&lt;OrderDetailsExtended&gt; Fill(DataTable dataTable, VList<OrderDetailsExtended> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					OrderDetailsExtended c = new OrderDetailsExtended();
					c.OrderId = (Convert.IsDBNull(row["OrderID"]))?(int)0:(System.Int32)row["OrderID"];
					c.ProductId = (Convert.IsDBNull(row["ProductID"]))?(int)0:(System.Int32)row["ProductID"];
					c.ProductName = (Convert.IsDBNull(row["ProductName"]))?string.Empty:(System.String)row["ProductName"];
					c.UnitPrice = (Convert.IsDBNull(row["UnitPrice"]))?0:(System.Decimal)row["UnitPrice"];
					c.Quantity = (Convert.IsDBNull(row["Quantity"]))?(short)0:(System.Int16)row["Quantity"];
					c.Discount = (Convert.IsDBNull(row["Discount"]))?0.0F:(System.Single)row["Discount"];
					c.ExtendedPrice = (Convert.IsDBNull(row["ExtendedPrice"]))?0:(System.Decimal?)row["ExtendedPrice"];
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
		/// Fill an <see cref="VList&lt;OrderDetailsExtended&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;OrderDetailsExtended&gt;"/></returns>
		protected VList<OrderDetailsExtended> Fill(IDataReader reader, VList<OrderDetailsExtended> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					OrderDetailsExtended entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<OrderDetailsExtended>("OrderDetailsExtended",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new OrderDetailsExtended();
					}
					
					entity.SuppressEntityEvents = true;

					entity.OrderId = (System.Int32)reader[((int)OrderDetailsExtendedColumn.OrderId)];
					//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
					entity.ProductId = (System.Int32)reader[((int)OrderDetailsExtendedColumn.ProductId)];
					//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
					entity.ProductName = (System.String)reader[((int)OrderDetailsExtendedColumn.ProductName)];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					entity.UnitPrice = (System.Decimal)reader[((int)OrderDetailsExtendedColumn.UnitPrice)];
					//entity.UnitPrice = (Convert.IsDBNull(reader["UnitPrice"]))?0:(System.Decimal)reader["UnitPrice"];
					entity.Quantity = (System.Int16)reader[((int)OrderDetailsExtendedColumn.Quantity)];
					//entity.Quantity = (Convert.IsDBNull(reader["Quantity"]))?(short)0:(System.Int16)reader["Quantity"];
					entity.Discount = (System.Single)reader[((int)OrderDetailsExtendedColumn.Discount)];
					//entity.Discount = (Convert.IsDBNull(reader["Discount"]))?0.0F:(System.Single)reader["Discount"];
					entity.ExtendedPrice = (reader.IsDBNull(((int)OrderDetailsExtendedColumn.ExtendedPrice)))?null:(System.Decimal?)reader[((int)OrderDetailsExtendedColumn.ExtendedPrice)];
					//entity.ExtendedPrice = (Convert.IsDBNull(reader["ExtendedPrice"]))?0:(System.Decimal?)reader["ExtendedPrice"];
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
		/// Refreshes the <see cref="OrderDetailsExtended"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="OrderDetailsExtended"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, OrderDetailsExtended entity)
		{
			reader.Read();
			entity.OrderId = (System.Int32)reader[((int)OrderDetailsExtendedColumn.OrderId)];
			//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
			entity.ProductId = (System.Int32)reader[((int)OrderDetailsExtendedColumn.ProductId)];
			//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
			entity.ProductName = (System.String)reader[((int)OrderDetailsExtendedColumn.ProductName)];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			entity.UnitPrice = (System.Decimal)reader[((int)OrderDetailsExtendedColumn.UnitPrice)];
			//entity.UnitPrice = (Convert.IsDBNull(reader["UnitPrice"]))?0:(System.Decimal)reader["UnitPrice"];
			entity.Quantity = (System.Int16)reader[((int)OrderDetailsExtendedColumn.Quantity)];
			//entity.Quantity = (Convert.IsDBNull(reader["Quantity"]))?(short)0:(System.Int16)reader["Quantity"];
			entity.Discount = (System.Single)reader[((int)OrderDetailsExtendedColumn.Discount)];
			//entity.Discount = (Convert.IsDBNull(reader["Discount"]))?0.0F:(System.Single)reader["Discount"];
			entity.ExtendedPrice = (reader.IsDBNull(((int)OrderDetailsExtendedColumn.ExtendedPrice)))?null:(System.Decimal?)reader[((int)OrderDetailsExtendedColumn.ExtendedPrice)];
			//entity.ExtendedPrice = (Convert.IsDBNull(reader["ExtendedPrice"]))?0:(System.Decimal?)reader["ExtendedPrice"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="OrderDetailsExtended"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="OrderDetailsExtended"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, OrderDetailsExtended entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderId = (Convert.IsDBNull(dataRow["OrderID"]))?(int)0:(System.Int32)dataRow["OrderID"];
			entity.ProductId = (Convert.IsDBNull(dataRow["ProductID"]))?(int)0:(System.Int32)dataRow["ProductID"];
			entity.ProductName = (Convert.IsDBNull(dataRow["ProductName"]))?string.Empty:(System.String)dataRow["ProductName"];
			entity.UnitPrice = (Convert.IsDBNull(dataRow["UnitPrice"]))?0:(System.Decimal)dataRow["UnitPrice"];
			entity.Quantity = (Convert.IsDBNull(dataRow["Quantity"]))?(short)0:(System.Int16)dataRow["Quantity"];
			entity.Discount = (Convert.IsDBNull(dataRow["Discount"]))?0.0F:(System.Single)dataRow["Discount"];
			entity.ExtendedPrice = (Convert.IsDBNull(dataRow["ExtendedPrice"]))?0:(System.Decimal?)dataRow["ExtendedPrice"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region OrderDetailsExtendedFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetailsExtended"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsExtendedFilterBuilder : SqlFilterBuilder<OrderDetailsExtendedColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedFilterBuilder class.
		/// </summary>
		public OrderDetailsExtendedFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsExtendedFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsExtendedFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsExtendedFilterBuilder

	#region OrderDetailsExtendedParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetailsExtended"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsExtendedParameterBuilder : ParameterizedSqlFilterBuilder<OrderDetailsExtendedColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedParameterBuilder class.
		/// </summary>
		public OrderDetailsExtendedParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsExtendedParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsExtendedParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsExtendedParameterBuilder
	
	#region OrderDetailsExtendedSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetailsExtended"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class OrderDetailsExtendedSortBuilder : SqlSortBuilder<OrderDetailsExtendedColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedSqlSortBuilder class.
		/// </summary>
		public OrderDetailsExtendedSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion OrderDetailsExtendedSortBuilder

} // end namespace
