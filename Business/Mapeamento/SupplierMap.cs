using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using MvcNorthwind.Models;

namespace MvcNorthwind.Map {
    
    
    public class SupplierMap : ClassMap<Supplier> {
        
        public SupplierMap() {
			Table("Suppliers");
			LazyLoad();
			Id(x => x.SupplierID).GeneratedBy.Identity().Column("SupplierID");
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
			Map(x => x.HomePage).Column("HomePage");
			HasMany(x => x.Products);
        }
    }
}
