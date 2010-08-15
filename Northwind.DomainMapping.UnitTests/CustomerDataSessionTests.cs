using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Northwind.Entities;
using Northwind.Data;

namespace Northwind.DomainMapping.UnitTests {
    [TestFixture]
    public class CustomerDataSessionTests {

        private DataSession session;

        [TestFixtureSetUp]
        public void Init() {
            session = new DataSession(DataRepository.Provider);
        }

        [TestFixtureTearDown]
        public void Dispose() {
        }


        [Test]
        public void Step_01_Insert() {
            var mock = CreateMockInstance_Generated();
        }

        [Test]
        public void Step_02_Get() {
            var key = new CustomersKey("BSBEV");
            var customer = session.Get<Customers, CustomersKey>(key);
            Assert.IsNotNull(customer);
            Assert.AreEqual(customer.EntityId, key);
        }

        [Test]
        public void Step_03_Get_1stLevelCache() {
            var key = new CustomersKey("BSBEV");
            var customer1 = session.Get<Customers, CustomersKey>(key);
            var customer2 = session.Get<Customers, CustomersKey>(key);
            Assert.IsTrue(object.ReferenceEquals(customer1, customer2));
        }


        static public Customers CreateMockInstance_Generated() {
            Customers mock = new Customers();

            mock.CustomerId = TestUtility.Instance.RandomString(5, false); ;
            mock.CompanyName = TestUtility.Instance.RandomString(19, false); ;
            mock.ContactName = TestUtility.Instance.RandomString(14, false); ;
            mock.ContactTitle = TestUtility.Instance.RandomString(14, false); ;
            mock.Address = TestUtility.Instance.RandomString(29, false); ;
            mock.City = TestUtility.Instance.RandomString(6, false); ;
            mock.Region = TestUtility.Instance.RandomString(6, false); ;
            mock.PostalCode = TestUtility.Instance.RandomString(10, false); ;
            mock.Country = TestUtility.Instance.RandomString(6, false); ;
            mock.Phone = TestUtility.Instance.RandomString(11, false); ;
            mock.Fax = TestUtility.Instance.RandomString(11, false); ;


            // create a temporary collection and add the item to it
            TList<Customers> tempMockCollection = new TList<Customers>();
            tempMockCollection.Add(mock);
            tempMockCollection.Remove(mock);


            return (Customers)mock;
        }


        ///<summary>
        ///  Update the Typed Customers Entity with modified mock values.
        ///</summary>
        static public void UpdateMockInstance_Generated(Customers mock) {
            mock.CompanyName = TestUtility.Instance.RandomString(19, false); ;
            mock.ContactName = TestUtility.Instance.RandomString(14, false); ;
            mock.ContactTitle = TestUtility.Instance.RandomString(14, false); ;
            mock.Address = TestUtility.Instance.RandomString(29, false); ;
            mock.City = TestUtility.Instance.RandomString(6, false); ;
            mock.Region = TestUtility.Instance.RandomString(6, false); ;
            mock.PostalCode = TestUtility.Instance.RandomString(10, false); ;
            mock.Country = TestUtility.Instance.RandomString(6, false); ;
            mock.Phone = TestUtility.Instance.RandomString(11, false); ;
            mock.Fax = TestUtility.Instance.RandomString(11, false); ;

        }
    }
}
