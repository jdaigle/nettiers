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
	/// This class is the base class for any <see cref="ProductsByCategoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class ProductsByCategoryProviderBaseCore : EntityViewProviderBase<ProductsByCategory>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;ProductsByCategory&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;ProductsByCategory&gt;"/></returns>
		protected static VList&lt;ProductsByCategory&gt; Fill(DataSet dataSet, VList<ProductsByCategory> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<ProductsByCategory>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;ProductsByCategory&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<ProductsByCategory>"/></returns>
		protected static VList&lt;ProductsByCategory&gt; Fill(DataTable dataTable, VList<ProductsByCategory> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					ProductsByCategory c = new ProductsByCategory();
					c.CategoryName = (Convert.IsDBNull(row["CategoryName"]))?string.Empty:(System.String)row["CategoryName"];
					c.ProductName = (Convert.IsDBNull(row["ProductName"]))?string.Empty:(System.String)row["ProductName"];
					c.QuantityPerUnit = (Convert.IsDBNull(row["QuantityPerUnit"]))?string.Empty:(System.String)row["QuantityPerUnit"];
					c.UnitsInStock = (Convert.IsDBNull(row["UnitsInStock"]))?(short)0:(System.Int16?)row["UnitsInStock"];
					c.Discontinued = (Convert.IsDBNull(row["Discontinued"]))?false:(System.Boolean)row["Discontinued"];
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
		/// Fill an <see cref="VList&lt;ProductsByCategory&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;ProductsByCategory&gt;"/></returns>
		protected VList<ProductsByCategory> Fill(IDataReader reader, VList<ProductsByCategory> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					ProductsByCategory entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<ProductsByCategory>("ProductsByCategory",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new ProductsByCategory();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CategoryName = (System.String)reader[((int)ProductsByCategoryColumn.CategoryName)];
					//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
					entity.ProductName = (System.String)reader[((int)ProductsByCategoryColumn.ProductName)];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					entity.QuantityPerUnit = (reader.IsDBNull(((int)ProductsByCategoryColumn.QuantityPerUnit)))?null:(System.String)reader[((int)ProductsByCategoryColumn.QuantityPerUnit)];
					//entity.QuantityPerUnit = (Convert.IsDBNull(reader["QuantityPerUnit"]))?string.Empty:(System.String)reader["QuantityPerUnit"];
					entity.UnitsInStock = (reader.IsDBNull(((int)ProductsByCategoryColumn.UnitsInStock)))?null:(System.Int16?)reader[((int)ProductsByCategoryColumn.UnitsInStock)];
					//entity.UnitsInStock = (Convert.IsDBNull(reader["UnitsInStock"]))?(short)0:(System.Int16?)reader["UnitsInStock"];
					entity.Discontinued = (System.Boolean)reader[((int)ProductsByCategoryColumn.Discontinued)];
					//entity.Discontinued = (Convert.IsDBNull(reader["Discontinued"]))?false:(System.Boolean)reader["Discontinued"];
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
		/// Refreshes the <see cref="ProductsByCategory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ProductsByCategory"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, ProductsByCategory entity)
		{
			reader.Read();
			entity.CategoryName = (System.String)reader[((int)ProductsByCategoryColumn.CategoryName)];
			//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
			entity.ProductName = (System.String)reader[((int)ProductsByCategoryColumn.ProductName)];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			entity.QuantityPerUnit = (reader.IsDBNull(((int)ProductsByCategoryColumn.QuantityPerUnit)))?null:(System.String)reader[((int)ProductsByCategoryColumn.QuantityPerUnit)];
			//entity.QuantityPerUnit = (Convert.IsDBNull(reader["QuantityPerUnit"]))?string.Empty:(System.String)reader["QuantityPerUnit"];
			entity.UnitsInStock = (reader.IsDBNull(((int)ProductsByCategoryColumn.UnitsInStock)))?null:(System.Int16?)reader[((int)ProductsByCategoryColumn.UnitsInStock)];
			//entity.UnitsInStock = (Convert.IsDBNull(reader["UnitsInStock"]))?(short)0:(System.Int16?)reader["UnitsInStock"];
			entity.Discontinued = (System.Boolean)reader[((int)ProductsByCategoryColumn.Discontinued)];
			//entity.Discontinued = (Convert.IsDBNull(reader["Discontinued"]))?false:(System.Boolean)reader["Discontinued"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="ProductsByCategory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ProductsByCategory"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, ProductsByCategory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CategoryName = (Convert.IsDBNull(dataRow["CategoryName"]))?string.Empty:(System.String)dataRow["CategoryName"];
			entity.ProductName = (Convert.IsDBNull(dataRow["ProductName"]))?string.Empty:(System.String)dataRow["ProductName"];
			entity.QuantityPerUnit = (Convert.IsDBNull(dataRow["QuantityPerUnit"]))?string.Empty:(System.String)dataRow["QuantityPerUnit"];
			entity.UnitsInStock = (Convert.IsDBNull(dataRow["UnitsInStock"]))?(short)0:(System.Int16?)dataRow["UnitsInStock"];
			entity.Discontinued = (Convert.IsDBNull(dataRow["Discontinued"]))?false:(System.Boolean)dataRow["Discontinued"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region ProductsByCategoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductsByCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsByCategoryFilterBuilder : SqlFilterBuilder<ProductsByCategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryFilterBuilder class.
		/// </summary>
		public ProductsByCategoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsByCategoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsByCategoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsByCategoryFilterBuilder

	#region ProductsByCategoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductsByCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsByCategoryParameterBuilder : ParameterizedSqlFilterBuilder<ProductsByCategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryParameterBuilder class.
		/// </summary>
		public ProductsByCategoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsByCategoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsByCategoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsByCategoryParameterBuilder
	
	#region ProductsByCategorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductsByCategory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProductsByCategorySortBuilder : SqlSortBuilder<ProductsByCategoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsByCategorySqlSortBuilder class.
		/// </summary>
		public ProductsByCategorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProductsByCategorySortBuilder

} // end namespace
