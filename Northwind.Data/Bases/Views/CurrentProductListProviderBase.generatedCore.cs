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
	/// This class is the base class for any <see cref="CurrentProductListProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class CurrentProductListProviderBaseCore : EntityViewProviderBase<CurrentProductList>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;CurrentProductList&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;CurrentProductList&gt;"/></returns>
		protected static VList&lt;CurrentProductList&gt; Fill(DataSet dataSet, VList<CurrentProductList> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<CurrentProductList>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;CurrentProductList&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<CurrentProductList>"/></returns>
		protected static VList&lt;CurrentProductList&gt; Fill(DataTable dataTable, VList<CurrentProductList> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					CurrentProductList c = new CurrentProductList();
					c.ProductId = (Convert.IsDBNull(row["ProductID"]))?(int)0:(System.Int32)row["ProductID"];
					c.ProductName = (Convert.IsDBNull(row["ProductName"]))?string.Empty:(System.String)row["ProductName"];
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
		/// Fill an <see cref="VList&lt;CurrentProductList&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;CurrentProductList&gt;"/></returns>
		protected VList<CurrentProductList> Fill(IDataReader reader, VList<CurrentProductList> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					CurrentProductList entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<CurrentProductList>("CurrentProductList",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new CurrentProductList();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ProductId = (System.Int32)reader[((int)CurrentProductListColumn.ProductId)];
					//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
					entity.ProductName = (System.String)reader[((int)CurrentProductListColumn.ProductName)];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
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
		/// Refreshes the <see cref="CurrentProductList"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CurrentProductList"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, CurrentProductList entity)
		{
			reader.Read();
			entity.ProductId = (System.Int32)reader[((int)CurrentProductListColumn.ProductId)];
			//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
			entity.ProductName = (System.String)reader[((int)CurrentProductListColumn.ProductName)];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="CurrentProductList"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CurrentProductList"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, CurrentProductList entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductId = (Convert.IsDBNull(dataRow["ProductID"]))?(int)0:(System.Int32)dataRow["ProductID"];
			entity.ProductName = (Convert.IsDBNull(dataRow["ProductName"]))?string.Empty:(System.String)dataRow["ProductName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region CurrentProductListFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CurrentProductList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrentProductListFilterBuilder : SqlFilterBuilder<CurrentProductListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrentProductListFilterBuilder class.
		/// </summary>
		public CurrentProductListFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrentProductListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrentProductListFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrentProductListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrentProductListFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrentProductListFilterBuilder

	#region CurrentProductListParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CurrentProductList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrentProductListParameterBuilder : ParameterizedSqlFilterBuilder<CurrentProductListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrentProductListParameterBuilder class.
		/// </summary>
		public CurrentProductListParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrentProductListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrentProductListParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrentProductListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrentProductListParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrentProductListParameterBuilder
	
	#region CurrentProductListSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CurrentProductList"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CurrentProductListSortBuilder : SqlSortBuilder<CurrentProductListColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrentProductListSqlSortBuilder class.
		/// </summary>
		public CurrentProductListSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CurrentProductListSortBuilder

} // end namespace
