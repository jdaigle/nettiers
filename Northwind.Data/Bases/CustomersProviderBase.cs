#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using Northwind.Entities;
using Northwind.Data;

#endregion

namespace Northwind.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="CustomersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomersProviderBase : CustomersProviderBaseCore
	{
        Stopwatch stopwatch = new Stopwatch();

        protected override void OnDataRequesting(CommandEventArgs e) {
            stopwatch.Reset();
            stopwatch.Start();
            base.OnDataRequesting(e);
        }

        protected override void OnDataRequested(CommandEventArgs e) {
            stopwatch.Stop();
            base.OnDataRequested(e);
        }


	} // end class
    
} // end namespace
