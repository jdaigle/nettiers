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
	/// This class is the base class for any <see cref="CustomerAndSuppliersByCityProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class CustomerAndSuppliersByCityProviderBaseCore : EntityViewProviderBase<CustomerAndSuppliersByCity>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;CustomerAndSuppliersByCity&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;CustomerAndSuppliersByCity&gt;"/></returns>
		protected static VList&lt;CustomerAndSuppliersByCity&gt; Fill(DataSet dataSet, VList<CustomerAndSuppliersByCity> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<CustomerAndSuppliersByCity>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;CustomerAndSuppliersByCity&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<CustomerAndSuppliersByCity>"/></returns>
		protected static VList&lt;CustomerAndSuppliersByCity&gt; Fill(DataTable dataTable, VList<CustomerAndSuppliersByCity> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					CustomerAndSuppliersByCity c = new CustomerAndSuppliersByCity();
					c.City = (Convert.IsDBNull(row["City"]))?string.Empty:(System.String)row["City"];
					c.CompanyName = (Convert.IsDBNull(row["CompanyName"]))?string.Empty:(System.String)row["CompanyName"];
					c.ContactName = (Convert.IsDBNull(row["ContactName"]))?string.Empty:(System.String)row["ContactName"];
					c.Relationship = (Convert.IsDBNull(row["Relationship"]))?string.Empty:(System.String)row["Relationship"];
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
		/// Fill an <see cref="VList&lt;CustomerAndSuppliersByCity&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;CustomerAndSuppliersByCity&gt;"/></returns>
		protected VList<CustomerAndSuppliersByCity> Fill(IDataReader reader, VList<CustomerAndSuppliersByCity> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					CustomerAndSuppliersByCity entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<CustomerAndSuppliersByCity>("CustomerAndSuppliersByCity",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new CustomerAndSuppliersByCity();
					}
					
					entity.SuppressEntityEvents = true;

					entity.City = (reader.IsDBNull(((int)CustomerAndSuppliersByCityColumn.City)))?null:(System.String)reader[((int)CustomerAndSuppliersByCityColumn.City)];
					//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
					entity.CompanyName = (System.String)reader[((int)CustomerAndSuppliersByCityColumn.CompanyName)];
					//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
					entity.ContactName = (reader.IsDBNull(((int)CustomerAndSuppliersByCityColumn.ContactName)))?null:(System.String)reader[((int)CustomerAndSuppliersByCityColumn.ContactName)];
					//entity.ContactName = (Convert.IsDBNull(reader["ContactName"]))?string.Empty:(System.String)reader["ContactName"];
					entity.Relationship = (System.String)reader[((int)CustomerAndSuppliersByCityColumn.Relationship)];
					//entity.Relationship = (Convert.IsDBNull(reader["Relationship"]))?string.Empty:(System.String)reader["Relationship"];
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
		/// Refreshes the <see cref="CustomerAndSuppliersByCity"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CustomerAndSuppliersByCity"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, CustomerAndSuppliersByCity entity)
		{
			reader.Read();
			entity.City = (reader.IsDBNull(((int)CustomerAndSuppliersByCityColumn.City)))?null:(System.String)reader[((int)CustomerAndSuppliersByCityColumn.City)];
			//entity.City = (Convert.IsDBNull(reader["City"]))?string.Empty:(System.String)reader["City"];
			entity.CompanyName = (System.String)reader[((int)CustomerAndSuppliersByCityColumn.CompanyName)];
			//entity.CompanyName = (Convert.IsDBNull(reader["CompanyName"]))?string.Empty:(System.String)reader["CompanyName"];
			entity.ContactName = (reader.IsDBNull(((int)CustomerAndSuppliersByCityColumn.ContactName)))?null:(System.String)reader[((int)CustomerAndSuppliersByCityColumn.ContactName)];
			//entity.ContactName = (Convert.IsDBNull(reader["ContactName"]))?string.Empty:(System.String)reader["ContactName"];
			entity.Relationship = (System.String)reader[((int)CustomerAndSuppliersByCityColumn.Relationship)];
			//entity.Relationship = (Convert.IsDBNull(reader["Relationship"]))?string.Empty:(System.String)reader["Relationship"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="CustomerAndSuppliersByCity"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CustomerAndSuppliersByCity"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, CustomerAndSuppliersByCity entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.City = (Convert.IsDBNull(dataRow["City"]))?string.Empty:(System.String)dataRow["City"];
			entity.CompanyName = (Convert.IsDBNull(dataRow["CompanyName"]))?string.Empty:(System.String)dataRow["CompanyName"];
			entity.ContactName = (Convert.IsDBNull(dataRow["ContactName"]))?string.Empty:(System.String)dataRow["ContactName"];
			entity.Relationship = (Convert.IsDBNull(dataRow["Relationship"]))?string.Empty:(System.String)dataRow["Relationship"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region CustomerAndSuppliersByCityFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerAndSuppliersByCity"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerAndSuppliersByCityFilterBuilder : SqlFilterBuilder<CustomerAndSuppliersByCityColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityFilterBuilder class.
		/// </summary>
		public CustomerAndSuppliersByCityFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerAndSuppliersByCityFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerAndSuppliersByCityFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerAndSuppliersByCityFilterBuilder

	#region CustomerAndSuppliersByCityParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerAndSuppliersByCity"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerAndSuppliersByCityParameterBuilder : ParameterizedSqlFilterBuilder<CustomerAndSuppliersByCityColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityParameterBuilder class.
		/// </summary>
		public CustomerAndSuppliersByCityParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerAndSuppliersByCityParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerAndSuppliersByCityParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerAndSuppliersByCityParameterBuilder
	
	#region CustomerAndSuppliersByCitySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerAndSuppliersByCity"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomerAndSuppliersByCitySortBuilder : SqlSortBuilder<CustomerAndSuppliersByCityColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCitySqlSortBuilder class.
		/// </summary>
		public CustomerAndSuppliersByCitySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomerAndSuppliersByCitySortBuilder

} // end namespace
