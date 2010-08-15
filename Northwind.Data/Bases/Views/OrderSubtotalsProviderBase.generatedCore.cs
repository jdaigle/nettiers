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
	/// This class is the base class for any <see cref="OrderSubtotalsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class OrderSubtotalsProviderBaseCore : EntityViewProviderBase<OrderSubtotals>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;OrderSubtotals&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;OrderSubtotals&gt;"/></returns>
		protected static VList&lt;OrderSubtotals&gt; Fill(DataSet dataSet, VList<OrderSubtotals> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<OrderSubtotals>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;OrderSubtotals&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<OrderSubtotals>"/></returns>
		protected static VList&lt;OrderSubtotals&gt; Fill(DataTable dataTable, VList<OrderSubtotals> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					OrderSubtotals c = new OrderSubtotals();
					c.OrderId = (Convert.IsDBNull(row["OrderID"]))?(int)0:(System.Int32)row["OrderID"];
					c.Subtotal = (Convert.IsDBNull(row["Subtotal"]))?0:(System.Decimal?)row["Subtotal"];
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
		/// Fill an <see cref="VList&lt;OrderSubtotals&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;OrderSubtotals&gt;"/></returns>
		protected VList<OrderSubtotals> Fill(IDataReader reader, VList<OrderSubtotals> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					OrderSubtotals entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<OrderSubtotals>("OrderSubtotals",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new OrderSubtotals();
					}
					
					entity.SuppressEntityEvents = true;

					entity.OrderId = (System.Int32)reader[((int)OrderSubtotalsColumn.OrderId)];
					//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
					entity.Subtotal = (reader.IsDBNull(((int)OrderSubtotalsColumn.Subtotal)))?null:(System.Decimal?)reader[((int)OrderSubtotalsColumn.Subtotal)];
					//entity.Subtotal = (Convert.IsDBNull(reader["Subtotal"]))?0:(System.Decimal?)reader["Subtotal"];
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
		/// Refreshes the <see cref="OrderSubtotals"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="OrderSubtotals"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, OrderSubtotals entity)
		{
			reader.Read();
			entity.OrderId = (System.Int32)reader[((int)OrderSubtotalsColumn.OrderId)];
			//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
			entity.Subtotal = (reader.IsDBNull(((int)OrderSubtotalsColumn.Subtotal)))?null:(System.Decimal?)reader[((int)OrderSubtotalsColumn.Subtotal)];
			//entity.Subtotal = (Convert.IsDBNull(reader["Subtotal"]))?0:(System.Decimal?)reader["Subtotal"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="OrderSubtotals"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="OrderSubtotals"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, OrderSubtotals entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderId = (Convert.IsDBNull(dataRow["OrderID"]))?(int)0:(System.Int32)dataRow["OrderID"];
			entity.Subtotal = (Convert.IsDBNull(dataRow["Subtotal"]))?0:(System.Decimal?)dataRow["Subtotal"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region OrderSubtotalsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderSubtotals"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderSubtotalsFilterBuilder : SqlFilterBuilder<OrderSubtotalsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsFilterBuilder class.
		/// </summary>
		public OrderSubtotalsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderSubtotalsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderSubtotalsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderSubtotalsFilterBuilder

	#region OrderSubtotalsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderSubtotals"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderSubtotalsParameterBuilder : ParameterizedSqlFilterBuilder<OrderSubtotalsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsParameterBuilder class.
		/// </summary>
		public OrderSubtotalsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderSubtotalsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderSubtotalsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderSubtotalsParameterBuilder
	
	#region OrderSubtotalsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderSubtotals"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class OrderSubtotalsSortBuilder : SqlSortBuilder<OrderSubtotalsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsSqlSortBuilder class.
		/// </summary>
		public OrderSubtotalsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion OrderSubtotalsSortBuilder

} // end namespace
