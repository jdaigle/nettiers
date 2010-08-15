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
	/// This class is the base class for any <see cref="AlphabeticalListOfProductsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class AlphabeticalListOfProductsProviderBaseCore : EntityViewProviderBase<AlphabeticalListOfProducts>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;AlphabeticalListOfProducts&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;AlphabeticalListOfProducts&gt;"/></returns>
		protected static VList&lt;AlphabeticalListOfProducts&gt; Fill(DataSet dataSet, VList<AlphabeticalListOfProducts> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<AlphabeticalListOfProducts>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;AlphabeticalListOfProducts&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<AlphabeticalListOfProducts>"/></returns>
		protected static VList&lt;AlphabeticalListOfProducts&gt; Fill(DataTable dataTable, VList<AlphabeticalListOfProducts> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					AlphabeticalListOfProducts c = new AlphabeticalListOfProducts();
					c.ProductId = (Convert.IsDBNull(row["ProductID"]))?(int)0:(System.Int32)row["ProductID"];
					c.ProductName = (Convert.IsDBNull(row["ProductName"]))?string.Empty:(System.String)row["ProductName"];
					c.SupplierId = (Convert.IsDBNull(row["SupplierID"]))?(int)0:(System.Int32?)row["SupplierID"];
					c.CategoryId = (Convert.IsDBNull(row["CategoryID"]))?(int)0:(System.Int32?)row["CategoryID"];
					c.QuantityPerUnit = (Convert.IsDBNull(row["QuantityPerUnit"]))?string.Empty:(System.String)row["QuantityPerUnit"];
					c.UnitPrice = (Convert.IsDBNull(row["UnitPrice"]))?0:(System.Decimal?)row["UnitPrice"];
					c.UnitsInStock = (Convert.IsDBNull(row["UnitsInStock"]))?(short)0:(System.Int16?)row["UnitsInStock"];
					c.UnitsOnOrder = (Convert.IsDBNull(row["UnitsOnOrder"]))?(short)0:(System.Int16?)row["UnitsOnOrder"];
					c.ReorderLevel = (Convert.IsDBNull(row["ReorderLevel"]))?(short)0:(System.Int16?)row["ReorderLevel"];
					c.Discontinued = (Convert.IsDBNull(row["Discontinued"]))?false:(System.Boolean)row["Discontinued"];
					c.CategoryName = (Convert.IsDBNull(row["CategoryName"]))?string.Empty:(System.String)row["CategoryName"];
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
		/// Fill an <see cref="VList&lt;AlphabeticalListOfProducts&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;AlphabeticalListOfProducts&gt;"/></returns>
		protected VList<AlphabeticalListOfProducts> Fill(IDataReader reader, VList<AlphabeticalListOfProducts> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					AlphabeticalListOfProducts entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<AlphabeticalListOfProducts>("AlphabeticalListOfProducts",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new AlphabeticalListOfProducts();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ProductId = (System.Int32)reader[((int)AlphabeticalListOfProductsColumn.ProductId)];
					//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
					entity.ProductName = (System.String)reader[((int)AlphabeticalListOfProductsColumn.ProductName)];
					//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
					entity.SupplierId = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.SupplierId)))?null:(System.Int32?)reader[((int)AlphabeticalListOfProductsColumn.SupplierId)];
					//entity.SupplierId = (Convert.IsDBNull(reader["SupplierID"]))?(int)0:(System.Int32?)reader["SupplierID"];
					entity.CategoryId = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.CategoryId)))?null:(System.Int32?)reader[((int)AlphabeticalListOfProductsColumn.CategoryId)];
					//entity.CategoryId = (Convert.IsDBNull(reader["CategoryID"]))?(int)0:(System.Int32?)reader["CategoryID"];
					entity.QuantityPerUnit = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.QuantityPerUnit)))?null:(System.String)reader[((int)AlphabeticalListOfProductsColumn.QuantityPerUnit)];
					//entity.QuantityPerUnit = (Convert.IsDBNull(reader["QuantityPerUnit"]))?string.Empty:(System.String)reader["QuantityPerUnit"];
					entity.UnitPrice = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.UnitPrice)))?null:(System.Decimal?)reader[((int)AlphabeticalListOfProductsColumn.UnitPrice)];
					//entity.UnitPrice = (Convert.IsDBNull(reader["UnitPrice"]))?0:(System.Decimal?)reader["UnitPrice"];
					entity.UnitsInStock = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.UnitsInStock)))?null:(System.Int16?)reader[((int)AlphabeticalListOfProductsColumn.UnitsInStock)];
					//entity.UnitsInStock = (Convert.IsDBNull(reader["UnitsInStock"]))?(short)0:(System.Int16?)reader["UnitsInStock"];
					entity.UnitsOnOrder = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.UnitsOnOrder)))?null:(System.Int16?)reader[((int)AlphabeticalListOfProductsColumn.UnitsOnOrder)];
					//entity.UnitsOnOrder = (Convert.IsDBNull(reader["UnitsOnOrder"]))?(short)0:(System.Int16?)reader["UnitsOnOrder"];
					entity.ReorderLevel = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.ReorderLevel)))?null:(System.Int16?)reader[((int)AlphabeticalListOfProductsColumn.ReorderLevel)];
					//entity.ReorderLevel = (Convert.IsDBNull(reader["ReorderLevel"]))?(short)0:(System.Int16?)reader["ReorderLevel"];
					entity.Discontinued = (System.Boolean)reader[((int)AlphabeticalListOfProductsColumn.Discontinued)];
					//entity.Discontinued = (Convert.IsDBNull(reader["Discontinued"]))?false:(System.Boolean)reader["Discontinued"];
					entity.CategoryName = (System.String)reader[((int)AlphabeticalListOfProductsColumn.CategoryName)];
					//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
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
		/// Refreshes the <see cref="AlphabeticalListOfProducts"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="AlphabeticalListOfProducts"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, AlphabeticalListOfProducts entity)
		{
			reader.Read();
			entity.ProductId = (System.Int32)reader[((int)AlphabeticalListOfProductsColumn.ProductId)];
			//entity.ProductId = (Convert.IsDBNull(reader["ProductID"]))?(int)0:(System.Int32)reader["ProductID"];
			entity.ProductName = (System.String)reader[((int)AlphabeticalListOfProductsColumn.ProductName)];
			//entity.ProductName = (Convert.IsDBNull(reader["ProductName"]))?string.Empty:(System.String)reader["ProductName"];
			entity.SupplierId = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.SupplierId)))?null:(System.Int32?)reader[((int)AlphabeticalListOfProductsColumn.SupplierId)];
			//entity.SupplierId = (Convert.IsDBNull(reader["SupplierID"]))?(int)0:(System.Int32?)reader["SupplierID"];
			entity.CategoryId = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.CategoryId)))?null:(System.Int32?)reader[((int)AlphabeticalListOfProductsColumn.CategoryId)];
			//entity.CategoryId = (Convert.IsDBNull(reader["CategoryID"]))?(int)0:(System.Int32?)reader["CategoryID"];
			entity.QuantityPerUnit = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.QuantityPerUnit)))?null:(System.String)reader[((int)AlphabeticalListOfProductsColumn.QuantityPerUnit)];
			//entity.QuantityPerUnit = (Convert.IsDBNull(reader["QuantityPerUnit"]))?string.Empty:(System.String)reader["QuantityPerUnit"];
			entity.UnitPrice = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.UnitPrice)))?null:(System.Decimal?)reader[((int)AlphabeticalListOfProductsColumn.UnitPrice)];
			//entity.UnitPrice = (Convert.IsDBNull(reader["UnitPrice"]))?0:(System.Decimal?)reader["UnitPrice"];
			entity.UnitsInStock = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.UnitsInStock)))?null:(System.Int16?)reader[((int)AlphabeticalListOfProductsColumn.UnitsInStock)];
			//entity.UnitsInStock = (Convert.IsDBNull(reader["UnitsInStock"]))?(short)0:(System.Int16?)reader["UnitsInStock"];
			entity.UnitsOnOrder = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.UnitsOnOrder)))?null:(System.Int16?)reader[((int)AlphabeticalListOfProductsColumn.UnitsOnOrder)];
			//entity.UnitsOnOrder = (Convert.IsDBNull(reader["UnitsOnOrder"]))?(short)0:(System.Int16?)reader["UnitsOnOrder"];
			entity.ReorderLevel = (reader.IsDBNull(((int)AlphabeticalListOfProductsColumn.ReorderLevel)))?null:(System.Int16?)reader[((int)AlphabeticalListOfProductsColumn.ReorderLevel)];
			//entity.ReorderLevel = (Convert.IsDBNull(reader["ReorderLevel"]))?(short)0:(System.Int16?)reader["ReorderLevel"];
			entity.Discontinued = (System.Boolean)reader[((int)AlphabeticalListOfProductsColumn.Discontinued)];
			//entity.Discontinued = (Convert.IsDBNull(reader["Discontinued"]))?false:(System.Boolean)reader["Discontinued"];
			entity.CategoryName = (System.String)reader[((int)AlphabeticalListOfProductsColumn.CategoryName)];
			//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="AlphabeticalListOfProducts"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="AlphabeticalListOfProducts"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, AlphabeticalListOfProducts entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProductId = (Convert.IsDBNull(dataRow["ProductID"]))?(int)0:(System.Int32)dataRow["ProductID"];
			entity.ProductName = (Convert.IsDBNull(dataRow["ProductName"]))?string.Empty:(System.String)dataRow["ProductName"];
			entity.SupplierId = (Convert.IsDBNull(dataRow["SupplierID"]))?(int)0:(System.Int32?)dataRow["SupplierID"];
			entity.CategoryId = (Convert.IsDBNull(dataRow["CategoryID"]))?(int)0:(System.Int32?)dataRow["CategoryID"];
			entity.QuantityPerUnit = (Convert.IsDBNull(dataRow["QuantityPerUnit"]))?string.Empty:(System.String)dataRow["QuantityPerUnit"];
			entity.UnitPrice = (Convert.IsDBNull(dataRow["UnitPrice"]))?0:(System.Decimal?)dataRow["UnitPrice"];
			entity.UnitsInStock = (Convert.IsDBNull(dataRow["UnitsInStock"]))?(short)0:(System.Int16?)dataRow["UnitsInStock"];
			entity.UnitsOnOrder = (Convert.IsDBNull(dataRow["UnitsOnOrder"]))?(short)0:(System.Int16?)dataRow["UnitsOnOrder"];
			entity.ReorderLevel = (Convert.IsDBNull(dataRow["ReorderLevel"]))?(short)0:(System.Int16?)dataRow["ReorderLevel"];
			entity.Discontinued = (Convert.IsDBNull(dataRow["Discontinued"]))?false:(System.Boolean)dataRow["Discontinued"];
			entity.CategoryName = (Convert.IsDBNull(dataRow["CategoryName"]))?string.Empty:(System.String)dataRow["CategoryName"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region AlphabeticalListOfProductsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AlphabeticalListOfProducts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AlphabeticalListOfProductsFilterBuilder : SqlFilterBuilder<AlphabeticalListOfProductsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsFilterBuilder class.
		/// </summary>
		public AlphabeticalListOfProductsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AlphabeticalListOfProductsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AlphabeticalListOfProductsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AlphabeticalListOfProductsFilterBuilder

	#region AlphabeticalListOfProductsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AlphabeticalListOfProducts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AlphabeticalListOfProductsParameterBuilder : ParameterizedSqlFilterBuilder<AlphabeticalListOfProductsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsParameterBuilder class.
		/// </summary>
		public AlphabeticalListOfProductsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AlphabeticalListOfProductsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AlphabeticalListOfProductsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AlphabeticalListOfProductsParameterBuilder
	
	#region AlphabeticalListOfProductsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AlphabeticalListOfProducts"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AlphabeticalListOfProductsSortBuilder : SqlSortBuilder<AlphabeticalListOfProductsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsSqlSortBuilder class.
		/// </summary>
		public AlphabeticalListOfProductsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AlphabeticalListOfProductsSortBuilder

} // end namespace
