﻿/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file QuarterlyOrders.cs instead.
*/
#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;
#endregion

namespace Northwind.Entities
{
	///<summary>
	/// An object representation of the 'Quarterly Orders' view. [No description found in the database]	
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("QuarterlyOrdersBase")]
	public abstract partial class QuarterlyOrdersBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{
		
		#region Variable Declarations
		
		/// <summary>
		/// CustomerID : 
		/// </summary>
		private System.String		  _customerId = null;
		
		/// <summary>
		/// CompanyName : 
		/// </summary>
		private System.String		  _companyName = null;
		
		/// <summary>
		/// City : 
		/// </summary>
		private System.String		  _city = null;
		
		/// <summary>
		/// Country : 
		/// </summary>
		private System.String		  _country = null;
		
		/// <summary>
		/// Object that contains data to associate with this object
		/// </summary>
		private object _tag;
		
		/// <summary>
		/// Suppresses Entity Events from Firing, 
		/// useful when loading the entities from the database.
		/// </summary>
	    [NonSerialized] 
		private bool suppressEntityEvents = false;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="QuarterlyOrdersBase"/> instance.
		///</summary>
		public QuarterlyOrdersBase()
		{
		}		
		
		///<summary>
		/// Creates a new <see cref="QuarterlyOrdersBase"/> instance.
		///</summary>
		///<param name="_customerId"></param>
		///<param name="_companyName"></param>
		///<param name="_city"></param>
		///<param name="_country"></param>
		public QuarterlyOrdersBase(System.String _customerId, System.String _companyName, System.String _city, System.String _country)
		{
			this._customerId = _customerId;
			this._companyName = _companyName;
			this._city = _city;
			this._country = _country;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="QuarterlyOrders"/> instance.
		///</summary>
		///<param name="_customerId"></param>
		///<param name="_companyName"></param>
		///<param name="_city"></param>
		///<param name="_country"></param>
		public static QuarterlyOrders CreateQuarterlyOrders(System.String _customerId, System.String _companyName, System.String _city, System.String _country)
		{
			QuarterlyOrders newQuarterlyOrders = new QuarterlyOrders();
			newQuarterlyOrders.CustomerId = _customerId;
			newQuarterlyOrders.CompanyName = _companyName;
			newQuarterlyOrders.City = _city;
			newQuarterlyOrders.Country = _country;
			return newQuarterlyOrders;
		}
				
		#endregion Constructors
		
		#region Properties	
		/// <summary>
		/// 	Gets or Sets the CustomerID property. 
		///		
		/// </summary>
		/// <value>This type is nchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String CustomerId
		{
			get
			{
				return this._customerId; 
			}
			set
			{
				if (_customerId == value)
					return;
					
				this._customerId = value;
				this._isDirty = true;
				
				OnPropertyChanged("CustomerId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the CompanyName property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String CompanyName
		{
			get
			{
				return this._companyName; 
			}
			set
			{
				if (_companyName == value)
					return;
					
				this._companyName = value;
				this._isDirty = true;
				
				OnPropertyChanged("CompanyName");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the City property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String City
		{
			get
			{
				return this._city; 
			}
			set
			{
				if (_city == value)
					return;
					
				this._city = value;
				this._isDirty = true;
				
				OnPropertyChanged("City");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Country property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Country
		{
			get
			{
				return this._country; 
			}
			set
			{
				if (_country == value)
					return;
					
				this._country = value;
				this._isDirty = true;
				
				OnPropertyChanged("Country");
			}
		}
		
		
		/// <summary>
		///     Gets or sets the object that contains supplemental data about this object.
		/// </summary>
		/// <value>Object</value>
		[System.ComponentModel.Bindable(false)]
		[LocalizableAttribute(false)]
		[DescriptionAttribute("Object containing data to be associated with this object")]
		public virtual object Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				if (this._tag == value)
					return;
		
				this._tag = value;
			}
		}
	
		/// <summary>
		/// Determines whether this entity is to suppress events while set to true.
		/// </summary>
		[System.ComponentModel.Bindable(false)]
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public bool SuppressEntityEvents
		{	
			get
			{
				return suppressEntityEvents;
			}
			set
			{
				suppressEntityEvents = value;
			}	
		}

		private bool _isDeleted = false;
		/// <summary>
		/// Gets a value indicating if object has been <see cref="MarkToDelete"/>. ReadOnly.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDeleted
		{
			get { return this._isDeleted; }
		}


		private bool _isDirty = false;
		/// <summary>
		///	Gets a value indicating  if the object has been modified from its original state.
		/// </summary>
		///<value>True if object has been modified from its original state; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDirty
		{
			get { return this._isDirty; }
		}
		

		private bool _isNew = true;
		/// <summary>
		///	Gets a value indicating if the object is new.
		/// </summary>
		///<value>True if objectis new; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsNew
		{
			get { return this._isNew; }
			set { this._isNew = value; }
		}

		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public string ViewName
		{
			get { return "Quarterly Orders"; }
		}

		
		#endregion
		
		#region Methods	
		
		/// <summary>
		/// Accepts the changes made to this object by setting each flags to false.
		/// </summary>
		public virtual void AcceptChanges()
		{
			this._isDeleted = false;
			this._isDirty = false;
			this._isNew = false;
			OnPropertyChanged(string.Empty);
		}
		
		
		///<summary>
		///  Revert all changes and restore original values.
		///  Currently not supported.
		///</summary>
		/// <exception cref="NotSupportedException">This method is not currently supported and always throws this exception.</exception>
		public virtual void CancelChanges()
		{
			throw new NotSupportedException("Method currently not Supported.");
		}
		
		///<summary>
		///   Marks entity to be deleted.
		///</summary>
		public virtual void MarkToDelete()
		{
			this._isDeleted = true;
		}
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed QuarterlyOrdersBase Entity 
		///</summary>
		public virtual QuarterlyOrdersBase Copy()
		{
			//shallow copy entity
			QuarterlyOrders copy = new QuarterlyOrders();
				copy.CustomerId = this.CustomerId;
				copy.CompanyName = this.CompanyName;
				copy.City = this.City;
				copy.Country = this.Country;
			copy.AcceptChanges();
			return (QuarterlyOrders)copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Deep Copy of this entity.
		///</summary>
		public object Clone(){
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		#endregion
		
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="QuarterlyOrdersBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(QuarterlyOrdersBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="QuarterlyOrdersBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="QuarterlyOrdersBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="QuarterlyOrdersBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(QuarterlyOrdersBase Object1, QuarterlyOrdersBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.CustomerId != null && Object2.CustomerId != null )
			{
				if (Object1.CustomerId != Object2.CustomerId)
					equal = false;
			}
			else if (Object1.CustomerId == null ^ Object1.CustomerId == null )
			{
				equal = false;
			}
			if (Object1.CompanyName != null && Object2.CompanyName != null )
			{
				if (Object1.CompanyName != Object2.CompanyName)
					equal = false;
			}
			else if (Object1.CompanyName == null ^ Object1.CompanyName == null )
			{
				equal = false;
			}
			if (Object1.City != null && Object2.City != null )
			{
				if (Object1.City != Object2.City)
					equal = false;
			}
			else if (Object1.City == null ^ Object1.City == null )
			{
				equal = false;
			}
			if (Object1.Country != null && Object2.Country != null )
			{
				if (Object1.Country != Object2.Country)
					equal = false;
			}
			else if (Object1.Country == null ^ Object1.Country == null )
			{
				equal = false;
			}
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
		}
	
		#endregion
		
		#region INotifyPropertyChanged Members
		
		/// <summary>
      /// Event to indicate that a property has changed.
      /// </summary>
		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="propertyName">The name of the property that has changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{ 
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
		
		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="e">PropertyChangedEventArgs</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (!SuppressEntityEvents)
			{
				if (null != PropertyChanged)
				{
					PropertyChanged(this, e);
				}
			}
		}
		
		#endregion
				
		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public static object GetPropertyValueByName(QuarterlyOrders entity, string propertyName)
		{
			switch (propertyName)
			{
				case "CustomerId":
					return entity.CustomerId;
				case "CompanyName":
					return entity.CompanyName;
				case "City":
					return entity.City;
				case "Country":
					return entity.Country;
			}
			return null;
		}
				
		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public object GetPropertyValueByName(string propertyName)
		{			
			return GetPropertyValueByName(this as QuarterlyOrders, propertyName);
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{5}{4}- CustomerId: {0}{4}- CompanyName: {1}{4}- City: {2}{4}- Country: {3}{4}", 
				(this.CustomerId == null) ? string.Empty : this.CustomerId.ToString(),
			     
				(this.CompanyName == null) ? string.Empty : this.CompanyName.ToString(),
			     
				(this.City == null) ? string.Empty : this.City.ToString(),
			     
				(this.Country == null) ? string.Empty : this.Country.ToString(),
			     
				System.Environment.NewLine, 
				this.GetType());
		}
	
	}//End Class
	
	
	/// <summary>
	/// Enumerate the QuarterlyOrders columns.
	/// </summary>
	[Serializable]
	public enum QuarterlyOrdersColumn
	{
		/// <summary>
		/// CustomerID : 
		/// </summary>
		[EnumTextValue("CustomerID")]
		[ColumnEnum("CustomerID", typeof(System.String), System.Data.DbType.StringFixedLength, false, false, true, 5)]
		CustomerId,
		/// <summary>
		/// CompanyName : 
		/// </summary>
		[EnumTextValue("CompanyName")]
		[ColumnEnum("CompanyName", typeof(System.String), System.Data.DbType.String, false, false, true, 40)]
		CompanyName,
		/// <summary>
		/// City : 
		/// </summary>
		[EnumTextValue("City")]
		[ColumnEnum("City", typeof(System.String), System.Data.DbType.String, false, false, true, 15)]
		City,
		/// <summary>
		/// Country : 
		/// </summary>
		[EnumTextValue("Country")]
		[ColumnEnum("Country", typeof(System.String), System.Data.DbType.String, false, false, true, 15)]
		Country
	}//End enum

} // end namespace
