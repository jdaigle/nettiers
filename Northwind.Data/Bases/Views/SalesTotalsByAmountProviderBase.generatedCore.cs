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
	/// This class is the base class for any <see cref="SalesTotalsByAmountProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class SalesTotalsByAmountProviderBaseCore : EntityViewProviderBase<SalesTotalsByAmount>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;SalesTotalsByAmount&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;SalesTotalsByAmount&gt;"/></returns>
		protected static VList&lt;SalesTotalsByAmount&gt; Fill(DataSet dataSet, VList<SalesTotalsByAmount> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<SalesTotalsByAmount>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;SalesTotalsByAmount&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<SalesTotalsByAmount>"/></returns>
		protected static VList&lt;SalesTotalsByAmount&gt; Fill(DataTable dataTable, VList<SalesTotalsByAmount> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					SalesTotalsByAmount c = new SalesTotalsByAmount();
					c.SaleAmount = (Convert.IsDBNull(row["SaleAmount"]))?0:(System.Decimal?)row["SaleAmount"];
					c.OrderId = (Convert.IsDBNull(row["OrderID"]))?(int)0:(System.Int32)row["OrderID"];
					c.CompanyName = (Convert.IsDBNull(row["CompanyName"]))?string.Empty:(System.String)row["CompanyName"];
					c.ShippedDate = (Convert.IsDBNull(row["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)row["ShippedDate"];
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
		/// Fill an <see cref="VList&lt;SalesTotalsByAmount&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;SalesTotalsByAmount&gt;"/></returns>
		protected VList<SalesTotalsByAmount> Fill(IDataReader reader, VList<SalesTotalsByAmount> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					SalesTotalsByAmount entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<SalesTotalsByAmount>("SalesTotalsByAmount",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new SalesTotalsByAmount();
					}
					
					entity.SuppressEntityEvents = true;

					entity.SaleAmount = (reader.IsDBNull(((int)SalesTotalsByAmountColumn.SaleAmount)))?null:(System.Decimal?)reader[((int)SalesTotalsByAmountColumn.SaleAmount)];
					//entity.SaleAmount = (Convert.IsDBNull(reader["SaleAmount"]))?0:(System.Decimal?)reader["SaleAmount"];
					entity.OrderId = (System.Int32)reader[((int)SalesTotalsByAmountColumn.OrderId)];
					//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
					entity.CompanyName = (System.String)reader[((int)SalesTotalsByAmountColumn.CompanyName)];
					//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
					entity.ShippedDate = (reader.IsDBNull(((int)SalesTotalsByAmountColumn.ShippedDate)))?null:(System.DateTime?)reader[((int)SalesTotalsByAmountColumn.ShippedDate)];
					//entity.ShippedDate = (Convert.IsDBNull(reader["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)reader["ShippedDate"];
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
		/// Refreshes the <see cref="SalesTotalsByAmount"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SalesTotalsByAmount"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, SalesTotalsByAmount entity)
		{
			reader.Read();
			entity.SaleAmount = (reader.IsDBNull(((int)SalesTotalsByAmountColumn.SaleAmount)))?null:(System.Decimal?)reader[((int)SalesTotalsByAmountColumn.SaleAmount)];
			//entity.SaleAmount = (Convert.IsDBNull(reader["SaleAmount"]))?0:(System.Decimal?)reader["SaleAmount"];
			entity.OrderId = (System.Int32)reader[((int)SalesTotalsByAmountColumn.OrderId)];
			//entity.OrderId = (Convert.IsDBNull(reader["OrderID"]))?(int)0:(System.Int32)reader["OrderID"];
			entity.CompanyName = (System.String)reader[((int)SalesTotalsByAmountColumn.CompanyName)];
			//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
			entity.ShippedDate = (reader.IsDBNull(((int)SalesTotalsByAmountColumn.ShippedDate)))?null:(System.DateTime?)reader[((int)SalesTotalsByAmountColumn.ShippedDate)];
			//entity.ShippedDate = (Convert.IsDBNull(reader["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)reader["ShippedDate"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="SalesTotalsByAmount"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SalesTotalsByAmount"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, SalesTotalsByAmount entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SaleAmount = (Convert.IsDBNull(dataRow["SaleAmount"]))?0:(System.Decimal?)dataRow["SaleAmount"];
			entity.OrderId = (Convert.IsDBNull(dataRow["OrderID"]))?(int)0:(System.Int32)dataRow["OrderID"];
			entity.CompanyName = (Convert.IsDBNull(dataRow["CompanyName"]))?string.Empty:(System.String)dataRow["CompanyName"];
			entity.ShippedDate = (Convert.IsDBNull(dataRow["ShippedDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["ShippedDate"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region SalesTotalsByAmountFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTotalsByAmount"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTotalsByAmountFilterBuilder : SqlFilterBuilder<SalesTotalsByAmountColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountFilterBuilder class.
		/// </summary>
		public SalesTotalsByAmountFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTotalsByAmountFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTotalsByAmountFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTotalsByAmountFilterBuilder

	#region SalesTotalsByAmountParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTotalsByAmount"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTotalsByAmountParameterBuilder : ParameterizedSqlFilterBuilder<SalesTotalsByAmountColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountParameterBuilder class.
		/// </summary>
		public SalesTotalsByAmountParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTotalsByAmountParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTotalsByAmountParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTotalsByAmountParameterBuilder
	
	#region SalesTotalsByAmountSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTotalsByAmount"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalesTotalsByAmountSortBuilder : SqlSortBuilder<SalesTotalsByAmountColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountSqlSortBuilder class.
		/// </summary>
		public SalesTotalsByAmountSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalesTotalsByAmountSortBuilder

} // end namespace
