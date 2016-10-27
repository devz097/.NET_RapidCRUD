
// This file was automatically generated by the Dapper.FastCRUD T4 Template
// Do not make changes directly to this file - edit the template configuration instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `EntityGeneration`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=(LocalDb)\MSSQLLocalDb;AttachDbFilename=D:\_Projects\Dapper.FastCRUD\Dapper.FastCrud.Tests\App_Data\\EntityGenDatabase.mdf;Initial Catalog=EntityGenDatabase;Integrated Security=True`
//     Include Views:          `True`

namespace Dapper.FastCrud.Tests.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Collections.Generic;

    /// <summary>
    /// A class which represents the Employee table.
    /// </summary>
	[Table("Employee")]
	public partial class Employee
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	    public virtual int UserId { get; set; }
		[Key]
		[Dapper.FastCrud.DatabaseGeneratedDefaultValue]
	    public virtual Guid EmployeeId { get; set; }
		[Dapper.FastCrud.DatabaseGeneratedDefaultValue]
	    public virtual Guid KeyPass { get; set; }
	    public virtual string LastName { get; set; }
	    public virtual string FirstName { get; set; }
	    public virtual DateTime BirthDate { get; set; }
	    [ForeignKey("Workstation")]
        public virtual long? WorkstationId { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
	    public virtual string FullName { get; set; }
		public virtual Workstation Workstation { get; set; }
	}

    /// <summary>
    /// A class which represents the Workstations table.
    /// </summary>
	[Table("Workstations")]
	public partial class Workstation
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	    public virtual long WorkstationId { get; set; }
	    public virtual string Name { get; set; }
		[Dapper.FastCrud.DatabaseGeneratedDefaultValue]
	    public virtual int AccessLevel { get; set; }
	    public virtual int InventoryIndex { get; set; }
		public virtual IEnumerable<Employee> Employees { get; set; }
	}

}

