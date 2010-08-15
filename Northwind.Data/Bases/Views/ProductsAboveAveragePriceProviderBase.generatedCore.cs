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
	/// This class is the base class for any <see cref="ProductsAboveAveragePriceProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ProductsAboveAveragePriceProviderBaseCore : EntityViewProviderBase<ProductsAboveAveragePrice>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;ProductsAboveAveragePrice&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;ProductsAboveAveragePrice&gt;"/></returns>
		protected static VList&lt;ProductsAboveAveragePrice&gt; Fill(DataSet dataSet, VList<ProductsAboveAveragePrice> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<ProductsAboveAveragePrice>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;ProductsAboveAveragePrice&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<ProductsAboveAveragePrice>"/></returns>
		protected static VList&lt;ProductsAboveAveragePrice&gt; Fill(DataTable dataTable, VList<ProductsAboveAveragePrice> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					ProductsAboveAveragePrice c = new ProductsAboveAveragePrice();
					c.ProductName = (Convert.IsDBNull(row["ProductName"]))?string.Empty:(System.String)row["ProductName"];
					c.UnitPrice = (Convert.IsDBNull(row["UnitPrice"]))?0:(System.Decimal?)row["UnitPrice"];
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
		/// Fill an <see cref="VList&lt;ProductsAboveAveragePrice&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;ProductsAboveAveragePrice&gt;"/></returns>
		protected VList<ProductsAboveAveragePrice> Fill(IDataReader reader, VList<ProductsAboveAveragePrice> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					ProductsAboveAveragePrice entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<ProductsAboveAveragePrice>("ProductsAboveAveragePrice",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new ProductsAboveAveragePrice();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ProductName = (System.String)reader[((int)ProductsAboveAveragePriceColumn.ProductName)];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					entity.UnitPrice = (reader.IsDBNull(((int)ProductsAboveAveragePriceColumn.UnitPrice)))?null:(System.Decimal?)reader[((int)ProductsAboveAveragePriceColumn.UnitPrice)];
					//entity.UnitPrice = (Convert.IsDBNull(reader["UnitPrice"]))?0:(System.Decimal?)reader["UnitPrice"];
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
		/// Refreshes the <see cref="ProductsAboveAveragePrice"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ProductsAboveAveragePrice"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, ProductsAboveAveragePrice entity)
		{
			reader.Read();
			entity.ProductName = (System.String)reader[((int)ProductsAboveAveragePriceColumn.ProductName)];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			entity.UnitPrice = (reader.IsDBNull(((int)ProductsAboveAveragePriceColumn.UnitPrice)))?null:(System.Decimal?)reader[((int)ProductsAboveAveragePriceColumn.UnitPrice)];
			//entity.UnitPrice = (Convert.IsDBNull(reader["UnitPrice"]))?0:(System.Decimal?)reader["UnitPrice"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="ProductsAboveAveragePrice"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ProductsAboveAveragePrice"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, ProductsAboveAveragePrice entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductName = (Convert.IsDBNull(dataRow["ProductName"]))?string.Empty:(System.String)dataRow["ProductName"];
			entity.UnitPrice = (Convert.IsDBNull(dataRow["UnitPrice"]))?0:(System.Decimal?)dataRow["UnitPrice"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region ProductsAboveAveragePriceFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductsAboveAveragePrice"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsAboveAveragePriceFilterBuilder : SqlFilterBuilder<ProductsAboveAveragePriceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceFilterBuilder class.
		/// </summary>
		public ProductsAboveAveragePriceFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsAboveAveragePriceFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsAboveAveragePriceFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsAboveAveragePriceFilterBuilder

	#region ProductsAboveAveragePriceParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductsAboveAveragePrice"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsAboveAveragePriceParameterBuilder : ParameterizedSqlFilterBuilder<ProductsAboveAveragePriceColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceParameterBuilder class.
		/// </summary>
		public ProductsAboveAveragePriceParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsAboveAveragePriceParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsAboveAveragePriceParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsAboveAveragePriceParameterBuilder
	
	#region ProductsAboveAveragePriceSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductsAboveAveragePrice"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductsAboveAveragePriceSortBuilder : SqlSortBuilder<ProductsAboveAveragePriceColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceSqlSortBuilder class.
		/// </summary>
		public ProductsAboveAveragePriceSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductsAboveAveragePriceSortBuilder

} // end namespace
