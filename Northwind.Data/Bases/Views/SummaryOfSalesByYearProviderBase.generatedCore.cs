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
	/// This class is the base class for any <see cref="SummaryOfSalesByYearProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class SummaryOfSalesByYearProviderBaseCore : EntityViewProviderBase<SummaryOfSalesByYear>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;SummaryOfSalesByYear&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;SummaryOfSalesByYear&gt;"/></returns>
		protected static VList&lt;SummaryOfSalesByYear&gt; Fill(DataSet dataSet, VList<SummaryOfSalesByYear> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<SummaryOfSalesByYear>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;SummaryOfSalesByYear&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<SummaryOfSalesByYear>"/></returns>
		protected static VList&lt;SummaryOfSalesByYear&gt; Fill(DataTable dataTable, VList<SummaryOfSalesByYear> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					SummaryOfSalesByYear c = new SummaryOfSalesByYear();
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
		/// Fill an <see cref="VList&lt;SummaryOfSalesByYear&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;SummaryOfSalesByYear&gt;"/></returns>
		protected VList<SummaryOfSalesByYear> Fill(IDataReader reader, VList<SummaryOfSalesByYear> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					SummaryOfSalesByYear entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<SummaryOfSalesByYear>("SummaryOfSalesByYear",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new SummaryOfSalesByYear();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ShippedDate = (reader.IsDBNull(((int)SummaryOfSalesByYearColumn.ShippedDate)))?null:(System.DateTime?)reader[((int)SummaryOfSalesByYearColumn.ShippedDate)];
					//entity.ShippedDate = (Convert.IsDBNull(reader["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)reader["ShippedDate"];
					entity.OrderId = (System.Int32)reader[((int)SummaryOfSalesByYearColumn.OrderId)];
					//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
					entity.Subtotal = (reader.IsDBNull(((int)SummaryOfSalesByYearColumn.Subtotal)))?null:(System.Decimal?)reader[((int)SummaryOfSalesByYearColumn.Subtotal)];
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
		/// Refreshes the <see cref="SummaryOfSalesByYear"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SummaryOfSalesByYear"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, SummaryOfSalesByYear entity)
		{
			reader.Read();
			entity.ShippedDate = (reader.IsDBNull(((int)SummaryOfSalesByYearColumn.ShippedDate)))?null:(System.DateTime?)reader[((int)SummaryOfSalesByYearColumn.ShippedDate)];
			//entity.ShippedDate = (Convert.IsDBNull(reader["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)reader["ShippedDate"];
			entity.OrderId = (System.Int32)reader[((int)SummaryOfSalesByYearColumn.OrderId)];
			//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
			entity.Subtotal = (reader.IsDBNull(((int)SummaryOfSalesByYearColumn.Subtotal)))?null:(System.Decimal?)reader[((int)SummaryOfSalesByYearColumn.Subtotal)];
			//entity.Subtotal = (Convert.IsDBNull(reader["Subtotal"]))?0:(System.Decimal?)reader["Subtotal"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="SummaryOfSalesByYear"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SummaryOfSalesByYear"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, SummaryOfSalesByYear entity)
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

	#region SummaryOfSalesByYearFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SummaryOfSalesByYear"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SummaryOfSalesByYearFilterBuilder : SqlFilterBuilder<SummaryOfSalesByYearColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearFilterBuilder class.
		/// </summary>
		public SummaryOfSalesByYearFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SummaryOfSalesByYearFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SummaryOfSalesByYearFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SummaryOfSalesByYearFilterBuilder

	#region SummaryOfSalesByYearParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SummaryOfSalesByYear"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SummaryOfSalesByYearParameterBuilder : ParameterizedSqlFilterBuilder<SummaryOfSalesByYearColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearParameterBuilder class.
		/// </summary>
		public SummaryOfSalesByYearParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SummaryOfSalesByYearParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SummaryOfSalesByYearParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SummaryOfSalesByYearParameterBuilder
	
	#region SummaryOfSalesByYearSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SummaryOfSalesByYear"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SummaryOfSalesByYearSortBuilder : SqlSortBuilder<SummaryOfSalesByYearColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearSqlSortBuilder class.
		/// </summary>
		public SummaryOfSalesByYearSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SummaryOfSalesByYearSortBuilder

} // end namespace
