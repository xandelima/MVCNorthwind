using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using MvcNorthwind.Models;

namespace MvcNorthwind.Map {
    
    
    public class EmployeeMap : ClassMap<Employee> {
        
        public EmployeeMap() {
			Table("Employees");
			LazyLoad();
			Id(x => x.EmployeeID).GeneratedBy.Identity().Column("EmployeeID");
			References(x => x.employee).Column("ReportsTo");
			Map(x => x.LastName).Not.Nullable().Column("LastName");
			Map(x => x.FirstName).Not.Nullable().Column("FirstName");
			Map(x => x.Title).Column("Title");
			Map(x => x.TitleOfCourtesy).Column("TitleOfCourtesy");
			Map(x => x.BirthDate).Column("BirthDate");
			Map(x => x.HireDate).Column("HireDate");
			Map(x => x.Address).Column("Address");
			Map(x => x.City).Column("City");
			Map(x => x.Region).Column("Region");
			Map(x => x.PostalCode).Column("PostalCode");
			Map(x => x.Country).Column("Country");
			Map(x => x.HomePhone).Column("HomePhone");
			Map(x => x.Extension).Column("Extension");
			Map(x => x.Photo).Column("Photo");
			Map(x => x.Notes).Column("Notes");
			Map(x => x.PhotoPath).Column("PhotoPath");
			HasMany(x => x.Employees);
			HasMany(x => x.EmployeeTerritories);
			HasMany(x => x.Orders);
        }
    }
}
