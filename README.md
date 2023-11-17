You hate verbatim SQL queries with zero type safety for your code but you love their speed? ``Devz.RapidCRUD`` is a fast orm built around essential features of the C# 6 / VB 14 that have finally raised the simplicity of raw SQL constructs to acceptable maintenance levels. These features leave no chance to mistypings or problems arising from db entity refactorings.
Visual Studio 2019 and above is recommended. 

#### Features:
- Support for LocalDb, Ms Sql Server, MySql, SqLite, PostgreSql and SAP/Sybase Anywhere SQL.
- Entities having composite primary keys are supported, however note that the CRUD operations only support UNIQUE primary keys.
- Multiple entity mappings are supported, useful for partial queries in large denormalized tables and data migrations between different database types.
- All the CRUD methods accept a transaction, a command timeout, and a custom entity mapping.
- Fast pre-computed entity queries for simple CRUD operations.
- Compatible with component model data annotations.
- Opt-in relationships. As of 3.0, self referenced entities and multiple joins to the same target are also supported via aliases.
- A set of "formattables" are also included, which can be used even if you don't need the CRUD features of this library but you want to take advantage of the DB mappings.
- A generic T4 template for C# is also provided for convenience in the NuGet package Devz.RapidCRUD.ModelGenerator.
- The following mapping styles are supported:
  - Database first (limited to SQL Server)
  - Code first, using model data annotations (preferred)
  - Fluent registration for POCO objects
  - Semi-POCO using metadata objects


#### WIKI
[The wiki](https://github.com/Devz/RapidCRUD/wiki) is a great place for learning more about this library.


#### Speed
Let's have a look at some popular ORMs out there and benchmark their speed:  

- ``Devz.SimpleCRUD v2.3.0``
- ``DapperExtensions v1.7.0 ``
- ``Entity Framework Core v7.0.3`` 

##### Automatic Benchmark Report (Last Run: Wednesday, March 8, 2023)

|  Library   |  Operation | Op Count |Time (ms) | Time/op (μs) |
|------------|------------|----------|----------|--------------|
| <a name="new_entry_marker"/> |
||||||
| Dapper | insert | 10000 | 1,929.23 | 192.92 |
| Fast Crud | insert | 10000 | 2,055.25 | 205.53 |
| Dapper Extensions | insert | 10000 | 2,268.53 | 226.85 |
| Simple Crud | insert | 10000 | 2,261.87 | 226.19 |
| Entity Framework - single op/call | insert | 10000 | 56,141.54 | 5,614.15 |
||||||
| Dapper | update | 10000 | 1,866.15 | 186.62 |
| Fast Crud | update | 10000 | 1,882.50 | 188.25 |
| Dapper Extensions | update | 10000 | 2,140.93 | 214.09 |
| Simple Crud | update | 10000 | 1,902.17 | 190.22 |
| Entity Framework - single op/call | update | 10000 | 109,686.07 | 10,968.61 |
||||||
| Dapper | delete | 10000 | 1,748.89 | 174.89 |
| Fast Crud | delete | 10000 | 1,874.53 | 187.45 |
| Dapper Extensions | delete | 10000 | 1,887.07 | 188.71 |
| Simple Crud | delete | 10000 | 1,811.88 | 181.19 |
| Entity Framework - single op/call | delete | 10000 | 2,683.03 | 268.30 |
||||||
| Dapper | select by id | 10000 | 846.25 | 84.62 |
| Fast Crud | select by id | 10000 | 892.80 | 89.28 |
| Dapper Extensions | select by id | 10000 | 4,273.33 | 427.33 |
| Simple Crud | select by id | 10000 | 1,212.33 | 121.23 |
| Entity Framework | select by id | 10000 | 1,912.39 | 191.24 |
||||||
| Dapper | select all | 10000 | 854.54 | 85.45 |
| Fast Crud | select all | 10000 | 944.38 | 94.44 |
| Dapper Extensions | select all | 10000 | 5,922.75 | 592.28 |
| Simple Crud | select all | 10000 | 1,310.30 | 131.03 |
| Entity Framework | select all | 10000 | 3,272.34 | 327.23 |

Dapper is included for reference. All the libs involved get their own internal cache cleared before each run, the benchmark database is re-created, data file gets pre-allocated, and the statistics are turned off.
The tests are following the same steps and are running in the same environment on the same number and size of records.

You can find more details about how to run the benchmarks yourself in the wiki.

##### Install [the main library](https://www.nuget.org/packages/Devz.RapidCRUD/) and [the model generator](https://www.nuget.org/packages/Devz.RapidCRUD.ModelGenerator/) via NuGet and enjoy!

