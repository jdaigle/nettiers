
USE [Northwind]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Get_List

AS


				
				SELECT
					[OrderID],
					[CustomerID],
					[EmployeeID],
					[OrderDate],
					[RequiredDate],
					[ShippedDate],
					[ShipVia],
					[Freight],
					[ShipName],
					[ShipAddress],
					[ShipCity],
					[ShipRegion],
					[ShipPostalCode],
					[ShipCountry]
				FROM
					[dbo].[Orders]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Orders table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderID]'
				SET @SQL = @SQL + ', [CustomerID]'
				SET @SQL = @SQL + ', [EmployeeID]'
				SET @SQL = @SQL + ', [OrderDate]'
				SET @SQL = @SQL + ', [RequiredDate]'
				SET @SQL = @SQL + ', [ShippedDate]'
				SET @SQL = @SQL + ', [ShipVia]'
				SET @SQL = @SQL + ', [Freight]'
				SET @SQL = @SQL + ', [ShipName]'
				SET @SQL = @SQL + ', [ShipAddress]'
				SET @SQL = @SQL + ', [ShipCity]'
				SET @SQL = @SQL + ', [ShipRegion]'
				SET @SQL = @SQL + ', [ShipPostalCode]'
				SET @SQL = @SQL + ', [ShipCountry]'
				SET @SQL = @SQL + ' FROM [dbo].[Orders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderID],'
				SET @SQL = @SQL + ' [CustomerID],'
				SET @SQL = @SQL + ' [EmployeeID],'
				SET @SQL = @SQL + ' [OrderDate],'
				SET @SQL = @SQL + ' [RequiredDate],'
				SET @SQL = @SQL + ' [ShippedDate],'
				SET @SQL = @SQL + ' [ShipVia],'
				SET @SQL = @SQL + ' [Freight],'
				SET @SQL = @SQL + ' [ShipName],'
				SET @SQL = @SQL + ' [ShipAddress],'
				SET @SQL = @SQL + ' [ShipCity],'
				SET @SQL = @SQL + ' [ShipRegion],'
				SET @SQL = @SQL + ' [ShipPostalCode],'
				SET @SQL = @SQL + ' [ShipCountry]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Orders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Insert
(

	@OrderId int    OUTPUT,

	@CustomerId nchar (5)  ,

	@EmployeeId int   ,

	@OrderDate datetime   ,

	@RequiredDate datetime   ,

	@ShippedDate datetime   ,

	@ShipVia int   ,

	@Freight money   ,

	@ShipName nvarchar (40)  ,

	@ShipAddress nvarchar (60)  ,

	@ShipCity nvarchar (15)  ,

	@ShipRegion nvarchar (15)  ,

	@ShipPostalCode nvarchar (10)  ,

	@ShipCountry nvarchar (15)  
)
AS


				
				INSERT INTO [dbo].[Orders]
					(
					[CustomerID]
					,[EmployeeID]
					,[OrderDate]
					,[RequiredDate]
					,[ShippedDate]
					,[ShipVia]
					,[Freight]
					,[ShipName]
					,[ShipAddress]
					,[ShipCity]
					,[ShipRegion]
					,[ShipPostalCode]
					,[ShipCountry]
					)
				VALUES
					(
					@CustomerId
					,@EmployeeId
					,@OrderDate
					,@RequiredDate
					,@ShippedDate
					,@ShipVia
					,@Freight
					,@ShipName
					,@ShipAddress
					,@ShipCity
					,@ShipRegion
					,@ShipPostalCode
					,@ShipCountry
					)
				
				-- Get the identity value
				SET @OrderId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Update
(

	@OrderId int   ,

	@CustomerId nchar (5)  ,

	@EmployeeId int   ,

	@OrderDate datetime   ,

	@RequiredDate datetime   ,

	@ShippedDate datetime   ,

	@ShipVia int   ,

	@Freight money   ,

	@ShipName nvarchar (40)  ,

	@ShipAddress nvarchar (60)  ,

	@ShipCity nvarchar (15)  ,

	@ShipRegion nvarchar (15)  ,

	@ShipPostalCode nvarchar (10)  ,

	@ShipCountry nvarchar (15)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Orders]
				SET
					[CustomerID] = @CustomerId
					,[EmployeeID] = @EmployeeId
					,[OrderDate] = @OrderDate
					,[RequiredDate] = @RequiredDate
					,[ShippedDate] = @ShippedDate
					,[ShipVia] = @ShipVia
					,[Freight] = @Freight
					,[ShipName] = @ShipName
					,[ShipAddress] = @ShipAddress
					,[ShipCity] = @ShipCity
					,[ShipRegion] = @ShipRegion
					,[ShipPostalCode] = @ShipPostalCode
					,[ShipCountry] = @ShipCountry
				WHERE
[OrderID] = @OrderId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Delete
(

	@OrderId int   
)
AS


				DELETE FROM [dbo].[Orders] WITH (ROWLOCK) 
				WHERE
					[OrderID] = @OrderId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByCustomerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByCustomerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByCustomerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Orders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByCustomerId
(

	@CustomerId nchar (5)  
)
AS


				SELECT
					[OrderID],
					[CustomerID],
					[EmployeeID],
					[OrderDate],
					[RequiredDate],
					[ShippedDate],
					[ShipVia],
					[Freight],
					[ShipName],
					[ShipAddress],
					[ShipCity],
					[ShipRegion],
					[ShipPostalCode],
					[ShipCountry]
				FROM
					[dbo].[Orders]
				WHERE
					[CustomerID] = @CustomerId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByEmployeeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByEmployeeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByEmployeeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Orders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByEmployeeId
(

	@EmployeeId int   
)
AS


				SELECT
					[OrderID],
					[CustomerID],
					[EmployeeID],
					[OrderDate],
					[RequiredDate],
					[ShippedDate],
					[ShipVia],
					[Freight],
					[ShipName],
					[ShipAddress],
					[ShipCity],
					[ShipRegion],
					[ShipPostalCode],
					[ShipCountry]
				FROM
					[dbo].[Orders]
				WHERE
					[EmployeeID] = @EmployeeId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByOrderDate procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByOrderDate') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByOrderDate
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Orders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByOrderDate
(

	@OrderDate datetime   
)
AS


				SELECT
					[OrderID],
					[CustomerID],
					[EmployeeID],
					[OrderDate],
					[RequiredDate],
					[ShippedDate],
					[ShipVia],
					[Freight],
					[ShipName],
					[ShipAddress],
					[ShipCity],
					[ShipRegion],
					[ShipPostalCode],
					[ShipCountry]
				FROM
					[dbo].[Orders]
				WHERE
					[OrderDate] = @OrderDate
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByOrderId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Orders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByOrderId
(

	@OrderId int   
)
AS


				SELECT
					[OrderID],
					[CustomerID],
					[EmployeeID],
					[OrderDate],
					[RequiredDate],
					[ShippedDate],
					[ShipVia],
					[Freight],
					[ShipName],
					[ShipAddress],
					[ShipCity],
					[ShipRegion],
					[ShipPostalCode],
					[ShipCountry]
				FROM
					[dbo].[Orders]
				WHERE
					[OrderID] = @OrderId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByShippedDate procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByShippedDate') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByShippedDate
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Orders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByShippedDate
(

	@ShippedDate datetime   
)
AS


				SELECT
					[OrderID],
					[CustomerID],
					[EmployeeID],
					[OrderDate],
					[RequiredDate],
					[ShippedDate],
					[ShipVia],
					[Freight],
					[ShipName],
					[ShipAddress],
					[ShipCity],
					[ShipRegion],
					[ShipPostalCode],
					[ShipCountry]
				FROM
					[dbo].[Orders]
				WHERE
					[ShippedDate] = @ShippedDate
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByShipVia procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByShipVia') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByShipVia
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Orders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByShipVia
(

	@ShipVia int   
)
AS


				SELECT
					[OrderID],
					[CustomerID],
					[EmployeeID],
					[OrderDate],
					[RequiredDate],
					[ShippedDate],
					[ShipVia],
					[Freight],
					[ShipName],
					[ShipAddress],
					[ShipCity],
					[ShipRegion],
					[ShipPostalCode],
					[ShipCountry]
				FROM
					[dbo].[Orders]
				WHERE
					[ShipVia] = @ShipVia
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByShipPostalCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByShipPostalCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByShipPostalCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Orders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByShipPostalCode
(

	@ShipPostalCode nvarchar (10)  
)
AS


				SELECT
					[OrderID],
					[CustomerID],
					[EmployeeID],
					[OrderDate],
					[RequiredDate],
					[ShippedDate],
					[ShipVia],
					[Freight],
					[ShipName],
					[ShipAddress],
					[ShipCity],
					[ShipRegion],
					[ShipPostalCode],
					[ShipCountry]
				FROM
					[dbo].[Orders]
				WHERE
					[ShipPostalCode] = @ShipPostalCode
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByProductIdFromOrderDetails procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByProductIdFromOrderDetails') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByProductIdFromOrderDetails
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByProductIdFromOrderDetails
(

	@ProductId int   
)
AS


SELECT dbo.[Orders].[OrderID]
       ,dbo.[Orders].[CustomerID]
       ,dbo.[Orders].[EmployeeID]
       ,dbo.[Orders].[OrderDate]
       ,dbo.[Orders].[RequiredDate]
       ,dbo.[Orders].[ShippedDate]
       ,dbo.[Orders].[ShipVia]
       ,dbo.[Orders].[Freight]
       ,dbo.[Orders].[ShipName]
       ,dbo.[Orders].[ShipAddress]
       ,dbo.[Orders].[ShipCity]
       ,dbo.[Orders].[ShipRegion]
       ,dbo.[Orders].[ShipPostalCode]
       ,dbo.[Orders].[ShipCountry]
  FROM dbo.[Orders]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[Order Details] 
                WHERE dbo.[Order Details].[ProductID] = @ProductId
                  AND dbo.[Order Details].[OrderID] = dbo.[Orders].[OrderID]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Orders table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Find
(

	@SearchUsingOR bit   = null ,

	@OrderId int   = null ,

	@CustomerId nchar (5)  = null ,

	@EmployeeId int   = null ,

	@OrderDate datetime   = null ,

	@RequiredDate datetime   = null ,

	@ShippedDate datetime   = null ,

	@ShipVia int   = null ,

	@Freight money   = null ,

	@ShipName nvarchar (40)  = null ,

	@ShipAddress nvarchar (60)  = null ,

	@ShipCity nvarchar (15)  = null ,

	@ShipRegion nvarchar (15)  = null ,

	@ShipPostalCode nvarchar (10)  = null ,

	@ShipCountry nvarchar (15)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderID]
	, [CustomerID]
	, [EmployeeID]
	, [OrderDate]
	, [RequiredDate]
	, [ShippedDate]
	, [ShipVia]
	, [Freight]
	, [ShipName]
	, [ShipAddress]
	, [ShipCity]
	, [ShipRegion]
	, [ShipPostalCode]
	, [ShipCountry]
    FROM
	[dbo].[Orders]
    WHERE 
	 ([OrderID] = @OrderId OR @OrderId IS NULL)
	AND ([CustomerID] = @CustomerId OR @CustomerId IS NULL)
	AND ([EmployeeID] = @EmployeeId OR @EmployeeId IS NULL)
	AND ([OrderDate] = @OrderDate OR @OrderDate IS NULL)
	AND ([RequiredDate] = @RequiredDate OR @RequiredDate IS NULL)
	AND ([ShippedDate] = @ShippedDate OR @ShippedDate IS NULL)
	AND ([ShipVia] = @ShipVia OR @ShipVia IS NULL)
	AND ([Freight] = @Freight OR @Freight IS NULL)
	AND ([ShipName] = @ShipName OR @ShipName IS NULL)
	AND ([ShipAddress] = @ShipAddress OR @ShipAddress IS NULL)
	AND ([ShipCity] = @ShipCity OR @ShipCity IS NULL)
	AND ([ShipRegion] = @ShipRegion OR @ShipRegion IS NULL)
	AND ([ShipPostalCode] = @ShipPostalCode OR @ShipPostalCode IS NULL)
	AND ([ShipCountry] = @ShipCountry OR @ShipCountry IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderID]
	, [CustomerID]
	, [EmployeeID]
	, [OrderDate]
	, [RequiredDate]
	, [ShippedDate]
	, [ShipVia]
	, [Freight]
	, [ShipName]
	, [ShipAddress]
	, [ShipCity]
	, [ShipRegion]
	, [ShipPostalCode]
	, [ShipCountry]
    FROM
	[dbo].[Orders]
    WHERE 
	 ([OrderID] = @OrderId AND @OrderId is not null)
	OR ([CustomerID] = @CustomerId AND @CustomerId is not null)
	OR ([EmployeeID] = @EmployeeId AND @EmployeeId is not null)
	OR ([OrderDate] = @OrderDate AND @OrderDate is not null)
	OR ([RequiredDate] = @RequiredDate AND @RequiredDate is not null)
	OR ([ShippedDate] = @ShippedDate AND @ShippedDate is not null)
	OR ([ShipVia] = @ShipVia AND @ShipVia is not null)
	OR ([Freight] = @Freight AND @Freight is not null)
	OR ([ShipName] = @ShipName AND @ShipName is not null)
	OR ([ShipAddress] = @ShipAddress AND @ShipAddress is not null)
	OR ([ShipCity] = @ShipCity AND @ShipCity is not null)
	OR ([ShipRegion] = @ShipRegion AND @ShipRegion is not null)
	OR ([ShipPostalCode] = @ShipPostalCode AND @ShipPostalCode is not null)
	OR ([ShipCountry] = @ShipCountry AND @ShipCountry is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Suppliers_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Suppliers_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Suppliers_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Suppliers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Suppliers_Get_List

AS


				
				SELECT
					[SupplierID],
					[CompanyName],
					[ContactName],
					[ContactTitle],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[Phone],
					[Fax],
					[HomePage]
				FROM
					[dbo].[Suppliers]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Suppliers_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Suppliers_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Suppliers_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Suppliers table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Suppliers_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SupplierID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SupplierID]'
				SET @SQL = @SQL + ', [CompanyName]'
				SET @SQL = @SQL + ', [ContactName]'
				SET @SQL = @SQL + ', [ContactTitle]'
				SET @SQL = @SQL + ', [Address]'
				SET @SQL = @SQL + ', [City]'
				SET @SQL = @SQL + ', [Region]'
				SET @SQL = @SQL + ', [PostalCode]'
				SET @SQL = @SQL + ', [Country]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ', [Fax]'
				SET @SQL = @SQL + ', [HomePage]'
				SET @SQL = @SQL + ' FROM [dbo].[Suppliers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SupplierID],'
				SET @SQL = @SQL + ' [CompanyName],'
				SET @SQL = @SQL + ' [ContactName],'
				SET @SQL = @SQL + ' [ContactTitle],'
				SET @SQL = @SQL + ' [Address],'
				SET @SQL = @SQL + ' [City],'
				SET @SQL = @SQL + ' [Region],'
				SET @SQL = @SQL + ' [PostalCode],'
				SET @SQL = @SQL + ' [Country],'
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [Fax],'
				SET @SQL = @SQL + ' [HomePage]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Suppliers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Suppliers_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Suppliers_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Suppliers_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Suppliers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Suppliers_Insert
(

	@SupplierId int    OUTPUT,

	@CompanyName nvarchar (40)  ,

	@ContactName nvarchar (30)  ,

	@ContactTitle nvarchar (30)  ,

	@Address nvarchar (60)  ,

	@City nvarchar (15)  ,

	@Region nvarchar (15)  ,

	@PostalCode nvarchar (10)  ,

	@Country nvarchar (15)  ,

	@Phone nvarchar (24)  ,

	@Fax nvarchar (24)  ,

	@HomePage ntext   
)
AS


				
				INSERT INTO [dbo].[Suppliers]
					(
					[CompanyName]
					,[ContactName]
					,[ContactTitle]
					,[Address]
					,[City]
					,[Region]
					,[PostalCode]
					,[Country]
					,[Phone]
					,[Fax]
					,[HomePage]
					)
				VALUES
					(
					@CompanyName
					,@ContactName
					,@ContactTitle
					,@Address
					,@City
					,@Region
					,@PostalCode
					,@Country
					,@Phone
					,@Fax
					,@HomePage
					)
				
				-- Get the identity value
				SET @SupplierId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Suppliers_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Suppliers_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Suppliers_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Suppliers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Suppliers_Update
(

	@SupplierId int   ,

	@CompanyName nvarchar (40)  ,

	@ContactName nvarchar (30)  ,

	@ContactTitle nvarchar (30)  ,

	@Address nvarchar (60)  ,

	@City nvarchar (15)  ,

	@Region nvarchar (15)  ,

	@PostalCode nvarchar (10)  ,

	@Country nvarchar (15)  ,

	@Phone nvarchar (24)  ,

	@Fax nvarchar (24)  ,

	@HomePage ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Suppliers]
				SET
					[CompanyName] = @CompanyName
					,[ContactName] = @ContactName
					,[ContactTitle] = @ContactTitle
					,[Address] = @Address
					,[City] = @City
					,[Region] = @Region
					,[PostalCode] = @PostalCode
					,[Country] = @Country
					,[Phone] = @Phone
					,[Fax] = @Fax
					,[HomePage] = @HomePage
				WHERE
[SupplierID] = @SupplierId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Suppliers_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Suppliers_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Suppliers_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Suppliers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Suppliers_Delete
(

	@SupplierId int   
)
AS


				DELETE FROM [dbo].[Suppliers] WITH (ROWLOCK) 
				WHERE
					[SupplierID] = @SupplierId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Suppliers_GetByCompanyName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Suppliers_GetByCompanyName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Suppliers_GetByCompanyName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Suppliers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Suppliers_GetByCompanyName
(

	@CompanyName nvarchar (40)  
)
AS


				SELECT
					[SupplierID],
					[CompanyName],
					[ContactName],
					[ContactTitle],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[Phone],
					[Fax],
					[HomePage]
				FROM
					[dbo].[Suppliers]
				WHERE
					[CompanyName] = @CompanyName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Suppliers_GetBySupplierId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Suppliers_GetBySupplierId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Suppliers_GetBySupplierId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Suppliers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Suppliers_GetBySupplierId
(

	@SupplierId int   
)
AS


				SELECT
					[SupplierID],
					[CompanyName],
					[ContactName],
					[ContactTitle],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[Phone],
					[Fax],
					[HomePage]
				FROM
					[dbo].[Suppliers]
				WHERE
					[SupplierID] = @SupplierId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Suppliers_GetByPostalCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Suppliers_GetByPostalCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Suppliers_GetByPostalCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Suppliers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Suppliers_GetByPostalCode
(

	@PostalCode nvarchar (10)  
)
AS


				SELECT
					[SupplierID],
					[CompanyName],
					[ContactName],
					[ContactTitle],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[Phone],
					[Fax],
					[HomePage]
				FROM
					[dbo].[Suppliers]
				WHERE
					[PostalCode] = @PostalCode
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Suppliers_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Suppliers_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Suppliers_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Suppliers table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Suppliers_Find
(

	@SearchUsingOR bit   = null ,

	@SupplierId int   = null ,

	@CompanyName nvarchar (40)  = null ,

	@ContactName nvarchar (30)  = null ,

	@ContactTitle nvarchar (30)  = null ,

	@Address nvarchar (60)  = null ,

	@City nvarchar (15)  = null ,

	@Region nvarchar (15)  = null ,

	@PostalCode nvarchar (10)  = null ,

	@Country nvarchar (15)  = null ,

	@Phone nvarchar (24)  = null ,

	@Fax nvarchar (24)  = null ,

	@HomePage ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SupplierID]
	, [CompanyName]
	, [ContactName]
	, [ContactTitle]
	, [Address]
	, [City]
	, [Region]
	, [PostalCode]
	, [Country]
	, [Phone]
	, [Fax]
	, [HomePage]
    FROM
	[dbo].[Suppliers]
    WHERE 
	 ([SupplierID] = @SupplierId OR @SupplierId IS NULL)
	AND ([CompanyName] = @CompanyName OR @CompanyName IS NULL)
	AND ([ContactName] = @ContactName OR @ContactName IS NULL)
	AND ([ContactTitle] = @ContactTitle OR @ContactTitle IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([City] = @City OR @City IS NULL)
	AND ([Region] = @Region OR @Region IS NULL)
	AND ([PostalCode] = @PostalCode OR @PostalCode IS NULL)
	AND ([Country] = @Country OR @Country IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Fax] = @Fax OR @Fax IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SupplierID]
	, [CompanyName]
	, [ContactName]
	, [ContactTitle]
	, [Address]
	, [City]
	, [Region]
	, [PostalCode]
	, [Country]
	, [Phone]
	, [Fax]
	, [HomePage]
    FROM
	[dbo].[Suppliers]
    WHERE 
	 ([SupplierID] = @SupplierId AND @SupplierId is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([ContactName] = @ContactName AND @ContactName is not null)
	OR ([ContactTitle] = @ContactTitle AND @ContactTitle is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([City] = @City AND @City is not null)
	OR ([Region] = @Region AND @Region is not null)
	OR ([PostalCode] = @PostalCode AND @PostalCode is not null)
	OR ([Country] = @Country AND @Country is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Region_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Region_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Region_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Region table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Region_Get_List

AS


				
				SELECT
					[RegionID],
					[RegionDescription]
				FROM
					[dbo].[Region]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Region_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Region_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Region_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Region table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Region_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[RegionID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [RegionID]'
				SET @SQL = @SQL + ', [RegionDescription]'
				SET @SQL = @SQL + ' FROM [dbo].[Region]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [RegionID],'
				SET @SQL = @SQL + ' [RegionDescription]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Region]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Region_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Region_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Region_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Region table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Region_Insert
(

	@RegionId int   ,

	@RegionDescription nchar (50)  
)
AS


				
				INSERT INTO [dbo].[Region]
					(
					[RegionID]
					,[RegionDescription]
					)
				VALUES
					(
					@RegionId
					,@RegionDescription
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Region_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Region_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Region_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Region table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Region_Update
(

	@RegionId int   ,

	@OriginalRegionId int   ,

	@RegionDescription nchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Region]
				SET
					[RegionID] = @RegionId
					,[RegionDescription] = @RegionDescription
				WHERE
[RegionID] = @OriginalRegionId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Region_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Region_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Region_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Region table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Region_Delete
(

	@RegionId int   
)
AS


				DELETE FROM [dbo].[Region] WITH (ROWLOCK) 
				WHERE
					[RegionID] = @RegionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Region_GetByRegionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Region_GetByRegionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Region_GetByRegionId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Region table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Region_GetByRegionId
(

	@RegionId int   
)
AS


				SELECT
					[RegionID],
					[RegionDescription]
				FROM
					[dbo].[Region]
				WHERE
					[RegionID] = @RegionId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Region_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Region_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Region_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Region table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Region_Find
(

	@SearchUsingOR bit   = null ,

	@RegionId int   = null ,

	@RegionDescription nchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [RegionID]
	, [RegionDescription]
    FROM
	[dbo].[Region]
    WHERE 
	 ([RegionID] = @RegionId OR @RegionId IS NULL)
	AND ([RegionDescription] = @RegionDescription OR @RegionDescription IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [RegionID]
	, [RegionDescription]
    FROM
	[dbo].[Region]
    WHERE 
	 ([RegionID] = @RegionId AND @RegionId is not null)
	OR ([RegionDescription] = @RegionDescription AND @RegionDescription is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Categories_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Categories_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Categories_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Categories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Categories_Get_List

AS


				
				SELECT
					[CategoryID],
					[CategoryName],
					[Description],
					[Picture]
				FROM
					[dbo].[Categories]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Categories_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Categories_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Categories_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Categories table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Categories_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CategoryID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CategoryID]'
				SET @SQL = @SQL + ', [CategoryName]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [Picture]'
				SET @SQL = @SQL + ' FROM [dbo].[Categories]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CategoryID],'
				SET @SQL = @SQL + ' [CategoryName],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [Picture]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Categories]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Categories_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Categories_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Categories_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Categories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Categories_Insert
(

	@CategoryId int    OUTPUT,

	@CategoryName nvarchar (15)  ,

	@Description ntext   ,

	@Picture image   
)
AS


				
				INSERT INTO [dbo].[Categories]
					(
					[CategoryName]
					,[Description]
					,[Picture]
					)
				VALUES
					(
					@CategoryName
					,@Description
					,@Picture
					)
				
				-- Get the identity value
				SET @CategoryId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Categories_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Categories_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Categories_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Categories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Categories_Update
(

	@CategoryId int   ,

	@CategoryName nvarchar (15)  ,

	@Description ntext   ,

	@Picture image   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Categories]
				SET
					[CategoryName] = @CategoryName
					,[Description] = @Description
					,[Picture] = @Picture
				WHERE
[CategoryID] = @CategoryId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Categories_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Categories_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Categories_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Categories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Categories_Delete
(

	@CategoryId int   
)
AS


				DELETE FROM [dbo].[Categories] WITH (ROWLOCK) 
				WHERE
					[CategoryID] = @CategoryId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Categories_GetByCategoryName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Categories_GetByCategoryName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Categories_GetByCategoryName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Categories table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Categories_GetByCategoryName
(

	@CategoryName nvarchar (15)  
)
AS


				SELECT
					[CategoryID],
					[CategoryName],
					[Description],
					[Picture]
				FROM
					[dbo].[Categories]
				WHERE
					[CategoryName] = @CategoryName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Categories_GetByCategoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Categories_GetByCategoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Categories_GetByCategoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Categories table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Categories_GetByCategoryId
(

	@CategoryId int   
)
AS


				SELECT
					[CategoryID],
					[CategoryName],
					[Description],
					[Picture]
				FROM
					[dbo].[Categories]
				WHERE
					[CategoryID] = @CategoryId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Categories_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Categories_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Categories_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Categories table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Categories_Find
(

	@SearchUsingOR bit   = null ,

	@CategoryId int   = null ,

	@CategoryName nvarchar (15)  = null ,

	@Description ntext   = null ,

	@Picture image   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CategoryID]
	, [CategoryName]
	, [Description]
	, [Picture]
    FROM
	[dbo].[Categories]
    WHERE 
	 ([CategoryID] = @CategoryId OR @CategoryId IS NULL)
	AND ([CategoryName] = @CategoryName OR @CategoryName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CategoryID]
	, [CategoryName]
	, [Description]
	, [Picture]
    FROM
	[dbo].[Categories]
    WHERE 
	 ([CategoryID] = @CategoryId AND @CategoryId is not null)
	OR ([CategoryName] = @CategoryName AND @CategoryName is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Shippers_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Shippers_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Shippers_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Shippers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Shippers_Get_List

AS


				
				SELECT
					[ShipperID],
					[CompanyName],
					[Phone]
				FROM
					[dbo].[Shippers]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Shippers_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Shippers_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Shippers_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Shippers table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Shippers_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ShipperID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ShipperID]'
				SET @SQL = @SQL + ', [CompanyName]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ' FROM [dbo].[Shippers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ShipperID],'
				SET @SQL = @SQL + ' [CompanyName],'
				SET @SQL = @SQL + ' [Phone]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Shippers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Shippers_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Shippers_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Shippers_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Shippers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Shippers_Insert
(

	@ShipperId int    OUTPUT,

	@CompanyName nvarchar (40)  ,

	@Phone nvarchar (24)  
)
AS


				
				INSERT INTO [dbo].[Shippers]
					(
					[CompanyName]
					,[Phone]
					)
				VALUES
					(
					@CompanyName
					,@Phone
					)
				
				-- Get the identity value
				SET @ShipperId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Shippers_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Shippers_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Shippers_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Shippers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Shippers_Update
(

	@ShipperId int   ,

	@CompanyName nvarchar (40)  ,

	@Phone nvarchar (24)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Shippers]
				SET
					[CompanyName] = @CompanyName
					,[Phone] = @Phone
				WHERE
[ShipperID] = @ShipperId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Shippers_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Shippers_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Shippers_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Shippers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Shippers_Delete
(

	@ShipperId int   
)
AS


				DELETE FROM [dbo].[Shippers] WITH (ROWLOCK) 
				WHERE
					[ShipperID] = @ShipperId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Shippers_GetByShipperId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Shippers_GetByShipperId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Shippers_GetByShipperId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Shippers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Shippers_GetByShipperId
(

	@ShipperId int   
)
AS


				SELECT
					[ShipperID],
					[CompanyName],
					[Phone]
				FROM
					[dbo].[Shippers]
				WHERE
					[ShipperID] = @ShipperId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Shippers_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Shippers_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Shippers_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Shippers table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Shippers_Find
(

	@SearchUsingOR bit   = null ,

	@ShipperId int   = null ,

	@CompanyName nvarchar (40)  = null ,

	@Phone nvarchar (24)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ShipperID]
	, [CompanyName]
	, [Phone]
    FROM
	[dbo].[Shippers]
    WHERE 
	 ([ShipperID] = @ShipperId OR @ShipperId IS NULL)
	AND ([CompanyName] = @CompanyName OR @CompanyName IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ShipperID]
	, [CompanyName]
	, [Phone]
    FROM
	[dbo].[Shippers]
    WHERE 
	 ([ShipperID] = @ShipperId AND @ShipperId is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeTerritories_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeTerritories_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeTerritories_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the EmployeeTerritories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeTerritories_Get_List

AS


				
				SELECT
					[EmployeeID],
					[TerritoryID]
				FROM
					[dbo].[EmployeeTerritories]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeTerritories_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeTerritories_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeTerritories_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the EmployeeTerritories table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeTerritories_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[EmployeeID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [EmployeeID]'
				SET @SQL = @SQL + ', [TerritoryID]'
				SET @SQL = @SQL + ' FROM [dbo].[EmployeeTerritories]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [EmployeeID],'
				SET @SQL = @SQL + ' [TerritoryID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[EmployeeTerritories]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeTerritories_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeTerritories_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeTerritories_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the EmployeeTerritories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeTerritories_Insert
(

	@EmployeeId int   ,

	@TerritoryId nvarchar (20)  
)
AS


				
				INSERT INTO [dbo].[EmployeeTerritories]
					(
					[EmployeeID]
					,[TerritoryID]
					)
				VALUES
					(
					@EmployeeId
					,@TerritoryId
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeTerritories_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeTerritories_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeTerritories_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the EmployeeTerritories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeTerritories_Update
(

	@EmployeeId int   ,

	@OriginalEmployeeId int   ,

	@TerritoryId nvarchar (20)  ,

	@OriginalTerritoryId nvarchar (20)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[EmployeeTerritories]
				SET
					[EmployeeID] = @EmployeeId
					,[TerritoryID] = @TerritoryId
				WHERE
[EmployeeID] = @OriginalEmployeeId 
AND [TerritoryID] = @OriginalTerritoryId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeTerritories_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeTerritories_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeTerritories_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the EmployeeTerritories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeTerritories_Delete
(

	@EmployeeId int   ,

	@TerritoryId nvarchar (20)  
)
AS


				DELETE FROM [dbo].[EmployeeTerritories] WITH (ROWLOCK) 
				WHERE
					[EmployeeID] = @EmployeeId
					AND [TerritoryID] = @TerritoryId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeTerritories_GetByEmployeeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeTerritories_GetByEmployeeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeTerritories_GetByEmployeeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the EmployeeTerritories table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeTerritories_GetByEmployeeId
(

	@EmployeeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EmployeeID],
					[TerritoryID]
				FROM
					[dbo].[EmployeeTerritories]
				WHERE
					[EmployeeID] = @EmployeeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeTerritories_GetByTerritoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeTerritories_GetByTerritoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeTerritories_GetByTerritoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the EmployeeTerritories table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeTerritories_GetByTerritoryId
(

	@TerritoryId nvarchar (20)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EmployeeID],
					[TerritoryID]
				FROM
					[dbo].[EmployeeTerritories]
				WHERE
					[TerritoryID] = @TerritoryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeTerritories_GetByEmployeeIdTerritoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeTerritories_GetByEmployeeIdTerritoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeTerritories_GetByEmployeeIdTerritoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the EmployeeTerritories table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeTerritories_GetByEmployeeIdTerritoryId
(

	@EmployeeId int   ,

	@TerritoryId nvarchar (20)  
)
AS


				SELECT
					[EmployeeID],
					[TerritoryID]
				FROM
					[dbo].[EmployeeTerritories]
				WHERE
					[EmployeeID] = @EmployeeId
					AND [TerritoryID] = @TerritoryId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeTerritories_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeTerritories_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeTerritories_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the EmployeeTerritories table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeTerritories_Find
(

	@SearchUsingOR bit   = null ,

	@EmployeeId int   = null ,

	@TerritoryId nvarchar (20)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [EmployeeID]
	, [TerritoryID]
    FROM
	[dbo].[EmployeeTerritories]
    WHERE 
	 ([EmployeeID] = @EmployeeId OR @EmployeeId IS NULL)
	AND ([TerritoryID] = @TerritoryId OR @TerritoryId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [EmployeeID]
	, [TerritoryID]
    FROM
	[dbo].[EmployeeTerritories]
    WHERE 
	 ([EmployeeID] = @EmployeeId AND @EmployeeId is not null)
	OR ([TerritoryID] = @TerritoryId AND @TerritoryId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employees_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employees_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employees_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Employees table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employees_Get_List

AS


				
				SELECT
					[EmployeeID],
					[LastName],
					[FirstName],
					[Title],
					[TitleOfCourtesy],
					[BirthDate],
					[HireDate],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[HomePhone],
					[Extension],
					[Photo],
					[Notes],
					[ReportsTo],
					[PhotoPath]
				FROM
					[dbo].[Employees]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employees_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employees_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employees_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Employees table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employees_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[EmployeeID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [EmployeeID]'
				SET @SQL = @SQL + ', [LastName]'
				SET @SQL = @SQL + ', [FirstName]'
				SET @SQL = @SQL + ', [Title]'
				SET @SQL = @SQL + ', [TitleOfCourtesy]'
				SET @SQL = @SQL + ', [BirthDate]'
				SET @SQL = @SQL + ', [HireDate]'
				SET @SQL = @SQL + ', [Address]'
				SET @SQL = @SQL + ', [City]'
				SET @SQL = @SQL + ', [Region]'
				SET @SQL = @SQL + ', [PostalCode]'
				SET @SQL = @SQL + ', [Country]'
				SET @SQL = @SQL + ', [HomePhone]'
				SET @SQL = @SQL + ', [Extension]'
				SET @SQL = @SQL + ', [Photo]'
				SET @SQL = @SQL + ', [Notes]'
				SET @SQL = @SQL + ', [ReportsTo]'
				SET @SQL = @SQL + ', [PhotoPath]'
				SET @SQL = @SQL + ' FROM [dbo].[Employees]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [EmployeeID],'
				SET @SQL = @SQL + ' [LastName],'
				SET @SQL = @SQL + ' [FirstName],'
				SET @SQL = @SQL + ' [Title],'
				SET @SQL = @SQL + ' [TitleOfCourtesy],'
				SET @SQL = @SQL + ' [BirthDate],'
				SET @SQL = @SQL + ' [HireDate],'
				SET @SQL = @SQL + ' [Address],'
				SET @SQL = @SQL + ' [City],'
				SET @SQL = @SQL + ' [Region],'
				SET @SQL = @SQL + ' [PostalCode],'
				SET @SQL = @SQL + ' [Country],'
				SET @SQL = @SQL + ' [HomePhone],'
				SET @SQL = @SQL + ' [Extension],'
				SET @SQL = @SQL + ' [Photo],'
				SET @SQL = @SQL + ' [Notes],'
				SET @SQL = @SQL + ' [ReportsTo],'
				SET @SQL = @SQL + ' [PhotoPath]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Employees]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employees_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employees_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employees_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Employees table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employees_Insert
(

	@EmployeeId int    OUTPUT,

	@LastName nvarchar (20)  ,

	@FirstName nvarchar (10)  ,

	@Title nvarchar (30)  ,

	@TitleOfCourtesy nvarchar (25)  ,

	@BirthDate datetime   ,

	@HireDate datetime   ,

	@Address nvarchar (60)  ,

	@City nvarchar (15)  ,

	@Region nvarchar (15)  ,

	@PostalCode nvarchar (10)  ,

	@Country nvarchar (15)  ,

	@HomePhone nvarchar (24)  ,

	@Extension nvarchar (4)  ,

	@Photo image   ,

	@Notes ntext   ,

	@ReportsTo int   ,

	@PhotoPath nvarchar (255)  
)
AS


				
				INSERT INTO [dbo].[Employees]
					(
					[LastName]
					,[FirstName]
					,[Title]
					,[TitleOfCourtesy]
					,[BirthDate]
					,[HireDate]
					,[Address]
					,[City]
					,[Region]
					,[PostalCode]
					,[Country]
					,[HomePhone]
					,[Extension]
					,[Photo]
					,[Notes]
					,[ReportsTo]
					,[PhotoPath]
					)
				VALUES
					(
					@LastName
					,@FirstName
					,@Title
					,@TitleOfCourtesy
					,@BirthDate
					,@HireDate
					,@Address
					,@City
					,@Region
					,@PostalCode
					,@Country
					,@HomePhone
					,@Extension
					,@Photo
					,@Notes
					,@ReportsTo
					,@PhotoPath
					)
				
				-- Get the identity value
				SET @EmployeeId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employees_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employees_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employees_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Employees table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employees_Update
(

	@EmployeeId int   ,

	@LastName nvarchar (20)  ,

	@FirstName nvarchar (10)  ,

	@Title nvarchar (30)  ,

	@TitleOfCourtesy nvarchar (25)  ,

	@BirthDate datetime   ,

	@HireDate datetime   ,

	@Address nvarchar (60)  ,

	@City nvarchar (15)  ,

	@Region nvarchar (15)  ,

	@PostalCode nvarchar (10)  ,

	@Country nvarchar (15)  ,

	@HomePhone nvarchar (24)  ,

	@Extension nvarchar (4)  ,

	@Photo image   ,

	@Notes ntext   ,

	@ReportsTo int   ,

	@PhotoPath nvarchar (255)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Employees]
				SET
					[LastName] = @LastName
					,[FirstName] = @FirstName
					,[Title] = @Title
					,[TitleOfCourtesy] = @TitleOfCourtesy
					,[BirthDate] = @BirthDate
					,[HireDate] = @HireDate
					,[Address] = @Address
					,[City] = @City
					,[Region] = @Region
					,[PostalCode] = @PostalCode
					,[Country] = @Country
					,[HomePhone] = @HomePhone
					,[Extension] = @Extension
					,[Photo] = @Photo
					,[Notes] = @Notes
					,[ReportsTo] = @ReportsTo
					,[PhotoPath] = @PhotoPath
				WHERE
[EmployeeID] = @EmployeeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employees_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employees_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employees_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Employees table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employees_Delete
(

	@EmployeeId int   
)
AS


				DELETE FROM [dbo].[Employees] WITH (ROWLOCK) 
				WHERE
					[EmployeeID] = @EmployeeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employees_GetByReportsTo procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employees_GetByReportsTo') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employees_GetByReportsTo
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Employees table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employees_GetByReportsTo
(

	@ReportsTo int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EmployeeID],
					[LastName],
					[FirstName],
					[Title],
					[TitleOfCourtesy],
					[BirthDate],
					[HireDate],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[HomePhone],
					[Extension],
					[Photo],
					[Notes],
					[ReportsTo],
					[PhotoPath]
				FROM
					[dbo].[Employees]
				WHERE
					[ReportsTo] = @ReportsTo
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employees_GetByLastName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employees_GetByLastName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employees_GetByLastName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Employees table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employees_GetByLastName
(

	@LastName nvarchar (20)  
)
AS


				SELECT
					[EmployeeID],
					[LastName],
					[FirstName],
					[Title],
					[TitleOfCourtesy],
					[BirthDate],
					[HireDate],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[HomePhone],
					[Extension],
					[Photo],
					[Notes],
					[ReportsTo],
					[PhotoPath]
				FROM
					[dbo].[Employees]
				WHERE
					[LastName] = @LastName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employees_GetByEmployeeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employees_GetByEmployeeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employees_GetByEmployeeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Employees table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employees_GetByEmployeeId
(

	@EmployeeId int   
)
AS


				SELECT
					[EmployeeID],
					[LastName],
					[FirstName],
					[Title],
					[TitleOfCourtesy],
					[BirthDate],
					[HireDate],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[HomePhone],
					[Extension],
					[Photo],
					[Notes],
					[ReportsTo],
					[PhotoPath]
				FROM
					[dbo].[Employees]
				WHERE
					[EmployeeID] = @EmployeeId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employees_GetByPostalCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employees_GetByPostalCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employees_GetByPostalCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Employees table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employees_GetByPostalCode
(

	@PostalCode nvarchar (10)  
)
AS


				SELECT
					[EmployeeID],
					[LastName],
					[FirstName],
					[Title],
					[TitleOfCourtesy],
					[BirthDate],
					[HireDate],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[HomePhone],
					[Extension],
					[Photo],
					[Notes],
					[ReportsTo],
					[PhotoPath]
				FROM
					[dbo].[Employees]
				WHERE
					[PostalCode] = @PostalCode
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employees_GetByTerritoryIdFromEmployeeTerritories procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employees_GetByTerritoryIdFromEmployeeTerritories') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employees_GetByTerritoryIdFromEmployeeTerritories
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employees_GetByTerritoryIdFromEmployeeTerritories
(

	@TerritoryId nvarchar (20)  
)
AS


SELECT dbo.[Employees].[EmployeeID]
       ,dbo.[Employees].[LastName]
       ,dbo.[Employees].[FirstName]
       ,dbo.[Employees].[Title]
       ,dbo.[Employees].[TitleOfCourtesy]
       ,dbo.[Employees].[BirthDate]
       ,dbo.[Employees].[HireDate]
       ,dbo.[Employees].[Address]
       ,dbo.[Employees].[City]
       ,dbo.[Employees].[Region]
       ,dbo.[Employees].[PostalCode]
       ,dbo.[Employees].[Country]
       ,dbo.[Employees].[HomePhone]
       ,dbo.[Employees].[Extension]
       ,dbo.[Employees].[Photo]
       ,dbo.[Employees].[Notes]
       ,dbo.[Employees].[ReportsTo]
       ,dbo.[Employees].[PhotoPath]
  FROM dbo.[Employees]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[EmployeeTerritories] 
                WHERE dbo.[EmployeeTerritories].[TerritoryID] = @TerritoryId
                  AND dbo.[EmployeeTerritories].[EmployeeID] = dbo.[Employees].[EmployeeID]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employees_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employees_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employees_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Employees table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employees_Find
(

	@SearchUsingOR bit   = null ,

	@EmployeeId int   = null ,

	@LastName nvarchar (20)  = null ,

	@FirstName nvarchar (10)  = null ,

	@Title nvarchar (30)  = null ,

	@TitleOfCourtesy nvarchar (25)  = null ,

	@BirthDate datetime   = null ,

	@HireDate datetime   = null ,

	@Address nvarchar (60)  = null ,

	@City nvarchar (15)  = null ,

	@Region nvarchar (15)  = null ,

	@PostalCode nvarchar (10)  = null ,

	@Country nvarchar (15)  = null ,

	@HomePhone nvarchar (24)  = null ,

	@Extension nvarchar (4)  = null ,

	@Photo image   = null ,

	@Notes ntext   = null ,

	@ReportsTo int   = null ,

	@PhotoPath nvarchar (255)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [EmployeeID]
	, [LastName]
	, [FirstName]
	, [Title]
	, [TitleOfCourtesy]
	, [BirthDate]
	, [HireDate]
	, [Address]
	, [City]
	, [Region]
	, [PostalCode]
	, [Country]
	, [HomePhone]
	, [Extension]
	, [Photo]
	, [Notes]
	, [ReportsTo]
	, [PhotoPath]
    FROM
	[dbo].[Employees]
    WHERE 
	 ([EmployeeID] = @EmployeeId OR @EmployeeId IS NULL)
	AND ([LastName] = @LastName OR @LastName IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([Title] = @Title OR @Title IS NULL)
	AND ([TitleOfCourtesy] = @TitleOfCourtesy OR @TitleOfCourtesy IS NULL)
	AND ([BirthDate] = @BirthDate OR @BirthDate IS NULL)
	AND ([HireDate] = @HireDate OR @HireDate IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([City] = @City OR @City IS NULL)
	AND ([Region] = @Region OR @Region IS NULL)
	AND ([PostalCode] = @PostalCode OR @PostalCode IS NULL)
	AND ([Country] = @Country OR @Country IS NULL)
	AND ([HomePhone] = @HomePhone OR @HomePhone IS NULL)
	AND ([Extension] = @Extension OR @Extension IS NULL)
	AND ([ReportsTo] = @ReportsTo OR @ReportsTo IS NULL)
	AND ([PhotoPath] = @PhotoPath OR @PhotoPath IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [EmployeeID]
	, [LastName]
	, [FirstName]
	, [Title]
	, [TitleOfCourtesy]
	, [BirthDate]
	, [HireDate]
	, [Address]
	, [City]
	, [Region]
	, [PostalCode]
	, [Country]
	, [HomePhone]
	, [Extension]
	, [Photo]
	, [Notes]
	, [ReportsTo]
	, [PhotoPath]
    FROM
	[dbo].[Employees]
    WHERE 
	 ([EmployeeID] = @EmployeeId AND @EmployeeId is not null)
	OR ([LastName] = @LastName AND @LastName is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([Title] = @Title AND @Title is not null)
	OR ([TitleOfCourtesy] = @TitleOfCourtesy AND @TitleOfCourtesy is not null)
	OR ([BirthDate] = @BirthDate AND @BirthDate is not null)
	OR ([HireDate] = @HireDate AND @HireDate is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([City] = @City AND @City is not null)
	OR ([Region] = @Region AND @Region is not null)
	OR ([PostalCode] = @PostalCode AND @PostalCode is not null)
	OR ([Country] = @Country AND @Country is not null)
	OR ([HomePhone] = @HomePhone AND @HomePhone is not null)
	OR ([Extension] = @Extension AND @Extension is not null)
	OR ([ReportsTo] = @ReportsTo AND @ReportsTo is not null)
	OR ([PhotoPath] = @PhotoPath AND @PhotoPath is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Territories_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Territories_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Territories_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Territories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Territories_Get_List

AS


				
				SELECT
					[TerritoryID],
					[TerritoryDescription],
					[RegionID]
				FROM
					[dbo].[Territories]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Territories_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Territories_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Territories_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Territories table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Territories_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[TerritoryID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [TerritoryID]'
				SET @SQL = @SQL + ', [TerritoryDescription]'
				SET @SQL = @SQL + ', [RegionID]'
				SET @SQL = @SQL + ' FROM [dbo].[Territories]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [TerritoryID],'
				SET @SQL = @SQL + ' [TerritoryDescription],'
				SET @SQL = @SQL + ' [RegionID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Territories]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Territories_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Territories_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Territories_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Territories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Territories_Insert
(

	@TerritoryId nvarchar (20)  ,

	@TerritoryDescription nchar (50)  ,

	@RegionId int   
)
AS


				
				INSERT INTO [dbo].[Territories]
					(
					[TerritoryID]
					,[TerritoryDescription]
					,[RegionID]
					)
				VALUES
					(
					@TerritoryId
					,@TerritoryDescription
					,@RegionId
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Territories_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Territories_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Territories_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Territories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Territories_Update
(

	@TerritoryId nvarchar (20)  ,

	@OriginalTerritoryId nvarchar (20)  ,

	@TerritoryDescription nchar (50)  ,

	@RegionId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Territories]
				SET
					[TerritoryID] = @TerritoryId
					,[TerritoryDescription] = @TerritoryDescription
					,[RegionID] = @RegionId
				WHERE
[TerritoryID] = @OriginalTerritoryId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Territories_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Territories_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Territories_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Territories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Territories_Delete
(

	@TerritoryId nvarchar (20)  
)
AS


				DELETE FROM [dbo].[Territories] WITH (ROWLOCK) 
				WHERE
					[TerritoryID] = @TerritoryId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Territories_GetByRegionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Territories_GetByRegionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Territories_GetByRegionId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Territories table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Territories_GetByRegionId
(

	@RegionId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[TerritoryID],
					[TerritoryDescription],
					[RegionID]
				FROM
					[dbo].[Territories]
				WHERE
					[RegionID] = @RegionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Territories_GetByTerritoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Territories_GetByTerritoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Territories_GetByTerritoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Territories table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Territories_GetByTerritoryId
(

	@TerritoryId nvarchar (20)  
)
AS


				SELECT
					[TerritoryID],
					[TerritoryDescription],
					[RegionID]
				FROM
					[dbo].[Territories]
				WHERE
					[TerritoryID] = @TerritoryId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Territories_GetByEmployeeIdFromEmployeeTerritories procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Territories_GetByEmployeeIdFromEmployeeTerritories') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Territories_GetByEmployeeIdFromEmployeeTerritories
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Territories_GetByEmployeeIdFromEmployeeTerritories
(

	@EmployeeId int   
)
AS


SELECT dbo.[Territories].[TerritoryID]
       ,dbo.[Territories].[TerritoryDescription]
       ,dbo.[Territories].[RegionID]
  FROM dbo.[Territories]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[EmployeeTerritories] 
                WHERE dbo.[EmployeeTerritories].[EmployeeID] = @EmployeeId
                  AND dbo.[EmployeeTerritories].[TerritoryID] = dbo.[Territories].[TerritoryID]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Territories_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Territories_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Territories_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Territories table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Territories_Find
(

	@SearchUsingOR bit   = null ,

	@TerritoryId nvarchar (20)  = null ,

	@TerritoryDescription nchar (50)  = null ,

	@RegionId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [TerritoryID]
	, [TerritoryDescription]
	, [RegionID]
    FROM
	[dbo].[Territories]
    WHERE 
	 ([TerritoryID] = @TerritoryId OR @TerritoryId IS NULL)
	AND ([TerritoryDescription] = @TerritoryDescription OR @TerritoryDescription IS NULL)
	AND ([RegionID] = @RegionId OR @RegionId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [TerritoryID]
	, [TerritoryDescription]
	, [RegionID]
    FROM
	[dbo].[Territories]
    WHERE 
	 ([TerritoryID] = @TerritoryId AND @TerritoryId is not null)
	OR ([TerritoryDescription] = @TerritoryDescription AND @TerritoryDescription is not null)
	OR ([RegionID] = @RegionId AND @RegionId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDemographics_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDemographics_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDemographics_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the CustomerDemographics table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDemographics_Get_List

AS


				
				SELECT
					[CustomerTypeID],
					[CustomerDesc]
				FROM
					[dbo].[CustomerDemographics]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDemographics_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDemographics_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDemographics_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the CustomerDemographics table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDemographics_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CustomerTypeID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CustomerTypeID]'
				SET @SQL = @SQL + ', [CustomerDesc]'
				SET @SQL = @SQL + ' FROM [dbo].[CustomerDemographics]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CustomerTypeID],'
				SET @SQL = @SQL + ' [CustomerDesc]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[CustomerDemographics]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDemographics_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDemographics_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDemographics_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the CustomerDemographics table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDemographics_Insert
(

	@CustomerTypeId nchar (10)  ,

	@CustomerDesc ntext   
)
AS


				
				INSERT INTO [dbo].[CustomerDemographics]
					(
					[CustomerTypeID]
					,[CustomerDesc]
					)
				VALUES
					(
					@CustomerTypeId
					,@CustomerDesc
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDemographics_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDemographics_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDemographics_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the CustomerDemographics table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDemographics_Update
(

	@CustomerTypeId nchar (10)  ,

	@OriginalCustomerTypeId nchar (10)  ,

	@CustomerDesc ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[CustomerDemographics]
				SET
					[CustomerTypeID] = @CustomerTypeId
					,[CustomerDesc] = @CustomerDesc
				WHERE
[CustomerTypeID] = @OriginalCustomerTypeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDemographics_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDemographics_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDemographics_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the CustomerDemographics table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDemographics_Delete
(

	@CustomerTypeId nchar (10)  
)
AS


				DELETE FROM [dbo].[CustomerDemographics] WITH (ROWLOCK) 
				WHERE
					[CustomerTypeID] = @CustomerTypeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDemographics_GetByCustomerTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDemographics_GetByCustomerTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDemographics_GetByCustomerTypeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerDemographics table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDemographics_GetByCustomerTypeId
(

	@CustomerTypeId nchar (10)  
)
AS


				SELECT
					[CustomerTypeID],
					[CustomerDesc]
				FROM
					[dbo].[CustomerDemographics]
				WHERE
					[CustomerTypeID] = @CustomerTypeId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDemographics_GetByCustomerIdFromCustomerCustomerDemo procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDemographics_GetByCustomerIdFromCustomerCustomerDemo') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDemographics_GetByCustomerIdFromCustomerCustomerDemo
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDemographics_GetByCustomerIdFromCustomerCustomerDemo
(

	@CustomerId nchar (5)  
)
AS


SELECT dbo.[CustomerDemographics].[CustomerTypeID]
       ,dbo.[CustomerDemographics].[CustomerDesc]
  FROM dbo.[CustomerDemographics]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[CustomerCustomerDemo] 
                WHERE dbo.[CustomerCustomerDemo].[CustomerID] = @CustomerId
                  AND dbo.[CustomerCustomerDemo].[CustomerTypeID] = dbo.[CustomerDemographics].[CustomerTypeID]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerDemographics_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerDemographics_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerDemographics_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the CustomerDemographics table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerDemographics_Find
(

	@SearchUsingOR bit   = null ,

	@CustomerTypeId nchar (10)  = null ,

	@CustomerDesc ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CustomerTypeID]
	, [CustomerDesc]
    FROM
	[dbo].[CustomerDemographics]
    WHERE 
	 ([CustomerTypeID] = @CustomerTypeId OR @CustomerTypeId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CustomerTypeID]
	, [CustomerDesc]
    FROM
	[dbo].[CustomerDemographics]
    WHERE 
	 ([CustomerTypeID] = @CustomerTypeId AND @CustomerTypeId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Customers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_Get_List

AS


				
				SELECT
					[CustomerID],
					[CompanyName],
					[ContactName],
					[ContactTitle],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[Phone],
					[Fax]
				FROM
					[dbo].[Customers]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Customers table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CustomerID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CustomerID]'
				SET @SQL = @SQL + ', [CompanyName]'
				SET @SQL = @SQL + ', [ContactName]'
				SET @SQL = @SQL + ', [ContactTitle]'
				SET @SQL = @SQL + ', [Address]'
				SET @SQL = @SQL + ', [City]'
				SET @SQL = @SQL + ', [Region]'
				SET @SQL = @SQL + ', [PostalCode]'
				SET @SQL = @SQL + ', [Country]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ', [Fax]'
				SET @SQL = @SQL + ' FROM [dbo].[Customers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CustomerID],'
				SET @SQL = @SQL + ' [CompanyName],'
				SET @SQL = @SQL + ' [ContactName],'
				SET @SQL = @SQL + ' [ContactTitle],'
				SET @SQL = @SQL + ' [Address],'
				SET @SQL = @SQL + ' [City],'
				SET @SQL = @SQL + ' [Region],'
				SET @SQL = @SQL + ' [PostalCode],'
				SET @SQL = @SQL + ' [Country],'
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [Fax]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Customers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Customers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_Insert
(

	@CustomerId nchar (5)  ,

	@CompanyName nvarchar (40)  ,

	@ContactName nvarchar (30)  ,

	@ContactTitle nvarchar (30)  ,

	@Address nvarchar (60)  ,

	@City nvarchar (15)  ,

	@Region nvarchar (15)  ,

	@PostalCode nvarchar (10)  ,

	@Country nvarchar (15)  ,

	@Phone nvarchar (24)  ,

	@Fax nvarchar (24)  
)
AS


				
				INSERT INTO [dbo].[Customers]
					(
					[CustomerID]
					,[CompanyName]
					,[ContactName]
					,[ContactTitle]
					,[Address]
					,[City]
					,[Region]
					,[PostalCode]
					,[Country]
					,[Phone]
					,[Fax]
					)
				VALUES
					(
					@CustomerId
					,@CompanyName
					,@ContactName
					,@ContactTitle
					,@Address
					,@City
					,@Region
					,@PostalCode
					,@Country
					,@Phone
					,@Fax
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Customers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_Update
(

	@CustomerId nchar (5)  ,

	@OriginalCustomerId nchar (5)  ,

	@CompanyName nvarchar (40)  ,

	@ContactName nvarchar (30)  ,

	@ContactTitle nvarchar (30)  ,

	@Address nvarchar (60)  ,

	@City nvarchar (15)  ,

	@Region nvarchar (15)  ,

	@PostalCode nvarchar (10)  ,

	@Country nvarchar (15)  ,

	@Phone nvarchar (24)  ,

	@Fax nvarchar (24)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Customers]
				SET
					[CustomerID] = @CustomerId
					,[CompanyName] = @CompanyName
					,[ContactName] = @ContactName
					,[ContactTitle] = @ContactTitle
					,[Address] = @Address
					,[City] = @City
					,[Region] = @Region
					,[PostalCode] = @PostalCode
					,[Country] = @Country
					,[Phone] = @Phone
					,[Fax] = @Fax
				WHERE
[CustomerID] = @OriginalCustomerId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Customers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_Delete
(

	@CustomerId nchar (5)  
)
AS


				DELETE FROM [dbo].[Customers] WITH (ROWLOCK) 
				WHERE
					[CustomerID] = @CustomerId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_GetByCity procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_GetByCity') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_GetByCity
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Customers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_GetByCity
(

	@City nvarchar (15)  
)
AS


				SELECT
					[CustomerID],
					[CompanyName],
					[ContactName],
					[ContactTitle],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[Phone],
					[Fax]
				FROM
					[dbo].[Customers]
				WHERE
					[City] = @City
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_GetByCompanyName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_GetByCompanyName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_GetByCompanyName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Customers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_GetByCompanyName
(

	@CompanyName nvarchar (40)  
)
AS


				SELECT
					[CustomerID],
					[CompanyName],
					[ContactName],
					[ContactTitle],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[Phone],
					[Fax]
				FROM
					[dbo].[Customers]
				WHERE
					[CompanyName] = @CompanyName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_GetByCustomerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_GetByCustomerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_GetByCustomerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Customers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_GetByCustomerId
(

	@CustomerId nchar (5)  
)
AS


				SELECT
					[CustomerID],
					[CompanyName],
					[ContactName],
					[ContactTitle],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[Phone],
					[Fax]
				FROM
					[dbo].[Customers]
				WHERE
					[CustomerID] = @CustomerId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_GetByPostalCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_GetByPostalCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_GetByPostalCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Customers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_GetByPostalCode
(

	@PostalCode nvarchar (10)  
)
AS


				SELECT
					[CustomerID],
					[CompanyName],
					[ContactName],
					[ContactTitle],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[Phone],
					[Fax]
				FROM
					[dbo].[Customers]
				WHERE
					[PostalCode] = @PostalCode
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_GetByRegion procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_GetByRegion') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_GetByRegion
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Customers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_GetByRegion
(

	@Region nvarchar (15)  
)
AS


				SELECT
					[CustomerID],
					[CompanyName],
					[ContactName],
					[ContactTitle],
					[Address],
					[City],
					[Region],
					[PostalCode],
					[Country],
					[Phone],
					[Fax]
				FROM
					[dbo].[Customers]
				WHERE
					[Region] = @Region
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_GetByCustomerTypeIdFromCustomerCustomerDemo procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_GetByCustomerTypeIdFromCustomerCustomerDemo') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_GetByCustomerTypeIdFromCustomerCustomerDemo
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_GetByCustomerTypeIdFromCustomerCustomerDemo
(

	@CustomerTypeId nchar (10)  
)
AS


SELECT dbo.[Customers].[CustomerID]
       ,dbo.[Customers].[CompanyName]
       ,dbo.[Customers].[ContactName]
       ,dbo.[Customers].[ContactTitle]
       ,dbo.[Customers].[Address]
       ,dbo.[Customers].[City]
       ,dbo.[Customers].[Region]
       ,dbo.[Customers].[PostalCode]
       ,dbo.[Customers].[Country]
       ,dbo.[Customers].[Phone]
       ,dbo.[Customers].[Fax]
  FROM dbo.[Customers]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[CustomerCustomerDemo] 
                WHERE dbo.[CustomerCustomerDemo].[CustomerTypeID] = @CustomerTypeId
                  AND dbo.[CustomerCustomerDemo].[CustomerID] = dbo.[Customers].[CustomerID]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Customers table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_Find
(

	@SearchUsingOR bit   = null ,

	@CustomerId nchar (5)  = null ,

	@CompanyName nvarchar (40)  = null ,

	@ContactName nvarchar (30)  = null ,

	@ContactTitle nvarchar (30)  = null ,

	@Address nvarchar (60)  = null ,

	@City nvarchar (15)  = null ,

	@Region nvarchar (15)  = null ,

	@PostalCode nvarchar (10)  = null ,

	@Country nvarchar (15)  = null ,

	@Phone nvarchar (24)  = null ,

	@Fax nvarchar (24)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CustomerID]
	, [CompanyName]
	, [ContactName]
	, [ContactTitle]
	, [Address]
	, [City]
	, [Region]
	, [PostalCode]
	, [Country]
	, [Phone]
	, [Fax]
    FROM
	[dbo].[Customers]
    WHERE 
	 ([CustomerID] = @CustomerId OR @CustomerId IS NULL)
	AND ([CompanyName] = @CompanyName OR @CompanyName IS NULL)
	AND ([ContactName] = @ContactName OR @ContactName IS NULL)
	AND ([ContactTitle] = @ContactTitle OR @ContactTitle IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([City] = @City OR @City IS NULL)
	AND ([Region] = @Region OR @Region IS NULL)
	AND ([PostalCode] = @PostalCode OR @PostalCode IS NULL)
	AND ([Country] = @Country OR @Country IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Fax] = @Fax OR @Fax IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CustomerID]
	, [CompanyName]
	, [ContactName]
	, [ContactTitle]
	, [Address]
	, [City]
	, [Region]
	, [PostalCode]
	, [Country]
	, [Phone]
	, [Fax]
    FROM
	[dbo].[Customers]
    WHERE 
	 ([CustomerID] = @CustomerId AND @CustomerId is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([ContactName] = @ContactName AND @ContactName is not null)
	OR ([ContactTitle] = @ContactTitle AND @ContactTitle is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([City] = @City AND @City is not null)
	OR ([Region] = @Region AND @Region is not null)
	OR ([PostalCode] = @PostalCode AND @PostalCode is not null)
	OR ([Country] = @Country AND @Country is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Products_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Products_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Products_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Products table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Products_Get_List

AS


				
				SELECT
					[ProductID],
					[ProductName],
					[SupplierID],
					[CategoryID],
					[QuantityPerUnit],
					[UnitPrice],
					[UnitsInStock],
					[UnitsOnOrder],
					[ReorderLevel],
					[Discontinued]
				FROM
					[dbo].[Products]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Products_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Products_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Products_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Products table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Products_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ProductID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ProductID]'
				SET @SQL = @SQL + ', [ProductName]'
				SET @SQL = @SQL + ', [SupplierID]'
				SET @SQL = @SQL + ', [CategoryID]'
				SET @SQL = @SQL + ', [QuantityPerUnit]'
				SET @SQL = @SQL + ', [UnitPrice]'
				SET @SQL = @SQL + ', [UnitsInStock]'
				SET @SQL = @SQL + ', [UnitsOnOrder]'
				SET @SQL = @SQL + ', [ReorderLevel]'
				SET @SQL = @SQL + ', [Discontinued]'
				SET @SQL = @SQL + ' FROM [dbo].[Products]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ProductID],'
				SET @SQL = @SQL + ' [ProductName],'
				SET @SQL = @SQL + ' [SupplierID],'
				SET @SQL = @SQL + ' [CategoryID],'
				SET @SQL = @SQL + ' [QuantityPerUnit],'
				SET @SQL = @SQL + ' [UnitPrice],'
				SET @SQL = @SQL + ' [UnitsInStock],'
				SET @SQL = @SQL + ' [UnitsOnOrder],'
				SET @SQL = @SQL + ' [ReorderLevel],'
				SET @SQL = @SQL + ' [Discontinued]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Products]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Products_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Products_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Products_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Products table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Products_Insert
(

	@ProductId int    OUTPUT,

	@ProductName nvarchar (40)  ,

	@SupplierId int   ,

	@CategoryId int   ,

	@QuantityPerUnit nvarchar (20)  ,

	@UnitPrice money   ,

	@UnitsInStock smallint   ,

	@UnitsOnOrder smallint   ,

	@ReorderLevel smallint   ,

	@Discontinued bit   
)
AS


				
				INSERT INTO [dbo].[Products]
					(
					[ProductName]
					,[SupplierID]
					,[CategoryID]
					,[QuantityPerUnit]
					,[UnitPrice]
					,[UnitsInStock]
					,[UnitsOnOrder]
					,[ReorderLevel]
					,[Discontinued]
					)
				VALUES
					(
					@ProductName
					,@SupplierId
					,@CategoryId
					,@QuantityPerUnit
					,@UnitPrice
					,@UnitsInStock
					,@UnitsOnOrder
					,@ReorderLevel
					,@Discontinued
					)
				
				-- Get the identity value
				SET @ProductId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Products_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Products_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Products_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Products table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Products_Update
(

	@ProductId int   ,

	@ProductName nvarchar (40)  ,

	@SupplierId int   ,

	@CategoryId int   ,

	@QuantityPerUnit nvarchar (20)  ,

	@UnitPrice money   ,

	@UnitsInStock smallint   ,

	@UnitsOnOrder smallint   ,

	@ReorderLevel smallint   ,

	@Discontinued bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Products]
				SET
					[ProductName] = @ProductName
					,[SupplierID] = @SupplierId
					,[CategoryID] = @CategoryId
					,[QuantityPerUnit] = @QuantityPerUnit
					,[UnitPrice] = @UnitPrice
					,[UnitsInStock] = @UnitsInStock
					,[UnitsOnOrder] = @UnitsOnOrder
					,[ReorderLevel] = @ReorderLevel
					,[Discontinued] = @Discontinued
				WHERE
[ProductID] = @ProductId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Products_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Products_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Products_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Products table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Products_Delete
(

	@ProductId int   
)
AS


				DELETE FROM [dbo].[Products] WITH (ROWLOCK) 
				WHERE
					[ProductID] = @ProductId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Products_GetByCategoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Products_GetByCategoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Products_GetByCategoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Products table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Products_GetByCategoryId
(

	@CategoryId int   
)
AS


				SELECT
					[ProductID],
					[ProductName],
					[SupplierID],
					[CategoryID],
					[QuantityPerUnit],
					[UnitPrice],
					[UnitsInStock],
					[UnitsOnOrder],
					[ReorderLevel],
					[Discontinued]
				FROM
					[dbo].[Products]
				WHERE
					[CategoryID] = @CategoryId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Products_GetByProductId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Products_GetByProductId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Products_GetByProductId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Products table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Products_GetByProductId
(

	@ProductId int   
)
AS


				SELECT
					[ProductID],
					[ProductName],
					[SupplierID],
					[CategoryID],
					[QuantityPerUnit],
					[UnitPrice],
					[UnitsInStock],
					[UnitsOnOrder],
					[ReorderLevel],
					[Discontinued]
				FROM
					[dbo].[Products]
				WHERE
					[ProductID] = @ProductId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Products_GetByProductName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Products_GetByProductName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Products_GetByProductName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Products table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Products_GetByProductName
(

	@ProductName nvarchar (40)  
)
AS


				SELECT
					[ProductID],
					[ProductName],
					[SupplierID],
					[CategoryID],
					[QuantityPerUnit],
					[UnitPrice],
					[UnitsInStock],
					[UnitsOnOrder],
					[ReorderLevel],
					[Discontinued]
				FROM
					[dbo].[Products]
				WHERE
					[ProductName] = @ProductName
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Products_GetBySupplierId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Products_GetBySupplierId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Products_GetBySupplierId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Products table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Products_GetBySupplierId
(

	@SupplierId int   
)
AS


				SELECT
					[ProductID],
					[ProductName],
					[SupplierID],
					[CategoryID],
					[QuantityPerUnit],
					[UnitPrice],
					[UnitsInStock],
					[UnitsOnOrder],
					[ReorderLevel],
					[Discontinued]
				FROM
					[dbo].[Products]
				WHERE
					[SupplierID] = @SupplierId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Products_GetByOrderIdFromOrderDetails procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Products_GetByOrderIdFromOrderDetails') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Products_GetByOrderIdFromOrderDetails
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Products_GetByOrderIdFromOrderDetails
(

	@OrderId int   
)
AS


SELECT dbo.[Products].[ProductID]
       ,dbo.[Products].[ProductName]
       ,dbo.[Products].[SupplierID]
       ,dbo.[Products].[CategoryID]
       ,dbo.[Products].[QuantityPerUnit]
       ,dbo.[Products].[UnitPrice]
       ,dbo.[Products].[UnitsInStock]
       ,dbo.[Products].[UnitsOnOrder]
       ,dbo.[Products].[ReorderLevel]
       ,dbo.[Products].[Discontinued]
  FROM dbo.[Products]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[Order Details] 
                WHERE dbo.[Order Details].[OrderID] = @OrderId
                  AND dbo.[Order Details].[ProductID] = dbo.[Products].[ProductID]
                  )
				SELECT @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Products_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Products_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Products_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Products table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Products_Find
(

	@SearchUsingOR bit   = null ,

	@ProductId int   = null ,

	@ProductName nvarchar (40)  = null ,

	@SupplierId int   = null ,

	@CategoryId int   = null ,

	@QuantityPerUnit nvarchar (20)  = null ,

	@UnitPrice money   = null ,

	@UnitsInStock smallint   = null ,

	@UnitsOnOrder smallint   = null ,

	@ReorderLevel smallint   = null ,

	@Discontinued bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ProductID]
	, [ProductName]
	, [SupplierID]
	, [CategoryID]
	, [QuantityPerUnit]
	, [UnitPrice]
	, [UnitsInStock]
	, [UnitsOnOrder]
	, [ReorderLevel]
	, [Discontinued]
    FROM
	[dbo].[Products]
    WHERE 
	 ([ProductID] = @ProductId OR @ProductId IS NULL)
	AND ([ProductName] = @ProductName OR @ProductName IS NULL)
	AND ([SupplierID] = @SupplierId OR @SupplierId IS NULL)
	AND ([CategoryID] = @CategoryId OR @CategoryId IS NULL)
	AND ([QuantityPerUnit] = @QuantityPerUnit OR @QuantityPerUnit IS NULL)
	AND ([UnitPrice] = @UnitPrice OR @UnitPrice IS NULL)
	AND ([UnitsInStock] = @UnitsInStock OR @UnitsInStock IS NULL)
	AND ([UnitsOnOrder] = @UnitsOnOrder OR @UnitsOnOrder IS NULL)
	AND ([ReorderLevel] = @ReorderLevel OR @ReorderLevel IS NULL)
	AND ([Discontinued] = @Discontinued OR @Discontinued IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ProductID]
	, [ProductName]
	, [SupplierID]
	, [CategoryID]
	, [QuantityPerUnit]
	, [UnitPrice]
	, [UnitsInStock]
	, [UnitsOnOrder]
	, [ReorderLevel]
	, [Discontinued]
    FROM
	[dbo].[Products]
    WHERE 
	 ([ProductID] = @ProductId AND @ProductId is not null)
	OR ([ProductName] = @ProductName AND @ProductName is not null)
	OR ([SupplierID] = @SupplierId AND @SupplierId is not null)
	OR ([CategoryID] = @CategoryId AND @CategoryId is not null)
	OR ([QuantityPerUnit] = @QuantityPerUnit AND @QuantityPerUnit is not null)
	OR ([UnitPrice] = @UnitPrice AND @UnitPrice is not null)
	OR ([UnitsInStock] = @UnitsInStock AND @UnitsInStock is not null)
	OR ([UnitsOnOrder] = @UnitsOnOrder AND @UnitsOnOrder is not null)
	OR ([ReorderLevel] = @ReorderLevel AND @ReorderLevel is not null)
	OR ([Discontinued] = @Discontinued AND @Discontinued is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Order Details] table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_Get_List

AS


				
				SELECT
					[OrderID],
					[ProductID],
					[UnitPrice],
					[Quantity],
					[Discount]
				FROM
					[dbo].[Order Details]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Order Details] table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[OrderID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [OrderID]'
				SET @SQL = @SQL + ', [ProductID]'
				SET @SQL = @SQL + ', [UnitPrice]'
				SET @SQL = @SQL + ', [Quantity]'
				SET @SQL = @SQL + ', [Discount]'
				SET @SQL = @SQL + ' FROM [dbo].[Order Details]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [OrderID],'
				SET @SQL = @SQL + ' [ProductID],'
				SET @SQL = @SQL + ' [UnitPrice],'
				SET @SQL = @SQL + ' [Quantity],'
				SET @SQL = @SQL + ' [Discount]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Order Details]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the [Order Details] table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_Insert
(

	@OrderId int   ,

	@ProductId int   ,

	@UnitPrice money   ,

	@Quantity smallint   ,

	@Discount real   
)
AS


				
				INSERT INTO [dbo].[Order Details]
					(
					[OrderID]
					,[ProductID]
					,[UnitPrice]
					,[Quantity]
					,[Discount]
					)
				VALUES
					(
					@OrderId
					,@ProductId
					,@UnitPrice
					,@Quantity
					,@Discount
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the [Order Details] table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_Update
(

	@OrderId int   ,

	@OriginalOrderId int   ,

	@ProductId int   ,

	@OriginalProductId int   ,

	@UnitPrice money   ,

	@Quantity smallint   ,

	@Discount real   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Order Details]
				SET
					[OrderID] = @OrderId
					,[ProductID] = @ProductId
					,[UnitPrice] = @UnitPrice
					,[Quantity] = @Quantity
					,[Discount] = @Discount
				WHERE
[OrderID] = @OriginalOrderId 
AND [ProductID] = @OriginalProductId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the [Order Details] table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_Delete
(

	@OrderId int   ,

	@ProductId int   
)
AS


				DELETE FROM [dbo].[Order Details] WITH (ROWLOCK) 
				WHERE
					[OrderID] = @OrderId
					AND [ProductID] = @ProductId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_GetByOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_GetByOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_GetByOrderId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Order Details table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_GetByOrderId
(

	@OrderId int   
)
AS


				SELECT
					[OrderID],
					[ProductID],
					[UnitPrice],
					[Quantity],
					[Discount]
				FROM
					[dbo].[Order Details]
				WHERE
					[OrderID] = @OrderId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_GetByOrderIdProductId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_GetByOrderIdProductId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_GetByOrderIdProductId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Order Details table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_GetByOrderIdProductId
(

	@OrderId int   ,

	@ProductId int   
)
AS


				SELECT
					[OrderID],
					[ProductID],
					[UnitPrice],
					[Quantity],
					[Discount]
				FROM
					[dbo].[Order Details]
				WHERE
					[OrderID] = @OrderId
					AND [ProductID] = @ProductId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_GetByProductId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_GetByProductId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_GetByProductId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Order Details table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_GetByProductId
(

	@ProductId int   
)
AS


				SELECT
					[OrderID],
					[ProductID],
					[UnitPrice],
					[Quantity],
					[Discount]
				FROM
					[dbo].[Order Details]
				WHERE
					[ProductID] = @ProductId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the [Order Details] table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_Find
(

	@SearchUsingOR bit   = null ,

	@OrderId int   = null ,

	@ProductId int   = null ,

	@UnitPrice money   = null ,

	@Quantity smallint   = null ,

	@Discount real   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [OrderID]
	, [ProductID]
	, [UnitPrice]
	, [Quantity]
	, [Discount]
    FROM
	[dbo].[Order Details]
    WHERE 
	 ([OrderID] = @OrderId OR @OrderId IS NULL)
	AND ([ProductID] = @ProductId OR @ProductId IS NULL)
	AND ([UnitPrice] = @UnitPrice OR @UnitPrice IS NULL)
	AND ([Quantity] = @Quantity OR @Quantity IS NULL)
	AND ([Discount] = @Discount OR @Discount IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [OrderID]
	, [ProductID]
	, [UnitPrice]
	, [Quantity]
	, [Discount]
    FROM
	[dbo].[Order Details]
    WHERE 
	 ([OrderID] = @OrderId AND @OrderId is not null)
	OR ([ProductID] = @ProductId AND @ProductId is not null)
	OR ([UnitPrice] = @UnitPrice AND @UnitPrice is not null)
	OR ([Quantity] = @Quantity AND @Quantity is not null)
	OR ([Discount] = @Discount AND @Discount is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerCustomerDemo_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerCustomerDemo_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerCustomerDemo_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the CustomerCustomerDemo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerCustomerDemo_Get_List

AS


				
				SELECT
					[CustomerID],
					[CustomerTypeID]
				FROM
					[dbo].[CustomerCustomerDemo]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerCustomerDemo_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerCustomerDemo_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerCustomerDemo_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the CustomerCustomerDemo table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerCustomerDemo_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CustomerID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CustomerID]'
				SET @SQL = @SQL + ', [CustomerTypeID]'
				SET @SQL = @SQL + ' FROM [dbo].[CustomerCustomerDemo]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CustomerID],'
				SET @SQL = @SQL + ' [CustomerTypeID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[CustomerCustomerDemo]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerCustomerDemo_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerCustomerDemo_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerCustomerDemo_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the CustomerCustomerDemo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerCustomerDemo_Insert
(

	@CustomerId nchar (5)  ,

	@CustomerTypeId nchar (10)  
)
AS


				
				INSERT INTO [dbo].[CustomerCustomerDemo]
					(
					[CustomerID]
					,[CustomerTypeID]
					)
				VALUES
					(
					@CustomerId
					,@CustomerTypeId
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerCustomerDemo_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerCustomerDemo_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerCustomerDemo_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the CustomerCustomerDemo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerCustomerDemo_Update
(

	@CustomerId nchar (5)  ,

	@OriginalCustomerId nchar (5)  ,

	@CustomerTypeId nchar (10)  ,

	@OriginalCustomerTypeId nchar (10)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[CustomerCustomerDemo]
				SET
					[CustomerID] = @CustomerId
					,[CustomerTypeID] = @CustomerTypeId
				WHERE
[CustomerID] = @OriginalCustomerId 
AND [CustomerTypeID] = @OriginalCustomerTypeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerCustomerDemo_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerCustomerDemo_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerCustomerDemo_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the CustomerCustomerDemo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerCustomerDemo_Delete
(

	@CustomerId nchar (5)  ,

	@CustomerTypeId nchar (10)  
)
AS


				DELETE FROM [dbo].[CustomerCustomerDemo] WITH (ROWLOCK) 
				WHERE
					[CustomerID] = @CustomerId
					AND [CustomerTypeID] = @CustomerTypeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerCustomerDemo_GetByCustomerTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerCustomerDemo_GetByCustomerTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerCustomerDemo_GetByCustomerTypeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerCustomerDemo table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerCustomerDemo_GetByCustomerTypeId
(

	@CustomerTypeId nchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CustomerID],
					[CustomerTypeID]
				FROM
					[dbo].[CustomerCustomerDemo]
				WHERE
					[CustomerTypeID] = @CustomerTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerCustomerDemo_GetByCustomerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerCustomerDemo_GetByCustomerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerCustomerDemo_GetByCustomerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerCustomerDemo table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerCustomerDemo_GetByCustomerId
(

	@CustomerId nchar (5)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[CustomerID],
					[CustomerTypeID]
				FROM
					[dbo].[CustomerCustomerDemo]
				WHERE
					[CustomerID] = @CustomerId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerCustomerDemo_GetByCustomerIdCustomerTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerCustomerDemo_GetByCustomerIdCustomerTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerCustomerDemo_GetByCustomerIdCustomerTypeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerCustomerDemo table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerCustomerDemo_GetByCustomerIdCustomerTypeId
(

	@CustomerId nchar (5)  ,

	@CustomerTypeId nchar (10)  
)
AS


				SELECT
					[CustomerID],
					[CustomerTypeID]
				FROM
					[dbo].[CustomerCustomerDemo]
				WHERE
					[CustomerID] = @CustomerId
					AND [CustomerTypeID] = @CustomerTypeId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerCustomerDemo_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerCustomerDemo_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerCustomerDemo_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the CustomerCustomerDemo table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerCustomerDemo_Find
(

	@SearchUsingOR bit   = null ,

	@CustomerId nchar (5)  = null ,

	@CustomerTypeId nchar (10)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CustomerID]
	, [CustomerTypeID]
    FROM
	[dbo].[CustomerCustomerDemo]
    WHERE 
	 ([CustomerID] = @CustomerId OR @CustomerId IS NULL)
	AND ([CustomerTypeID] = @CustomerTypeId OR @CustomerTypeId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CustomerID]
	, [CustomerTypeID]
    FROM
	[dbo].[CustomerCustomerDemo]
    WHERE 
	 ([CustomerID] = @CustomerId AND @CustomerId is not null)
	OR ([CustomerTypeID] = @CustomerTypeId AND @CustomerTypeId is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Alphabeticallistofproducts_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Alphabeticallistofproducts_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Alphabeticallistofproducts_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Alphabetical list of products] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Alphabeticallistofproducts_Get_List

AS


                    
                    SELECT
                        [ProductID],
                        [ProductName],
                        [SupplierID],
                        [CategoryID],
                        [QuantityPerUnit],
                        [UnitPrice],
                        [UnitsInStock],
                        [UnitsOnOrder],
                        [ReorderLevel],
                        [Discontinued],
                        [CategoryName]
                    FROM
                        [dbo].[Alphabetical list of products]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Alphabeticallistofproducts_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Alphabeticallistofproducts_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Alphabeticallistofproducts_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Alphabetical list of products] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Alphabeticallistofproducts_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[ProductID]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [ProductID]'
                    SET @SQL = @SQL + ', [ProductName]'
                    SET @SQL = @SQL + ', [SupplierID]'
                    SET @SQL = @SQL + ', [CategoryID]'
                    SET @SQL = @SQL + ', [QuantityPerUnit]'
                    SET @SQL = @SQL + ', [UnitPrice]'
                    SET @SQL = @SQL + ', [UnitsInStock]'
                    SET @SQL = @SQL + ', [UnitsOnOrder]'
                    SET @SQL = @SQL + ', [ReorderLevel]'
                    SET @SQL = @SQL + ', [Discontinued]'
                    SET @SQL = @SQL + ', [CategoryName]'
                    SET @SQL = @SQL + ' FROM [dbo].[Alphabetical list of products]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [ProductID],'
                    SET @SQL = @SQL + ' [ProductName],'
                    SET @SQL = @SQL + ' [SupplierID],'
                    SET @SQL = @SQL + ' [CategoryID],'
                    SET @SQL = @SQL + ' [QuantityPerUnit],'
                    SET @SQL = @SQL + ' [UnitPrice],'
                    SET @SQL = @SQL + ' [UnitsInStock],'
                    SET @SQL = @SQL + ' [UnitsOnOrder],'
                    SET @SQL = @SQL + ' [ReorderLevel],'
                    SET @SQL = @SQL + ' [Discontinued],'
                    SET @SQL = @SQL + ' [CategoryName]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Alphabetical list of products]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CategorySalesfor1997_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CategorySalesfor1997_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CategorySalesfor1997_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Category Sales for 1997] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CategorySalesfor1997_Get_List

AS


                    
                    SELECT
                        [CategoryName],
                        [CategorySales]
                    FROM
                        [dbo].[Category Sales for 1997]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CategorySalesfor1997_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CategorySalesfor1997_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CategorySalesfor1997_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Category Sales for 1997] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CategorySalesfor1997_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[CategoryName]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [CategoryName]'
                    SET @SQL = @SQL + ', [CategorySales]'
                    SET @SQL = @SQL + ' FROM [dbo].[Category Sales for 1997]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [CategoryName],'
                    SET @SQL = @SQL + ' [CategorySales]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Category Sales for 1997]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CurrentProductList_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CurrentProductList_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CurrentProductList_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Current Product List] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CurrentProductList_Get_List

AS


                    
                    SELECT
                        [ProductID],
                        [ProductName]
                    FROM
                        [dbo].[Current Product List]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CurrentProductList_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CurrentProductList_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CurrentProductList_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Current Product List] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CurrentProductList_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[ProductID]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [ProductID]'
                    SET @SQL = @SQL + ', [ProductName]'
                    SET @SQL = @SQL + ' FROM [dbo].[Current Product List]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [ProductID],'
                    SET @SQL = @SQL + ' [ProductName]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Current Product List]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerandSuppliersbyCity_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerandSuppliersbyCity_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerandSuppliersbyCity_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Customer and Suppliers by City] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerandSuppliersbyCity_Get_List

AS


                    
                    SELECT
                        [City],
                        [CompanyName],
                        [ContactName],
                        [Relationship]
                    FROM
                        [dbo].[Customer and Suppliers by City]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerandSuppliersbyCity_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerandSuppliersbyCity_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerandSuppliersbyCity_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Customer and Suppliers by City] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerandSuppliersbyCity_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[City]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [City]'
                    SET @SQL = @SQL + ', [CompanyName]'
                    SET @SQL = @SQL + ', [ContactName]'
                    SET @SQL = @SQL + ', [Relationship]'
                    SET @SQL = @SQL + ' FROM [dbo].[Customer and Suppliers by City]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [City],'
                    SET @SQL = @SQL + ' [CompanyName],'
                    SET @SQL = @SQL + ' [ContactName],'
                    SET @SQL = @SQL + ' [Relationship]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Customer and Suppliers by City]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Invoices_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Invoices_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Invoices_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Invoices view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Invoices_Get_List

AS


                    
                    SELECT
                        [ShipName],
                        [ShipAddress],
                        [ShipCity],
                        [ShipRegion],
                        [ShipPostalCode],
                        [ShipCountry],
                        [CustomerID],
                        [CustomerName],
                        [Address],
                        [City],
                        [Region],
                        [PostalCode],
                        [Country],
                        [Salesperson],
                        [OrderID],
                        [OrderDate],
                        [RequiredDate],
                        [ShippedDate],
                        [ShipperName],
                        [ProductID],
                        [ProductName],
                        [UnitPrice],
                        [Quantity],
                        [Discount],
                        [ExtendedPrice],
                        [Freight]
                    FROM
                        [dbo].[Invoices]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Invoices_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Invoices_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Invoices_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Invoices view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Invoices_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[ShipName]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [ShipName]'
                    SET @SQL = @SQL + ', [ShipAddress]'
                    SET @SQL = @SQL + ', [ShipCity]'
                    SET @SQL = @SQL + ', [ShipRegion]'
                    SET @SQL = @SQL + ', [ShipPostalCode]'
                    SET @SQL = @SQL + ', [ShipCountry]'
                    SET @SQL = @SQL + ', [CustomerID]'
                    SET @SQL = @SQL + ', [CustomerName]'
                    SET @SQL = @SQL + ', [Address]'
                    SET @SQL = @SQL + ', [City]'
                    SET @SQL = @SQL + ', [Region]'
                    SET @SQL = @SQL + ', [PostalCode]'
                    SET @SQL = @SQL + ', [Country]'
                    SET @SQL = @SQL + ', [Salesperson]'
                    SET @SQL = @SQL + ', [OrderID]'
                    SET @SQL = @SQL + ', [OrderDate]'
                    SET @SQL = @SQL + ', [RequiredDate]'
                    SET @SQL = @SQL + ', [ShippedDate]'
                    SET @SQL = @SQL + ', [ShipperName]'
                    SET @SQL = @SQL + ', [ProductID]'
                    SET @SQL = @SQL + ', [ProductName]'
                    SET @SQL = @SQL + ', [UnitPrice]'
                    SET @SQL = @SQL + ', [Quantity]'
                    SET @SQL = @SQL + ', [Discount]'
                    SET @SQL = @SQL + ', [ExtendedPrice]'
                    SET @SQL = @SQL + ', [Freight]'
                    SET @SQL = @SQL + ' FROM [dbo].[Invoices]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [ShipName],'
                    SET @SQL = @SQL + ' [ShipAddress],'
                    SET @SQL = @SQL + ' [ShipCity],'
                    SET @SQL = @SQL + ' [ShipRegion],'
                    SET @SQL = @SQL + ' [ShipPostalCode],'
                    SET @SQL = @SQL + ' [ShipCountry],'
                    SET @SQL = @SQL + ' [CustomerID],'
                    SET @SQL = @SQL + ' [CustomerName],'
                    SET @SQL = @SQL + ' [Address],'
                    SET @SQL = @SQL + ' [City],'
                    SET @SQL = @SQL + ' [Region],'
                    SET @SQL = @SQL + ' [PostalCode],'
                    SET @SQL = @SQL + ' [Country],'
                    SET @SQL = @SQL + ' [Salesperson],'
                    SET @SQL = @SQL + ' [OrderID],'
                    SET @SQL = @SQL + ' [OrderDate],'
                    SET @SQL = @SQL + ' [RequiredDate],'
                    SET @SQL = @SQL + ' [ShippedDate],'
                    SET @SQL = @SQL + ' [ShipperName],'
                    SET @SQL = @SQL + ' [ProductID],'
                    SET @SQL = @SQL + ' [ProductName],'
                    SET @SQL = @SQL + ' [UnitPrice],'
                    SET @SQL = @SQL + ' [Quantity],'
                    SET @SQL = @SQL + ' [Discount],'
                    SET @SQL = @SQL + ' [ExtendedPrice],'
                    SET @SQL = @SQL + ' [Freight]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Invoices]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetailsExtended_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetailsExtended_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetailsExtended_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Order Details Extended] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetailsExtended_Get_List

AS


                    
                    SELECT
                        [OrderID],
                        [ProductID],
                        [ProductName],
                        [UnitPrice],
                        [Quantity],
                        [Discount],
                        [ExtendedPrice]
                    FROM
                        [dbo].[Order Details Extended]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetailsExtended_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetailsExtended_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetailsExtended_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Order Details Extended] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetailsExtended_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[OrderID]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [OrderID]'
                    SET @SQL = @SQL + ', [ProductID]'
                    SET @SQL = @SQL + ', [ProductName]'
                    SET @SQL = @SQL + ', [UnitPrice]'
                    SET @SQL = @SQL + ', [Quantity]'
                    SET @SQL = @SQL + ', [Discount]'
                    SET @SQL = @SQL + ', [ExtendedPrice]'
                    SET @SQL = @SQL + ' FROM [dbo].[Order Details Extended]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [OrderID],'
                    SET @SQL = @SQL + ' [ProductID],'
                    SET @SQL = @SQL + ' [ProductName],'
                    SET @SQL = @SQL + ' [UnitPrice],'
                    SET @SQL = @SQL + ' [Quantity],'
                    SET @SQL = @SQL + ' [Discount],'
                    SET @SQL = @SQL + ' [ExtendedPrice]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Order Details Extended]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderSubtotals_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderSubtotals_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderSubtotals_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Order Subtotals] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderSubtotals_Get_List

AS


                    
                    SELECT
                        [OrderID],
                        [Subtotal]
                    FROM
                        [dbo].[Order Subtotals]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderSubtotals_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderSubtotals_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderSubtotals_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Order Subtotals] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderSubtotals_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[OrderID]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [OrderID]'
                    SET @SQL = @SQL + ', [Subtotal]'
                    SET @SQL = @SQL + ' FROM [dbo].[Order Subtotals]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [OrderID],'
                    SET @SQL = @SQL + ' [Subtotal]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Order Subtotals]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrdersQry_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrdersQry_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrdersQry_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Orders Qry] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrdersQry_Get_List

AS


                    
                    SELECT
                        [OrderID],
                        [CustomerID],
                        [EmployeeID],
                        [OrderDate],
                        [RequiredDate],
                        [ShippedDate],
                        [ShipVia],
                        [Freight],
                        [ShipName],
                        [ShipAddress],
                        [ShipCity],
                        [ShipRegion],
                        [ShipPostalCode],
                        [ShipCountry],
                        [CompanyName],
                        [Address],
                        [City],
                        [Region],
                        [PostalCode],
                        [Country]
                    FROM
                        [dbo].[Orders Qry]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrdersQry_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrdersQry_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrdersQry_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Orders Qry] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrdersQry_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[OrderID]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [OrderID]'
                    SET @SQL = @SQL + ', [CustomerID]'
                    SET @SQL = @SQL + ', [EmployeeID]'
                    SET @SQL = @SQL + ', [OrderDate]'
                    SET @SQL = @SQL + ', [RequiredDate]'
                    SET @SQL = @SQL + ', [ShippedDate]'
                    SET @SQL = @SQL + ', [ShipVia]'
                    SET @SQL = @SQL + ', [Freight]'
                    SET @SQL = @SQL + ', [ShipName]'
                    SET @SQL = @SQL + ', [ShipAddress]'
                    SET @SQL = @SQL + ', [ShipCity]'
                    SET @SQL = @SQL + ', [ShipRegion]'
                    SET @SQL = @SQL + ', [ShipPostalCode]'
                    SET @SQL = @SQL + ', [ShipCountry]'
                    SET @SQL = @SQL + ', [CompanyName]'
                    SET @SQL = @SQL + ', [Address]'
                    SET @SQL = @SQL + ', [City]'
                    SET @SQL = @SQL + ', [Region]'
                    SET @SQL = @SQL + ', [PostalCode]'
                    SET @SQL = @SQL + ', [Country]'
                    SET @SQL = @SQL + ' FROM [dbo].[Orders Qry]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [OrderID],'
                    SET @SQL = @SQL + ' [CustomerID],'
                    SET @SQL = @SQL + ' [EmployeeID],'
                    SET @SQL = @SQL + ' [OrderDate],'
                    SET @SQL = @SQL + ' [RequiredDate],'
                    SET @SQL = @SQL + ' [ShippedDate],'
                    SET @SQL = @SQL + ' [ShipVia],'
                    SET @SQL = @SQL + ' [Freight],'
                    SET @SQL = @SQL + ' [ShipName],'
                    SET @SQL = @SQL + ' [ShipAddress],'
                    SET @SQL = @SQL + ' [ShipCity],'
                    SET @SQL = @SQL + ' [ShipRegion],'
                    SET @SQL = @SQL + ' [ShipPostalCode],'
                    SET @SQL = @SQL + ' [ShipCountry],'
                    SET @SQL = @SQL + ' [CompanyName],'
                    SET @SQL = @SQL + ' [Address],'
                    SET @SQL = @SQL + ' [City],'
                    SET @SQL = @SQL + ' [Region],'
                    SET @SQL = @SQL + ' [PostalCode],'
                    SET @SQL = @SQL + ' [Country]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Orders Qry]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProductSalesfor1997_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProductSalesfor1997_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProductSalesfor1997_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Product Sales for 1997] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProductSalesfor1997_Get_List

AS


                    
                    SELECT
                        [CategoryName],
                        [ProductName],
                        [ProductSales]
                    FROM
                        [dbo].[Product Sales for 1997]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProductSalesfor1997_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProductSalesfor1997_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProductSalesfor1997_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Product Sales for 1997] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProductSalesfor1997_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[CategoryName]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [CategoryName]'
                    SET @SQL = @SQL + ', [ProductName]'
                    SET @SQL = @SQL + ', [ProductSales]'
                    SET @SQL = @SQL + ' FROM [dbo].[Product Sales for 1997]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [CategoryName],'
                    SET @SQL = @SQL + ' [ProductName],'
                    SET @SQL = @SQL + ' [ProductSales]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Product Sales for 1997]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProductsAboveAveragePrice_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProductsAboveAveragePrice_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProductsAboveAveragePrice_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Products Above Average Price] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProductsAboveAveragePrice_Get_List

AS


                    
                    SELECT
                        [ProductName],
                        [UnitPrice]
                    FROM
                        [dbo].[Products Above Average Price]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProductsAboveAveragePrice_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProductsAboveAveragePrice_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProductsAboveAveragePrice_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Products Above Average Price] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProductsAboveAveragePrice_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[ProductName]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [ProductName]'
                    SET @SQL = @SQL + ', [UnitPrice]'
                    SET @SQL = @SQL + ' FROM [dbo].[Products Above Average Price]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [ProductName],'
                    SET @SQL = @SQL + ' [UnitPrice]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Products Above Average Price]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProductsbyCategory_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProductsbyCategory_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProductsbyCategory_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Products by Category] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProductsbyCategory_Get_List

AS


                    
                    SELECT
                        [CategoryName],
                        [ProductName],
                        [QuantityPerUnit],
                        [UnitsInStock],
                        [Discontinued]
                    FROM
                        [dbo].[Products by Category]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProductsbyCategory_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProductsbyCategory_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProductsbyCategory_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Products by Category] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProductsbyCategory_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[CategoryName]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [CategoryName]'
                    SET @SQL = @SQL + ', [ProductName]'
                    SET @SQL = @SQL + ', [QuantityPerUnit]'
                    SET @SQL = @SQL + ', [UnitsInStock]'
                    SET @SQL = @SQL + ', [Discontinued]'
                    SET @SQL = @SQL + ' FROM [dbo].[Products by Category]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [CategoryName],'
                    SET @SQL = @SQL + ' [ProductName],'
                    SET @SQL = @SQL + ' [QuantityPerUnit],'
                    SET @SQL = @SQL + ' [UnitsInStock],'
                    SET @SQL = @SQL + ' [Discontinued]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Products by Category]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuarterlyOrders_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuarterlyOrders_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuarterlyOrders_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Quarterly Orders] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuarterlyOrders_Get_List

AS


                    
                    SELECT
                        [CustomerID],
                        [CompanyName],
                        [City],
                        [Country]
                    FROM
                        [dbo].[Quarterly Orders]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuarterlyOrders_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuarterlyOrders_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuarterlyOrders_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Quarterly Orders] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuarterlyOrders_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[CustomerID]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [CustomerID]'
                    SET @SQL = @SQL + ', [CompanyName]'
                    SET @SQL = @SQL + ', [City]'
                    SET @SQL = @SQL + ', [Country]'
                    SET @SQL = @SQL + ' FROM [dbo].[Quarterly Orders]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [CustomerID],'
                    SET @SQL = @SQL + ' [CompanyName],'
                    SET @SQL = @SQL + ' [City],'
                    SET @SQL = @SQL + ' [Country]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Quarterly Orders]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SalesbyCategory_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SalesbyCategory_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SalesbyCategory_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Sales by Category] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SalesbyCategory_Get_List

AS


                    
                    SELECT
                        [CategoryID],
                        [CategoryName],
                        [ProductName],
                        [ProductSales]
                    FROM
                        [dbo].[Sales by Category]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SalesbyCategory_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SalesbyCategory_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SalesbyCategory_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Sales by Category] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SalesbyCategory_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[CategoryID]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [CategoryID]'
                    SET @SQL = @SQL + ', [CategoryName]'
                    SET @SQL = @SQL + ', [ProductName]'
                    SET @SQL = @SQL + ', [ProductSales]'
                    SET @SQL = @SQL + ' FROM [dbo].[Sales by Category]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [CategoryID],'
                    SET @SQL = @SQL + ' [CategoryName],'
                    SET @SQL = @SQL + ' [ProductName],'
                    SET @SQL = @SQL + ' [ProductSales]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Sales by Category]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SalesTotalsbyAmount_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SalesTotalsbyAmount_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SalesTotalsbyAmount_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Sales Totals by Amount] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SalesTotalsbyAmount_Get_List

AS


                    
                    SELECT
                        [SaleAmount],
                        [OrderID],
                        [CompanyName],
                        [ShippedDate]
                    FROM
                        [dbo].[Sales Totals by Amount]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SalesTotalsbyAmount_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SalesTotalsbyAmount_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SalesTotalsbyAmount_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Sales Totals by Amount] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SalesTotalsbyAmount_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[SaleAmount]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [SaleAmount]'
                    SET @SQL = @SQL + ', [OrderID]'
                    SET @SQL = @SQL + ', [CompanyName]'
                    SET @SQL = @SQL + ', [ShippedDate]'
                    SET @SQL = @SQL + ' FROM [dbo].[Sales Totals by Amount]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [SaleAmount],'
                    SET @SQL = @SQL + ' [OrderID],'
                    SET @SQL = @SQL + ' [CompanyName],'
                    SET @SQL = @SQL + ' [ShippedDate]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Sales Totals by Amount]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SummaryofSalesbyQuarter_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SummaryofSalesbyQuarter_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SummaryofSalesbyQuarter_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Summary of Sales by Quarter] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SummaryofSalesbyQuarter_Get_List

AS


                    
                    SELECT
                        [ShippedDate],
                        [OrderID],
                        [Subtotal]
                    FROM
                        [dbo].[Summary of Sales by Quarter]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SummaryofSalesbyQuarter_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SummaryofSalesbyQuarter_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SummaryofSalesbyQuarter_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Summary of Sales by Quarter] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SummaryofSalesbyQuarter_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[ShippedDate]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [ShippedDate]'
                    SET @SQL = @SQL + ', [OrderID]'
                    SET @SQL = @SQL + ', [Subtotal]'
                    SET @SQL = @SQL + ' FROM [dbo].[Summary of Sales by Quarter]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [ShippedDate],'
                    SET @SQL = @SQL + ' [OrderID],'
                    SET @SQL = @SQL + ' [Subtotal]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Summary of Sales by Quarter]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SummaryofSalesbyYear_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SummaryofSalesbyYear_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SummaryofSalesbyYear_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the [Summary of Sales by Year] view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SummaryofSalesbyYear_Get_List

AS


                    
                    SELECT
                        [ShippedDate],
                        [OrderID],
                        [Subtotal]
                    FROM
                        [dbo].[Summary of Sales by Year]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SummaryofSalesbyYear_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SummaryofSalesbyYear_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SummaryofSalesbyYear_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the [Summary of Sales by Year] view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SummaryofSalesbyYear_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


                    
                    BEGIN
    
                    DECLARE @PageLowerBound int
                    DECLARE @PageUpperBound int
                    
                    -- Set the page bounds
                    SET @PageLowerBound = @PageSize * @PageIndex
                    SET @PageUpperBound = @PageLowerBound + @PageSize
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[ShippedDate]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [ShippedDate]'
                    SET @SQL = @SQL + ', [OrderID]'
                    SET @SQL = @SQL + ', [Subtotal]'
                    SET @SQL = @SQL + ' FROM [dbo].[Summary of Sales by Year]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [ShippedDate],'
                    SET @SQL = @SQL + ' [OrderID],'
                    SET @SQL = @SQL + ' [Subtotal]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[Summary of Sales by Year]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    EXEC sp_executesql @SQL
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

