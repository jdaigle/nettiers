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
	/// This class is the base class for any <see cref="CategorySalesFor1997ProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class CategorySalesFor1997ProviderBaseCore : EntityViewProviderBase<CategorySalesFor1997>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;CategorySalesFor1997&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;CategorySalesFor1997&gt;"/></returns>
		protected static VList&lt;CategorySalesFor1997&gt; Fill(DataSet dataSet, VList<CategorySalesFor1997> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<CategorySalesFor1997>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;CategorySalesFor1997&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<CategorySalesFor1997>"/></returns>
		protected static VList&lt;CategorySalesFor1997&gt; Fill(DataTable dataTable, VList<CategorySalesFor1997> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					CategorySalesFor1997 c = new CategorySalesFor1997();
					c.CategoryName = (Convert.IsDBNull(row["CategoryName"]))?string.Empty:(System.String)row["CategoryName"];
					c.CategorySales = (Convert.IsDBNull(row["CategorySales"]))?0:(System.Decimal?)row["CategorySales"];
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
		/// Fill an <see cref="VList&lt;CategorySalesFor1997&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;CategorySalesFor1997&gt;"/></returns>
		protected VList<CategorySalesFor1997> Fill(IDataReader reader, VList<CategorySalesFor1997> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					CategorySalesFor1997 entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<CategorySalesFor1997>("CategorySalesFor1997",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new CategorySalesFor1997();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CategoryName = (System.String)reader[((int)CategorySalesFor1997Column.CategoryName)];
					//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
					entity.CategorySales = (reader.IsDBNull(((int)CategorySalesFor1997Column.CategorySales)))?null:(System.Decimal?)reader[((int)CategorySalesFor1997Column.CategorySales)];
					//entity.CategorySales = (Convert.IsDBNull(reader["CategorySales"]))?0:(System.Decimal?)reader["CategorySales"];
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
		/// Refreshes the <see cref="CategorySalesFor1997"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CategorySalesFor1997"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, CategorySalesFor1997 entity)
		{
			reader.Read();
			entity.CategoryName = (System.String)reader[((int)CategorySalesFor1997Column.CategoryName)];
			//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
			entity.CategorySales = (reader.IsDBNull(((int)CategorySalesFor1997Column.CategorySales)))?null:(System.Decimal?)reader[((int)CategorySalesFor1997Column.CategorySales)];
			//entity.CategorySales = (Convert.IsDBNull(reader["CategorySales"]))?0:(System.Decimal?)reader["CategorySales"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="CategorySalesFor1997"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CategorySalesFor1997"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, CategorySalesFor1997 entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CategoryName = (Convert.IsDBNull(dataRow["CategoryName"]))?string.Empty:(System.String)dataRow["CategoryName"];
			entity.CategorySales = (Convert.IsDBNull(dataRow["CategorySales"]))?0:(System.Decimal?)dataRow["CategorySales"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region CategorySalesFor1997FilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CategorySalesFor1997"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategorySalesFor1997FilterBuilder : SqlFilterBuilder<CategorySalesFor1997Column>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997FilterBuilder class.
		/// </summary>
		public CategorySalesFor1997FilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997FilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategorySalesFor1997FilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997FilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategorySalesFor1997FilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategorySalesFor1997FilterBuilder

	#region CategorySalesFor1997ParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CategorySalesFor1997"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategorySalesFor1997ParameterBuilder : ParameterizedSqlFilterBuilder<CategorySalesFor1997Column>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997ParameterBuilder class.
		/// </summary>
		public CategorySalesFor1997ParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997ParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategorySalesFor1997ParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997ParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategorySalesFor1997ParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategorySalesFor1997ParameterBuilder
	
	#region CategorySalesFor1997SortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CategorySalesFor1997"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CategorySalesFor1997SortBuilder : SqlSortBuilder<CategorySalesFor1997Column>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997SqlSortBuilder class.
		/// </summary>
		public CategorySalesFor1997SortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CategorySalesFor1997SortBuilder

} // end namespace
