﻿using System;
using System.ComponentModel;

namespace Northwind.Entities
{
	/// <summary>
	///		The data structure representation of the 'Region' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IRegion 
	{
		/// <summary>			
		/// RegionID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Region"</remarks>
		System.Int32 RegionId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalRegionId { get; set; }
			
		
		
		/// <summary>
		/// RegionDescription : 
		/// </summary>
		System.String  RegionDescription  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _territoriesRegionId
		/// </summary>	
		TList<Territories> TerritoriesCollection {  get;  set;}	

		#endregion Data Properties

	}
}


