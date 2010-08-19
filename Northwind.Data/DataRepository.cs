#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using Northwind.Entities;
using Northwind.Data;
using Northwind.Data.Bases;

#endregion

namespace Northwind.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("Northwind.Data") as NetTiersServiceSection;
				}

				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
					return WebConfigurationManager.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region OrdersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Orders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OrdersProviderBase OrdersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrdersProvider;
			}
		}
		
		#endregion
		
		#region SuppliersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Suppliers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SuppliersProviderBase SuppliersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SuppliersProvider;
			}
		}
		
		#endregion
		
		#region EmployeesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Employees"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmployeesProviderBase EmployeesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmployeesProvider;
			}
		}
		
		#endregion
		
		#region CustomerCustomerDemoProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomerCustomerDemo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerCustomerDemoProviderBase CustomerCustomerDemoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerCustomerDemoProvider;
			}
		}
		
		#endregion
		
		#region ProductsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Products"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductsProviderBase ProductsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductsProvider;
			}
		}
		
		#endregion
		
		#region RegionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Region"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RegionProviderBase RegionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RegionProvider;
			}
		}
		
		#endregion
		
		#region TerritoriesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Territories"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TerritoriesProviderBase TerritoriesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TerritoriesProvider;
			}
		}
		
		#endregion
		
		#region CategoriesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Categories"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CategoriesProviderBase CategoriesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CategoriesProvider;
			}
		}
		
		#endregion
		
		#region CustomerDemographicsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomerDemographics"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerDemographicsProviderBase CustomerDemographicsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerDemographicsProvider;
			}
		}
		
		#endregion
		
		#region CustomersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Customers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomersProviderBase CustomersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomersProvider;
			}
		}
		
		#endregion
		
		#region ShippersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Shippers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ShippersProviderBase ShippersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ShippersProvider;
			}
		}
		
		#endregion
		
		#region OrderDetailsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OrderDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OrderDetailsProviderBase OrderDetailsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrderDetailsProvider;
			}
		}
		
		#endregion
		
		#region EmployeeTerritoriesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EmployeeTerritories"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmployeeTerritoriesProviderBase EmployeeTerritoriesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmployeeTerritoriesProvider;
			}
		}
		
		#endregion
		
		
		#region AlphabeticalListOfProductsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AlphabeticalListOfProducts"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AlphabeticalListOfProductsProviderBase AlphabeticalListOfProductsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AlphabeticalListOfProductsProvider;
			}
		}
		
		#endregion
		
		#region CategorySalesFor1997Provider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CategorySalesFor1997"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CategorySalesFor1997ProviderBase CategorySalesFor1997Provider
		{
			get 
			{
				LoadProviders();
				return _provider.CategorySalesFor1997Provider;
			}
		}
		
		#endregion
		
		#region CurrentProductListProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CurrentProductList"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CurrentProductListProviderBase CurrentProductListProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CurrentProductListProvider;
			}
		}
		
		#endregion
		
		#region CustomerAndSuppliersByCityProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomerAndSuppliersByCity"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerAndSuppliersByCityProviderBase CustomerAndSuppliersByCityProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerAndSuppliersByCityProvider;
			}
		}
		
		#endregion
		
		#region InvoicesProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Invoices"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static InvoicesProviderBase InvoicesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.InvoicesProvider;
			}
		}
		
		#endregion
		
		#region OrderDetailsExtendedProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OrderDetailsExtended"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OrderDetailsExtendedProviderBase OrderDetailsExtendedProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrderDetailsExtendedProvider;
			}
		}
		
		#endregion
		
		#region OrderSubtotalsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OrderSubtotals"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OrderSubtotalsProviderBase OrderSubtotalsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrderSubtotalsProvider;
			}
		}
		
		#endregion
		
		#region OrdersQryProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OrdersQry"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OrdersQryProviderBase OrdersQryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrdersQryProvider;
			}
		}
		
		#endregion
		
		#region ProductSalesFor1997Provider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductSalesFor1997"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductSalesFor1997ProviderBase ProductSalesFor1997Provider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductSalesFor1997Provider;
			}
		}
		
		#endregion
		
		#region ProductsAboveAveragePriceProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductsAboveAveragePrice"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductsAboveAveragePriceProviderBase ProductsAboveAveragePriceProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductsAboveAveragePriceProvider;
			}
		}
		
		#endregion
		
		#region ProductsByCategoryProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProductsByCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProductsByCategoryProviderBase ProductsByCategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProductsByCategoryProvider;
			}
		}
		
		#endregion
		
		#region QuarterlyOrdersProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="QuarterlyOrders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuarterlyOrdersProviderBase QuarterlyOrdersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuarterlyOrdersProvider;
			}
		}
		
		#endregion
		
		#region SalesByCategoryProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesByCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesByCategoryProviderBase SalesByCategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesByCategoryProvider;
			}
		}
		
		#endregion
		
		#region SalesTotalsByAmountProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalesTotalsByAmount"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalesTotalsByAmountProviderBase SalesTotalsByAmountProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalesTotalsByAmountProvider;
			}
		}
		
		#endregion
		
		#region SummaryOfSalesByQuarterProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SummaryOfSalesByQuarter"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SummaryOfSalesByQuarterProviderBase SummaryOfSalesByQuarterProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SummaryOfSalesByQuarterProvider;
			}
		}
		
		#endregion
		
		#region SummaryOfSalesByYearProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SummaryOfSalesByYear"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SummaryOfSalesByYearProviderBase SummaryOfSalesByYearProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SummaryOfSalesByYearProvider;
			}
		}
		
		#endregion
		
		#endregion
	}
	
	#region Query/Filters
		
	#region OrdersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersFilters : OrdersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersFilters class.
		/// </summary>
		public OrdersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersFilters
	
	#region OrdersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OrdersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersQuery : OrdersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersQuery class.
		/// </summary>
		public OrdersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersQuery
		
	#region SuppliersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Suppliers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SuppliersFilters : SuppliersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SuppliersFilters class.
		/// </summary>
		public SuppliersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SuppliersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SuppliersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SuppliersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SuppliersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SuppliersFilters
	
	#region SuppliersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SuppliersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Suppliers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SuppliersQuery : SuppliersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SuppliersQuery class.
		/// </summary>
		public SuppliersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SuppliersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SuppliersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SuppliersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SuppliersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SuppliersQuery
		
	#region EmployeesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employees"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeesFilters : EmployeesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeesFilters class.
		/// </summary>
		public EmployeesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeesFilters
	
	#region EmployeesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmployeesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Employees"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeesQuery : EmployeesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeesQuery class.
		/// </summary>
		public EmployeesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeesQuery
		
	#region CustomerCustomerDemoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerCustomerDemo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerCustomerDemoFilters : CustomerCustomerDemoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoFilters class.
		/// </summary>
		public CustomerCustomerDemoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerCustomerDemoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerCustomerDemoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerCustomerDemoFilters
	
	#region CustomerCustomerDemoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerCustomerDemoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomerCustomerDemo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerCustomerDemoQuery : CustomerCustomerDemoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoQuery class.
		/// </summary>
		public CustomerCustomerDemoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerCustomerDemoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerCustomerDemoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerCustomerDemoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerCustomerDemoQuery
		
	#region ProductsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Products"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsFilters : ProductsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsFilters class.
		/// </summary>
		public ProductsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsFilters
	
	#region ProductsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Products"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsQuery : ProductsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsQuery class.
		/// </summary>
		public ProductsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsQuery
		
	#region RegionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Region"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RegionFilters : RegionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RegionFilters class.
		/// </summary>
		public RegionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RegionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RegionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RegionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RegionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RegionFilters
	
	#region RegionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RegionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Region"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RegionQuery : RegionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RegionQuery class.
		/// </summary>
		public RegionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RegionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RegionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RegionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RegionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RegionQuery
		
	#region TerritoriesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Territories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TerritoriesFilters : TerritoriesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TerritoriesFilters class.
		/// </summary>
		public TerritoriesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TerritoriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TerritoriesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TerritoriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TerritoriesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TerritoriesFilters
	
	#region TerritoriesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TerritoriesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Territories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TerritoriesQuery : TerritoriesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TerritoriesQuery class.
		/// </summary>
		public TerritoriesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TerritoriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TerritoriesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TerritoriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TerritoriesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TerritoriesQuery
		
	#region CategoriesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Categories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategoriesFilters : CategoriesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoriesFilters class.
		/// </summary>
		public CategoriesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategoriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategoriesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategoriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategoriesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategoriesFilters
	
	#region CategoriesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CategoriesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Categories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategoriesQuery : CategoriesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoriesQuery class.
		/// </summary>
		public CategoriesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategoriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategoriesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategoriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategoriesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategoriesQuery
		
	#region CustomerDemographicsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDemographicsFilters : CustomerDemographicsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsFilters class.
		/// </summary>
		public CustomerDemographicsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDemographicsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDemographicsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDemographicsFilters
	
	#region CustomerDemographicsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerDemographicsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomerDemographics"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDemographicsQuery : CustomerDemographicsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsQuery class.
		/// </summary>
		public CustomerDemographicsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDemographicsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDemographicsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDemographicsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDemographicsQuery
		
	#region CustomersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomersFilters : CustomersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersFilters class.
		/// </summary>
		public CustomersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomersFilters
	
	#region CustomersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomersQuery : CustomersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersQuery class.
		/// </summary>
		public CustomersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomersQuery
		
	#region ShippersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Shippers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippersFilters : ShippersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippersFilters class.
		/// </summary>
		public ShippersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippersFilters
	
	#region ShippersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ShippersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Shippers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ShippersQuery : ShippersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ShippersQuery class.
		/// </summary>
		public ShippersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ShippersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ShippersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ShippersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ShippersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ShippersQuery
		
	#region OrderDetailsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsFilters : OrderDetailsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilters class.
		/// </summary>
		public OrderDetailsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsFilters
	
	#region OrderDetailsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OrderDetailsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsQuery : OrderDetailsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsQuery class.
		/// </summary>
		public OrderDetailsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsQuery
		
	#region EmployeeTerritoriesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeTerritories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeTerritoriesFilters : EmployeeTerritoriesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesFilters class.
		/// </summary>
		public EmployeeTerritoriesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeTerritoriesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeTerritoriesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeTerritoriesFilters
	
	#region EmployeeTerritoriesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmployeeTerritoriesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EmployeeTerritories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeTerritoriesQuery : EmployeeTerritoriesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesQuery class.
		/// </summary>
		public EmployeeTerritoriesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeTerritoriesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeTerritoriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeTerritoriesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeTerritoriesQuery
		
	#region AlphabeticalListOfProductsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AlphabeticalListOfProducts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AlphabeticalListOfProductsFilters : AlphabeticalListOfProductsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsFilters class.
		/// </summary>
		public AlphabeticalListOfProductsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AlphabeticalListOfProductsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AlphabeticalListOfProductsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AlphabeticalListOfProductsFilters
	
	#region AlphabeticalListOfProductsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AlphabeticalListOfProductsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AlphabeticalListOfProducts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AlphabeticalListOfProductsQuery : AlphabeticalListOfProductsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsQuery class.
		/// </summary>
		public AlphabeticalListOfProductsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AlphabeticalListOfProductsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AlphabeticalListOfProductsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AlphabeticalListOfProductsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AlphabeticalListOfProductsQuery
		
	#region CategorySalesFor1997Filters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CategorySalesFor1997"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategorySalesFor1997Filters : CategorySalesFor1997FilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997Filters class.
		/// </summary>
		public CategorySalesFor1997Filters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997Filters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategorySalesFor1997Filters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997Filters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategorySalesFor1997Filters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategorySalesFor1997Filters
	
	#region CategorySalesFor1997Query
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CategorySalesFor1997ParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CategorySalesFor1997"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CategorySalesFor1997Query : CategorySalesFor1997ParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997Query class.
		/// </summary>
		public CategorySalesFor1997Query() : base() { }

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997Query class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CategorySalesFor1997Query(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CategorySalesFor1997Query class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CategorySalesFor1997Query(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CategorySalesFor1997Query
		
	#region CurrentProductListFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CurrentProductList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrentProductListFilters : CurrentProductListFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrentProductListFilters class.
		/// </summary>
		public CurrentProductListFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrentProductListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrentProductListFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrentProductListFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrentProductListFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrentProductListFilters
	
	#region CurrentProductListQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CurrentProductListParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CurrentProductList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrentProductListQuery : CurrentProductListParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrentProductListQuery class.
		/// </summary>
		public CurrentProductListQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrentProductListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrentProductListQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrentProductListQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrentProductListQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrentProductListQuery
		
	#region CustomerAndSuppliersByCityFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerAndSuppliersByCity"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerAndSuppliersByCityFilters : CustomerAndSuppliersByCityFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityFilters class.
		/// </summary>
		public CustomerAndSuppliersByCityFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerAndSuppliersByCityFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerAndSuppliersByCityFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerAndSuppliersByCityFilters
	
	#region CustomerAndSuppliersByCityQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerAndSuppliersByCityParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomerAndSuppliersByCity"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerAndSuppliersByCityQuery : CustomerAndSuppliersByCityParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityQuery class.
		/// </summary>
		public CustomerAndSuppliersByCityQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerAndSuppliersByCityQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerAndSuppliersByCityQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerAndSuppliersByCityQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerAndSuppliersByCityQuery
		
	#region InvoicesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Invoices"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoicesFilters : InvoicesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoicesFilters class.
		/// </summary>
		public InvoicesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoicesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoicesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoicesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoicesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoicesFilters
	
	#region InvoicesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="InvoicesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Invoices"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoicesQuery : InvoicesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoicesQuery class.
		/// </summary>
		public InvoicesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoicesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoicesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoicesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoicesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoicesQuery
		
	#region OrderDetailsExtendedFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetailsExtended"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsExtendedFilters : OrderDetailsExtendedFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedFilters class.
		/// </summary>
		public OrderDetailsExtendedFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsExtendedFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsExtendedFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsExtendedFilters
	
	#region OrderDetailsExtendedQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OrderDetailsExtendedParameterBuilder"/> class
	/// that is used exclusively with a <see cref="OrderDetailsExtended"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsExtendedQuery : OrderDetailsExtendedParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedQuery class.
		/// </summary>
		public OrderDetailsExtendedQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsExtendedQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsExtendedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsExtendedQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsExtendedQuery
		
	#region OrderSubtotalsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderSubtotals"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderSubtotalsFilters : OrderSubtotalsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsFilters class.
		/// </summary>
		public OrderSubtotalsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderSubtotalsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderSubtotalsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderSubtotalsFilters
	
	#region OrderSubtotalsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OrderSubtotalsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="OrderSubtotals"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderSubtotalsQuery : OrderSubtotalsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsQuery class.
		/// </summary>
		public OrderSubtotalsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderSubtotalsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderSubtotalsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderSubtotalsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderSubtotalsQuery
		
	#region OrdersQryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrdersQry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersQryFilters : OrdersQryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersQryFilters class.
		/// </summary>
		public OrdersQryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersQryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersQryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersQryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersQryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersQryFilters
	
	#region OrdersQryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OrdersQryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="OrdersQry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersQryQuery : OrdersQryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersQryQuery class.
		/// </summary>
		public OrdersQryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersQryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersQryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersQryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersQryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersQryQuery
		
	#region ProductSalesFor1997Filters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductSalesFor1997"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductSalesFor1997Filters : ProductSalesFor1997FilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997Filters class.
		/// </summary>
		public ProductSalesFor1997Filters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997Filters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductSalesFor1997Filters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997Filters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductSalesFor1997Filters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductSalesFor1997Filters
	
	#region ProductSalesFor1997Query
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductSalesFor1997ParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductSalesFor1997"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductSalesFor1997Query : ProductSalesFor1997ParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997Query class.
		/// </summary>
		public ProductSalesFor1997Query() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997Query class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductSalesFor1997Query(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductSalesFor1997Query class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductSalesFor1997Query(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductSalesFor1997Query
		
	#region ProductsAboveAveragePriceFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductsAboveAveragePrice"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsAboveAveragePriceFilters : ProductsAboveAveragePriceFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceFilters class.
		/// </summary>
		public ProductsAboveAveragePriceFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsAboveAveragePriceFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsAboveAveragePriceFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsAboveAveragePriceFilters
	
	#region ProductsAboveAveragePriceQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductsAboveAveragePriceParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductsAboveAveragePrice"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsAboveAveragePriceQuery : ProductsAboveAveragePriceParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceQuery class.
		/// </summary>
		public ProductsAboveAveragePriceQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsAboveAveragePriceQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsAboveAveragePriceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsAboveAveragePriceQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsAboveAveragePriceQuery
		
	#region ProductsByCategoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProductsByCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsByCategoryFilters : ProductsByCategoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryFilters class.
		/// </summary>
		public ProductsByCategoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsByCategoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsByCategoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsByCategoryFilters
	
	#region ProductsByCategoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProductsByCategoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProductsByCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProductsByCategoryQuery : ProductsByCategoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryQuery class.
		/// </summary>
		public ProductsByCategoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProductsByCategoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProductsByCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProductsByCategoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProductsByCategoryQuery
		
	#region QuarterlyOrdersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuarterlyOrders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuarterlyOrdersFilters : QuarterlyOrdersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersFilters class.
		/// </summary>
		public QuarterlyOrdersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuarterlyOrdersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuarterlyOrdersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuarterlyOrdersFilters
	
	#region QuarterlyOrdersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuarterlyOrdersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="QuarterlyOrders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuarterlyOrdersQuery : QuarterlyOrdersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersQuery class.
		/// </summary>
		public QuarterlyOrdersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuarterlyOrdersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuarterlyOrdersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuarterlyOrdersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuarterlyOrdersQuery
		
	#region SalesByCategoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesByCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesByCategoryFilters : SalesByCategoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryFilters class.
		/// </summary>
		public SalesByCategoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesByCategoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesByCategoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesByCategoryFilters
	
	#region SalesByCategoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesByCategoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesByCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesByCategoryQuery : SalesByCategoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryQuery class.
		/// </summary>
		public SalesByCategoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesByCategoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesByCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesByCategoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesByCategoryQuery
		
	#region SalesTotalsByAmountFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesTotalsByAmount"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTotalsByAmountFilters : SalesTotalsByAmountFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountFilters class.
		/// </summary>
		public SalesTotalsByAmountFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTotalsByAmountFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTotalsByAmountFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTotalsByAmountFilters
	
	#region SalesTotalsByAmountQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalesTotalsByAmountParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalesTotalsByAmount"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesTotalsByAmountQuery : SalesTotalsByAmountParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountQuery class.
		/// </summary>
		public SalesTotalsByAmountQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesTotalsByAmountQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesTotalsByAmountQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesTotalsByAmountQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesTotalsByAmountQuery
		
	#region SummaryOfSalesByQuarterFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SummaryOfSalesByQuarter"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SummaryOfSalesByQuarterFilters : SummaryOfSalesByQuarterFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterFilters class.
		/// </summary>
		public SummaryOfSalesByQuarterFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SummaryOfSalesByQuarterFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SummaryOfSalesByQuarterFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SummaryOfSalesByQuarterFilters
	
	#region SummaryOfSalesByQuarterQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SummaryOfSalesByQuarterParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SummaryOfSalesByQuarter"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SummaryOfSalesByQuarterQuery : SummaryOfSalesByQuarterParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterQuery class.
		/// </summary>
		public SummaryOfSalesByQuarterQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SummaryOfSalesByQuarterQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByQuarterQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SummaryOfSalesByQuarterQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SummaryOfSalesByQuarterQuery
		
	#region SummaryOfSalesByYearFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SummaryOfSalesByYear"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SummaryOfSalesByYearFilters : SummaryOfSalesByYearFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearFilters class.
		/// </summary>
		public SummaryOfSalesByYearFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SummaryOfSalesByYearFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SummaryOfSalesByYearFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SummaryOfSalesByYearFilters
	
	#region SummaryOfSalesByYearQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SummaryOfSalesByYearParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SummaryOfSalesByYear"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SummaryOfSalesByYearQuery : SummaryOfSalesByYearParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearQuery class.
		/// </summary>
		public SummaryOfSalesByYearQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SummaryOfSalesByYearQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SummaryOfSalesByYearQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SummaryOfSalesByYearQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SummaryOfSalesByYearQuery
	#endregion

	
}
