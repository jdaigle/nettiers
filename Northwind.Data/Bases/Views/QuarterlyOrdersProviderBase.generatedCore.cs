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
	/// This class is the base class for any <see cref="QuarterlyOrdersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class QuarterlyOrdersProviderBaseCore : EntityViewProviderBase<QuarterlyOrders>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;QuarterlyOrders&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;QuarterlyOrders&gt;"/></returns>
		protected static VList&lt;QuarterlyOrders&gt; Fill(DataSet dataSet, VList<QuarterlyOrders> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<QuarterlyOrders>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;QuarterlyOrders&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<QuarterlyOrders>"/></returns>
		protected static VList&lt;QuarterlyOrders&gt; Fill(DataTable dataTable, VList<QuarterlyOrders> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					QuarterlyOrders c = new QuarterlyOrders();
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?string.Empty:(System.String)row["CustomerID"];
					c.CompanyName = (Convert.IsDBNull(row["CompanyName"]))?string.Empty:(System.String)row["CompanyName"];
					c.City = (Convert.IsDBNull(row["City"]))?string.Empty:(System.String)row["City"];
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
		/// Fill an <see cref="VList&lt;QuarterlyOrders&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;QuarterlyOrders&gt;"/></returns>
		protected VList<QuarterlyOrders> Fill(IDataReader reader, VList<QuarterlyOrders> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					QuarterlyOrders entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<QuarterlyOrders>("QuarterlyOrders",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new QuarterlyOrders();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CustomerId = (reader.IsDBNull(((int)QuarterlyOrdersColumn.CustomerId)))?null:(System.String)reader[((int)QuarterlyOrdersColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?string.Empty:(System.String)reader["CustomerID"];
					entity.CompanyName = (reader.IsDBNull(((int)QuarterlyOrdersColumn.CompanyName)))?null:(System.String)reader[((int)QuarterlyOrdersColumn.CompanyName)];
					//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
					entity.City = (reader.IsDBNull(((int)QuarterlyOrdersColumn.City)))?null:(System.String)reader[((int)QuarterlyOrdersColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.Country = (reader.IsDBNull(((int)QuarterlyOrdersColumn.Country)))?null:(System.String)reader[((int)QuarterlyOrdersColumn.Country)];
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
		/// Refreshes the <see cref="QuarterlyOrders"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QuarterlyOrders"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, QuarterlyOrders entity)
		{
			reader.Read();
			entity.CustomerId = (reader.IsDBNull(((int)QuarterlyOrdersColumn.CustomerId)))?null:(System.String)reader[((int)QuarterlyOrdersColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?string.Empty:(System.String)reader["CustomerID"];
			entity.CompanyName = (reader.IsDBNull(((int)QuarterlyOrdersColumn.CompanyName)))?null:(System.String)reader[((int)QuarterlyOrdersColumn.CompanyName)];
			//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
			entity.City = (reader.IsDBNull(((int)QuarterlyOrdersColumn.City)))?null:(System.String)reader[((int)QuarterlyOrdersColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.Country = (reader.IsDBNull(((int)QuarterlyOrdersColumn.Country)))?null:(System.String)reader[((int)QuarterlyOrdersColumn.Country)];
			//entity.Country = (Convert.IsDBNull(reader["Country"]))?string.Empty:(System.String)reader["Country"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="QuarterlyOrders"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QuarterlyOrders"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, QuarterlyOrders entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?string.Empty:(System.String)dataRow["CustomerID"];
			entity.CompanyName = (Convert.IsDBNull(dataRow["CompanyName"]))?string.Empty:(System.String)dataRow["CompanyName"];
			entity.City = (Convert.IsDBNull(dataRow["City"]))?string.Empty:(System.String)dataRow["City"];
			entity.Country = (Convert.IsDBNull(dataRow["Country"]))?string.Empty:(System.String)dataRow["Country"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region QuarterlyOrdersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuarterlyOrders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuarterlyOrdersFilterBuilder : SqlFilterBuilder<QuarterlyOrdersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersFilterBuilder class.
		/// </summary>
		public QuarterlyOrdersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuarterlyOrdersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuarterlyOrdersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuarterlyOrdersFilterBuilder

	#region QuarterlyOrdersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuarterlyOrders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuarterlyOrdersParameterBuilder : ParameterizedSqlFilterBuilder<QuarterlyOrdersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersParameterBuilder class.
		/// </summary>
		public QuarterlyOrdersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuarterlyOrdersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuarterlyOrdersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuarterlyOrdersParameterBuilder
	
	#region QuarterlyOrdersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuarterlyOrders"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class QuarterlyOrdersSortBuilder : SqlSortBuilder<QuarterlyOrdersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersSqlSortBuilder class.
		/// </summary>
		public QuarterlyOrdersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion QuarterlyOrdersSortBuilder

} // end namespace
