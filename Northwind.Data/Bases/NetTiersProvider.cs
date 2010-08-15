
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Northwind.Entities;

#endregion

namespace Northwind.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current OrdersProviderBase instance.
		///</summary>
		public virtual OrdersProviderBase OrdersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SuppliersProviderBase instance.
		///</summary>
		public virtual SuppliersProviderBase SuppliersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RegionProviderBase instance.
		///</summary>
		public virtual RegionProviderBase RegionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CategoriesProviderBase instance.
		///</summary>
		public virtual CategoriesProviderBase CategoriesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ShippersProviderBase instance.
		///</summary>
		public virtual ShippersProviderBase ShippersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmployeeTerritoriesProviderBase instance.
		///</summary>
		public virtual EmployeeTerritoriesProviderBase EmployeeTerritoriesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmployeesProviderBase instance.
		///</summary>
		public virtual EmployeesProviderBase EmployeesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TerritoriesProviderBase instance.
		///</summary>
		public virtual TerritoriesProviderBase TerritoriesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerDemographicsProviderBase instance.
		///</summary>
		public virtual CustomerDemographicsProviderBase CustomerDemographicsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomersProviderBase instance.
		///</summary>
		public virtual CustomersProviderBase CustomersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductsProviderBase instance.
		///</summary>
		public virtual ProductsProviderBase ProductsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderDetailsProviderBase instance.
		///</summary>
		public virtual OrderDetailsProviderBase OrderDetailsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerCustomerDemoProviderBase instance.
		///</summary>
		public virtual CustomerCustomerDemoProviderBase CustomerCustomerDemoProvider{get {throw new NotImplementedException();}}
		
		
		///<summary>
		/// Current AlphabeticalListOfProductsProviderBase instance.
		///</summary>
		public virtual AlphabeticalListOfProductsProviderBase AlphabeticalListOfProductsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CategorySalesFor1997ProviderBase instance.
		///</summary>
		public virtual CategorySalesFor1997ProviderBase CategorySalesFor1997Provider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CurrentProductListProviderBase instance.
		///</summary>
		public virtual CurrentProductListProviderBase CurrentProductListProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerAndSuppliersByCityProviderBase instance.
		///</summary>
		public virtual CustomerAndSuppliersByCityProviderBase CustomerAndSuppliersByCityProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current InvoicesProviderBase instance.
		///</summary>
		public virtual InvoicesProviderBase InvoicesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderDetailsExtendedProviderBase instance.
		///</summary>
		public virtual OrderDetailsExtendedProviderBase OrderDetailsExtendedProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderSubtotalsProviderBase instance.
		///</summary>
		public virtual OrderSubtotalsProviderBase OrderSubtotalsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrdersQryProviderBase instance.
		///</summary>
		public virtual OrdersQryProviderBase OrdersQryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductSalesFor1997ProviderBase instance.
		///</summary>
		public virtual ProductSalesFor1997ProviderBase ProductSalesFor1997Provider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductsAboveAveragePriceProviderBase instance.
		///</summary>
		public virtual ProductsAboveAveragePriceProviderBase ProductsAboveAveragePriceProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductsByCategoryProviderBase instance.
		///</summary>
		public virtual ProductsByCategoryProviderBase ProductsByCategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current QuarterlyOrdersProviderBase instance.
		///</summary>
		public virtual QuarterlyOrdersProviderBase QuarterlyOrdersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalesByCategoryProviderBase instance.
		///</summary>
		public virtual SalesByCategoryProviderBase SalesByCategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalesTotalsByAmountProviderBase instance.
		///</summary>
		public virtual SalesTotalsByAmountProviderBase SalesTotalsByAmountProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SummaryOfSalesByQuarterProviderBase instance.
		///</summary>
		public virtual SummaryOfSalesByQuarterProviderBase SummaryOfSalesByQuarterProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SummaryOfSalesByYearProviderBase instance.
		///</summary>
		public virtual SummaryOfSalesByYearProviderBase SummaryOfSalesByYearProvider{get {throw new NotImplementedException();}}
		
	}
}
