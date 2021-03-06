﻿using System;
using System.ComponentModel;

namespace Northwind.Entities
{
	/// <summary>
	///		The data structure representation of the 'Suppliers' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ISuppliers 
	{
		/// <summary>			
		/// SupplierID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Suppliers"</remarks>
		System.Int32 SupplierId { get; set; }
				
		
		
		/// <summary>
		/// CompanyName : 
		/// </summary>
		System.String  CompanyName  { get; set; }
		
		/// <summary>
		/// ContactName : 
		/// </summary>
		System.String  ContactName  { get; set; }
		
		/// <summary>
		/// ContactTitle : 
		/// </summary>
		System.String  ContactTitle  { get; set; }
		
		/// <summary>
		/// Address : 
		/// </summary>
		System.String  Address  { get; set; }
		
		/// <summary>
		/// City : 
		/// </summary>
		System.String  City  { get; set; }
		
		/// <summary>
		/// Region : 
		/// </summary>
		System.String  Region  { get; set; }
		
		/// <summary>
		/// PostalCode : 
		/// </summary>
		System.String  PostalCode  { get; set; }
		
		/// <summary>
		/// Country : 
		/// </summary>
		System.String  Country  { get; set; }
		
		/// <summary>
		/// Phone : 
		/// </summary>
		System.String  Phone  { get; set; }
		
		/// <summary>
		/// Fax : 
		/// </summary>
		System.String  Fax  { get; set; }
		
		/// <summary>
		/// HomePage : 
		/// </summary>
		System.String  HomePage  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _productsSupplierId
		/// </summary>	
		TList<Products> ProductsCollection {  get;  set;}	

		#endregion Data Properties

	}
}


