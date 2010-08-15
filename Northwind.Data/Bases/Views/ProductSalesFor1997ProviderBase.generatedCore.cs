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
	/// This class is the base class for any <see cref="ProductSalesFor1997ProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ProductSalesFor1997ProviderBaseCore : EntityViewProviderBase<ProductSalesFor1997>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;ProductSalesFor1997&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;ProductSalesFor1997&gt;"/></returns>
		protected static VList&lt;ProductSalesFor1997&gt; Fill(DataSet dataSet, VList<ProductSalesFor1997> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<ProductSalesFor1997>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;ProductSalesFor1997&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<ProductSalesFor1997>"/></returns>
		protected static VList&lt;ProductSalesFor1997&gt; Fill(DataTable dataTable, VList<ProductSalesFor1997> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					ProductSalesFor1997 c = new ProductSalesFor1997();
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
		/// Fill an <see cref="VList&lt;ProductSalesFor1997&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;ProductSalesFor1997&gt;"/></returns>
		protected VList<ProductSalesFor1997> Fill(IDataReader reader, VList<ProductSalesFor1997> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					ProductSalesFor1997 entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<ProductSalesFor1997>("ProductSalesFor1997",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new ProductSalesFor1997();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CategoryName = (System.String)reader[((int)ProductSalesFor1997Column.CategoryName)];
					//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
					entity.ProductName = (System.String)reader[((int)ProductSalesFor1997Column.ProductName)];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					entity.ProductSales = (reader.IsDBNull(((int)ProductSalesFor1997Column.ProductSales)))?null:(System.Decimal?)reader[((int)ProductSalesFor1997Column.ProductSales)];
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
		/// Refreshes the <see cref="ProductSalesFor1997"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ProductSalesFor1997"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, ProductSalesFor1997 entity)
		{
			reader.Read();
			entity.CategoryName = (System.String)reader[((int)ProductSalesFor1997Column.CategoryName)];
			//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
			entity.ProductName = (System.String)reader[((int)ProductSalesFor1997Column.ProductName)];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			entity.ProductSales = (reader.IsDBNull(((int)ProductSalesFor1997Column.ProductSales)))?null:(System.Decimal?)reader[((int)ProductSalesFor1997Column.ProductSales)];
			//entity.ProductSales = (Convert.IsDBNull(reader["ProductSales"]))?0:(System.Decimal?)reader["ProductSales"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="ProductSalesFor1997"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ProductSalesFor1997"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, ProductSalesFor1997 entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CategoryName = (Convert.IsDBNull(dataRow["CategoryName"]))?string.Empty:(System.String)dataRow["CategoryName"];
			entity.ProductName = (Convert.IsDBNull(dataRow["ProductName"]))?string.Empty:(System.String)dataRow["ProductName"];
			entity.ProductSales = (Convert.IsDBNull(dataRow["ProductSales"]))?0:(System.Decimal?)dataRow["ProductSales"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region ProductSalesFor1997FilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductSalesFor1997"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductSalesFor1997FilterBuilder : SqlFilterBuilder<ProductSalesFor1997Column>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997FilterBuilder class.
		/// </summary>
		public ProductSalesFor1997FilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997FilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductSalesFor1997FilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997FilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductSalesFor1997FilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductSalesFor1997FilterBuilder

	#region ProductSalesFor1997ParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductSalesFor1997"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductSalesFor1997ParameterBuilder : ParameterizedSqlFilterBuilder<ProductSalesFor1997Column>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997ParameterBuilder class.
		/// </summary>
		public ProductSalesFor1997ParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997ParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductSalesFor1997ParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997ParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductSalesFor1997ParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductSalesFor1997ParameterBuilder
	
	#region ProductSalesFor1997SortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductSalesFor1997"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductSalesFor1997SortBuilder : SqlSortBuilder<ProductSalesFor1997Column>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997SqlSortBuilder class.
		/// </summary>
		public ProductSalesFor1997SortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductSalesFor1997SortBuilder

} // end namespace
