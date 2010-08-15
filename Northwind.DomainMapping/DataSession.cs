using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Data.Bases;
using Northwind.Entities;

namespace Northwind.DomainMapping {
    public class DataSession {

        private NetTiersProvider netTiersProvider;

        public DataSession(NetTiersProvider netTiersProvider) {
            this.netTiersProvider = netTiersProvider;
        }

        public TEntity Get<TEntity, TEntityKey>(TEntityKey key)
            where TEntity : IEntityId<TEntityKey>, new()
            where TEntityKey : IEntityKey, new() {
            var provider = GetProvider<TEntity, TEntityKey>();
            return provider.Get(key);
        }

        private EntityProviderBase<TEntity, TEntityKey> GetProvider<TEntity, TEntityKey>()
            where TEntity : IEntityId<TEntityKey>, new()
            where TEntityKey : IEntityKey, new() {
            return (EntityProviderBase<TEntity, TEntityKey>)GetProvider(typeof(TEntity));
        }

        private object GetProvider(Type entityType) {
            if (entityType == typeof(Customers))
                return netTiersProvider.CustomersProvider;
            return null;
        }
    }
}
