using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using MvcNorthwind.Models;

namespace MvcNorthwind.Map {
    
    
    public class EmployeeTerritoryMap : ClassMap<EmployeeTerritory> {
        
        public EmployeeTerritoryMap() {
			Table("EmployeeTerritories");
			LazyLoad();
			CompositeId().KeyProperty(x => x.EmployeeID).KeyProperty(x => x.TerritoryID);
			References(x => x.Employee).Column("EmployeeID");
			References(x => x.Territory).Column("TerritoryID");
        }
    }
}
