using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcNorthwind.Models {
    
    
    public class TerritoryMap : ClassMap<Territory> {
        
        public TerritoryMap() {
			Table("Territories");
			LazyLoad();
			Id(x => x.TerritoryID).GeneratedBy.Assigned().Column("TerritoryID");
			References(x => x.Region).Column("RegionID");
			Map(x => x.TerritoryDescription).Not.Nullable().Column("TerritoryDescription");
			HasMany(x => x.EmployeeTerritories);
        }
    }
}
