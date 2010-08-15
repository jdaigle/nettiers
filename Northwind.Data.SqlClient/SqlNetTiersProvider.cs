
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Northwind.Entities;
using Northwind.Data;
using Northwind.Data.Bases;

#endregion

namespace Northwind.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : Northwind.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <see cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "OrdersProvider"
			
		private SqlOrdersProvider innerSqlOrdersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Orders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrdersProviderBase OrdersProvider
		{
			get
			{
				if (innerSqlOrdersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrdersProvider == null)
						{
							this.innerSqlOrdersProvider = new SqlOrdersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrdersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlOrdersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrdersProvider SqlOrdersProvider
		{
			get {return OrdersProvider as SqlOrdersProvider;}
		}
		
		#endregion
		
		
		#region "SuppliersProvider"
			
		private SqlSuppliersProvider innerSqlSuppliersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Suppliers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SuppliersProviderBase SuppliersProvider
		{
			get
			{
				if (innerSqlSuppliersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSuppliersProvider == null)
						{
							this.innerSqlSuppliersProvider = new SqlSuppliersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSuppliersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSuppliersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSuppliersProvider SqlSuppliersProvider
		{
			get {return SuppliersProvider as SqlSuppliersProvider;}
		}
		
		#endregion
		
		
		#region "RegionProvider"
			
		private SqlRegionProvider innerSqlRegionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Region"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RegionProviderBase RegionProvider
		{
			get
			{
				if (innerSqlRegionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRegionProvider == null)
						{
							this.innerSqlRegionProvider = new SqlRegionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRegionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlRegionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRegionProvider SqlRegionProvider
		{
			get {return RegionProvider as SqlRegionProvider;}
		}
		
		#endregion
		
		
		#region "CategoriesProvider"
			
		private SqlCategoriesProvider innerSqlCategoriesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Categories"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CategoriesProviderBase CategoriesProvider
		{
			get
			{
				if (innerSqlCategoriesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCategoriesProvider == null)
						{
							this.innerSqlCategoriesProvider = new SqlCategoriesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCategoriesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCategoriesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCategoriesProvider SqlCategoriesProvider
		{
			get {return CategoriesProvider as SqlCategoriesProvider;}
		}
		
		#endregion
		
		
		#region "ShippersProvider"
			
		private SqlShippersProvider innerSqlShippersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Shippers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ShippersProviderBase ShippersProvider
		{
			get
			{
				if (innerSqlShippersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlShippersProvider == null)
						{
							this.innerSqlShippersProvider = new SqlShippersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlShippersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlShippersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlShippersProvider SqlShippersProvider
		{
			get {return ShippersProvider as SqlShippersProvider;}
		}
		
		#endregion
		
		
		#region "EmployeeTerritoriesProvider"
			
		private SqlEmployeeTerritoriesProvider innerSqlEmployeeTerritoriesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmployeeTerritories"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeTerritoriesProviderBase EmployeeTerritoriesProvider
		{
			get
			{
				if (innerSqlEmployeeTerritoriesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmployeeTerritoriesProvider == null)
						{
							this.innerSqlEmployeeTerritoriesProvider = new SqlEmployeeTerritoriesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmployeeTerritoriesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEmployeeTerritoriesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmployeeTerritoriesProvider SqlEmployeeTerritoriesProvider
		{
			get {return EmployeeTerritoriesProvider as SqlEmployeeTerritoriesProvider;}
		}
		
		#endregion
		
		
		#region "EmployeesProvider"
			
		private SqlEmployeesProvider innerSqlEmployeesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Employees"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeesProviderBase EmployeesProvider
		{
			get
			{
				if (innerSqlEmployeesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmployeesProvider == null)
						{
							this.innerSqlEmployeesProvider = new SqlEmployeesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmployeesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEmployeesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmployeesProvider SqlEmployeesProvider
		{
			get {return EmployeesProvider as SqlEmployeesProvider;}
		}
		
		#endregion
		
		
		#region "TerritoriesProvider"
			
		private SqlTerritoriesProvider innerSqlTerritoriesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Territories"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TerritoriesProviderBase TerritoriesProvider
		{
			get
			{
				if (innerSqlTerritoriesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTerritoriesProvider == null)
						{
							this.innerSqlTerritoriesProvider = new SqlTerritoriesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTerritoriesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlTerritoriesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTerritoriesProvider SqlTerritoriesProvider
		{
			get {return TerritoriesProvider as SqlTerritoriesProvider;}
		}
		
		#endregion
		
		
		#region "CustomerDemographicsProvider"
			
		private SqlCustomerDemographicsProvider innerSqlCustomerDemographicsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomerDemographics"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerDemographicsProviderBase CustomerDemographicsProvider
		{
			get
			{
				if (innerSqlCustomerDemographicsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerDemographicsProvider == null)
						{
							this.innerSqlCustomerDemographicsProvider = new SqlCustomerDemographicsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerDemographicsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCustomerDemographicsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerDemographicsProvider SqlCustomerDemographicsProvider
		{
			get {return CustomerDemographicsProvider as SqlCustomerDemographicsProvider;}
		}
		
		#endregion
		
		
		#region "CustomersProvider"
			
		private SqlCustomersProvider innerSqlCustomersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Customers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomersProviderBase CustomersProvider
		{
			get
			{
				if (innerSqlCustomersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomersProvider == null)
						{
							this.innerSqlCustomersProvider = new SqlCustomersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCustomersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomersProvider SqlCustomersProvider
		{
			get {return CustomersProvider as SqlCustomersProvider;}
		}
		
		#endregion
		
		
		#region "ProductsProvider"
			
		private SqlProductsProvider innerSqlProductsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Products"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductsProviderBase ProductsProvider
		{
			get
			{
				if (innerSqlProductsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductsProvider == null)
						{
							this.innerSqlProductsProvider = new SqlProductsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductsProvider SqlProductsProvider
		{
			get {return ProductsProvider as SqlProductsProvider;}
		}
		
		#endregion
		
		
		#region "OrderDetailsProvider"
			
		private SqlOrderDetailsProvider innerSqlOrderDetailsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderDetailsProviderBase OrderDetailsProvider
		{
			get
			{
				if (innerSqlOrderDetailsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrderDetailsProvider == null)
						{
							this.innerSqlOrderDetailsProvider = new SqlOrderDetailsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrderDetailsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlOrderDetailsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrderDetailsProvider SqlOrderDetailsProvider
		{
			get {return OrderDetailsProvider as SqlOrderDetailsProvider;}
		}
		
		#endregion
		
		
		#region "CustomerCustomerDemoProvider"
			
		private SqlCustomerCustomerDemoProvider innerSqlCustomerCustomerDemoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomerCustomerDemo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerCustomerDemoProviderBase CustomerCustomerDemoProvider
		{
			get
			{
				if (innerSqlCustomerCustomerDemoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerCustomerDemoProvider == null)
						{
							this.innerSqlCustomerCustomerDemoProvider = new SqlCustomerCustomerDemoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerCustomerDemoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCustomerCustomerDemoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerCustomerDemoProvider SqlCustomerCustomerDemoProvider
		{
			get {return CustomerCustomerDemoProvider as SqlCustomerCustomerDemoProvider;}
		}
		
		#endregion
		
		
		
		#region "AlphabeticalListOfProductsProvider"
		
		private SqlAlphabeticalListOfProductsProvider innerSqlAlphabeticalListOfProductsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AlphabeticalListOfProducts"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AlphabeticalListOfProductsProviderBase AlphabeticalListOfProductsProvider
		{
			get
			{
				if (innerSqlAlphabeticalListOfProductsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAlphabeticalListOfProductsProvider == null)
						{
							this.innerSqlAlphabeticalListOfProductsProvider = new SqlAlphabeticalListOfProductsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAlphabeticalListOfProductsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAlphabeticalListOfProductsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAlphabeticalListOfProductsProvider SqlAlphabeticalListOfProductsProvider
		{
			get {return AlphabeticalListOfProductsProvider as SqlAlphabeticalListOfProductsProvider;}
		}
		
		#endregion
		
		
		#region "CategorySalesFor1997Provider"
		
		private SqlCategorySalesFor1997Provider innerSqlCategorySalesFor1997Provider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CategorySalesFor1997"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CategorySalesFor1997ProviderBase CategorySalesFor1997Provider
		{
			get
			{
				if (innerSqlCategorySalesFor1997Provider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCategorySalesFor1997Provider == null)
						{
							this.innerSqlCategorySalesFor1997Provider = new SqlCategorySalesFor1997Provider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCategorySalesFor1997Provider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCategorySalesFor1997Provider"/>.
		/// </summary>
		/// <value></value>
		public SqlCategorySalesFor1997Provider SqlCategorySalesFor1997Provider
		{
			get {return CategorySalesFor1997Provider as SqlCategorySalesFor1997Provider;}
		}
		
		#endregion
		
		
		#region "CurrentProductListProvider"
		
		private SqlCurrentProductListProvider innerSqlCurrentProductListProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CurrentProductList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CurrentProductListProviderBase CurrentProductListProvider
		{
			get
			{
				if (innerSqlCurrentProductListProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCurrentProductListProvider == null)
						{
							this.innerSqlCurrentProductListProvider = new SqlCurrentProductListProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCurrentProductListProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCurrentProductListProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCurrentProductListProvider SqlCurrentProductListProvider
		{
			get {return CurrentProductListProvider as SqlCurrentProductListProvider;}
		}
		
		#endregion
		
		
		#region "CustomerAndSuppliersByCityProvider"
		
		private SqlCustomerAndSuppliersByCityProvider innerSqlCustomerAndSuppliersByCityProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomerAndSuppliersByCity"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerAndSuppliersByCityProviderBase CustomerAndSuppliersByCityProvider
		{
			get
			{
				if (innerSqlCustomerAndSuppliersByCityProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerAndSuppliersByCityProvider == null)
						{
							this.innerSqlCustomerAndSuppliersByCityProvider = new SqlCustomerAndSuppliersByCityProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerAndSuppliersByCityProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCustomerAndSuppliersByCityProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerAndSuppliersByCityProvider SqlCustomerAndSuppliersByCityProvider
		{
			get {return CustomerAndSuppliersByCityProvider as SqlCustomerAndSuppliersByCityProvider;}
		}
		
		#endregion
		
		
		#region "InvoicesProvider"
		
		private SqlInvoicesProvider innerSqlInvoicesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Invoices"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override InvoicesProviderBase InvoicesProvider
		{
			get
			{
				if (innerSqlInvoicesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlInvoicesProvider == null)
						{
							this.innerSqlInvoicesProvider = new SqlInvoicesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlInvoicesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlInvoicesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlInvoicesProvider SqlInvoicesProvider
		{
			get {return InvoicesProvider as SqlInvoicesProvider;}
		}
		
		#endregion
		
		
		#region "OrderDetailsExtendedProvider"
		
		private SqlOrderDetailsExtendedProvider innerSqlOrderDetailsExtendedProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderDetailsExtended"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderDetailsExtendedProviderBase OrderDetailsExtendedProvider
		{
			get
			{
				if (innerSqlOrderDetailsExtendedProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrderDetailsExtendedProvider == null)
						{
							this.innerSqlOrderDetailsExtendedProvider = new SqlOrderDetailsExtendedProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrderDetailsExtendedProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlOrderDetailsExtendedProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrderDetailsExtendedProvider SqlOrderDetailsExtendedProvider
		{
			get {return OrderDetailsExtendedProvider as SqlOrderDetailsExtendedProvider;}
		}
		
		#endregion
		
		
		#region "OrderSubtotalsProvider"
		
		private SqlOrderSubtotalsProvider innerSqlOrderSubtotalsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderSubtotals"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderSubtotalsProviderBase OrderSubtotalsProvider
		{
			get
			{
				if (innerSqlOrderSubtotalsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrderSubtotalsProvider == null)
						{
							this.innerSqlOrderSubtotalsProvider = new SqlOrderSubtotalsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrderSubtotalsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlOrderSubtotalsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrderSubtotalsProvider SqlOrderSubtotalsProvider
		{
			get {return OrderSubtotalsProvider as SqlOrderSubtotalsProvider;}
		}
		
		#endregion
		
		
		#region "OrdersQryProvider"
		
		private SqlOrdersQryProvider innerSqlOrdersQryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrdersQry"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrdersQryProviderBase OrdersQryProvider
		{
			get
			{
				if (innerSqlOrdersQryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrdersQryProvider == null)
						{
							this.innerSqlOrdersQryProvider = new SqlOrdersQryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrdersQryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlOrdersQryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrdersQryProvider SqlOrdersQryProvider
		{
			get {return OrdersQryProvider as SqlOrdersQryProvider;}
		}
		
		#endregion
		
		
		#region "ProductSalesFor1997Provider"
		
		private SqlProductSalesFor1997Provider innerSqlProductSalesFor1997Provider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductSalesFor1997"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductSalesFor1997ProviderBase ProductSalesFor1997Provider
		{
			get
			{
				if (innerSqlProductSalesFor1997Provider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductSalesFor1997Provider == null)
						{
							this.innerSqlProductSalesFor1997Provider = new SqlProductSalesFor1997Provider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductSalesFor1997Provider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductSalesFor1997Provider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductSalesFor1997Provider SqlProductSalesFor1997Provider
		{
			get {return ProductSalesFor1997Provider as SqlProductSalesFor1997Provider;}
		}
		
		#endregion
		
		
		#region "ProductsAboveAveragePriceProvider"
		
		private SqlProductsAboveAveragePriceProvider innerSqlProductsAboveAveragePriceProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductsAboveAveragePrice"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductsAboveAveragePriceProviderBase ProductsAboveAveragePriceProvider
		{
			get
			{
				if (innerSqlProductsAboveAveragePriceProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductsAboveAveragePriceProvider == null)
						{
							this.innerSqlProductsAboveAveragePriceProvider = new SqlProductsAboveAveragePriceProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductsAboveAveragePriceProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductsAboveAveragePriceProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductsAboveAveragePriceProvider SqlProductsAboveAveragePriceProvider
		{
			get {return ProductsAboveAveragePriceProvider as SqlProductsAboveAveragePriceProvider;}
		}
		
		#endregion
		
		
		#region "ProductsByCategoryProvider"
		
		private SqlProductsByCategoryProvider innerSqlProductsByCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProductsByCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProductsByCategoryProviderBase ProductsByCategoryProvider
		{
			get
			{
				if (innerSqlProductsByCategoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProductsByCategoryProvider == null)
						{
							this.innerSqlProductsByCategoryProvider = new SqlProductsByCategoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProductsByCategoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProductsByCategoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProductsByCategoryProvider SqlProductsByCategoryProvider
		{
			get {return ProductsByCategoryProvider as SqlProductsByCategoryProvider;}
		}
		
		#endregion
		
		
		#region "QuarterlyOrdersProvider"
		
		private SqlQuarterlyOrdersProvider innerSqlQuarterlyOrdersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuarterlyOrders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuarterlyOrdersProviderBase QuarterlyOrdersProvider
		{
			get
			{
				if (innerSqlQuarterlyOrdersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuarterlyOrdersProvider == null)
						{
							this.innerSqlQuarterlyOrdersProvider = new SqlQuarterlyOrdersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuarterlyOrdersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlQuarterlyOrdersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuarterlyOrdersProvider SqlQuarterlyOrdersProvider
		{
			get {return QuarterlyOrdersProvider as SqlQuarterlyOrdersProvider;}
		}
		
		#endregion
		
		
		#region "SalesByCategoryProvider"
		
		private SqlSalesByCategoryProvider innerSqlSalesByCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesByCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesByCategoryProviderBase SalesByCategoryProvider
		{
			get
			{
				if (innerSqlSalesByCategoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesByCategoryProvider == null)
						{
							this.innerSqlSalesByCategoryProvider = new SqlSalesByCategoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesByCategoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSalesByCategoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesByCategoryProvider SqlSalesByCategoryProvider
		{
			get {return SalesByCategoryProvider as SqlSalesByCategoryProvider;}
		}
		
		#endregion
		
		
		#region "SalesTotalsByAmountProvider"
		
		private SqlSalesTotalsByAmountProvider innerSqlSalesTotalsByAmountProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalesTotalsByAmount"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalesTotalsByAmountProviderBase SalesTotalsByAmountProvider
		{
			get
			{
				if (innerSqlSalesTotalsByAmountProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalesTotalsByAmountProvider == null)
						{
							this.innerSqlSalesTotalsByAmountProvider = new SqlSalesTotalsByAmountProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalesTotalsByAmountProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSalesTotalsByAmountProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalesTotalsByAmountProvider SqlSalesTotalsByAmountProvider
		{
			get {return SalesTotalsByAmountProvider as SqlSalesTotalsByAmountProvider;}
		}
		
		#endregion
		
		
		#region "SummaryOfSalesByQuarterProvider"
		
		private SqlSummaryOfSalesByQuarterProvider innerSqlSummaryOfSalesByQuarterProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SummaryOfSalesByQuarter"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SummaryOfSalesByQuarterProviderBase SummaryOfSalesByQuarterProvider
		{
			get
			{
				if (innerSqlSummaryOfSalesByQuarterProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSummaryOfSalesByQuarterProvider == null)
						{
							this.innerSqlSummaryOfSalesByQuarterProvider = new SqlSummaryOfSalesByQuarterProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSummaryOfSalesByQuarterProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSummaryOfSalesByQuarterProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSummaryOfSalesByQuarterProvider SqlSummaryOfSalesByQuarterProvider
		{
			get {return SummaryOfSalesByQuarterProvider as SqlSummaryOfSalesByQuarterProvider;}
		}
		
		#endregion
		
		
		#region "SummaryOfSalesByYearProvider"
		
		private SqlSummaryOfSalesByYearProvider innerSqlSummaryOfSalesByYearProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SummaryOfSalesByYear"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SummaryOfSalesByYearProviderBase SummaryOfSalesByYearProvider
		{
			get
			{
				if (innerSqlSummaryOfSalesByYearProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSummaryOfSalesByYearProvider == null)
						{
							this.innerSqlSummaryOfSalesByYearProvider = new SqlSummaryOfSalesByYearProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSummaryOfSalesByYearProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSummaryOfSalesByYearProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSummaryOfSalesByYearProvider SqlSummaryOfSalesByYearProvider
		{
			get {return SummaryOfSalesByYearProvider as SqlSummaryOfSalesByYearProvider;}
		}
		
		#endregion
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
