using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Entities
{
    /// <summary>
    /// Provides a means to weak reference and already created and untouched locate entities.
    /// </summary>	
    public class EntityLocator //: Microsoft.Practices.ObjectBuilder.Locator 
    {
        //UnityContainer _container = new UnityContainer();
        WeakRefDictionary<string, object> _weakDictionary = new WeakRefDictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityLocator"/> class.
        /// </summary>
        public EntityLocator()
        { 
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, object value)
        {
            //_container.RegisterInstance<T>(key, value, new ExternallyControlledLifetimeManager());
            _weakDictionary.Add(key, value);
            //base.Add(key as object, value);
        }


        /// <summary>
        /// Determines whether [contains] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified key]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(string key)
        {
            return _weakDictionary.ContainsKey(key);
            //return _container.IsRegistered<T>(key);
        }


        /// <summary>
        /// Gets the specified key of any object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>object if available, else null </returns>
        public object Get(string key)
        {
            return _weakDictionary[key];
            //return _container.Resolve<T>(key);
        }

        /// <summary>
        /// Get's an Entity from the Tracking Locator
        /// </summary>
        /// <typeparam name="TEntity">A type that implements IEntity</typeparam>
        /// <param name="key">locator list key to fetch, best used 
        /// if it's the (TypeName or TableName) + EntityKey of the this entity</param>
        /// <returns>Entity from Locator if available.</returns>
        public TEntity GetEntity<TEntity>(string key) where TEntity : EntityBase, new()
        {
            return Get(key) as TEntity;
        }

        /// <summary>
        /// Get's a List of Entities from the Tracking Locator
        /// </summary>
        /// <typeparam name="TEntityList"> a type that implements ListBase&lt;IEntity&gt;</typeparam>
        /// <param name="key">locator list key to fetch, best used 
        /// if it's like the criteria of the method used to populate this list
        /// </param>
        /// <returns>ListBase&lt;IEntity&gt; if available</returns>
        public TEntityList GetList<TEntityList>(string key) where TEntityList : ListBase<IEntity>, new()
        {
            return Get(key) as TEntityList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public bool Remove(string key)
        {
            //_container.RegisterInstance<T>(key, default(T), new ExternallyControlledLifetimeManager());
            _weakDictionary.Remove(key);
            return true;
        }
		
        /// <summary>
        /// Re-Creates the key based on primary key values.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="pkItems">The pk items.</param>
        /// <returns></returns>
		public static string ConstructKeyFromPkItems(Type type, params object[] pkItems)
		{
			if (type == null)
				throw new ArgumentNullException("type");
			
			if (pkItems.Length == 0)
				throw new ArgumentNullException("pkItems");
				
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(type.Name);
			
			for(int i=0; i < pkItems.Length; i++)
			{
				if (pkItems[i] != null)
					sb.Append("|").Append(pkItems[i].ToString());
			}
			
			return sb.ToString();
		}
	}
}