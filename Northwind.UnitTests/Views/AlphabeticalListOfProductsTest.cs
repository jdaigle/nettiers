﻿


#region Using directives

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Northwind.Entities;
using Northwind.Data;

#endregion

namespace Northwind.UnitTests
{
    /// <summary>
    /// Provides tests for the <see cref="AlphabeticalListOfProducts"/> objects (entity, collection and repository).
    /// </summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>
    [TestFixture]
    public partial class AlphabeticalListOfProductsTest
    {
		/// <summary>
		/// Creates a new <see cref="AlphabeticalListOfProductsTest"/> instance.
		/// </summary>	
		public AlphabeticalListOfProductsTest()
		{			
		}
      
		
		/// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
		[TestFixtureSetUp]
		public void Init()
        {
			Init_Generated();
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
		[TestFixtureTearDown]
        public void Dispose()
        {       	
			CleanUp_Generated();
        }
        
		
		/// <summary>
		/// Selects all AlphabeticalListOfProducts objects of the database.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_1_SelectAll()
		{
			Step_1_SelectAll_Generated();			
		}
		
		/// <summary>
		/// Selects all AlphabeticalListOfProducts objects of the database.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_2_Search()
		{
			Step_2_Search_Generated();
		}
			
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock AlphabeticalListOfProducts entity into a temporary file.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_6_SerializeEntity()
		{
			Step_6_SerializeEntity_Generated();			
		}
		
		/// <summary>
		/// Deserialize the mock AlphabeticalListOfProducts entity from a temporary file.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_7_DeserializeEntity()
		{
			Step_7_DeserializeEntity_Generated();
		}
		
		/// <summary>
		/// Serialize a AlphabeticalListOfProducts collection into a temporary file.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_8_SerializeCollection()
		{
			Step_8_SerializeCollection_Generated();					
		}
		
		
		/// <summary>
		/// Deserialize a AlphabeticalListOfProducts collection from a temporary file.
		/// </summary>
		[NUnit.Framework.Test]
		public void Step_9_DeserializeCollection()
		{
			Step_9_DeserializeCollection_Generated();	
		}
		#endregion
    }
}
