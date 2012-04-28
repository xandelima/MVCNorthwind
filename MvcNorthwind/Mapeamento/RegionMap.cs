using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcNorthwind.Models {
    
    
    public class RegionMap : ClassMap<Region> {
        
        public RegionMap() {
			Table("Region");
			LazyLoad();
			Id(x => x.RegionID).GeneratedBy.Identity().Column("RegionID");
			Map(x => x.RegionDescription).Not.Nullable().Column("RegionDescription");
			HasMany(x => x.Territories);
        }
    }
}
