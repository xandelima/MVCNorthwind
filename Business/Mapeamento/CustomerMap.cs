using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using MvcNorthwind.Models;

namespace MvcNorthwind.Map {
    
    
    public class CustomerMap : ClassMap<Customer> {
        
        public CustomerMap() {
			Table("Customers");
			LazyLoad();
			Id(x => x.CustomerID).Column("CustomerID").CustomSqlType("nchar(5)");
			Map(x => x.CompanyName).Not.Nullable().Column("CompanyName");
			Map(x => x.ContactName).Column("ContactName");
			Map(x => x.ContactTitle).Column("ContactTitle");
			Map(x => x.Address).Column("Address");
			Map(x => x.City).Column("City");
			Map(x => x.Region).Column("Region");
			Map(x => x.PostalCode).Column("PostalCode");
			Map(x => x.Country).Column("Country");
			Map(x => x.Phone).Column("Phone");
			Map(x => x.Fax).Column("Fax");
			//HasMany(x => x.Orders);
        }
    }
}
