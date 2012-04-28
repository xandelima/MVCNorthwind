using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcNorthwind.Models {
    
    
    public class ShipperMap : ClassMap<Shipper> {
        
        public ShipperMap() {
			Table("Shippers");
			LazyLoad();
			Id(x => x.ShipperID).GeneratedBy.Identity().Column("ShipperID");
			Map(x => x.CompanyName).Not.Nullable().Column("CompanyName");
			Map(x => x.Phone).Column("Phone");
			HasMany(x => x.Orders);
        }
    }
}
