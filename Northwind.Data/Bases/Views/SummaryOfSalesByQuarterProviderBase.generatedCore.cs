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
	/// This class is the base class for any <see cref="SummaryOfSalesByQuarterProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class SummaryOfSalesByQuarterProviderBaseCore : EntityViewProviderBase<SummaryOfSalesByQuarter>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;SummaryOfSalesByQuarter&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;SummaryOfSalesByQuarter&gt;"/></returns>
		protected static VList&lt;SummaryOfSalesByQuarter&gt; Fill(DataSet dataSet, VList<SummaryOfSalesByQuarter> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<SummaryOfSalesByQuarter>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;SummaryOfSalesByQuarter&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<SummaryOfSalesByQuarter>"/></returns>
		protected static VList&lt;SummaryOfSalesByQuarter&gt; Fill(DataTable dataTable, VList<SummaryOfSalesByQuarter> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					SummaryOfSalesByQuarter c = new SummaryOfSalesByQuarter();
					c.ShippedDate = (Convert.IsDBNull(row["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)row["ShippedDate"];
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
		/// Fill an <see cref="VList&lt;SummaryOfSalesByQuarter&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;SummaryOfSalesByQuarter&gt;"/></returns>
		protected VList<SummaryOfSalesByQuarter> Fill(IDataReader reader, VList<SummaryOfSalesByQuarter> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					SummaryOfSalesByQuarter entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<SummaryOfSalesByQuarter>("SummaryOfSalesByQuarter",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new SummaryOfSalesByQuarter();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ShippedDate = (reader.IsDBNull(((int)SummaryOfSalesByQuarterColumn.ShippedDate)))?null:(System.DateTime?)reader[((int)SummaryOfSalesByQuarterColumn.ShippedDate)];
					//entity.ShippedDate = (Convert.IsDBNull(reader["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)reader["ShippedDate"];
					entity.OrderId = (System.Int32)reader[((int)SummaryOfSalesByQuarterColumn.OrderId)];
					//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
					entity.Subtotal = (reader.IsDBNull(((int)SummaryOfSalesByQuarterColumn.Subtotal)))?null:(System.Decimal?)reader[((int)SummaryOfSalesByQuarterColumn.Subtotal)];
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
		/// Refreshes the <see cref="SummaryOfSalesByQuarter"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SummaryOfSalesByQuarter"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, SummaryOfSalesByQuarter entity)
		{
			reader.Read();
			entity.ShippedDate = (reader.IsDBNull(((int)SummaryOfSalesByQuarterColumn.ShippedDate)))?null:(System.DateTime?)reader[((int)SummaryOfSalesByQuarterColumn.ShippedDate)];
			//entity.ShippedDate = (Convert.IsDBNull(reader["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)reader["ShippedDate"];
			entity.OrderId = (System.Int32)reader[((int)SummaryOfSalesByQuarterColumn.OrderId)];
			//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
			entity.Subtotal = (reader.IsDBNull(((int)SummaryOfSalesByQuarterColumn.Subtotal)))?null:(System.Decimal?)reader[((int)SummaryOfSalesByQuarterColumn.Subtotal)];
			//entity.Subtotal = (Convert.IsDBNull(reader["Subtotal"]))?0:(System.Decimal?)reader["Subtotal"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="SummaryOfSalesByQuarter"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SummaryOfSalesByQuarter"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, SummaryOfSalesByQuarter entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ShippedDate = (Convert.IsDBNull(dataRow["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["ShippedDate"];
			entity.OrderId = (Convert.IsDBNull(dataRow["OrderID"]))?(int)0:(System.Int32)dataRow["OrderID"];
			entity.Subtotal = (Convert.IsDBNull(dataRow["Subtotal"]))?0:(System.Decimal?)dataRow["Subtotal"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region SummaryOfSalesByQuarterFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SummaryOfSalesByQuarter"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SummaryOfSalesByQuarterFilterBuilder : SqlFilterBuilder<SummaryOfSalesByQuarterColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterFilterBuilder class.
		/// </summary>
		public SummaryOfSalesByQuarterFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SummaryOfSalesByQuarterFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SummaryOfSalesByQuarterFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SummaryOfSalesByQuarterFilterBuilder

	#region SummaryOfSalesByQuarterParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SummaryOfSalesByQuarter"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SummaryOfSalesByQuarterParameterBuilder : ParameterizedSqlFilterBuilder<SummaryOfSalesByQuarterColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterParameterBuilder class.
		/// </summary>
		public SummaryOfSalesByQuarterParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SummaryOfSalesByQuarterParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SummaryOfSalesByQuarterParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SummaryOfSalesByQuarterParameterBuilder
	
	#region SummaryOfSalesByQuarterSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SummaryOfSalesByQuarter"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SummaryOfSalesByQuarterSortBuilder : SqlSortBuilder<SummaryOfSalesByQuarterColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterSqlSortBuilder class.
		/// </summary>
		public SummaryOfSalesByQuarterSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SummaryOfSalesByQuarterSortBuilder

} // end namespace
