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
	/// This class is the base class for any <see cref="SalesByCategoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class SalesByCategoryProviderBaseCore : EntityViewProviderBase<SalesByCategory>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;SalesByCategory&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;SalesByCategory&gt;"/></returns>
		protected static VList&lt;SalesByCategory&gt; Fill(DataSet dataSet, VList<SalesByCategory> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<SalesByCategory>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;SalesByCategory&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<SalesByCategory>"/></returns>
		protected static VList&lt;SalesByCategory&gt; Fill(DataTable dataTable, VList<SalesByCategory> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					SalesByCategory c = new SalesByCategory();
					c.CategoryId = (Convert.IsDBNull(row["CategoryID"]))?(int)0:(System.Int32)row["CategoryID"];
					c.CategoryName = (Convert.IsDBNull(row["CategoryName"]))?string.Empty:(System.String)row["CategoryName"];
					c.ProductName = (Convert.IsDBNull(row["ProductName"]))?string.Empty:(System.String)row["ProductName"];
					c.ProductSales = (Convert.IsDBNull(row["ProductSales"]))?0:(System.Decimal?)row["ProductSales"];
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
		/// Fill an <see cref="VList&lt;SalesByCategory&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;SalesByCategory&gt;"/></returns>
		protected VList<SalesByCategory> Fill(IDataReader reader, VList<SalesByCategory> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					SalesByCategory entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<SalesByCategory>("SalesByCategory",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new SalesByCategory();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CategoryId = (System.Int32)reader[((int)SalesByCategoryColumn.CategoryId)];
					//entity.CategoryId = (Convert.IsDBNull(reader["CategoryID"]))?(int)0:(System.Int32)reader["CategoryID"];
					entity.CategoryName = (System.String)reader[((int)SalesByCategoryColumn.CategoryName)];
					//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
					entity.ProductName = (System.String)reader[((int)SalesByCategoryColumn.ProductName)];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					entity.ProductSales = (reader.IsDBNull(((int)SalesByCategoryColumn.ProductSales)))?null:(System.Decimal?)reader[((int)SalesByCategoryColumn.ProductSales)];
					//entity.ProductSales = (Convert.IsDBNull(reader["ProductSales"]))?0:(System.Decimal?)reader["ProductSales"];
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
		/// Refreshes the <see cref="SalesByCategory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SalesByCategory"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, SalesByCategory entity)
		{
			reader.Read();
			entity.CategoryId = (System.Int32)reader[((int)SalesByCategoryColumn.CategoryId)];
			//entity.CategoryId = (Convert.IsDBNull(reader["CategoryID"]))?(int)0:(System.Int32)reader["CategoryID"];
			entity.CategoryName = (System.String)reader[((int)SalesByCategoryColumn.CategoryName)];
			//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
			entity.ProductName = (System.String)reader[((int)SalesByCategoryColumn.ProductName)];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			entity.ProductSales = (reader.IsDBNull(((int)SalesByCategoryColumn.ProductSales)))?null:(System.Decimal?)reader[((int)SalesByCategoryColumn.ProductSales)];
			//entity.ProductSales = (Convert.IsDBNull(reader["ProductSales"]))?0:(System.Decimal?)reader["ProductSales"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="SalesByCategory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SalesByCategory"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, SalesByCategory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CategoryId = (Convert.IsDBNull(dataRow["CategoryID"]))?(int)0:(System.Int32)dataRow["CategoryID"];
			entity.CategoryName = (Convert.IsDBNull(dataRow["CategoryName"]))?string.Empty:(System.String)dataRow["CategoryName"];
			entity.ProductName = (Convert.IsDBNull(dataRow["ProductName"]))?string.Empty:(System.String)dataRow["ProductName"];
			entity.ProductSales = (Convert.IsDBNull(dataRow["ProductSales"]))?0:(System.Decimal?)dataRow["ProductSales"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region SalesByCategoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesByCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesByCategoryFilterBuilder : SqlFilterBuilder<SalesByCategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryFilterBuilder class.
		/// </summary>
		public SalesByCategoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesByCategoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesByCategoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesByCategoryFilterBuilder

	#region SalesByCategoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesByCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesByCategoryParameterBuilder : ParameterizedSqlFilterBuilder<SalesByCategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryParameterBuilder class.
		/// </summary>
		public SalesByCategoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesByCategoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesByCategoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesByCategoryParameterBuilder
	
	#region SalesByCategorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesByCategory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalesByCategorySortBuilder : SqlSortBuilder<SalesByCategoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesByCategorySqlSortBuilder class.
		/// </summary>
		public SalesByCategorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalesByCategorySortBuilder

} // end namespace
