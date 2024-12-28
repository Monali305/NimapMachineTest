# NimapMachineTest
Solution For Nimap Machine Test

This Document contains the information on the web application created for Nimap Machine Test.

## Problem Statement:
Below are the requirements to be developed for machine test :

1. Category Master with CRUD operations 

2. Product Master with CRUD operations. A product belongs to a category.

3. Product list should be displayed with following Columns : 

|ProductId |   ProductName |   CategoryId  |  CategoryName |
|-|-|-|-|

5. The product list should have pagination on the server side, which means extract records

from DB as per the page size on the view.

So if the page size is 10 and the user is on page 9 then pull only records from 90 - 100.

## Solution Provided:
An Webapplication is created with C# called Nimap Machine Test,
 with SQL server as database,Entity framework as ORM, We have setup Repository pattern in code first pattern.

Main objective of the Project,
  - CRUD operation on Category table,
  - CRUD operation on Product table,
  - Expected list display( as per problem statement )
  - Pagination on Product list.

The Screeshots are provided for the requirement,

>Note:
  The screenshot of the solution has product table items from number 8 since other items were deleted. 





