﻿/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file CategorySalesFor1997.cs instead.
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
	/// An object representation of the 'Category Sales for 1997' view. [No description found in the database]	
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("CategorySalesFor1997Base")]
	public abstract partial class CategorySalesFor1997Base : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{
		
		#region Variable Declarations
		
		/// <summary>
		/// CategoryName : 
		/// </summary>
		private System.String		  _categoryName = string.Empty;
		
		/// <summary>
		/// CategorySales : 
		/// </summary>
		private System.Decimal?		  _categorySales = null;
		
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
		/// Creates a new <see cref="CategorySalesFor1997Base"/> instance.
		///</summary>
		public CategorySalesFor1997Base()
		{
		}		
		
		///<summary>
		/// Creates a new <see cref="CategorySalesFor1997Base"/> instance.
		///</summary>
		///<param name="_categoryName"></param>
		///<param name="_categorySales"></param>
		public CategorySalesFor1997Base(System.String _categoryName, System.Decimal? _categorySales)
		{
			this._categoryName = _categoryName;
			this._categorySales = _categorySales;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="CategorySalesFor1997"/> instance.
		///</summary>
		///<param name="_categoryName"></param>
		///<param name="_categorySales"></param>
		public static CategorySalesFor1997 CreateCategorySalesFor1997(System.String _categoryName, System.Decimal? _categorySales)
		{
			CategorySalesFor1997 newCategorySalesFor1997 = new CategorySalesFor1997();
			newCategorySalesFor1997.CategoryName = _categoryName;
			newCategorySalesFor1997.CategorySales = _categorySales;
			return newCategorySalesFor1997;
		}
				
		#endregion Constructors
		
		#region Properties	
		/// <summary>
		/// 	Gets or Sets the CategoryName property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String CategoryName
		{
			get
			{
				return this._categoryName; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "CategoryName does not allow null values.");
				if (_categoryName == value)
					return;
					
				this._categoryName = value;
				this._isDirty = true;
				
				OnPropertyChanged("CategoryName");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the CategorySales property. 
		///		
		/// </summary>
		/// <value>This type is money</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return 0. It is up to the developer
		/// to check the value of IsCategorySalesNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Decimal? CategorySales
		{
			get
			{
				return this._categorySales; 
			}
			set
			{
				if (_categorySales == value && CategorySales != null )
					return;
					
				this._categorySales = value;
				this._isDirty = true;
				
				OnPropertyChanged("CategorySales");
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
			get { return "Category Sales for 1997"; }
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
		///  Returns a Typed CategorySalesFor1997Base Entity 
		///</summary>
		public virtual CategorySalesFor1997Base Copy()
		{
			//shallow copy entity
			CategorySalesFor1997 copy = new CategorySalesFor1997();
				copy.CategoryName = this.CategoryName;
				copy.CategorySales = this.CategorySales;
			copy.AcceptChanges();
			return (CategorySalesFor1997)copy;
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
		///<returns>true if toObject is a <see cref="CategorySalesFor1997Base"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(CategorySalesFor1997Base toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="CategorySalesFor1997Base"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="CategorySalesFor1997Base"/> to compare.</param>
		///<param name="Object2">The second <see cref="CategorySalesFor1997Base"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(CategorySalesFor1997Base Object1, CategorySalesFor1997Base Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.CategoryName != Object2.CategoryName)
				equal = false;
			if (Object1.CategorySales != null && Object2.CategorySales != null )
			{
				if (Object1.CategorySales != Object2.CategorySales)
					equal = false;
			}
			else if (Object1.CategorySales == null ^ Object1.CategorySales == null )
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
		public static object GetPropertyValueByName(CategorySalesFor1997 entity, string propertyName)
		{
			switch (propertyName)
			{
				case "CategoryName":
					return entity.CategoryName;
				case "CategorySales":
					return entity.CategorySales;
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
			return GetPropertyValueByName(this as CategorySalesFor1997, propertyName);
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{3}{2}- CategoryName: {0}{2}- CategorySales: {1}{2}", 
				this.CategoryName,
				(this.CategorySales == null) ? string.Empty : this.CategorySales.ToString(),
			     
				System.Environment.NewLine, 
				this.GetType());
		}
	
	}//End Class
	
	
	/// <summary>
	/// Enumerate the CategorySalesFor1997 columns.
	/// </summary>
	[Serializable]
	public enum CategorySalesFor1997Column
	{
		/// <summary>
		/// CategoryName : 
		/// </summary>
		[EnumTextValue("CategoryName")]
		[ColumnEnum("CategoryName", typeof(System.String), System.Data.DbType.String, false, false, false, 15)]
		CategoryName,
		/// <summary>
		/// CategorySales : 
		/// </summary>
		[EnumTextValue("CategorySales")]
		[ColumnEnum("CategorySales", typeof(System.Decimal), System.Data.DbType.Currency, false, false, true)]
		CategorySales
	}//End enum

} // end namespace
